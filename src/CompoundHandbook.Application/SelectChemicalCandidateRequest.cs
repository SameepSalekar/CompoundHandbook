/*
During chemical entity resolution, the Compound Handbook may encounter situations
where the supplied chemical information corresponds to more than one possible
ChemicalEntity.
Instead of automatically choosing one candidate, the application can allow the caller
to select the appropriate chemical entity.

Once a candidate has been selected, the Compound Handbook needs enough information
to continue the chemical-analysis workflow. That information will be represented by
the SelectChemicalCandidateRequest

SelectChemicalCandidateRequest = CandidateEntityId + RequestedOperations + RequestedProperties
*/

/*
SelectChemicalCandidateRequest is declared as a sealed class.

A sealed class cannot be used as a base class for inheritance.

This is appropriate because SelectChemicalCandidateRequest represents a specific
application request contract. Their values can be read publicly but cannot be 
reassigned through public setters after construction.

The constructor receives the selected entity identifier, requested chemical operations,
and requested experimental properties and assigns those values to the corresponding
properties.

IReadOnlyCollection<T> is used for the requested operations and requested properties.
*/

using System.Collections.Generic;
using CompoundHandbook.Classification;
using CompoundHandbook.Domain;

namespace CompoundHandbook.Application
{
    /*
    SelectChemicalCandidateRequest represents the information required to continue
    chemical analysis after the caller has selected one ChemicalEntity candidate.
    */

    public sealed class SelectChemicalCandidateRequest
    {
        // CandidateEntityId identifies the chemical entity selected by the caller.
        // The selected identifier can later be supplied to a chemical entity repository
        // so that the corresponding ChemicalEntity can be retrieved.
        // The data-type here is string.
        public string CandidateEntityId { get; }

        /*
        RequestedOperations contains the chemical operations that the caller wants
        performed on the selected ChemicalEntity.
        ChemicalOperation describes WHAT operation should be performed, which is 
        intentionally different from StructureRepresentationKind.

        StructureRepresentationKind describes the respresentation format (Text or Svg)
        ChemicalOperation identifies the chemical operation itself.

        The application request must carry ChemicalOperation values here, because
        the current StructureGenerationRequest accepts a ChemicalOperation.
        */
        public IReadOnlyCollection<ChemicalOperation> RequestedOperations { get; }

        /*
        RequestedProperties contains the experimental property kinds requested
        for the selected chemical entity.
        Because this is an IReadOnlyCollection<ExperimentalPropertyKind>, consumers
        can enumerate the requested property kinds without this property exposing
        collection-modification operations.
        */
        public IReadOnlyCollection<ExperimentalPropertyKind> RequestedProperties { get; }

        /*
        The constructor creates a SelectChemicalCandidateRequest, where:
        candidateEntityId: Identifies the ChemicalEntity selected by the caller.
        requestedOperations: Identifies the chemical operations that should be performed.
        requestedProperties: identifies the experimental properties that should be retrieved.
        */
        public SelectChemicalCandidateRequest(string candidateEntityId, IReadOnlyCollection<ChemicalOperation> requestedOperations, IReadOnlyCollection<ExperimentalPropertyKind> requestedProperties) 
        {
            // Store the identifier of the selected chemical entity.
            CandidateEntityId = candidateEntityId;

            // Store the requested chemical operations.
            RequestedOperations = requestedOperations;

            // Store the requested experimental property kinds.
            RequestedProperties = requestedProperties;
        }
    }
}