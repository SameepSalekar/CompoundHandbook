/*
ChemicalEntityResolver is the class that contains the actual logic used by the Resolution
system to attempt to determine which ChemicalEntity corresponds to the chemical input
supplied to the Compound Handbook.

Earlier files inside the Resolution system established the information that enters and
leaves this process:
ChemicalResolutionRequest -> ChemicalEntityResolver -> ChemicalEntityResolutionResult

ChemicalResolutionRequest contains the information that has already been obtained about
the user's chemical input. ChemicalEntityResolutionResult represents what happened after 
attempting to resolve that input into a ChemicalEntity.

ChemicalEntityResolver connects these two parts together by examining the request,
determining what type of chemical input is being resolved, searching for matching
ChemicalEntity objects, and then constructing the appropriate result.

The resolution process performed by this class can generally be represented as:
1) Receive a ChemicalResolutionRequest.
2) Determine which ChemicalInputKind the request represents.
3) If the input is a Formula, then the parsed ChemicalFormula to search for matching ChemicalEntity objects.
4) If the input is a Name, then use the recognized ChemicalIdentifier, then normalize the ChemicalIdentifier
...Search for ChemicalEntity objects matching that normalized identifier.
5) Examine how many ChemicalEntity objects were found.
6) Return a ChemicalEntityResolutionResult containing the appropriate ResolutionStatus and associated information.

Structure-image resolution is not performed directly by this resolver and therefore
produces an Unsupported result.
*/

/*
ChemicalEntityResolver implements the IChemicalEntityResolver interface.
IChemicalEntityResolver defines the "ChemicalEntityResolutionResult Resolve(ChemicalResolutionRequest request);"
contract.

Therefore, because ChemicalEntityResolver implements IChemicalEntityResolver, ChemicalEntityResolver must 
provide the actual implementation of the Resolve() method.

The class also depends upon two other following abstractions:
(i)  IChemicalEntityRepository: Used to search the available chemical data for matching ChemicalEntity objects.
(ii) IChemicalIdentifierNormalizer: Used to normalize a ChemicalIdentifier before performing an identifier-based search.

These dependencies are supplied through the ChemicalEntityResolver constructor instead of
being created directly inside the resolver.

This means that ChemicalEntityResolver is responsible for coordinating the resolution
process, while the repository remains responsible for chemical-entity retrieval and the
identifier normalizer remains responsible for chemical-identifier normalization.
*/

using CompoundHandbook.DataContracts;
using CompoundHandbook.Domain;
using CompoundHandbook.Parsing;

namespace CompoundHandbook.Resolution 
{
    /*
    The following ChemicalEntityResolver class implements IChemicalEntityResolver.

    The ':' symbol following ChemicalEntityResolver indicates that this class implements
    the IChemicalEntityResolver interface.

    ChemicalEntityResolver provides the actual implementation of the chemical
    resolution operation that was previously declared by IChemicalEntityResolver.
    */
    public class ChemicalEntityResolver : IChemicalEntityResolver 
    {
        /*
        The following field stores the chemical-entity repository that will be used
        by this resolver.

        IChemicalEntityRepository is an interface itself, but is being used as the
        datatype of the _entityRepository field.
        
        ChemicalEntityResolver does not need to depend upon one particular repository implementation.

        It only requires an object that implements IChemicalEntityRepository and can
        therefore provide the chemical-entity retrieval operations defined by that interface.

        Also, the following field can only be accessed from inside the ChemicalEntityResolver class.

        'readonly' indicates that after this field has been assigned during construction
        of the ChemicalEntityResolver object, the field cannot later be reassigned
        to a different repository object.        
        */        
        private readonly IChemicalEntityRepository _entityRepository;

        /*
        The following field stores the chemical-identifier normalizer that will be
        used by this resolver.

        IChemicalIdentifierNormalizer is an interface itself, but is being used as
        the datatype of the _identifierNormalizer field.

        This object will be used whenever a ChemicalIdentifier needs to be normalized
        before it is supplied to the chemical-entity repository.

        Just like _entityRepository, this field is private and readonly.
        */        
        private readonly IChemicalIdentifierNormalizer _identifierNormalizer;

