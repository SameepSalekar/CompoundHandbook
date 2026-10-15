/*
The Compound Handbook needs to be able to generate a chemical formula from the
structural information contained inside a molecular graph.

A MolecularGraph represents the structure of a molecule using Atom objects and
Bond objects.

Because the MolecularGraph contains the atoms that make up the molecular
structure, the elements represented by those atoms can be examined and counted
to determine the molecular formula of that structure.

For example, if a MolecularGraph contains two hydrogen atoms and one oxygen atom,
the molecular formula generated from that graph would represent H2O.

However, I do not want other parts of the Compound Handbook to depend directly
upon one particular class that performs molecular-formula generation.

Instead, I want the molecular-formula-generation operation to be represented
through its own contract.

This is why IMolecularFormulaGenerator is being created.

IMolecularFormulaGenerator defines the common contract that a molecular-formula
generator inside the Compound Handbook must follow.

Any class that implements IMolecularFormulaGenerator must provide a Generate()
method that receives a MolecularGraph and returns a ChemicalFormula.

The interface itself does not define the actual steps used to examine the
MolecularGraph, count the elements, and construct the resulting ChemicalFormula.

Those steps will instead be provided by a class that implements
IMolecularFormulaGenerator.

This allows other parts of the Compound Handbook to depend upon the
molecular-formula-generation contract rather than depending directly upon one
particular implementation of the generator.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.Calculations
{
    /*
    The following IMolecularFormulaGenerator is an interface.

    An interface defines a contract describing the operations that an implementing
    class must provide.

    The 'I' at the beginning of IMolecularFormulaGenerator follows the common C#
    naming convention of beginning interface names with the letter 'I'.

    IMolecularFormulaGenerator defines the operation of generating a ChemicalFormula
    from a MolecularGraph.

    The method inside this interface contains a method declaration but does not
    contain a method body.

    Therefore, this interface specifies that molecular-formula generation must be
    available, but it does not specify exactly how the molecular formula is generated.

    It will be the responsibility of a class that implements
    IMolecularFormulaGenerator to provide the actual method body and the
    formula-generation logic.
    */
    public interface IMolecularFormulaGenerator 
    {
        /*
        The following Generate() method represents the operation that a
        molecular-formula generator must perform.

        MolecularGraph graph is the parameter representing the molecular structure
        from which the ChemicalFormula needs to be generated.

        MolecularGraph is a class itself, but is being used as the datatype of
        the graph parameter.

        The MolecularGraph object contains the Atom objects and Bond objects that
        describe the molecular structure.

        The atoms contained inside the MolecularGraph can therefore be examined
        to determine which chemical elements are present and how many atoms of
        each element occur in the molecular structure.

        ChemicalFormula is the return datatype of this method.

        Therefore, after Generate() processes the supplied MolecularGraph, it
        returns a ChemicalFormula representing the elemental composition obtained
        from that molecular structure.

        The returned ChemicalFormula can contain information such as the original
        formula text, the FormulaKind, and the collection of ElementCount objects
        representing the elements and their corresponding counts.

        Because this method is declared inside an interface without an
        implementation, a class that implements IMolecularFormulaGenerator must
        provide the actual implementation of Generate().
        */        
        ChemicalFormula Generate(MolecularGraph graph);
    }
}