/*
SelectChemicalCandidateUseCase continues the Compound Handbook chemical-analysis
workflow after the caller has selected one ChemicalEntity from a set of possible
resolution candidates.

This use case exists because chemical resolution can sometimes be ambiguous.

For example, the original chemical input may produce multiple possible
ChemicalEntity candidates.

Rather than restarting the entire analysis process, the caller can select one
candidate and provide its identifier to SelectChemicalCandidateUseCase.

The use case then:
1. retrieves the selected ChemicalEntity,
2. validates the entity,
3. classifies the entity,
4. generates its molecular formula when the entity is a Molecule,
5. calculates molar mass,
6. calculates elemental percent composition,
7. performs the requested chemical structure operations,
8. retrieves the requested experimental properties,
9. creates a successful resolution result for the selected entity,
10. returns the combined information inside AnalyzeChemicalResponse.

Unlike AnalyzeChemicalUseCase, this use case does not need to parse the original
chemical input again.

The caller has already selected the intended ChemicalEntity.

Therefore, this workflow begins with retrieval of that selected entity.
*/

/*
SelectChemicalCandidateUseCase implements ISelectChemicalCandidateUseCase.

The class uses constructor injection.

Each external collaborator required by the workflow is supplied through the
constructor and stored in a private readonly field.

This allows the use case to coordinate existing Compound Handbook services without
constructing those services itself.

The Execute method contains the main application workflow.
*/

using System.Collections.Generic;
using CompoundHandbook.Calculations;
using CompoundHandbook.Classification;
using CompoundHandbook.DataContracts;
using CompoundHandbook.Domain;
using CompoundHandbook.Resolution;
using CompoundHandbook.StructureGeneration;
using CompoundHandbook.Validation;

namespace CompoundHandbook.Application
{
    // SelectChemicalCandidateUseCase continues chemical analysis using a ChemicalEntity explicitly selected by the caller.
    public sealed class SelectChemicalCandidateUseCase : ISelectChemicalCandidateUseCase 
    {
        // chemicalEntityRepository provides access to stored ChemicalEntity objects.
        private readonly IChemicalEntityRepository chemicalEntityRepository;

        // chemicalEntityValidator validates the selected ChemicalEntity before the remaining analysis operations are performed.
        private readonly IChemicalEntityValidator chemicalEntityValidator;

        // chemicalEntityClassifier determines the chemical classifications associated with the selected entity.
        private readonly IChemicalEntityClassifier chemicalEntityClassifier;

        // molecularFormulaGenerator generates a ChemicalFormula from a Molecule's MolecularGraph.
        private readonly IMolecularFormulaGenerator molecularFormulaGenerator;

        // molarMassCalculator calculates the molar mass associated with a ChemicalFormula.
        private readonly IMolarMassCalculator molarMassCalculator;

        // percentCompositionCalculator calculates the elemental percent composition associated with a ChemicalFormula.
        private readonly IPercentCompositionCalculator percentCompositionCalculator;

        // structureGenerationService coordinates the requested chemical structure-generation operations.
        private readonly StructureGenerationService structureGenerationService;

        // chemicalPropertyService retrieves experimental chemical properties while using the Compound Handbook's configured caching behavior.
        private readonly CachedChemicalPropertyService chemicalPropertyService;

        /*
        The constructor receives every collaborator required by this use case.
        Each constructor parameter is assigned to the corresponding private readonly field.
        */
        public SelectChemicalCandidateUseCase(IChemicalEntityRepository chemicalEntityRepository, IChemicalEntityValidator chemicalEntityValidator,
        IChemicalEntityClassifier chemicalEntityClassifier, IMolecularFormulaGenerator molecularFormulaGenerator,
        IMolarMassCalculator molarMassCalculator, IPercentCompositionCalculator percentCompositionCalculator,
        StructureGenerationService structureGenerationService, CachedChemicalPropertyService chemicalPropertyService)
        {
            this.chemicalEntityRepository = chemicalEntityRepository;
            this.chemicalEntityValidator = chemicalEntityValidator;
            this.chemicalEntityClassifier = chemicalEntityClassifier;
            this.molecularFormulaGenerator = molecularFormulaGenerator;
            this.molarMassCalculator = molarMassCalculator;
            this.percentCompositionCalculator = percentCompositionCalculator;
            this.structureGenerationService = structureGenerationService;
            this.chemicalPropertyService = chemicalPropertyService;
        }

