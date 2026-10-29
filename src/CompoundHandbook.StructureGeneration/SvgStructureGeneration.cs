/*
A graphical chemical structure needs a way of storing the information required to display
the generated drawing.

For the Compound Handbook, one graphical representation can be stored using SVG.

SVG stands for Scalable Vector Graphics.

SVG is a text-based vector-graphics format in which graphical information can be described
using markup. This makes it suitable for representing a chemical-structure drawing because
the graphical components of the structure can be described without storing the drawing as
a fixed-resolution raster image.

For example, an SVG chemical-structure representation can contain the graphical information
required to display atoms, bonds, and other visual components of the generated structure.

The actual SVG information is still stored as text. However, the purpose of that text is
to describe a graphical representation rather than to act as an ordinary textual
chemical-structure representation.

This is why SvgStructureGeneration is being created as a specific type of
ChemicalStructureRepresentation.

Every SvgStructureGeneration object represents a chemical-structure representation whose
StructureRepresentationKind is Svg.
*/

/*
The following SvgStructureGeneration class inherits from the
ChemicalStructureRepresentation abstract base class.

ChemicalStructureRepresentation contains the common Kind property used to identify what
type of chemical-structure representation an object contains.

SvgStructureGeneration then adds the Svg property that stores the actual SVG markup
associated with this particular representation.

SvgStructureGeneration is declared using the 'sealed' keyword.

A sealed class cannot be inherited by another class.

Therefore, another class cannot derive from SvgStructureGeneration and create an additional
specialized type underneath it in the inheritance hierarchy.

Unlike the abstract ChemicalStructureRepresentation base class, SvgStructureGeneration is
a concrete class. Therefore, SvgStructureGeneration objects can be directly created.

The constructor receives the SVG markup as a string and passes StructureRepresentationKind.Svg
to the constructor of the ChemicalStructureRepresentation base class.

This means that every SvgStructureGeneration object automatically identifies itself as an
SVG representation without requiring the caller to separately provide its representation kind.
*/

namespace CompoundHandbook.StructureGeneration
{
    /*
    The following class represents a chemical-structure representation stored using SVG markup.
    SvgStructureGeneration inherits the common Kind property from ChemicalStructureRepresentation.
    The 'sealed' keyword prevents another class from inheriting from SvgStructureGeneration.
    */
    public sealed class SvgStructureGeneration : ChemicalStructureRepresentation 
    {
        /*
        Read-only property that stores the SVG markup of the generated chemical-structure representation.
        The datatype here is string because SVG itself is represented using textual markup. Although the 
        datatype is string, the contents of this property are intended to describe a graphical chemical-structure 
        representation.
        */
        public string Svg { get; }

        /*
        The following constructor will be called whenever a new SvgStructureGeneration object gets created.
        The constructor receives the SVG markup through the 'svg' parameter.

        : base(StructureRepresentationKind.Svg) portion calls the constructor of the 
        ChemicalStructureRepresentation base class.

        StructureRepresentationKind.Svg is passed to that base constructor so that the inherited
        Kind property will identify this object as an SVG representation.

        Therefore, the caller only needs to provide the SVG markup. The representation kind does
        not need to be separately supplied because every SvgStructureGeneration object is always
        an SVG representation.
        */
        public SvgStructureGeneration(string svg) : base(StructureRepresentationKind.Svg)
        {
            // Stores the supplied SVG markup in the Svg property.
            Svg = svg;
        }
    }
}