/*
When the Compound Handbook examines the structure of a chemical entity, it may detect
functional groups within that structure.

A functional group is a particular atom or group of atoms whose structural arrangement
is associated with characteristic chemical behavior.

For example, a molecular structure may contain functional groups such as an alcohol,
carbonyl, carboxylic acid, amine, or other recognizable structural group.

Simply determining the name of a detected functional group is not always enough.

The Compound Handbook may also need to know which particular atoms in the molecular
structure formed the detected functional-group match.

For example, if a functional group is detected within a larger molecular structure,
the program needs a way to associate that detected group with the atoms that participated
in the structural match.

This is why FunctionalGroupMatch is being created.

A FunctionalGroupMatch object represents one detected functional-group match within
a chemical structure.

The FunctionalGroupMatch itself does not perform functional-group detection.

Instead, it acts as a container for the information describing a functional group that
has already been detected.

FunctionalGroupMatch = Name + AtomIds

(i) Name: Stores the name of the functional group that was detected.
(ii) AtomIds: Stores the identifiers of the atoms that participated in the detected functional-group match.

Both of these are read-only properties because they contain only a 'getter' accessor.

Therefore, these properties can be read from outside of the class, but they cannot be
directly changed from outside of the class after the FunctionalGroupMatch object has
been constructed.

The following class also contains a constructor that receives the functional-group name
and the collection of atom identifiers required to initialize a new FunctionalGroupMatch
object.
*/

namespace CompoundHandbook.Classification
{
    // The following class represents one detected functional-group match within a chemical structure.
    public class FunctionalGroupMatch
    {
        /*
        Read-only property that stores the name of the detected functional group.

        string is the C# datatype used to represent textual information.

        Therefore, the Name property can store a textual name identifying the
        functional group associated with this match.

        For example, the stored name could identify a detected functional group such
        as an alcohol, carbonyl, carboxylic acid, or amine group.

        The Name property describes what functional group was detected, while the
        AtomIds property identifies where that functional group was detected within
        the chemical structure.
        */
        public string Name { get; }

        /*
        Read-only property that stores the identifiers of the atoms participating in
        the detected functional-group match.

        IReadOnlyCollection<T> is a .NET generic interface that represents a collection
        whose elements can be accessed but cannot be added or removed through this
        interface.

        int is being used as the datatype of the values contained inside this collection.

        Therefore, IReadOnlyCollection<int> represents a read-only collection containing
        the integer identifiers of the atoms associated with this functional-group match.

        A collection is required because a functional group generally involves a
        structural arrangement containing one or more atoms rather than necessarily
        being represented by only one atom.

        These identifiers allow the Compound Handbook to connect the detected
        functional group back to the particular atoms in the molecular structure
        that produced the match.
        */
        public IReadOnlyCollection<int> AtomIds { get; }

        /*
        The following constructor will be called whenever a new FunctionalGroupMatch
        object gets created.

        The constructor receives:
        (i) The name of the detected functional group.
        (ii) The collection of atom identifiers associated with the detected functional-group match.

        The supplied arguments are then assigned to their corresponding read-only
        properties of the FunctionalGroupMatch object.
        */
        public FunctionalGroupMatch(string name, IReadOnlyCollection<int> atomIds)
        {
            // Stores the supplied functional-group name in the Name property.
            Name = name;

            // Stores the supplied collection of atom identifiers in the AtomIds property.
            AtomIds = atomIds;
        }
    }
}