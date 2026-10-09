/*
A ChemicalEntityCandidate represents one possible ChemicalEntity that may correspond to the
chemical input being processed by the Resolution system.

During chemical-entity resolution, the Compound Handbook may not always be able to immediately
determine one unique ChemicalEntity from the supplied input.

For example, the supplied chemical input may match more than one ChemicalEntity stored inside
the available chemical-entity repository.

When this happens, the Resolution system needs a way to keep track of each possible
ChemicalEntity together with the particular ChemicalIdentifier that caused that entity
to be considered a match.

This is why, ChemicalEntityCandidate class is being created.

ChemicalEntityCandidate = Entity + MatchedIdentifier

(i)  Entity:            Represents the ChemicalEntity that is being considered as one possible match.
(ii) MatchedIdentifier: Represents the ChemicalIdentifier through which this particular ChemicalEntity matched the supplied chemical input.

Keeping both pieces of information together is useful because the Compound Handbook can know
not only which ChemicalEntity was found, but also which identifier associated with that
ChemicalEntity produced the match.

One or more ChemicalEntityCandidate objects can later be stored inside a
ChemicalEntityResolutionResult when the resolution process needs to return possible candidates.
*/

/*
The following ChemicalEntityCandidate class contains two read-only properties because both of them contain
only a 'getter' accessor.

Therefore, these properties can be read from outside of the class, but they cannot be directly
changed from outside of the class after the ChemicalEntityCandidate object has been constructed.

The following class also contains a constructor that receives the ChemicalEntity and
ChemicalIdentifier required to initialize a new ChemicalEntityCandidate object.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.Resolution 
{   
    // The following class represents one possible ChemicalEntity match produced during the chemical-entity resolution process.
    public class ChemicalEntityCandidate
    {
        /*
        Read-only property that stores the ChemicalEntity being considered as a possible match.

        ChemicalEntity is an abstract class itself, but is being used as the datatype of this property.
        
        Entity property can reference an object belonging to a specific class that inherits from 
        ChemicalEntity, such as Molecule, IonicSolid, NetworkCovalentSolid, Metal, or Polymer.
        */
        public ChemicalEntity Entity { get; }

        /*
        Read-only property that stores the ChemicalIdentifier through which the ChemicalEntity
        was matched during the resolution process.

        ChemicalIdentifier is a class itself, but is being used as the datatype of this property.

        The ChemicalIdentifier object stores the identifier type and its corresponding value.

        This allows the Compound Handbook to preserve information about which particular
        identifier caused this ChemicalEntity to become a candidate.
        */
        public ChemicalIdentifier MatchedIdentifier { get; }

        /*
        The following constructor will be called whenever a new ChemicalEntityCandidate
        object gets created.

        The constructor receives a ChemicalEntity object and a ChemicalIdentifier object
        as parameters.

        The supplied arguments are then assigned to their corresponding read-only properties
        of the ChemicalEntityCandidate object.
        */
        public ChemicalEntityCandidate(ChemicalEntity entity, ChemicalIdentifier matchedIdentifier) 
        {
            // Stores the supplied ChemicalEntity object in the Entity property.
            Entity = entity;

            // Stores the supplied ChemicalIdentifier object in the MatchedIdentifier property.
            MatchedIdentifier = matchedIdentifier;
        }
    }
}