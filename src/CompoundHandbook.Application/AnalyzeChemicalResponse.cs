/*
The Compound Handbook chemical-analysis workflow can produce several different kinds
of information from a single chemical-analysis request.

The workflow may:
1. resolve the supplied chemical input to a ChemicalEntity,
2. classify the resolved chemical entity,
3. determine or generate its ChemicalFormula,
4. calculate its molar mass,
5. calculate its elemental percent composition,
6. generate requested chemical structures,
7. retrieve requested experimental chemical properties,
8. produce informational, validation, or processing messages.

Returning each of these pieces of information separately would make the application
workflow more difficult to use.

AnalyzeChemicalResponse therefore acts as one application-level response object that
collects the major results produced by the chemical-analysis pipeline.

It does not perform the calculations, classification, resolution, structure generation,
or property retrieval itself.

Instead, it acts as a container for the results produced by those systems.
*/

/*
AnalyzeChemicalResponse is declared as a sealed class.

The sealed keyword prevents another class from inheriting from this class.

This is appropriate because AnalyzeChemicalResponse represents a concrete
application-level response contract rather than a base class intended for inheritance.

Each property of this class can be read publicly but cannot be reassigned through a public
setter after the object has been constructed.

The constructor receives each result produced by the analysis pipeline and assigns it
to the corresponding property.
*/

using System.Collections.Generic;
using CompoundHandbook.Calculations;
using CompoundHandbook.Classification;
using CompoundHandbook.Domain;
using CompoundHandbook.Resolution;
using CompoundHandbook.StructureGeneration;
using CompoundHandbook.DataContracts;

namespace CompoundHandbook.Application
{
    /*
    AnalyzeChemicalResponse represents the combined result of an application-level
    chemical-analysis operation.
    The application layer can return this single object rather than requiring its
    caller to independently collect results from each subsystem.
    */

    public sealed class AnalyzeChemicalResponse 
    {
        /*
        Resolution stores the result of attempting to resolve the supplied chemical
        input to a ChemicalEntity.
        ChemicalEntityResolutionResult can describe the outcome of the resolution
        process and the entity or candidate information produced by that process.
        */
        public ChemicalEntityResolutionResult Resolution { get; }

        /*
        Classification stores the classification result associated with the resolved
        chemical entity.
        The classification system determines which chemical classifications apply
        to the entity according to the classification logic implemented elsewhere
        in the Compound Handbook.
        */
        public ChemicalClassificationResult Classification { get; }

        /*
        Formula stores the ChemicalFormula associated with the analyzed entity.
        ChemicalFormula belongs to the Domain system and represents the chemical
        formula used by downstream calculation operations.
        */
        public ChemicalFormula Formula { get; }

        /*
        MolarMass stores the result produced by the molar-mass calculation.
        CalculationResult is used rather than storing only a raw numeric value because
        the calculation system can represent the result through its own result contract.
        */
        public CalculationResult MolarMass { get; }

        /*
        PercentComposition stores the elemental percent-composition results.
        Each ElementPercentComposition object represents the calculated contribution
        associated with one element.
        IReadOnlyCollection<ElementPercentComposition> allows multiple elemental
        composition results to be returned while exposing them as a read-only
        collection through this property.
        */
        public IReadOnlyCollection<ElementPercentComposition> PercentComposition { get; }

        /*
        Structures stores the results of the requested structure-generation operations.
        This property contains StructureGenerationResult objects.
        It does not contains ChemicalOperation values because ChemicalOperation describes
        what operation was requested.
        StructureGenerationResult describes what happened when a structure-generation
        request was actually processed.
        Its result can communicate whether generation succeeded, failed or was unsupported
        or invalid or was not applicable according to the StructureGenerationStatus associated
        with that result.
        */
        public IReadOnlyCollection<StructureGenerationResult> Structures { get; }

        /*
        Properties stores the result of experimental-property retrieval.
        PropertyRetrievalResult packages the information produced by the chemical
        property retrieval system.
        */
        public PropertyRetrievalResult Properties { get; }

        /*
        Messages stores application-level messages collected while the chemical
        analysis pipeline is executed.
        The collection can contain messages propagated from validation or other
        processing stages.
        */
        public IReadOnlyCollection<string> Messages { get; }

        /*
        The following constructor creates an AnalyzeChemicalResponse.
        Each parameter corresponds to one result produced during the chemical-analysis
        workflow.
        The constructor assigns those supplied result objects to their corresponding
        read-only properties.
        */
        public AnalyzeChemicalResponse(ChemicalEntityResolutionResult resolution, ChemicalClassificationResult classification, ChemicalFormula formula, CalculationResult molarMass, IReadOnlyCollection<ElementPercentComposition> percentComposition, IReadOnlyCollection<StructureGenerationResult> structures, PropertyRetrievalResult properties, IReadOnlyCollection<string> messages)
        {
            // Supplied resolution parameter gets assigned to the Resolution property.
            Resolution = resolution;

            // Supplied classification parameter gets assigned to the Classification property.
            Classification = classification;

            // Supplied formula parameter gets assigned to the Formula property.
            Formula = formula;

            // Supplied molarMass parameter gets assigned to the MolarMass property.
            MolarMass = molarMass;

            // Supplied percentComposition parameter gets assigned to the PercentComposition property
            PercentComposition = percentComposition;

            // Supplied structures parameter gets assigned to the Structures property
            Structures = structures;

            // Supplied properties parameter gets assigned to the Properties property
            Properties = properties;

            // Supplied messages parameter gets assigned to the Messages property
            Messages = messages;

        }

    }
}