        /*
        The following constructor will be called whenever a new ChemicalEntityResolver
        object gets created.

        Instead of ChemicalEntityResolver constructing its own repository and identifier
        normalizer, both objects are received through the constructor. This is known as 
        constructor dependency injection.
        
        The constructor receives entityRepository object to implement IChemicalEntityRepository and
        identifierNormalizer object to implement IChemicalIdentifierNormalizer.

        These supplied objects are then stored inside the corresponding private readonly fields
        so that the resolver can use them later.
        */        
        public ChemicalEntityResolver(IChemicalEntityRepository entityRepository, IChemicalIdentifierNormalizer identifierNormalizer)
        {
            // Stores the supplied chemical-entity repository inside the resolver.
            _entityRepository = entityRepository;

            // Stores the supplied chemical-identifier normalizer inside the resolver.
            _identifierNormalizer = identifierNormalizer;
        }

        /*
        Resolve() is the main public operation of ChemicalEntityResolver.

        This is the actual implementation of the Resolve() method that was declared
        inside IChemicalEntityResolver.

        The method receives one ChemicalResolutionRequest and returns one
        ChemicalEntityResolutionResult.

        The method first validates that a request was actually supplied.

        It then examines request.InputKind to determine which resolution path should
        be followed.

        Therefore, Resolve() acts as the main decision point that routes the supplied
        request toward the appropriate resolution operation.        
        */        
        public ChemicalEntityResolutionResult Resolve(ChemicalResolutionRequest request)
        {
            /*
            Before attempting to access any information from request, if statement is 
            checking whether request itself is null.

            The condition inside this if-statment evaluates to true when no 
            ChemicalResolutionRequest object was supplied.

            Attempting to access request.InputKind or another property when request
            is null would cause a NullReferenceException.

            Therefore, the resolver immediately returns an InvalidInput result instead.
            */
            if(request == null)
            {
                /*
                Because the request itself is invalid, a new
                ChemicalEntityResolutionResult is immediately returned.

                ResolutionStatus.InvalidInput indicates that the supplied input to
                the resolution operation is invalid.

                'null!' basically means that no ChemicalEntity has been resolved.

                Array.Empty<ChemicalEntityCandidate>() says that there are no candidate
                ChemicalEntity objects to return.

                'new[] { ... }' is there to create a string array that contains an explanatory message.                
                */
                return new ChemicalEntityResolutionResult(ResolutionStatus.InvalidInput, null!, Array.Empty<ChemicalEntityCandidate>(), new[]
                {
                    "The chemical resolution request cannot be null."
                });
            }

            /*
            The following switch statement examines the InputKind property of the
            ChemicalResolutionRequest.

            request.InputKind is a ChemicalInputKind enum value.

            Each 'case' represents one possible type of chemical input and therefore
            determines which resolution path should be followed.
            */
            switch (request.InputKind)
            {
                
                /*
                The following case executes when the supplied chemical input has been
                identified as a chemical formula.
                */                
                case ChemicalInputKind.Formula:
                    
                    /*
                    Formula-based resolution requires a parsed ChemicalFormula object.

                    Therefore, before calling ResolveByFormula(), the resolver checks
                    whether request.ParsedFormula is null.
                    */
                    if(request.ParsedFormula == null)
                    {   

                        /*
                        The request says that the input is a Formula, but no parsed
                        ChemicalFormula was supplied.

                        Therefore, this request does not contain the information required
                        for formula-based resolution and is returned as InvalidInput.
                        */
                        return new ChemicalEntityResolutionResult(ResolutionStatus.InvalidInput, null!, Array.Empty<ChemicalEntityCandidate>(), new[]
                        {
                            "A formula resolution request requires a parsed formula."
                        });
                    }

                    /*
                    At this point ParsedFormula is available.

                    The actual formula-based lookup is delegated to the private
                    ResolveByFormula() helper method.

                    Because the result of ResolveByFormula() is returned directly,
                    execution of Resolve() ends here for Formula input.
                    */                    
                    return ResolveByFormula(request.ParsedFormula);

                /*
                The following case executes when the supplied chemical input has been
                identified as a chemical name.

                For this resolution path, the resolver expects a recognized
                ChemicalIdentifier to already be available.
                */
                case ChemicalInputKind.Name:

                    /*
                    Before attempting identifier-based resolution, check whether
                    request.RecognizedIdentifier is null.

                    Without a recognized identifier, the resolver does not have the
                    ChemicalIdentifier required for this resolution path.
                    */
                    if(request.RecognizedIdentifier == null ) 
                    {
                        /*
                        Because the required ChemicalIdentifier is missing, return an
                        InvalidInput result.

                        No resolved entity or candidates are available.
                        */
                        return new ChemicalEntityResolutionResult(ResolutionStatus.InvalidInput, null!, Array.Empty<ChemicalEntityCandidate>(), new[]
                        {
                            "The request does not contain a recognized chemical identifier."
                        });
                    }
                    /*
                    The request contains a recognized ChemicalIdentifier.

                    Delegate the identifier-based resolution process to
                    ResolveByIdentifier() and return the result.
                    */
                    return ResolveByIdentifier(request.RecognizedIdentifier);

                /*
                The following case executes when the supplied input is a structure image.

                ChemicalEntityResolver does not perform structure-image recognition itself.

                Therefore, this input kind is currently reported as Unsupported by this
                particular resolver.
                */
                case ChemicalInputKind.StructureImage:
                    return new ChemicalEntityResolutionResult(ResolutionStatus.Unsupported, null!, Array.Empty<ChemicalEntityCandidate>(), new[]
                        {
                            "Structure-image resolution is not not supported by this resolver."
                        });

                /*
                'default' handles any ChemicalInputKind value that was not explicitly
                handled by the cases above.

                This provides a fallback result rather than allowing an unknown or future
                input kind to proceed through an incorrect resolution path.
                */
                default:
                    return new ChemicalEntityResolutionResult(ResolutionStatus.Unsupported, null!, Array.Empty<ChemicalEntityCandidate>(), new[]
                        {
                        "The supplied chemical input kind is not supported."
                        });
            }
        }

