/*
After the Compound Handbook determines how a molecular structure should be arranged in
two-dimensional space, that layout still needs to be converted into a representation
that can be displayed.

MolecularLayout2D contains the two-dimensional positioning information associated with
the molecular structure.

However, the layout itself is not the final graphical output.

It describes where the components of the molecular structure should be positioned, but
the Compound Handbook still needs a rendering step that converts this layout information
into graphical markup.

For skeletal structures, the Compound Handbook can use SVG as the graphical output format.

SVG stands for Scalable Vector Graphics.

SVG is a text-based vector-graphics format that can describe graphical components such
as lines, paths, shapes, and text.

This makes SVG suitable for displaying skeletal chemical structures because the
two-dimensional structural layout can be converted into graphical elements that can
be rendered visually.

The Compound Handbook needs a clearly defined contract for any component responsible for
performing this rendering operation.

This is why ISkeletalSvgRenderer is being created.

ISkeletalSvgRenderer defines what a skeletal SVG renderer must be able to do without
defining the particular rendering algorithm used to convert the molecular layout into
SVG.
*/

/*
The following ISkeletalSvgRenderer is an interface.

An interface defines a contract that implementing classes agree to follow.

This interface does not contain the actual rendering logic responsible for converting
a MolecularLayout2D into SVG.

Instead, it declares the Render method that an implementing class must provide.

This separates the definition of the required rendering capability from the particular
implementation of that capability.

Therefore, other parts of the Compound Handbook can depend upon ISkeletalSvgRenderer
rather than depending directly upon one specific SVG-rendering implementation.

Any class that implements ISkeletalSvgRenderer must provide a Render method that:
(i)  Accepts a MolecularLayout2D as its input.
(ii) Returns an SvgStructureRepresentation as its output.

This creates a separation between the layout stage and the rendering stage.

The layout stage determines WHERE the molecular components should appear.

The rendering stage determines HOW that layout is converted into the SVG representation
that can ultimately be displayed.
*/

namespace CompoundHandbook.StructureGeneration
{
    /*
    The following interface defines the contract for a component capable of rendering
    a two-dimensional molecular layout as an SVG skeletal-structure representation.

    The name begins with the letter 'I', which is the conventional C# naming pattern
    used for interfaces.

    ISkeletalSvgRenderer does not specify HOW the SVG markup must be generated.

    It specifies WHAT rendering operation an SVG skeletal renderer must provide.
    */
    public interface ISkeletalSvgRenderer
    {
        /*
        The following Render method defines the operation required from every class
        that implements ISkeletalSvgRenderer.

        The method receives MolecularLayout2D layout 
        MolecularLayout2D is the datatype of the 'layout' parameter.

        The supplied MolecularLayout2D contains the two-dimensional positioning
        information that the renderer needs in order to create the graphical
        representation.

        The return type of the method is SvgStructureRepresentation
        Therefore, after the implementing class performs its SVG-rendering logic,
        it must return an SvgStructureRepresentation object.

        The returned object represents the final SVG-based graphical output produced
        from the supplied two-dimensional molecular layout.

        This establishes an important separation of responsibilities:
        MolecularLayout2D describes WHERE the molecular structure has been positioned.
        ISkeletalSvgRenderer defines the capability responsible for converting that layout into graphical SVG output.
        SvgStructureRepresentation contains the resulting SVG representation.

        Because this is an interface method declaration, there is no method body here.

        The semicolon at the end of the declaration indicates that this interface is
        declaring the required method signature rather than providing the actual
        rendering implementation.

        A concrete class implementing ISkeletalSvgRenderer will provide the actual
        body of the Render method.
        */
        SvgStructureGeneration Render(MolecularLayout2D layout);
    }
}