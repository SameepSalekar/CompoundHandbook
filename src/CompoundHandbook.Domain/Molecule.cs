/*
Now, this is the category of the ChemicalEntity that I originally imagined 
when I first time came up with the Compound Handbook project.

When students begin learning chemistry, after learning the basic ideas of atoms and the periodic
table, they are commonly introduced to molecules and different ways of representing molecular
structures.

This includes representations:
(i)   Molecular formulas
(ii)  Lewis-dot structures
(iii) Structural formulas
(iv)  Skeletal structures
(v)   Three-dimensional molecular geometries

A molecule (in a general sense) is a discrete group of atoms that are chemically bonded together, primarily through
covalent bonds.

In a covalent bond, atoms share electrons with each other rather than completely transferring
electrons as they would in an ionic interaction.

This makes a molecule fundamentally different from the other solid-state ChemicalEntity categories
such as IonicSolid, NetworkCovalentSolid, and Metal.

An ionic solid consists of an extended ionic lattice.

A network covalent solid consists of an extended network of covalently bonded atoms.

A metallic solid consists of an extended metallic structure involving delocalized electrons.

A molecule, however, has a defined group of atoms belonging to one discrete molecular unit.

When a molecular substance exists in a large quantity, the sample can therefore contain an enormous
number of these individual discrete molecules.

The individual molecules may interact with neighboring molecules through intermolecular forces,
such as London dispersion forces, dipole-dipole interactions, or hydrogen bonding where applicable,
rather than becoming one continuous covalently bonded structure.

Therefore, I have created Molecule as a separate ChemicalEntity category so that when the user enters
a molecular substance, the Compound Handbook can recognize it as a discrete molecular entity and
handle its molecular representations appropriately
*/

/*
The following Molecule class represents a specific type of ChemicalEntity whose chemical entity
is a discrete molecule.

This class inherits from the ChemicalEntity base class.
Molecule will receive the common properties that were defined inside ChemicalEntity.

This will allow a Molecule object to contain the same basic identifying information as every other
ChemicalEntity while still allowing the Compound Handbook to recognize it as a specific molecular
chemical-entity type.

The constructor in here has a 'public' access modifier, therefore a Molecule object can be directly
created from outside of the class.

The Molecule constructor receives the same three pieces of information required by ChemicalEntity.

The base(...) call then passes these 3 arguments to the ChemicalEntity constructor, which will
initialize the inherited properties.
*/
namespace CompoundHandbook.Domain
{
    // Molecule inherits from the ChemicalEntity abstract base class
    public class Molecule : ChemicalEntity
    {
        // The following constructor will be called whenever a new Molecule object gets created.
        /*
        The arguments will be received by the Molecule constructor and are passed upwards to the
        ChemicalEntity constructor, which is being called by base(...).
        */
        public Molecule(string id, string displayName, IReadOnlyCollection<ChemicalIdentifier> identifiers) : base(id, displayName, identifiers)
        {
            /*
            The body of the Molecule constructor is empty because all three properties
            are initialized by the ChemicalEntity constructor.
            */
        }
    }
}