        /*
        ResolveByFormula() is a private helper method responsible specifically for
        formula-based chemical-entity resolution.

        This method is an internal implementation detail of ChemicalEntityResolver and 
        cannot be called directly from outside this class.
        
        The method receives a ChemicalFormula object.

        It then asks the IChemicalEntityRepository to find ChemicalEntity objects
        matching that formula.

        ResolveByFormula() does not itself decide whether these results represent
        NotFound, Resolved, or Ambiguous.

        Instead, it passes the returned collection to BuildResult(), which contains
        the common result-building logic.        
        */
        private ChemicalEntityResolutionResult ResolveByFormula(ChemicalFormula formula)
        {
            /*
            FindByFormula() searches the chemical-entity repository using the supplied
            ChemicalFormula.
            The returned value is stored as IReadOnlyCollection<ChemicalEntity>
            Therefore, 'entities' represents a collection of ChemicalEntity objects
            that matched the supplied formula.
            */            
            IReadOnlyCollection<ChemicalEntity> entities = _entityRepository.FindByFormula(formula);

            /*
            Pass the matching entities to BuildResult().
            null is supplied for matchedIdentifier because this resolution path was
            based upon a ChemicalFormula rather than a matched ChemicalIdentifier.
            */
            return BuildResult(entities, null);
        }
        
        /*
        ResolveByIdentifier() is a private helper method responsible specifically
        for identifier-based chemical-entity resolution.

        Unlike formula-based resolution, the supplied ChemicalIdentifier is first
        normalized before the repository search is performed.

        The flow will be:
        ChemicalIdentifier -> _identifierNormalizer.Normalize() -> normalized ChemicalIdentifier ->
        _entityRepository.FindByIdentifer() -> Matching ChemicalEntity objects -> BuildResult()
        */
        private ChemicalEntityResolutionResult ResolveByIdentifier(ChemicalIdentifier identifier)
        {
            
            /*
            Asks the IChemicalIdentifierNormalizer to normalize the supplied identifier.
            The returned normalized ChemicalIdentifier is then stored inside the local 
            variable normalizedIdentifier.
            A local variable exists only within the method/block in which it is declared.
            */
            ChemicalIdentifier normalizedIdentifier = _identifierNormalizer.Normalize(identifier);

            /*
            Search the chemical-entity repository using the normalized identifier.
            The returned collection contains the ChemicalEntity objects that matched
            that normalized ChemicalIdentifier.
            */            
            IReadOnlyCollection<ChemicalEntity> entities = _entityRepository.FindByIdentifier(normalizedIdentifier);
            
            /*
            Build the final ChemicalEntityResolutionResult from the entities returned
            by the repository.

            Unlike the formula path, normalizedIdentifier is also supplied because
            this is the identifier through which these ChemicalEntity objects matched.
            */            
            return BuildResult(entities, normalizedIdentifier);
        }