        // Execute continues chemical analysis using the ChemicalEntity selected by the caller.
        public AnalyzeChemicalResponse Execute(SelectChemicalCandidateRequest request)
        {
            // Collect messages produced during validation and other application processing.
            List<string> messages = new();

            // Collect the result produced by each requested structure-generation operation.
            List<StructureGenerationResult> structures = new();

            // Retrieve the ChemicalEntity selected by the caller.
            ChemicalEntity entity = chemicalEntityRepository.FindById(request.CandidateEntityId);

            // Validate the selected ChemicalEntity.
            ValidationResult entityValidation = chemicalEntityValidator.Validate(entity);

            // Copy validation messages into the application-level message collection.
            AddValidationMessages(entityValidation, messages);

            // Classify the selected ChemicalEntity.
            ChemicalClassificationResult classification = chemicalEntityClassifier.Classify(entity);

            // Prepare the ChemicalFormula.



            // Ensure the selected ChemicalEntity is a Molecule.
            if (entity is not Molecule molecule)
            {
                throw new InvalidOperationException("The selected ChemicalEntity must be a Molecule.");
            }

            // Calculate molar mass using the generated ChemicalFormula.
            ChemicalFormula formula = molecularFormulaGenerator.Generate(molecule.Graph);
            
            // Calculate molar mass using the generated ChemicalFormula.
            CalculationResult molarMass = molarMassCalculator.Calculate(formula);
    
            // Calculate elemental percent composition.
            IReadOnlyCollection<ElementPercentComposition> percentComposition = percentCompositionCalculator.Calculate(formula);

            // Perform every ChemicalOperation requested by the caller.
            foreach(ChemicalOperation operation in request.RequestedOperations) 
            {
                // Create one StructureGenerationRequest for the current operation
                StructureGenerationRequest structureRequest = new StructureGenerationRequest(entity, operation);

                // Execute the requested structure-generation operation.
                StructureGenerationResult structureResult = structureGenerationService.Generate(structureRequest);

                // Store the result so that it can later be included in the AnalyzeChemicalResponse.
                structures.Add(structureResult);
            }

            // Retrieve the experimental properties requested by the caller.
            PropertyRetrievalResult properties = RetrieveProperties(entity, request.RequestedProperties);

            // Create a resolution result representing the entity as resolved.
            ChemicalEntityResolutionResult resolution = CreateResolutionResult(entity);

            // Combine the completed analysis results into one application-level response.
            return new AnalyzeChemicalResponse(resolution, classification, formula, molarMass, percentComposition, structures, properties, messages);
        }

        // RetrieveProperties creates the PropertyQuery required by the chemical property service.
        private PropertyRetrievalResult RetrieveProperties(ChemicalEntity entity, IReadOnlyCollection<ExperimentalPropertyKind> requestedProperties) 
        {
            // Construct the property query that contains the ChemicalEntity and the requested property kinds
            PropertyQuery query = new PropertyQuery(entity, requestedProperties);
                
            // Delegate property retrieval to CachedChemicalPropertyService.
            return chemicalPropertyService.GetProperties(query);
        }

        /*
        CreateResolutionResult constructs the resolution result associated with the caller's explicit candidate selection.
        Since the caller has already selected the desired entity, the resolution status is Resolved.
        There are no remaining ambiguous candidates, so an empty candidate collection is supplied.
        There are also no additional resolution messages generated by this helper, so an empty string collection is supplied.
        */
        private static ChemicalEntityResolutionResult CreateResolutionResult(ChemicalEntity entity)
        {
            return new ChemicalEntityResolutionResult(ResolutionStatus.Resolved, entity, new List<ChemicalEntityCandidate>(), new List<string>());
        }

        /*
        AddValidationMessages copies each ValidationIssue message into the application-level message collection.
        static is appropriate because this helper does not access any instance fields belonging to SelectChemicalCandidateUseCase.
        */
        private static void AddValidationMessages(ValidationResult validationResult, ICollection<string> messages)
        {
            // Examine every ValidationIssue contained in the ValidationResult.
            foreach (ValidationIssue issue in validationResult.Issues)
            {
                // Add the human-readable validation message to the application's message collection.
                messages.Add(issue.Message);
            }
        }
    }
}