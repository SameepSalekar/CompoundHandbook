/*
A ChemicalResolutionRequest represents all of the information that can be supplied to the
chemical-entity resolution system when the Compound Handbook attempts to determine which
ChemicalEntity the user's chemical input refers to.

The user can provide different kinds of chemical input.

For example, the supplied input may represent:
(i)   A chemical formula.
(ii)  A chemical name.
(iii) A chemical structure image.

The original input by itself is not always enough for the Resolution system.

Earlier stages of the Compound Handbook may already have interpreted or processed some of
the supplied input before the chemical-entity resolution process begins.

For example, if the user entered a chemical formula, the Parsing system may have already
converted that formula into a ChemicalFormula object.

Similarly, if the input has already been recognized as a particular chemical identifier,
that ChemicalIdentifier information can also be supplied to the Resolution system.

ChemicalResolutionRequest therefore collects the information required by the chemical-entity
resolution process into one request object.

ChemicalResolutionRequest = InputText + InputKind + ParsedFormula + RecognizedIdentifier

The Resolution system can then receive one ChemicalResolutionRequest object rather than
requiring each piece of resolution information to be supplied separately.
*/

/*
The following ChemicalResolutionRequest class contains four read-only properties:
(i)   InputText             : Stores the original textual chemical input.
(ii)  InputKind             : Stores what kind of chemical input was supplied.
(iii) ParsedFormula         : Stores the ChemicalFormula produced when the input has been parsed as a chemical formula.
(iv)  RecognizedIdentifier  : Stores a chemical identifier that has already been recognized from the supplied input.

All four of these are read-only properties because they contain only a 'getter' accessor.

Therefore, these properties can be read from outside of the class, but they cannot be directly
changed from outside of the class after the ChemicalResolutionRequest object has been constructed.

The following class also contains a constructor that receives the InputText, InputKind,
ParsedFormula, and RecognizedIdentifier required to initialize a new ChemicalResolutionRequest object.
*/

using CompoundHandbook.Domain;
using CompoundHandbook.Parsing;

namespace CompoundHandbook.Resolution
{
    // The following class represents one request that will be supplied to the chemical-entity resolution system.
    public class ChemicalResolutionRequest 
    {
        // Read-only property that stores the original textual input supplied for chemical resolution. The datatype here is string.
        public string InputText { get; }

        /*
        Read-only property that stores the type of chemical input being represented.

        ChemicalInputKind is an enum itself, but is being used as the datatype of this property.
        The value here can be Formula, Name, or StructureImage.

        This allows the Resolution system to know how the supplied chemical input should be interpreted.
        */
        public ChemicalInputKind InputKind { get; }

        /*
        Read-only property that stores the parsed chemical formula associated with this resolution request.        
        
        ChemicalFormula is a class itself, but is being used as the datatype of this property.

        The property references a ChemicalFormula object containing the structured
        representation of a chemical formula that was obtained from the supplied input.

        This allows the Resolution system to use the already-parsed formula information rather
        than having to parse the original formula text again.
        */
        public ChemicalFormula ParsedFormula { get; }

        /*
        Read-only property that stores a chemical identifier that has already been recognized
        from the supplied chemical input.

        ChemicalIdentifer is a class itself, but is being used as the datatype of this property.

        The property references a ChemicalIdentifer object containing the type and
        value of the recognized chemical identifier.

        This recognized identifier can later be used by the Resolution system when searching
        for the corresponding ChemicalEntity.        
        */
        public ChemicalIdentifier RecognizedIdentifier { get; }

        /*
        The following constructor will be called whenever a new ChemicalResolutionRequest
        object gets created.

        The constructor receives the original input text, its ChemicalInputKind, the parsed
        ChemicalFormula, and the recognized ChemicalIdentifer as parameters.

        The supplied arguments are then assigned to their corresponding read-only properties
        of the ChemicalResolutionRequest object.
        */
        public ChemicalResolutionRequest(string inputText, ChemicalInputKind inputKind, ChemicalFormula parsedFormula, ChemicalIdentifier recognizedIdentifier) 
        {
            // Stores the supplied original chemical-input text in the InputText property.
            InputText = inputText;

            // Stores the supplied ChemicalInputKind value in the InputKind property.
            InputKind = inputKind;

            // Stores the supplied ChemicalFormula object in the ParsedFormula property.
            ParsedFormula = parsedFormula;

            // Stores the supplied ChemicalIdentifer object in the RecognizedIdentifier property.
            RecognizedIdentifier = recognizedIdentifier;
        }
    }
}