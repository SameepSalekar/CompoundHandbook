/*
ChemicalFormulaParser is being created to convert a chemical formula supplied
as text into a structured ChemicalFormula object that the rest of the Compound
Handbook can understand and work with.

ChemicalFormulaParser reads through the supplied formula from
left to right and separates it into element symbols and their corresponding
element counts.
*/

/*
The basic parsing process performed by ChemicalFormulaParser is:
Chemical Formula Text -> Read Element Symbol -> Verify Element using IElementRepository
-> Read Element Count -> Create ElementCount object -> Continue to Next Element

An ElementCount object will be created for every recognized element.

ElementCount objects are collected together and are eventually used
to create a ChemicalFormula object.

If the parser encounters a problem, a FormulaParseError object is created
instead. The collection of errors and the parsing result are then returned
inside a FormulaParseResult object.

Therefore, ChemicalFormulaParser attempts to convert formula text into the
structured chemical information used by the rest of the Compound Handbook.
*/

using CompoundHandbook.Domain;
using CompoundHandbook.DataContracts;

namespace CompoundHandbook.Parsing 
{
    /*
    ChemicalFormulaParser contains the logic responsible for parsing chemical
    formula text.

    This class needs access to IElementRepository because reading characters
    such as "C", "Na", or "Cl" from a string does not by itself provide the
    corresponding Element object.

    The parser will use IElementRepository to find the Element associated
    with the element symbol that was read from the formula.
    */
    public class ChemicalFormulaParser 
    {
        /*
        Private read-only field that stores the element repository used by
        ChemicalFormulaParser.

        IElementRepository is being used as the datatype rather than a specific
        repository implementation. Therefore, ChemicalFormulaParser only needs
        an object that follows the IElementRepository contract.

        This allows the parser to find an Element using its chemical symbol
        without needing to know where the element data is actually stored.

        private is used because this repository is an internal dependency of
        ChemicalFormulaParser.

        readonly means that after _elementRepository receives its value through
        the constructor, this field cannot normally be reassigned to another
        repository.
        */        
        private readonly IElementRepository _elementRepository;

        /*
        ChemicalFormulaParser requires an IElementRepository in order to
        find the Element objects represented by the symbols it discovers
        while parsing a formula.

        Instead of creating an element repository inside ChemicalFormulaParser,
        the required repository will be supplied to this constructor.

        elementRepository is the parameter that represents the repository that
        this ChemicalFormulaParser object will use while parsing chemical formulas.
        */
        public ChemicalFormulaParser(IElementRepository elementRepository)
        {
            // Stores the supplied element repository in the parser's private field.
            _elementRepository = elementRepository;
        }

