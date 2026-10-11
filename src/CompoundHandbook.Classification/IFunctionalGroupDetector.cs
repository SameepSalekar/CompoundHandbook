/*
The Compound Handbook needs to identify functional groups that are present within
the molecular structure of a chemical entity.

A functional group is a particular atom or group of atoms whose structural arrangement
is associated with characteristic chemical behavior.

For example, recognizing functional groups can help the Compound Handbook describe
important structural features of a molecule and provide information that is more
chemically meaningful than simply listing the elements present in the molecule.

The molecular structure that needs to be examined is represented by MolecularGraph.

MolecularGraph contains the atoms and bonds that describe how the atoms of a molecule
are connected.

Functional-group detection therefore involves examining this molecular graph for
structural arrangements corresponding to recognized functional groups.

When a functional group is detected, the Compound Handbook needs to know:
(i) The name of the functional group that was detected.
(ii) The identifiers of the atoms that participated in that particular match.

This information is represented by FunctionalGroupMatch.

Because one molecular structure can contain multiple functional groups, functional-group
detection can produce multiple FunctionalGroupMatch objects.

This is why IFunctionalGroupDetector is being created.

IFunctionalGroupDetector defines the common contract for detecting functional groups
within a MolecularGraph.

Any class that implements IFunctionalGroupDetector must provide a Detect() method that
receives a MolecularGraph and returns a collection of FunctionalGroupMatch objects.

The IFunctionalGroupDetector itself does not contain the actual functional-group
detection logic.

Instead, the actual detection logic will be contained inside a class that implements
this interface.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.Classification
{
    /*
    The following interface defines the common contract for detecting functional groups
    within a MolecularGraph.

    An interface defines the members that an implementing class is required to provide.

    IFunctionalGroupDetector does not perform the functional-group detection itself.

    Instead, a class that implements this interface will contain the actual logic used
    to examine a molecular structure and identify recognized functional groups.

    The 'I' at the beginning of IFunctionalGroupDetector follows the common C# naming
    convention of beginning interface names with the letter 'I'.
    */
    public interface IFunctionalGroupDetector
    {
        /*
        The following Detect() method represents the operation that a functional-group
        detector must perform.

        MolecularGraph graph is the parameter represents the molecular structure that needs to 
        be examined for functional groups.

        MolecularGraph represents a molecule using atoms and the bonds connecting those atoms.

        This structural information is important because functional groups are identified
        from arrangements of atoms and bonds rather than merely from the elemental
        composition of a chemical substance.

        IReadOnlyCollection<FunctionalGroupMatch> is the return type of the method.

        IReadOnlyCollection<T> is a .NET generic interface that represents a collection
        whose elements can be accessed but cannot be added or removed through this
        interface.

        FunctionalGroupMatch is a class, but it is being used as the datatype of the
        objects contained inside the returned collection.

        Therefore, IReadOnlyCollection<FunctionalGroupMatch> represents a read-only
        collection containing the functional-group matches detected within the supplied
        MolecularGraph.

        A collection is returned because a molecular structure may contain more than
        one functional-group match.

        Each FunctionalGroupMatch identifies the name of a detected functional group
        and the AtomIds associated with that particular match.

        If no recognized functional groups are detected, the implementation can return
        an empty collection rather than requiring a functional-group match to exist.

        Because this method is declared inside an interface without an implementation,
        a class that implements IFunctionalGroupDetector must provide the actual
        implementation of Detect().
        */        
        IReadOnlyCollection<FunctionalGroupMatch> Detect(MolecularGraph graph);
    }
}