        /*
        BuildResult() is a private helper method that converts the collection of
        ChemicalEntity objects returned by the repository into a
        ChemicalEntityResolutionResult.

        Both formula-based and identifier-based resolution eventually arrive here.

        This avoids duplicating the same result-building logic inside both
        ResolveByFormula() and ResolveByIdentifier().
        
        'entities' are the ChemicalEntity objects returned by the repository and matchedIdentifier
        is The ChemicalIdentifier responsible for the match when identifier-based resolution was performed
        Both of these are recieved by the following method. And as matchedIdentifier is nullable to contain 
        either a ChemicalIdentifier object or null.

        Formula-based resolution passes null because that lookup was performed
        using a ChemicalFormula rather than a ChemicalIdentifier.

        And then finally the number of matching entities determines the ResolutionStatus
        */
        private ChemicalEntityResolutionResult BuildResult(IReadOnlyCollection<ChemicalEntity> entities, ChemicalIdentifier? matchedIdentifier) 
        {
            // First determine whether the repository returned zero matching entities
            if (entities.Count == 0)
            {
                /*
                If no ChemicalEntity corresponding to the supplied formula or identifier is found
                then 'NotFound' result should be returned.
                Therefore, there is no ResolvedEntity and there are no candidate objects.
                */
                return new ChemicalEntityResolutionResult(ResolutionStatus.NotFound, null!, Array.Empty<ChemicalEntityCandidate>(), new[]
                {
                    "No matching chemical entity was found."
                });
            }

            /*
            This list will be used to collect ChemicalEntityCandidate objects representing
            the ChemicalEntity objects returned by the repository.
            */
            List<ChemicalEntityCandidate> candidates = new List<ChemicalEntityCandidate>();

            /*
            The foreach loop visits each ChemicalEntity contained inside 'entities'
            one at a time.

            During each iteration, the current ChemicalEntity is temporarily represented
            by the local variable named entity.
            */
            foreach(ChemicalEntity entity in entities)
            {
                /*
                Checks whether this resolution path has a matched ChemicalIdentifier.
                Identifier-based resolution will supply the normalized identifier.
                Formula-based resolution supplies null.
                Therefore, this condition prevents a ChemicalEntityCandidate requiring
                a matched identifier from being created when no identifier exists.
                */                
                if(matchedIdentifier != null)
                {
                    /*
                    Creates a new ChemicalEntityCandidate containing:
                    (i)  The current ChemicalEntity.
                    (ii) The ChemicalIdentifier through which the entity was matched.

                    Add() then inserts that newly created candidate into the candidates list.
                    */                    
                    candidates.Add(new ChemicalEntityCandidate(entity, matchedIdentifier));
                }
            }

            /*
            After candidate construction, this if-statement determines whether exactly one ChemicalEntity
            was returned by the repository or not.
            Exactly one because that means the resolution is unambiguous.
            */
            if(entities.Count == 1)
            {

                /*
                entities is an IReadOnlyCollection and is not indexed here.

                First() is a LINQ method that returns the first element of a sequence.

                Because entities.Count has already been verified to equal 1, there is
                exactly one ChemicalEntity available.

                That entity is stored inside the local variable resolvedEntity.
                */
                ChemicalEntity resolvedEntity = entities.First();

                /*
                Returns a successful Resolved result.

                resolvedEntity contains the single ChemicalEntity that matched.

                candidates contains any candidate information created above.

                Array.Empty<string>() is used because this successful result does not
                currently require any additional textual messages.
                */
                return new ChemicalEntityResolutionResult(ResolutionStatus.Resolved, resolvedEntity, candidates, Array.Empty<string>());
            }
            
            /*
            When the execution reaches the point where the count (entities.Count) is greater than 1 then, 
            it means that more than one ChemicalEntity matched the supplied input.

            The resolver therefore cannot uniquely determine which ChemicalEntity was intended, so the result 
            is Ambiguous.

            No single ResolvedEntity is supplied because choosing one of the matching entities here would incorrectly 
            treat an ambiguous result as resolved.

            Instead, the candidate collection is returned so that the possible matches can be represented.
            */
            return new ChemicalEntityResolutionResult(ResolutionStatus.Ambiguous, null!, candidates, new[]
            {
                "Multiple chemical entities matched the supplied input."
            });
        }
    }
}