        /*
        Parse is the main method responsible for converting the supplied
        chemical formula text into a FormulaParseResult.
        
        'text' is the parameter, it represents the chemical formula that needs to be interpreted.

        The method will move through the string using the position variable.

        During each iteration, it performs the following major operations:
        1) Reads an element symbol.
        2) Uses IElementRepository to find the corresponding Element.
        3) Reads the numerical count following that element, if one exists.
        4) Creates an ElementCount object.
        5) Adds that ElementCount to the collection.
        6) Continues parsing from the next unread character.

        If an error is encountered, a FormulaParseError is added to the
        errors collection.

        After parsing is complete, the method returns a FormulaParseResult
        describing whether parsing succeeded and containing either the parsed
        ChemicalFormula or the errors that were encountered.
        */        
        public FormulaParseResult Parse(string text)
        {
            /*
            Creates a List of ElementCount objects.

            This list will gradually store the elements and their corresponding
            counts as they are discovered in the supplied chemical formula.
            
            List<ElementCount> is used because the parser needs to add new
            ElementCount objects to the collection as it moves through the
            formula            
            */            
            List<ElementCount> elementCounts = new List<ElementCount>();

            /*
            Creates a List of FormulaParseError objects.

            This list will store the errors that are encountered during the
            parsing operation.

            At the beginning, the list is empty because no parsing errors have
            been discovered yet.
            */            
            List<FormulaParseError> errors = new List<FormulaParseError>();

            /*
            Before examining the individual characters of the formula, the
            parser checks whether useful text was actually supplied.

            string.IsNullOrWhiteSpace(text) returns true if text is:
            (i)   null
            (ii)  an empty string ""
            (iii) a string containing only whitespace

            None of these can be processed as a chemical formula.
            */
            if(string.IsNullOrWhiteSpace(text))
            {
                // Adds an error stating that there is no chemical formula to parse.                
                errors.Add(new FormulaParseError(0, "The chemical formula cannot be empty"));
                
                // Returns an unsuccessful result because no ChemicalFormula was created.                
                return new FormulaParseResult(false, null!, errors);
            }

            /*
            position keeps track of the character in the formula string that
            the parser is currently examining.

            String indexing begins at 0 in C#.
            */
            int position = 0;

            /*
            This while loop continues as long as position still refers to a
            character inside the supplied formula.

            text.Length gives the total number of characters in the string.

            As symbols and counts are read, position will be moved forward
            through the formula.
            */
            while (position < text.Length)
            {
                /*
                Stores the position where the current element symbol begins.

                This position is stored because if the symbol turns out to be
                unknown, the FormulaParseError should identify where that
                element symbol began in the supplied text.
                */                
                int elementStartPosition = position;

                /*
                A chemical element symbol must begin with an uppercase letter.
                Which will be checked by the following if-statement.
                */
                if (!char.IsUpper(text[position]))
                {
                    // Adds an error at the position where an element symbol was expected.
                    errors.Add(new FormulaParseError(position, "Expected an uppercase letter at the beginning of an element symbol."));
                    
                    // Stops the parsing loop because the expected element symbol was not found.
                    break;
                }

                /*
                Converts the char into a string so that it can be
                stored inside symbol and potentially combined with a second
                lowercase character.
                */
                string symbol = text[position].ToString();

                // Moves to the next character after reading the first symbol character.
                position++;

                /*
                Some chemical element symbols contain a second lowercase letter.
                
                The parser checks:
                (i)  Whether another character still exists in the string.
                (ii) Whether that character is lowercase.

                'position < text.Length' is checked first so that the program
                does not attempt to access a character beyond the end of the
                string.
                */
                if (position < text.Length && char.IsLower(text[position]))
                {
                    // Adds the lowercase character to the element symbol.
                    symbol += text[position];

                    // Moves forward after reading the second character of the symbol.
                    position++;
                }

                /*
                Declares an Element variable that will store the Element object
                corresponding to the symbol that was just read.
                
                This is when IElementRepository will be used in order to find the 
                actual Element represented by this symbol.
                */
                Element element;

                /*
                'try' and 'catch' are being used because the repository lookup may
                fail if the parsed symbol does not correspond to a known Element.

                The code inside 'try' attempts the repository lookup.

                If that operation throws an exception, execution moves into
                the catch block, where the problem is converted into a
                FormulaParseError.
                */
                try
                {
                    // Finds the Element object represented by the parsed chemical symbol.
                    element = _elementRepository.FindBySymbol(symbol);
                }

                catch 
                {
                    // Adds an error at the position where the unknown element symbol began.
                    errors.Add(new FormulaParseError(elementStartPosition, $"Unknown element symbol '{symbol}'."));
                    
                    // Stops parsing because the current element symbol could not be resolved.
                    break;
                }

                /*
                In a chemical formula, if no numerical subscript appears after
                an element symbol, then a count of 1 is implied.                
                */
                int count = 1;

                /*
                Stores the position where the optional numerical element count
                would begin.

                This value will later be used to determine whether any digits
                were actually found after the element symbol.
                */
                int countStartPosition = position;

                /*
                Reads all consecutive numerical digits that appear after the
                element symbol.

                char.IsDigit(text[position]) checks whether the current
                character is a numerical digit.

                The loop moves position forward until either:
                (i)  there are no more characters, or
                (ii) the next character is not a digit.

                This also allows element counts containing more than one digit
                to be read.
                */
                while (position < text.Length && char.IsDigit(text[position]))
                {
                    // Moves through each digit belonging to the current element count.
                    position++;
                }

                /*
                If position is greater than countStartPosition, then at least
                one digit was discovered after the element symbol.

                If they are equal, no explicit numerical count was supplied,
                so count remains equal to its default value of 1.
                */
                if (position > countStartPosition)
                {
                    /*
                    Extracts the numerical part of the formula from the original
                    string.

                    Substring() receives:
                    (i)  The starting position.
                    (ii) The number of characters to extract.

                    countStartPosition tells Substring where the numerical
                    count begins.

                    position - countStartPosition calculates how many digit
                    characters were read.
                    */                    
                    string countText = text.Substring(countStartPosition, position - countStartPosition);

                    /*
                    int.TryParse attempts to convert countText from a string
                    into an int
                    
                    out count means that if TryParse succeeds, the converted
                    integer will be stored inside the existing count variable.

                    TryParse itself returns a bool indicating whether the
                    conversion succeeded.

                    The condition here checks whether the countText could not be converted 
                    into an integer or if the resulting count is less than or equal to zero
                    */
                    if(!int.TryParse(countText, out count) || (count <= 0)) 
                    {
                        // Adds an error describing the invalid numerical element count.
                        errors.Add(new FormulaParseError(countStartPosition, $"Invalid element count '{countText}'."));
                        
                        // Stops parsing because a valid ElementCount cannot be created.
                        break;
                    }
                }

                /*
                At this point, both pieces of information required to create
                an ElementCount object have been obtained:

                ElementCount object = Element + Count

                Therefore, a new ElementCount object is created and added to
                the elementCounts list.                
                */
                elementCounts.Add(new ElementCount(element, count));

            }

            /*
            After the parsing loop has ended, the parser checks whether any
            FormulaParseError objects were added to the errors list.
            */
            if (errors.Count > 0)
            {
                /*
                Returns an unsuccessful FormulaParseResult.

                false indicates that the parsing operation failed.

                null! is supplied in place of a ChemicalFormula because a
                successfully parsed formula was not created.

                errors contains the information explaining what went wrong.
                */
                return new FormulaParseResult(false, null!, errors);
            }

            /*
            If execution reaches this point, the parser completed its loop
            without adding any FormulaParseError objects.

            A ChemicalFormula object is therefore created using:
            (i)   text: The original chemical formula text.
            (ii)  FormulaKind.Molecular: The kind assigned to the formula.
            (iii) elementCounts: The elements and counts obtained by parsing.
            */
            ChemicalFormula formula = new ChemicalFormula(text, FormulaKind.Molecular, elementCounts);
            
            /*
            Returns a successful FormulaParseResult.

            true indicates that the parsing operation succeeded.

            formula contains the ChemicalFormula that was created.

            errors is also supplied to the result, but on this successful
            path the collection contains no parsing errors.
            */            
            return new FormulaParseResult(true, formula, errors);
        }
    }
}