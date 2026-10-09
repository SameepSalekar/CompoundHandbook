/*
A ChemicalEntityResolutionResult represents the result produced after the Compound Handbook
attempts to resolve chemical input into a particular ChemicalEntity.

The chemical-entity resolution process does not always produce the same type of outcome.

The supplied chemical input may:
(i)   Successfully resolve to one particular ChemicalEntity.
(ii)  Produce multiple possible ChemicalEntity candidates.
(iii) Fail to match any known ChemicalEntity.
(iv)  Be invalid for the resolution process.
(v)   Represent a resolution case that is currently unsupported.

Because of these different possible outcomes, simply returning a ChemicalEntity object would
not provide enough information about what happened during the resolution process.

For example, if no ChemicalEntity were returned, the rest of the Compound Handbook would
still need to know whether the entity was not found, whether the input was invalid, or whether
the requested resolution case was unsupported.

This is why, ChemicalEntityResolutionResult class is being created, in order to allow the Resolution 
system to return both the outcome of the resolution attempt and the information associated with that 
outcome inside one object.
*/

/*
ChemicalEntityResolutionResult = Status + ResolvedEntity + Candidates + Messages

(i)   Status         : Stores the ResolutionStatus describing the result of resolution.
(ii)  ResolvedEntity : Stores the successfully resolved ChemicalEntity.
(iii) Candidates     : Stores a collection of possible ChemicalEntityCandidate objects.
(iv)  Messages       : Stores a collection of messages associated with the resolution result.

All four of these are read-only properties because they contain only a 'getter' accessor.
These properties can be read from outside of the class, but they cannot be directly
changed from outside of the class after the ChemicalEntityResolutionResult object has been constructed.

The following class also contains a constructor that receives the ResolutionStatus,
ChemicalEntity, collection of ChemicalEntityCandidate objects, and collection of messages
required to initialize a new ChemicalEntityResolutionResult object.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.Resolution 
{
    // The following class represents the result produced by the chemical-entity resolution process.
    public class ChemicalEntityResolutionResult 
    {
        /*
        Read-only property that stores the overall status of the chemical-entity resolution process.

        ResolutionStatus is an enum itself, but is being used as the datatype of this property.
        The value of the Status can be either Resolved, Ambiguous, NotFound, InvalidInput, or Unsupported.
        
        This property allows the rest of the Compound Handbook to determine what happened 
        during the resolution attempt.
        */        
        public ResolutionStatus Status { get; }

        /*
        Read-only property that stores the ChemicalEntity successfully identified
        by the resolution process.

        ChemicalEntity is an abstract class itself, but is being used as the datatype
        of this property.

        Therefore, ResolvedEntity can reference an object belonging to one of the
        specific classes that inherits from ChemicalEntity.

        This property is used to carry the particular ChemicalEntity when the
        resolution process successfully determines one entity.        
        */
        public ChemicalEntity ResolvedEntity { get; }

        /*
        Read-only property that stores the possible ChemicalEntityCandidate objects
        produced by the resolution process.

        IReadOnlyCollection<T> is a .NET generic interface that represents a collection
        whose elements can be accessed but cannot be added or removed through this interface.

        ChemicalEntityCandidate is the datatype of the objects contained inside
        this collection.

        Therefore, IReadOnlyCollection<ChemicalEntityCandidate> represents a read-only
        collection containing the possible chemical-entity matches.

        This collection is particularly useful when the resolution Status is Ambiguous
        and more than one possible ChemicalEntity needs to be returned.
        */
        public IReadOnlyCollection<ChemicalEntityCandidate> Candidates { get; }

        /*
        Read-only property that stores the messages associated with the
        chemical-entity resolution result.

        IReadOnlyCollection<string> represents a read-only collection containing string values.
        Each string can contain additional information produced during the resolution process.

        These messages allow the Resolution system to provide information about
        the result in addition to the ResolutionStatus itself.        
        */
        public IReadOnlyCollection<string> Messages { get; }

        /*
        The following constructor will be called whenever a new
        ChemicalEntityResolutionResult object gets created.

        The constructor receives the ResolutionStatus, resolved ChemicalEntity,
        collection of ChemicalEntityCandidate objects, and collection of messages
        as parameters.

        The supplied arguments are then assigned to their corresponding read-only
        properties of the ChemicalEntityResolutionResult object.
        */
        public ChemicalEntityResolutionResult(ResolutionStatus status, ChemicalEntity resolvedEntity, IReadOnlyCollection<ChemicalEntityCandidate> candidates, IReadOnlyCollection<string> messages) 
        {
            // Stores the supplied ResolutionStatus value in the Status property.
            Status = status;

            // Stores the supplied ChemicalEntity object in the ResolvedEntity property.
            ResolvedEntity = resolvedEntity;

            // Stores the supplied collection of ChemicalEntityCandidate objects in the Candidates property.
            Candidates = candidates;

            // Stores the supplied collection of string messages in the Messages property.
            Messages = messages;
        }
    }
}