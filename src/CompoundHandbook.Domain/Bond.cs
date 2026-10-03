/*
A chemical bond represents a connection between two particular atoms inside a chemical structure.

A Bond object answers the following three important questions:
(i)   Which two atoms are connected?
(ii)  What type of bond connects them?
(iii) Which particular bond is this inside the molecular structure?

The two atoms are identified using their Atom Id values. The BondOrder property 
describes the type of bonding relationship between the two atoms.

The Bond class by itself does not contain the complete molecular structure. 
Instead, individual Atom objects and Bond objects will later be collected together inside a different class.
*/

/*
The following Bond class represents one particular bond inside a molecular structure.

Bond object = Id + Atom1Id + Atom2Id + Order

All four properties are read-only properties because they contain only a 'getter' accessor.

Therefore, their values can be read from outside of the class but cannot be directly changed
from outside of the class after the Bond object has been constructed.

The following class also contains a constructor that receives the Bond Id, the Id values of the
two connected atoms, and the BondOrder required to initialize a new Bond object.
*/

namespace CompoundHandbook.Domain 
{
    // The following class represents one particular bond inside a molecular structure.
    public class Bond 
    {
        /*
        Read-only property that stores the identifier of this particular Bond object.
        The datatype here is int.
        This Id identifies the bond itself and not any atoms
        */
        public int Id { get; }

        /*
        Read-only properties that store the Id of the first Atom and second Atom connected by this bond.
        The datatype here is int.
        The purpose of these properties is that they will identify particular atoms inside the Molecular Graph.
        */
        public int Atom1Id { get; }
        public int Atom2Id { get; }

        /*
        Read-only property that stores the type of the bond.
        BondOrder enum is the datatype of the Order property.
        */
        public BondOrder Order { get; }

        // The following constructor will be called whenever a new Bond object gets created.
        // The supplied arguments will be assigned to their corresponding read-only properties.
        public Bond (int id, int atom1Id, int atom2Id, BondOrder order) 
        {
            // Stores the supplied bond identifier in the Id property.
            Id = id;

            // Stores the Id of the first Atom connected by this bond.
            Atom1Id = atom1Id;

            // Stores the Id of the second Atom connected by this bond.
            Atom2Id = atom2Id;

            // Stores the supplied BondOrder in the Order property.
            Order = order;
        }
    }
}