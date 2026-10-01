/*
I have made a separate NetworkCovalentSolid category because although the bonds and structures
of a network covalent solid can be represented using Lewis-dot structures and structural
representations, the complete solid itself is not a discrete molecule.

In a typical covalent molecule, a specific and finite number of atoms are covalently bonded
together to form an individual molecular unit.

For example, H2O is a single discrete molecule that contains 2 hydrogen atoms and 1 oxygen atom.

A network covalent solid is different because its atoms are covalently bonded together throughout
an extended crystal lattice rather than existing as separate individual molecules.

For example, SiO2 in quartz does not mean that the crystal consists of separate SiO2 molecules.
Instead, the silicon and oxygen atoms are connected through a repeating three-dimensional network.

Therefore, representing a network covalent solid requires more information than simply knowing
its name or chemical formula.

To see its visual representation, we also need to know:
(i)   How the atoms are bonded and connected throughout the network.
(ii)  How the repeating structural units are arranged.
(iii) What type of crystal structure or network is being formed.
(iv)  How many repeating units need to be generated or displayed when constructing a finite representation of the otherwise extended crystal lattice.

A Lewis-dot structure can still describe the bonding and electron sharing around atoms, and
structural representations can describe connectivity, but a single molecular representation
does not by itself describe the complete extended crystal structure.

This is why NetworkCovalentSolid needs to be treated as a separate ChemicalEntity category so that
the Compound Handbook can later associate it with the additional structural and crystal information
required to properly represent a network covalent solid.
*/

/*
The following NetworkCovalentSolid class represents a specific type of ChemicalEntity whose chemical
entity is a network covalent solid.

This class inherits from the ChemicalEntity base class.
NetworkCovalentSolid will receive the common properties that were defined inside ChemicalEntity.

This will allow a NetworkCovalentSolid object to contain the same basic identifying information as
every other ChemicalEntity while still allowing the Compound Handbook to recognize it as a specific
network-covalent-solid type.

The constructor in here has a 'public' access modifier, therefore a NetworkCovalentSolid object can
be directly created from outside of the class.

The NetworkCovalentSolid constructor receives the same three pieces of information required by
ChemicalEntity.

The base(...) call then passes these 3 arguments to the ChemicalEntity constructor, which will
initialize the inherited properties.
*/
namespace CompoundHandbook.Domain
{
    // NetworkCovalentSolid inherits from the ChemicalEntity abstract base class
    public class NetworkCovalentSolid : ChemicalEntity
    {
        // The following constructor will be called whenever a new NetworkCovalentSolid object gets created.
        /*
        The arguments will be received by the NetworkCovalentSolid constructor and are passed upwards to the
        ChemicalEntity constructor, which is being called by base(...).
        */
        public NetworkCovalentSolid(string id, string displayName, IReadOnlyCollection<ChemicalIdentifier> identifiers) : base(id, displayName, identifiers)
        {
            /*
            The body of the NetworkCovalentSolid constructor is empty because all three properties
            are initialized by the ChemicalEntity constructor.
            */
        }
    }
}