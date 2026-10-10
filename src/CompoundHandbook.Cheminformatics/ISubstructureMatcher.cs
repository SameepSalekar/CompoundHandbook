/*
Substructure matching is the process of determining whether a smaller molecular structure or
structural pattern occurs inside a larger molecular structure.

Inside the Compound Handbook, molecular structures are represented using MolecularGraph objects.

A MolecularGraph represents atoms as nodes or vertices and bonds as the connections or edges
between those atoms. Because both the molecule being searched and the structural pattern being
searched for can be represented as molecular graphs, substructure matching can be treated as a
graph-matching problem.

For example, a structural pattern representing a particular functional group could be searched
for inside the MolecularGraph of a larger molecule.

The larger MolecularGraph contains the complete molecular structure being searched.

The smaller MolecularGraph represents the structural pattern whose occurrence is being searched for.

If the pattern occurs inside the larger molecular graph, the matching atoms can be represented
using a SubstructureMatch object.

A molecule can contain the same structural pattern more than once. Therefore, the result of a
substructure search is represented as a collection of SubstructureMatch objects rather than as
only one SubstructureMatch object.

The Compound Handbook also needs different parts of the program to be able to request
substructure matching without depending directly upon one particular implementation of the
matching algorithm.

This is why ISubstructureMatcher is being created.

ISubstructureMatcher defines a common contract for searching a MolecularGraph for occurrences
of another MolecularGraph that represents the structural pattern.

The actual algorithm used to perform the graph matching will be provided by a class that
implements this interface.

This separation will also allow other parts of the Compound Handbook, such as functional-group
detection, to use the ISubstructureMatcher contract without needing to know the particular
algorithm used to perform the substructure search.
*/

/*
The following ISubstructureMatcher is an interface.

An interface defines a contract that describes what operations an implementing class must
provide without defining the actual implementation of those operations here.

The 'I' at the beginning of ISubstructureMatcher follows the common C# naming convention
of beginning interface names with the letter 'I'.

ISubstructureMatcher defines the operation that finds the the occurrences of a smaller 
MolecularGraph pattern inside another MolecularGraph.

The FindMatches method receives two MolecularGraph objects:
(i)  graph   : The molecular graph that will be searched.
(ii) pattern : The molecular graph representing the structural pattern being searched for.

The method returns an IReadOnlyCollection<SubstructureMatch>.

IReadOnlyCollection<T> is a .NET generic interface that represents a collection whose elements
can be accessed but cannot be added or removed through this interface.

The <SubstructureMatch> portion specifies that the collection contains SubstructureMatch objects.

Each SubstructureMatch object identifies the Atom Id values associated with one particular
occurrence of the requested structural pattern.

This interface only declares the substructure-matching operation. The actual process used to
compare the molecular graphs and locate matching substructures will be defined by a class that
implements ISubstructureMatcher.
*/
using CompoundHandbook.Domain;

namespace CompoundHandbook.Cheminformatics
{
    /*
    The following interface defines the operation that must be provided by a substructure-matching
    implementation used by the Compound Handbook.

    The 'public' access modifier allows this interface to be accessed from outside of the
    CompoundHandbook.Cheminformatics namespace.
    */
    public interface ISubstructureMatcher
    {
        /*
        The following method searches the supplied molecular graph for occurrences of the supplied
        molecular-graph pattern.

        The first parameter, graph, has the datatype MolecularGraph and represents the larger
        molecular structure that will be searched.

        The second parameter, pattern, also has the datatype MolecularGraph and represents the
        smaller structural pattern being searched for.

        The return datatype is IReadOnlyCollection<SubstructureMatch>.

        Therefore, when this method is called, the substructure matcher is expected to return a
        read-only collection containing the SubstructureMatch objects that represent the detected
        occurrences of the pattern.

        This interface only declares the operation. The actual algorithm used to compare the
        MolecularGraph objects and determine the matching atoms will be defined by the class
        that implements ISubstructureMatcher.
        */        
        IReadOnlyCollection<SubstructureMatch> FindMatches(MolecularGraph graph, MolecularGraph pattern);
    }
}