/*
A substructure is a smaller structural pattern that exists inside a larger molecular structure.

Inside the Compound Handbook, molecular structures are represented using MolecularGraph objects,
where the atoms act as the nodes or vertices of the graph and the bonds act as the edges connecting
those atoms.

Substructure matching is the process of searching a molecular graph to determine whether a smaller
structural pattern occurs somewhere inside the larger molecular structure.

For example, a particular functional group can be represented as a structural pattern containing
specific atoms and bonds. A substructure matcher can search a molecule to determine whether that
pattern occurs inside the molecule.

If a matching substructure is found, the Compound Handbook needs a way to identify which particular
atoms of the larger molecular structure participated in that match.

This is why the SubstructureMatch class is being created.

The Atom Id values stored inside a SubstructureMatch object identify the atoms of the molecular
graph that belong to one particular detected substructure.

The SubstructureMatch class itself does not perform the process of searching for a substructure.
Instead, it represents the result of one successful substructure match.

According to the Cheminformatics architecture, an ISubstructureMatcher can return a collection of
SubstructureMatch objects because the same structural pattern may occur more than once inside a
molecular structure.
*/

/*
The following SubstructureMatch class represents one detected substructure match inside a
molecular graph.

SubstructureMatch object = Collection of Atom Ids

AtomIds stores the integer Id values of the atoms that participate in this particular
substructure match.

AtomIds is a read-only property because it contains only a 'getter' accessor.

Therefore, the AtomIds property can be read from outside of the class, but it cannot be directly
assigned a different collection from outside of the class after the SubstructureMatch object
has been constructed.

The datatype of AtomIds is IReadOnlyCollection<int>.

IReadOnlyCollection<T> is a .NET generic interface that represents a collection whose elements
can be accessed but cannot be added or removed through this interface.

In this particular class, those integers represent the Id values of the atoms participating
in the detected substructure.

The following class also contains a constructor that receives the collection of Atom Id values
required to initialize a new SubstructureMatch object.
*/

namespace CompoundHandbook.Cheminformatics
{
    // The following class represents one detected substructure match inside a molecular graph.
    public class SubstructureMatch
    {
        /*
        Read-only property that stores the Id values of the atoms participating in this
        particular substructure match.

        IReadOnlyCollection<int> is the datatype of this property.

        IReadOnlyCollection indicates that the elements of the collection can be accessed
        through this property without allowing elements to be added or removed through the
        IReadOnlyCollection interface.
        
        Each integer represents the Id of one Atom belonging to this particular
        substructure match        
        */        
        public IReadOnlyCollection<int> AtomIds { get; }

        /*
        The following constructor will be called whenever a new SubstructureMatch object
        gets created.

        The constructor receives an IReadOnlyCollection<int> containing the Id values of
        the atoms participating in the detected substructure.

        The supplied atomIds argument is then assigned to the corresponding AtomIds
        read-only property of the SubstructureMatch object.
        */
        public SubstructureMatch(IReadOnlyCollection<int> atomIds)
        {
            // Stores the supplied collection of Atom Id values in the AtomIds property.
            AtomIds = atomIds;
        }
    }
}