/*
A chemical structure does not always need to be represented using a graphical drawing.

Some chemical-structure representations can instead be expressed using text.

For example, a structure-generation component may produce a textual representation that
describes the chemical structure in a form that can be directly stored, displayed, or
processed as text by the Compound Handbook.

The actual textual information therefore needs an object that can store the generated
text while also identifying that the representation is a Text representation.

This is why TextStructureRepresentation is being created as a specific type of
ChemicalStructureRepresentation.

ChemicalStructureRepresentation provides the common Kind property that identifies the
format of a generated chemical-structure representation.

TextStructureRepresentation then provides the Text property that stores the actual textual
content of the representation.

Every TextStructureRepresentation object represents a chemical-structure representation
whose StructureRepresentationKind is Text.
*/

/*
The following TextStructureRepresentation class inherits from the
ChemicalStructureRepresentation abstract base class.

ChemicalStructureRepresentation contains the common Kind property used to identify what
type of chemical-structure representation an object contains.

TextStructureRepresentation then adds the Text property that stores the actual textual
content associated with this particular representation.

TextStructureRepresentation is declared using the 'sealed' keyword.

A sealed class cannot be inherited by another class.

Therefore, another class cannot derive from TextStructureRepresentation and create an
additional specialized type underneath it in the inheritance hierarchy.

Unlike the abstract ChemicalStructureRepresentation base class,
TextStructureRepresentation is a concrete class. Therefore,
TextStructureRepresentation objects can be directly created.

The constructor receives the textual representation as a string and passes
StructureRepresentationKind.Text to the constructor of the
ChemicalStructureRepresentation base class.

This means that every TextStructureRepresentation object automatically identifies itself
as a Text representation without requiring the caller to separately provide its
representation kind.
*/

namespace CompoundHandbook.StructureGeneration 
{
    /*
    The following class represents a chemical-structure representation that is 
    stored as textual information
    TextStructureRepresentation inherits the common Kind property from ChemicalStructureRepresentation.
    The 'sealed' keyword prevents another class from inheriting from TextStructureRepresentation.
    */
    public sealed class TextStructureRepresentation : ChemicalStructureRepresentation 
    {
        /*
        Read-only property that stores the actual textual content of the generated
        chemical-structure representation.
        The datatype here is string.
        Since this property contains only a 'getter' accessor, its value can be read
        from outside of the object but cannot be directly changed from outside of the
        class after the object has been constructed.
        */
        public string Text { get; }

        /*
        The following constructor will be called whenever a new
        TextStructureRepresentation object gets created.

        The constructor receives the textual representation through the 'text'
        parameter.

        The ': base(StructureRepresentationKind.Text)' portion calls the constructor
        of the ChemicalStructureRepresentation base class.

        StructureRepresentationKind.Text is passed to that base constructor so that
        the inherited Kind property will identify this object as a Text representation.

        Therefore, the caller only needs to provide the actual textual content.
        The representation kind does not need to be separately supplied because every
        TextStructureRepresentation object is always a Text representation.
        */
        public TextStructureRepresentation(string text) : base(StructureRepresentationKind.Text)
        {
            // Stores the textual representation supplied through the 'text' parameter
            // inside the Text property of this TextStructureRepresentation object.
            Text = text;
        }
    }
}