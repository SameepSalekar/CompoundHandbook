/*
RecognizeStructureUseCase implements the application-level workflow for OCSR.
The user begins this workflow by supplying a StructureImageInput.
RecognizeStructureUseCase does not perform image recognition itself.
Instead, it delegates that responsibility to IOCSRProvider.

The workflow is:
StructureImageInput -> RecognizeStructureUseCase -> IOCSRProvider -> StructureRecognitionResult -(Success)-(Candidates)-(Messages)

If recognition succeeds, each StructureRecognitionCandidate can contain a
machine-readable representation of a possible recognized structure.

For the current architecture, the candidate's SMILES representation is converted
into a ChemicalIdentifier.

That identifier is then passed into the ordinary chemical-entity resolution
pipeline through IChemicalEntityResolver.

This is important architecturally because image-recognition workflow does not create an entirely 
separate system for finding ChemicalEntity objects.

image recognition -> recognized SMILES -> ChemicalIdentifier -> existing Resolution System

Therefore, the OCSR workflow reuses the same chemical-resolution infrastructure
already used elsewhere in Compound Handbook.
*/

/*
This class implements IRecognizeStructureUseCase. This class will provide a compatible
Execute method. The class receives two dependencies through its constructor
(IOCSRProvider and IChemicalEntityResolver). These dependencies are stored in private 
readonly fields. Therefore, they are only accessible inside this class, also
once the constructor assigns the dependency reference, the field cannot later be reassigned through normal instance code.

This is constructor dependency injection. The class therefore coordinates existing abstractions rather 
than constructing specific implementations internally.
*/

using CompoundHandbook.Domain;
using CompoundHandbook.Parsing;
using CompoundHandbook.Resolution;

namespace CompoundHandbook.Application 
{
    // RecognizeStructureUseCase coordinates OCSR and the existing chemical-entity resolution system.
    public sealed class RecognizeStructureUseCase : IRecognizeStructureUseCase 
    {
        /*
        ocsrProvider references the component responsible for performing OCSR.
        The field uses the IOCSRProvider interface rather than depending on a 
        particular concrete OCSR implementation.
        */
        private readonly IOCSRProvider ocsrProvider;

        /*
        chemicalEntityResolver references the existing chemical-resolution abstraction.
        Recognized structure candidates can therefore be passed into the same
        resolution pipeline used elsewhere in Compound Handbook.
        */
        private readonly IChemicalEntityResolver chemicalEntityResolver;

        /*
        The constructor receives the dependencies required by this use case.
        Parameter ocsrProvider performs the actual optical chemical structure recognition.
        Parameter chemicalEntityResolver attempts to resolve recognized chemical identifiers 
        into ChemicalEntity objects.
        The supplied dependencies are stored in the corresponding readonly fields.
        */
        public RecognizeStructureUseCase(IOCSRProvider ocsrProvider, IChemicalEntityResolver chemicalEntityResolver)
        {
            this.ocsrProvider = ocsrProvider;
            this.chemicalEntityResolver = chemicalEntityResolver;
        }

        /*
        Execute performs the application-level structure-recognition workflow.
        Step 1: Send the supplied image to the OCSR provider.
        Step 2: Receive the StructureRecognitionResult.
        Step 3: If recognition failed, immediately return that result.
        Step 4: If recognition succeeded, examine each recognized candidate.
        Step 5: Convert the candidate's SMILES representation into a ChemicalIdentifier
        Step 6: Construct a ChemicalResolutionRequest.
        Step 7: Pass that request into the existing chemical-entity resolver.
        Step 8: Return the original StructureRecognitionResult.
        */
        public StructureRecognitionResult Execute(StructureImageInput input)
        {
            // Ask the configured OCSR provider to examine the supplied image.
            StructureRecognitionResult recognitionResult = ocsrProvider.Recognize(input);
        

            // Return the recognition result immediately if recognition doesn't succeeds
            if (!recognitionResult.Success)
            {
                return recognitionResult;
            }

            // Recognition may produce more than one possible candidate.
            // foreach processes each StructureRecognitionCandidate contained in the Candidates collection.
            foreach (StructureRecognitionCandidate candidate in recognitionResult.Candidates)
            {
                // Convert the candidate's SMILES string into a typed ChemicalIdentifier.
                ChemicalIdentifier identifier = CreateChemicalIdentifier(candidate);

                // Create a request for the existing chemical-resolution system.
                ChemicalResolutionRequest resolutionRequest = new ChemicalResolutionRequest(candidate.Smiles, ChemicalInputKind.StructureImage, null, identifier);

                // Pass the recognized chemical identifier through the ordinary chemical-entity resolution system.
                chemicalEntityResolver.Resolve(resolutionRequest);
            }
        
            // Return the recognition result originally produced by the OCSR provider (preserving the contract declaired by IRecognizeStructureUseCase)
            return recognitionResult;
        }
        
        /*
        CreateChemicalIdentifier converts a recognized OCSR candidate into the
        ChemicalIdentifier representation expected by the Domain and Resolution
        layers.
        */
        private static ChemicalIdentifier CreateChemicalIdentifier(StructureRecognitionCandidate candidate)
        {
            return new ChemicalIdentifier(ChemicalIdentifierType.Smiles, candidate.Smiles);
        }
    }
}