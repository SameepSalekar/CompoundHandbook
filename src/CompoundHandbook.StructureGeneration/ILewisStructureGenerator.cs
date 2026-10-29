/*
A Lewis structure needs to be generated from information describing the underlying
molecular structure.

Within the Compound Handbook, that underlying molecular structure is represented by
MolecularGraph.

MolecularGraph contains the atoms belonging to the molecular structure and the bonds
that connect those atoms.

The Structure Generation system can use this molecular information to construct the
internal model required for a Lewis structure.

The generated Lewis-structure model is represented by LewisStructureModel.

LewisStructureModel combines the MolecularGraph with the MolecularLayout2D that describes
how the atoms should be positioned in two-dimensional space.

The Compound Handbook needs a clearly defined contract for any component that performs
this operation.

This is why ILewisStructureGenerator is being created.

ILewisStructureGenerator defines what a Lewis-structure generator must be able to do
without defining the particular algorithm that must be used to perform the generation.
*/

/*
The following ILewisStructureGenerator is an interface.

An interface defines a contract that implementing classes agree to follow.

Unlike an ordinary class, this interface does not contain the implementation of the
Lewis-structure-generation algorithm.

Instead, it declares the Generate method that an implementing class must provide.

This separates the definition of the required capability from the particular
implementation of that capability.

Therefore, other parts of the Compound Handbook can depend upon
ILewisStructureGenerator rather than depending directly upon one specific
Lewis-structure-generator implementation.

Any class that implements ILewisStructureGenerator must provide a Generate method that:
(i)  Accepts a MolecularGraph as its input.
(ii) Returns a LewisStructureModel as its output.

This allows the Structure Generation system to work through the interface while the
actual generation logic remains inside whichever concrete class implements it.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.StructureGeneration
{
    /*
    The following interface defines the contract for a component capable of generating
    the internal model of a Lewis structure.

    The name begins with the letter 'I', which is the conventional C# naming pattern
    used for interfaces.

    ILewisStructureGenerator does not specify HOW the Lewis structure must be generated.

    It specifies WHAT operation a Lewis-structure generator must provide.
    */
    public interface ILewisStructureGenerator
    {
        /*
        The following Generate method defines the operation required from every class
        that implements ILewisStructureGenerator.

        The method receives the MolecularGraph graph
        MolecularGraph is the datatype of the 'graph' parameter.

        The supplied MolecularGraph contains the atoms and bonds that describe the
        molecular structure from which the Lewis-structure model will be generated.

        The return type of the method is LewisStructureModel
        Therefore, after the implementing class performs its Lewis-structure-generation
        logic, it must return a LewisStructureModel object.

        That LewisStructureModel can contain both the molecular graph and the
        two-dimensional layout associated with the generated Lewis structure.

        Because this is an interface method declaration, there is no method body here.

        The semicolon at the end of the declaration indicates that this interface is
        declaring the required method signature rather than providing the method's
        implementation.

        A concrete class implementing ILewisStructureGenerator will provide the actual
        body of the Generate method.
        */
        LewisStructureModel Generate(MolecularGraph graph);
    }
}