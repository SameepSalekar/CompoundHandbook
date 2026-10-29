/*
A condensed chemical structure represents a molecular structure using a compact textual
form rather than displaying every atom and bond as a complete graphical drawing.

For the Compound Handbook to generate a condensed structure, it needs information about
the atoms in the molecule and how those atoms are connected.

Within the Compound Handbook, this underlying molecular information is represented by
MolecularGraph.

MolecularGraph contains the atoms belonging to the molecular structure and the bonds
connecting those atoms.

A condensed-structure generator can analyze this molecular connectivity and convert the
relevant structural information into a textual representation.

The resulting condensed structure is represented using TextStructureRepresentation.

The Compound Handbook needs a clearly defined contract for any component that performs
this operation.

This is why ICondensedStructureGenerator is being created.

ICondensedStructureGenerator defines what a condensed-structure generator must be able
to do without defining the particular algorithm that must be used to generate the
condensed textual representation.
*/

/*
The following ICondensedStructureGenerator is an interface.

An interface defines a contract that implementing classes agree to follow.

This interface does not contain the actual algorithm responsible for converting a
MolecularGraph into a condensed chemical-structure representation.

Instead, it declares the Generate method that an implementing class must provide.

This separates the definition of the required capability from the particular
implementation of that capability.

Therefore, other parts of the Compound Handbook can depend upon
ICondensedStructureGenerator rather than depending directly upon one particular
condensed-structure-generator implementation.

Any class that implements ICondensedStructureGenerator must provide a Generate method that:
(i)  Accepts a MolecularGraph as its input.
(ii) Returns a TextStructureRepresentation as its output.

The use of TextStructureRepresentation as the return type is important because the
generated condensed structure is represented as textual information.

This also allows the resulting object to participate in the common
ChemicalStructureRepresentation inheritance hierarchy while specifically identifying
the returned representation as a Text representation.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.StructureGeneration
{
    /*
    The following interface defines the contract for a component capable of generating
    a condensed textual representation from a molecular graph.

    The name begins with the letter 'I', which is the conventional C# naming pattern
    used for interfaces.

    ICondensedStructureGenerator does not specify HOW the condensed structure must
    be generated.

    It specifies WHAT operation a condensed-structure generator must provide.
    */
    public interface ICondensedStructureGenerator
    {
        /*
        The following Generate method defines the operation required from every class
        that implements ICondensedStructureGenerator.
        The method recieves MolecularGraph graph
        (Molecular graph is the datatype of the 'graph' parameter.)
        The supplied MolecularGraph contains the atoms and bonds describing the
        molecular structure from which the condensed representation will be generated.

        The return type of the method is TextStructureRepresentation
        Therefore, after the implementing class performs its condensed-structure-generation
        logic, it must return a TextStructureRepresentation object.

        TextStructureRepresentation is appropriate here because the generated condensed
        structure is being stored as textual information.

        TextStructureRepresentation itself inherits from
        ChemicalStructureRepresentation and automatically identifies its inherited
        Kind property as StructureRepresentationKind.Text.

        Because this is an interface method declaration, there is no method body here.

        The semicolon at the end of the declaration indicates that the interface is
        declaring the required method signature rather than providing the actual
        generation algorithm.

        A concrete class implementing ICondensedStructureGenerator will provide the
        actual body of the Generate method.
        */
        TextStructureRepresentation Generate(MolecularGraph graph);
    }
}