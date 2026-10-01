/*
I have made a separate Metal category because metallic bonding is fundamentally different from both
covalent bonding and ionic bonding.

A metallic solid cannot be accurately represented using a conventional skeletal structure or
molecular Lewis-dot structure.

In a covalent bond, electrons are shared between particular atoms, usually as localized electron pairs.

In an ionic solid, electrons are transferred between atoms, producing positively charged cations
and negatively charged anions that are held together by electrostatic attraction.

Metallic bonding is different from both of these.

In a metallic solid, the valence electrons are not localized between specific pairs of atoms.
Instead, the valence electrons become delocalized across the metallic lattice.

The metal atoms can therefore be viewed approximately as positively charged metal ion cores surrounded
by a mobile collection of delocalized valence electrons, commonly described as a "sea of electrons."

These delocalized electrons are able to move throughout the metallic structure rather than belonging
to one specific bond between two particular atoms.

Therefore, a conventional Lewis-dot structure or skeletal structure would not accurately describe
the bonding throughout a bulk metallic solid.

The metallic structure must instead be treated as an extended metallic lattice whose atoms are held
together through metallic bonding.

This is also important for alloys.

An alloy may contain more than one type of element arranged within the metallic structure, and simply
knowing the name or chemical composition may not be enough to completely describe how the atoms are
arranged throughout the material.

Therefore, I have created Metal as a separate ChemicalEntity category so that when the user enters
the name of a metal or an alloy, the Compound Handbook can recognize that the entity requires metallic
bonding and solid-state structural information rather than treating it as a discrete molecule.
*/

/*
The following Metal class represents a specific type of ChemicalEntity whose chemical entity
is a metal or metallic material.

This class inherits from the ChemicalEntity base class.
Metal will receive the common properties that were defined inside ChemicalEntity.

This will allow a Metal object to contain the same basic identifying information as every other
ChemicalEntity while still allowing the Compound Handbook to recognize it as a specific metallic
chemical-entity type.

The constructor in here has a 'public' access modifier, therefore a Metal object can be directly
created from outside of the class.

The Metal constructor receives the same three pieces of information required by ChemicalEntity.

The base(...) call then passes these 3 arguments to the ChemicalEntity constructor, which will
initialize the inherited properties.
*/
namespace CompoundHandbook.Domain
{
    // Metal inherits from the ChemicalEntity abstract base class
    public class Metal : ChemicalEntity
    {
        // The following constructor will be called whenever a new Metal object gets created.
        /*
        The arguments will be received by the Metal constructor and are passed upwards to the
        ChemicalEntity constructor, which is being called by base(...).
        */
        public Metal(string id, string displayName, IReadOnlyCollection<ChemicalIdentifier> identifiers) : base(id, displayName, identifiers)
        {
            /*
            The body of the Metal constructor is empty because all three properties
            are initialized by the ChemicalEntity constructor.
            */            
        }
    }
}