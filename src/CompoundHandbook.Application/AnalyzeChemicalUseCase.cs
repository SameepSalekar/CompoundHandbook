/*
AnalyzeChemicalUseCase is the application-level coordinator for the Compound Handbook's
complete chemical-analysis workflow.

The individual subsystems of the Compound Handbook each perform specialized work

ChemicalFormulaParser parses the chemical input.
IChemicalFormulaValidator validates the resulting chemical formula.
IChemicalEntityResolver attempts to resolve the chemical information to a ChemicalEntity.
IChemicalEntityValidator validates the resolved chemical entity.
IChemicalEntityClassifier determines the chemical classifications associated with the entity.
IMolecularFormulaGenerator generates a molecular formula from a Molecule's MolecularGraph.
IMolarMassCalculator calculates molar mass.
IPercentCompositionCalculator calculates elemental percent composition.
StructureGenerationService performs requested chemical structure-generation operations.
CachedChemicalPropertyService retrieves requested experimental chemical properties.

AnalyzeChemicalUseCase does not replace any of those specialized components.
Instead, it coordinates them.
This is an important application-layer responsibility.
The application layer determines the ORDER in which domain operations and services
must be useful to fulfuill a complete user request.

Therfore, the workflow should be:
AnalyzeChemicalRequest -> Parse chemical input -> Validate formula -> Resolve ChemicalEntity
-> Validate entity -> Classify entity -> Generate the molecular formula whenever applicable
-> Calculate molar mass -> Calculate percent composition -> Execute requested structure operations
-> Retrieve requested experimental properties -> AnalyzeChemicalRespone
*/

/*
This class will provide the Execute method that is required by the IAnalyzeChemicalUseCase interface.
This class uses constructor injection.
Its required collaborators are received through constructor parameters and are stored in
private readonly fields.

Most dependancies are represented by interfaces.

AnalyzeChemicalUseCase is basically depending on the contract rather than needing to know
the implementation details of every subsystem.
'Execute' coordinates those dependencies and then combines their results into an AnalyzeChemicalResponse.
*/

using System.Collections.Generic;
using CompoundHandbook.Calculations;
using CompoundHandbook.Classification;
using CompoundHandbook.Domain;
using CompoundHandbook.Parsing;
using CompoundHandbook.Resolution;
using CompoundHandbook.StructureGeneration;
using CompoundHandbook.Validation;
using CompoundHandbook.DataContracts;

namespace CompoundHandbook.Application
{
    /*
    AnalyzeChemicalUseCase implements the application's complete chemical-analysis
    operation.
    It receives an AnalyzeChemicalRequest and coordinates the appropriate Compound
    Handbook services to produce an AnalyzeChemicalResponse.
    */
    public sealed class AnalyzeChemicalUseCase : IAnalyzeChemicalUseCase 
    {
        // chemicalFormulaParser parses the caller's textual chemical input into the ChemicalFormula representation used by later stages.
        private readonly ChemicalFormulaParser chemicalFormulaParser;

        // chemicalFormulaValidator validates the parsed ChemicalFormula.
        private readonly IChemicalFormulaValidator chemicalFormulaValidator;

        // chemicalEntityResolver resolves chemical information to a ChemicalEntity.
        private readonly IChemicalEntityResolver chemicalEntityResolver;

        // chemicalEntityValidator validates the resolved ChemicalEntity.
        private readonly IChemicalEntityValidator chemicalEntityValidator;

        // chemicalEntityClassifier determines the classifications that apply to the resolved chemical entity.
        private readonly IChemicalEntityClassifier chemicalEntityClassifier;

        // molecularFormulaGenerator can generate a ChemicalFormula from a Molecule's MolecularGraph.
        private readonly IMolecularFormulaGenerator molecularFormulaGenerator;

        // molarMassCalculator calculates the molar mass associated with a ChemicalFormula.
        private readonly IMolarMassCalculator molarMassCalculator;

        // percentCompositionCalculator calculates the elemental percent composition associated with a ChemicalFormula.
        private readonly IPercentCompositionCalculator percentCompositionCalculator;

        /*
        structureGenerationService coordinates chemical structure generation.
        The service receives a StructureGenerationRequest containing: ChemicalEntity + ChemicalOperation
        */
        private readonly StructureGenerationService structureGenerationService;

        /*
        chemicalPropertyService retrieves requested experimental chemical properties.
        The cached service can use its configured caching behavior while presenting
        property-retrieval functionality to this application use case.
        */
        private readonly CachedChemicalPropertyService chemicalPropertyService;

        /*
        The constructor receives all collaborators required by the chemical-analysis workflow.
        Each dependency is assigned to the corresponding private readonly field. This is constructor 
        injection (the use case does not construct these services internally). They are supplied to it 
        when the AnalyzeChemicalUseCase object is created.
        */
        public AnalyzeChemicalUseCase(ChemicalFormulaParser chemicalFormulaParser, 
        IChemicalFormulaValidator chemicalFormulaValidator, IChemicalEntityResolver chemicalEntityResolver,
        IChemicalEntityValidator chemicalEntityValidator, IChemicalEntityClassifier chemicalEntityClassifier,
        IMolecularFormulaGenerator molecularFormulaGenerator, IMolarMassCalculator molarMassCalculator,
        IPercentCompositionCalculator percentCompositionCalculator, StructureGenerationService structureGenerationService,
        CachedChemicalPropertyService chemicalPropertyService) 
        {
            this.chemicalFormulaParser = chemicalFormulaParser;
            this.chemicalFormulaValidator = chemicalFormulaValidator;
            this.chemicalEntityResolver = chemicalEntityResolver;
            this.chemicalEntityValidator = chemicalEntityValidator;
            this.chemicalEntityClassifier = chemicalEntityClassifier;
            this.molecularFormulaGenerator = molecularFormulaGenerator;
            this.molarMassCalculator = molarMassCalculator;
            this.percentCompositionCalculator = percentCompositionCalculator;
            this.structureGenerationService = structureGenerationService;
            this.chemicalPropertyService = chemicalPropertyService;
        }

