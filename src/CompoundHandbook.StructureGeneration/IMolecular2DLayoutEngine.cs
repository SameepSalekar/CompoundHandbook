/*
A MolecularGraph describes the chemical connectivity of a molecular structure.

It contains information about the atoms that belong to the molecular structure and the
bonds that connect those atoms.

However, molecular connectivity by itself does not specify where those atoms should be
placed when the molecule needs to be displayed as a two-dimensional structure.

For example, knowing that two atoms are connected by a bond tells the Compound Handbook
that those atoms are chemically connected, but it does not tell the Compound Handbook
where the first atom should appear on the screen or where the second atom should appear
relative to it.

A two-dimensional chemical-structure representation therefore requires an additional
layout step.

During this step, positions are assigned to the atoms of the MolecularGraph so that the
molecular structure can be arranged in two-dimensional space.

The resulting positioning information is represented by MolecularLayout2D
The Compound Handbook needs a clearly defined contract for any component responsible for
performing this layout operation.

This is why IMolecular2DLayoutEngine is being created.

IMolecular2DLayoutEngine defines what a molecular 2D layout engine must be able to do
without defining the particular algorithm that must be used to calculate the positions
of the atoms.
*/

/*
The following IMolecular2DLayoutEngine is an interface.

An interface defines a contract that implementing classes agree to follow.

This interface does not contain the actual algorithm responsible for determining the
two-dimensional positions of atoms.

Instead, it declares the GenerateLayout method that an implementing class must provide.

This separates the definition of the required layout capability from the particular
implementation of that capability.

Therefore, other parts of the Compound Handbook can depend upon
IMolecular2DLayoutEngine rather than depending directly upon one specific 2D-layout
implementation.

Any class that implements IMolecular2DLayoutEngine must provide a GenerateLayout method that:
(i)  Accepts a MolecularGraph as its input.
(ii) Returns a MolecularLayout2D as its output.

This means that the layout engine receives the chemical connectivity of the molecular
structure and produces the two-dimensional positioning information associated with that
structure.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.StructureGeneration
{
    /*
    The following interface defines the contract for a component capable of generating
    a two-dimensional layout for a molecular graph.

    The name begins with the letter 'I', which is the conventional C# naming pattern
    used for interfaces.

    IMolecular2DLayoutEngine does not specify HOW the two-dimensional coordinates must
    be calculated.

    It specifies WHAT operation a molecular 2D layout engine must provide.
    */
    public interface IMolecular2DLayoutEngine
    {
        /*
        The following GenerateLayout method defines the operation required from every
        class that implements IMolecular2DLayoutEngine.

        The method receives MolecularGraph graph 
        MolecularGraph is the datatype of the 'graph' parameter.

        The supplied MolecularGraph contains the atoms and bonds describing the
        connectivity of the molecular structure that needs to be arranged in
        two-dimensional space.

        The return type of the method is MolecularLayout2D
        Therefore, after the implementing class performs its layout-generation logic,
        it must return a MolecularLayout2D object.

        MolecularLayout2D represents the two-dimensional layout associated with the
        supplied molecular graph.

        The layout can contain the positional information that associates individual
        atoms with their calculated two-dimensional coordinates

        MolecularGraph tells the layout engine WHICH atoms exist and HOW they are connected

        MolecularLayout2D tells the rest of the Structure Generation system WHERE those atoms
        have been positioned in two-dimensional space.

        Because this is an interface method declaration, there is no method body here.

        The semicolon at the end of the declaration indicates that the interface is
        declaring the required method signature rather than providing the actual
        layout-generation algorithm.

        A concrete class implementing IMolecular2DLayoutEngine will provide the actual
        body of the GenerateLayout method.
        */
        MolecularLayout2D GenerateLayout(MolecularGraph graph);
    }
}