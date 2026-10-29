/*
A chemical structure can be represented in different output formats depending upon how the
Compound Handbook needs to present the generated structural information.

For example, some chemical-structure representations can be expressed using text, while other
representations need to be displayed graphically.

A textual representation stores the generated structure as text that can be directly displayed
or processed by the Compound Handbook.

A graphical representation requires information that describes how the chemical structure
should be visually drawn.

For the Structure Generation system, SVG is being used as one of these graphical output formats.

SVG stands for Scalable Vector Graphics. It is a text-based vector-graphics format that can
describe graphical elements such as lines, paths, shapes, and text.

This makes SVG useful for displaying chemical structures because bonds can be represented using
lines and atoms or other chemical information can be positioned as graphical or textual elements.

Therefore, StructureRepresentationKind is being created so that the Compound Handbook can
distinguish between a structure representation that contains ordinary textual output and one
that contains an SVG graphical representation.
*/

/*
The following StructureRepresentationKind is an enumeration.

An enumeration is a value type that defines a fixed set of named constants.

I do not want the different structure-representation formats being represented using arbitrary
strings. Instead, I want the Compound Handbook to restrict the representation format to one of
the predefined values.

This is why I decided to create this enum.

StructureRepresentationKind is therefore being created as its own datatype.

A variable or property whose datatype is StructureRepresentationKind can use one of the named
values defined inside this enumeration.
*/

namespace CompoundHandbook.StructureGeneration
{
    /*
    StructureRepresentationKind is the datatype that is being created here.
    The values defined inside this enumeration identify the format in which a generated
    chemical-structure representation is stored.
    */
    public enum StructureRepresentationKind
    {
        // Represents a chemical-structure representation that is stored as text.
        Text,
        /*
        The Text value is used when the generated chemical-structure representation can be
        expressed using textual information.

        A structure representation using this kind can therefore contain text that can be
        directly stored, displayed, or otherwise processed by the Compound Handbook.
        */


        // Represents a chemical-structure representation that is stored as SVG graphical markup.
        Svg
        /*
        The Svg value is used when the generated chemical-structure representation is intended
        to be displayed graphically using Scalable Vector Graphics.

        SVG markup can describe the graphical components required for displaying a chemical
        structure, including lines representing bonds and positioned graphical or textual
        elements representing atoms.

        Because SVG is vector-based, the generated chemical-structure drawing can also be
        scaled without depending upon a fixed pixel resolution.
        */

    }
}