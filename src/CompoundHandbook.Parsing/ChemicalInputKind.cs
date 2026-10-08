/*
ChemicalInputKind is being created to identify the type of chemical information
that the user has supplied to the Compound Handbook.

The Compound Handbook is designed to accept more than one type of chemical input.
For example, a user may identify a chemical by typing its chemical formula,
typing its name, or providing an image of its chemical structure.

These different forms of input cannot all be processed in exactly the same way.

Knowing the type of input allows the Compound Handbook to determine which
processing path should be used for the supplied information.

ChemicalInputKind is therefore used to classify the form of the chemical input
before the appropriate parsing, resolution, or structure-recognition process
is performed.

An enum is appropriate here because the input can belong to one of a fixed
number of predefined categories.

An enumeration defines a set of named constant values. Instead of representing
the input type using arbitrary strings such as "Formula", "Name", or
"StructureImage", the program can use the strongly typed ChemicalInputKind
values defined below.

This reduces the possibility of spelling mistakes and makes the possible
chemical input types explicitly defined by the program.
*/

namespace CompoundHandbook.Parsing 
{
    /*
    ChemicalInputKind represents the different forms of chemical inputs
    supplied to the Compound Handbook.

    Each value represents a different route through which the program will
    identify/analyze a chemical.
    */    
    public enum ChemicalInputKind 
    {
        /*
        Formula indicates that the supplied input is a chemical formula.
        Formula input will be sent through the chemical-formula parsing process,
        where the text will be interpreted as elements and their corresponding
        element counts.
        */
        Formula,

        /*
        Name indicates that the supplied input is the name of a chemical.
        A chemical name will be resolved to a ChemicalEntity using chemical 
        identifiers or some other chemical data.
        */
        Name,

        /*
        StructureImage indicates that the supplied chemical information is
        represented by an image of a chemical structure.

        A structure image will be passed through the structure
        recognition process so that chemical information can first be extracted
        from the image and then used by the rest of the Compound Handbook.
        */
        StructureImage
    }
}