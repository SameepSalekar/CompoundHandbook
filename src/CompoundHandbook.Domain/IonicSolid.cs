/*
I have made a separate IonicSolid category because an ionic solid cannot be accurately represented
as a discrete molecule using a conventional structural formula, skeletal structure, or molecular
Lewis-dot structure.

In a typical covalent molecule, atoms are connected through shared electron pairs. Therefore,
Lewis structures and structural formulas can represent which atoms are bonded to each other.

In an ionic solid, however, electrons are transferred between atoms, producing positively charged
cations and negatively charged anions

The cations and anions in an ionic bond is held together by electrostatic attraction rather than by
localized covalent bonds between specific pairs of atoms.

The ionic attraction is also non-directional, or approximately isotropic, meaning that an ion
electrostatically interacts with surrounding oppositely charged ions in multiple directions.

Therefore, an ionic solid is better represented as an extended three-dimensional ionic lattice
rather than as one discrete skeletal structure or molecular Lewis-dot structure.

A Lewis representation can still be useful for showing the individual ions, their charges,
and electron transfer, but it does not by itself represent the complete three-dimensional
crystal lattice of the ionic solid.
*/

/*
The following IonicSolid class represents a specific type of ChemicalEntity whose chemical entity
is an ionic solid.

This class inherits from the ChemicalEntity base class.
IonicSolid will receive the common properties that were defined inside ChemicalEntity.

This will allow an IonicSolid object to contain the same basic identifying information as every other
ChemicalEntity while still allowing the Compound Handbook to recognize it as a specific ionic-solid type.

The constructor in here has a 'public' access modifier, therefore an IonicSolid object can be directly
created from outside of the class.

The IonicSolid constructor receives the same three pieces of information required by ChemicalEntity.
The base(...) call then passes these 3 arguments to the ChemicalEntity constructor, which will initialize
the inherited properties
*/

namespace CompoundHandbook.Domain
{
    // IonicSolid inherits from the ChemicalEntity abstract base class
    public class IonicSolid : ChemicalEntity
    {
        // The following constructor will be called whenever a new IonicSolid object gets created.
        /*
        The arguments will be received by the IonicSolid constructor and are passed upwards to the
        ChemicalEntity constructor, which is being called by the base(...)
        */ 
        public IonicSolid(string id, string displayName, IReadOnlyCollection<ChemicalIdentifier> identifiers) : base(id, displayName, identifiers)
        {
           /*
            The body of the IonicSolid constructor is empty because all three properties
            are initialized by the ChemicalEntity constructor.
            */
        }
    }
}