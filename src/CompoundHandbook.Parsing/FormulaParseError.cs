/*
FormulaParseError is being created to represent a specific error that occurs
while the Compound Handbook is attempting to parse a chemical formula.

When a chemical formula is supplied as text, the ChemicalFormulaParser must
analyze that text and determine whether it can be converted into a valid
ChemicalFormula object.

For example, the parser may encounter a part of the input that it cannot
interpret correctly.

Simply knowing that parsing failed is not enough. The program should also be
able to describe:
1) Where in the supplied formula the problem was detected.
2) What problem was detected at that location.
*/

/*
FormulaParseError object = Position + Message

When a parsing error occurs at a particular position in a supplied formula text,
then this object will store the numerical position of that error through
Position and an explanation of the problem through Message.

And as it is possible for ChemicalFormulaParser to encounter multiple problems,
FormulaParseResult exists to collect the FormulaParseError objects. This allows
multiple parsing errors to be returned as part of the overall parsing result.

Therefore, FormulaParseError represents one individual parsing error.
*/

namespace CompoundHandbook.Parsing 
{
    /*
    FormulaParseError represents one error discovered while attempting to
    interpret chemical-formula text.

    FormulaParseError should be accessed from other parts of the Compound
    Handbook that need to inspect or report formula-parsing errors. This is
    why the public access modifier is used for this class.
    */
    public class FormulaParseError 
    {
        /*
        Read-only property that stores the position in the supplied formula
        text where the parsing error was detected.

        Code outside the class retrieves the Position value through its
        getter. The value is supplied when the FormulaParseError object is
        created and assigned by this class' constructor.
        */              
        public int Position { get; }

        /*
        Read-only property that stores a human-readable description of the
        parsing error.

        Message is necessary because it describes why a particular portion
        of the supplied formula could not be interpreted.

        This property has a read-only feature. It can be read after the
        FormulaParseError object has been created, but it cannot be directly
        replaced from outside the class.
        */
        public string Message { get; }
        
        /*
        A constructor is a special method that is called when a new object
        of a class is created.

        This constructor receives the information of:
        (i)  position: Indicates where the error was detected.
        (ii) message: Is the description of that error.
        */
        public FormulaParseError(int position, string message)
        {
            // Assigns the supplied error position to the Position property.
            Position = position;

            // Assigns the supplied error description to the Message property.
            Message = message;
        }
    }
}