/*
FormulaParseResult is being created to represent the complete result produced
after the Compound Handbook attempts to parse a supplied chemical formula.

When ChemicalFormulaParser receives chemical formula text, there are generally
two important possibilities:

1) The formula is successfully parsed and converted into a ChemicalFormula object.
2) The formula cannot be completely parsed because one or more parsing errors were encountered.

Therefore, simply returning a ChemicalFormula object from the parser would not
be enough. The program also needs to know whether the parsing operation was
successful and, if it was not, what parsing errors were encountered.

FormulaParseResult packages all of this information into a single object that
can be returned by ChemicalFormulaParser.
*/

/*
FormulaParseResult object = Success + Formula + Errors

Success indicates whether the overall formula-parsing operation succeeded.

Formula stores the ChemicalFormula object produced from the supplied text.

Errors stores the collection of FormulaParseError objects that describe the
problems encountered during the parsing operation.

This means that FormulaParseResult acts like a container for the complete
outcome of one formula-parsing attempt.

For example, ChemicalFormulaParser can perform its parsing operation and then
return one FormulaParseResult object. The code that receives this object can
first inspect Success and then access either the parsed Formula or information
about the Errors that occurred.

Also, there can be more than one FormulaParseError produced during parsing.
This is why Errors is represented as a collection rather than as one individual
FormulaParseError object.
*/

using CompoundHandbook.Domain;
using CompoundHandbook.DataContracts;

namespace CompoundHandbook.Parsing 
{
    /*
    FormulaParseResult represents the result produced by the chemical formula
    parsing process.

    Other parts of the Compound Handbook need to access the parsing result in
    order to determine whether parsing succeeded, retrieve the resulting
    ChemicalFormula, and inspect any parsing errors. This is why the public
    access modifier is used for this class.
    */
    public class FormulaParseResult
    {
        /*
        Read-only property that indicates whether the chemical formula parsing
        operation was successful.

        The datatype here is bool because the only two possible outputs are TRUE or FALSE.

        The Success value can be read after the FormulaParseResult object has
        been created, but it cannot be directly replaced from outside the class.
        */        
        public bool Success { get; }

        /*
        Read-only property that stores the ChemicalFormula associated with this
        parsing result.

        ChemicalFormula is itself a class, but it is being used here as the
        datatype of the Formula property. Therefore, this property stores a
        reference to a ChemicalFormula object.

        When the supplied formula text is successfully interpreted, this
        ChemicalFormula object represents the structured chemical formula
        obtained from that text.

        The Formula value is supplied when the FormulaParseResult object is
        created and is assigned by this class' constructor.
        */
        public ChemicalFormula Formula { get; }

        /*
        Read-only property that stores the parsing errors associated with this
        formula-parsing operation.

        IReadOnlyCollection<FormulaParseError> means that this property
        represents a collection whose individual items are FormulaParseError
        objects.

        A collection is necessary because one parsing operation may encounter
        more than one error.

        IReadOnlyCollection is used so that code receiving the parsing result
        can inspect the collection of errors without directly modifying the
        collection through this property.

        Therefore:
        Errors = Collection of FormulaParseError objects
        */        
        public IReadOnlyCollection<FormulaParseError> Errors { get; }

        /*
        A constructor is a special method that is called when a new object
        of a class is created.
        
        This constructor receives the information necessary to represent the
        complete result of one chemical formula-parsing operation.

        This constructor receives the information of:
        (i)   success: Indicates whether the parsing operation succeeded.
        (ii)  formula: Is the ChemicalFormula associated with the parsing result.
        (iii) errors: Is the collection of FormulaParseError objects encountered during the parsing operation.        
        */
        public FormulaParseResult(bool success, ChemicalFormula formula, IReadOnlyCollection<FormulaParseError> errors) 
        {
            // Assigns the supplied parsing-success state to the Success property.
            Success = success;

            // Assigns the supplied chemical formula to the Formula property.
            Formula = formula;

            // Assigns the supplied collection of parsing errors to the Errors property.
            Errors = errors;
        }

    }
}