        /*
        Execute performs the complete application-level chemical-analysis workflow.
        The supplied request determines the chemical input, how the input should be interpreted,
        which chemical operations should be performed, and which experimental properties should be retrieved
        The results are collected and returned inside one AnalyzeChemicalResponse.
        */
        public AnalyzeChemicalResponse Execute(AnalyzeChemicalRequest request)
        {
            /*
            messages collects messages produced while the analysis pipeline executes.
            List<string> is used internally because this method needs to add messages as processing proceeds.
            The finished list can later be exposed through the IReadOnlyCollection<string> property of AnalyzeChemicalResponse.
            */
            List<string> messages = new();

            /*
            structures collects the result of each requested structure-generation operation.
            One StructureGenerationResult is added for each requested ChemicalOperation.
            */
            List<StructureGenerationResult> structures = new();

            // Parse the supplied chemical input
            FormulaParseResult parseResult = chemicalFormulaParser.Parse(request.InputText);
            if (!parseResult.Success)
            {
                throw new ArgumentException("The supplied chemical formula should not be parsed.");
            }

            ChemicalFormula formula = parseResult.Formula;

            ValidationResult formulaValidation = chemicalFormulaValidator.Validate(formula);

            // Copy the validation messages into the application-level messages list.
            AddValidationMessages(formulaValidation, messages);

            // Resolve the ChemicalFormula to a ChemicalEntity.
            // The resolution system determines which chemical entity corresponds to the supplied chemical information.
            ChemicalResolutionRequest resolutionRequest = new ChemicalResolutionRequest(request.InputText, request.InputKind, formula, null!);
            ChemicalEntityResolutionResult resolution = chemicalEntityResolver.Resolve(resolutionRequest);

            // Obtain the resolved ChemicalEntity from the resolution result.
            // The entity becomes the central domain object used by the remaining application workflow.
            if (resolution.Status != ResolutionStatus.Resolved)
            {
                throw new InvalidOperationException("The chemical input could not be resolved to a unique chemical entity.");
            }
            ChemicalEntity entity = resolution.ResolvedEntity;

            // Validate the resolved ChemicalEntity.
            ValidationResult entityValidation = chemicalEntityValidator.Validate(entity);

            // Add any entity-validation messages to the application-level message collection.
            AddValidationMessages(entityValidation, messages);

            // Classify the resolved ChemicalEntity.
            ChemicalClassificationResult classification = chemicalEntityClassifier.Classify(entity);

            // If the resolved ChemicalEntity is specifically a Molecule, regenerate its ChemicalFormula from its MolecularGraph.
            // If entity refers to a Molecule, the same object becomes available through the local variable named molecule.
            if (entity is Molecule molecule)
            {
                // molecule.Graph provides the MolecularGraph associated with the Molecule.
                // The molecularFormulaGenerator uses that graph to generate the corresponding ChemicalFormula.
                formula = molecularFormulaGenerator.Generate(molecule.Graph);
            }

            // Other calculations and requested operations go here.
            // This return must be reachable for every successful execution path.

            // Calculate molar mass using the current ChemicalFormula.
            CalculationResult molarMass = molarMassCalculator.Calculate(formula);

            // Calculate elemental percent composition using the same ChemicalFormula.
            IReadOnlyCollection<ElementPercentComposition> percentComposition = percentCompositionCalculator.Calculate(formula);

            // Perform each chemical operation requested by the caller.
            foreach (ChemicalOperation operation in request.RequestedOperations)
            {
                // Create a StructureGenerationRequest for the current operation.
                // The request contains entity (to process ChemicalEntity) and operation (to perform ChemicalOperation)
                StructureGenerationRequest structureRequest = new StructureGenerationRequest(entity, operation);

                // Ask StructureGenerationService to perform the requested operation.
                // The service returns a StructureGenerationResult describing the outcome.
                StructureGenerationResult structureResult = structureGenerationService.Generate(structureRequest);

                // Add the result to the collection that will eventually be placed inside AnalyzeChemicalResponse.
                structures.Add(structureResult);
            }

            // Create a query containing the chemical entity and requested properties.
            PropertyQuery propertyQuery = new PropertyQuery(entity, request.RequestedProperties);

            // Retrieve the requested experimental chemical properties.
            PropertyRetrievalResult properties = chemicalPropertyService.GetProperties(propertyQuery);

            // Combine all results produced by the chemical-analysis workflow into a single application-level response object.
            return new AnalyzeChemicalResponse(resolution, classification, formula, molarMass, percentComposition, structures, properties, messages);


        }

        /*
        AddValidationMessages is a private helper method.
        This method is an implementation detail of AnalyzeChemicalUseCase.
        The method does not need access to a particular AnalyzeChemicalUseCase object's instance fields.
        Its responsibility is to copy the textual messages contained in the ValidationResult into the application-level message collection.
        */
        private static void AddValidationMessages(ValidationResult validationResult, ICollection<string> messages)
        {
            // Iterate through every ValidationIssue contained in the validation result.
            foreach (ValidationIssue issue in validationResult.Issues)
            {
                // Add the human-readable validation message to the application-level message collection.
                messages.Add(issue.Message);
            }
        }

    }
}