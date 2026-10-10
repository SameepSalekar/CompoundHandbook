/*
A chemical structure toolkit provides computational operations that can be used when working with
molecular structures.

Inside the Compound Handbook, the connectivity of a molecule is represented using a MolecularGraph.

The MolecularGraph describes which atoms are present and which bonds connect those atoms. However,
the MolecularGraph by itself does not specify where those atoms should be positioned when the
molecular structure is displayed visually in two dimensions.

For example, knowing that two carbon atoms are connected by a bond describes molecular connectivity,
but it does not specify the X and Y coordinates at which those atoms should appear in a two-dimensional
drawing.

The Compound Handbook therefore needs a way to generate a two-dimensional layout from the molecular
connectivity stored inside a MolecularGraph.

This two-dimensional layout is represented using a MolecularLayout2D object.

After the two-dimensional coordinates have been generated, the Compound Handbook also needs a way
to convert the molecular graph and its layout into a visual skeletal representation.

The skeletal representation used by this contract is an SVG representation.

SVG stands for Scalable Vector Graphics and provides a way of representing two-dimensional graphics
using text-based markup.

The generated SVG structure is represented inside the Compound Handbook using an
SvgStructureRepresentation object.

The Compound Handbook should not require the Core Chemistry code to depend directly upon one
particular external chemical toolkit or one particular implementation of these structure-processing
operations.

This is why IChemicalStructureToolkit is being created.

IChemicalStructureToolkit defines a common contract for the chemical-structure operations that
the Compound Handbook requires from a chemical structure toolkit.

The actual implementation of these operations can then be provided by a separate class that
implements this interface.

According to the architecture of the Compound Handbook, the Infrastructure layer can provide
a ChemicalToolkitAdapter that implements IChemicalStructureToolkit. This allows the
Cheminformatics and Structure Generation portions of the program to depend upon this contract
instead of depending directly upon the particular external toolkit being used.
*/

/*
The following IChemicalStructureToolkit is an interface.

An interface defines a contract that describes what operations an implementing class must
provide without defining the actual implementation of those operations here.

The 'I' at the beginning of IChemicalStructureToolkit follows the common C# naming convention
of beginning interface names with the letter 'I'.

IChemicalStructureToolkit defines two operations:
(i)  Generate two-dimensional coordinates for the atoms of a MolecularGraph.
(ii) Render a skeletal SVG representation using a MolecularGraph and its MolecularLayout2D.

The Generate2DCoordinates method receives a MolecularGraph and returns a MolecularLayout2D.

The RenderSkeletalSvg method receives both the MolecularGraph and its MolecularLayout2D and
returns an SvgStructureRepresentation.

This interface only declares these operations. It does not specify the particular algorithms
or external chemical toolkit that will be used to perform them.

A class that implements IChemicalStructureToolkit will provide the actual method bodies and
therefore determine how the two-dimensional coordinates are generated and how the skeletal
SVG representation is rendered.
*/

using CompoundHandbook.Domain;
using CompoundHandbook.StructureGeneration;

namespace CompoundHandbook.Cheminformatics
{
    /*
    The following interface defines the chemical-structure operations that must be provided by
    a chemical structure toolkit used by the Compound Handbook.

    The 'public' access modifier allows this interface to be accessed from outside of the
    CompoundHandbook.Cheminformatics namespace.

    The 'interface' keyword specifies that IChemicalStructureToolkit is an interface rather
    than a class.
    */    
    public interface IChemicalStructureToolkit
    {
        /*
        The following method is used to generate two-dimensional coordinates for the atoms
        contained inside a MolecularGraph.

        The graph parameter has the datatype MolecularGraph and represents the molecular
        structure whose atoms need to be positioned in two-dimensional space.

        The return datatype is MolecularLayout2D.

        MolecularLayout2D represents the generated two-dimensional layout of the molecular
        structure and contains the positions associated with the atoms.

        This interface only declares the operation. The actual process or algorithm used to
        determine the two-dimensional coordinates will be defined by the class that implements
        IChemicalStructureToolkit.
        */
        MolecularLayout2D Generate2DCoordinates(MolecularGraph graph);

        /*
        The following method is used to render a skeletal representation of a molecular
        structure as SVG.

        The graph parameter has the datatype MolecularGraph and provides the molecular
        connectivity that needs to be represented.

        The layout parameter has the datatype MolecularLayout2D and provides the
        two-dimensional positions used when drawing the molecular structure.

        The return datatype is SvgStructureRepresentation.

        Therefore, when this method is called with a MolecularGraph and its corresponding
        MolecularLayout2D, the chemical structure toolkit is expected to return an
        SvgStructureRepresentation containing the rendered skeletal structure.

        This interface only declares the operation. The actual process used to convert the
        molecular graph and its two-dimensional layout into the SVG representation will be
        defined by the class that implements IChemicalStructureToolkit.
        */
        SvgStructureRepresentation RenderSkeletalSvg(MolecularGraph graph, MolecularLayout2D layout);
    }
}