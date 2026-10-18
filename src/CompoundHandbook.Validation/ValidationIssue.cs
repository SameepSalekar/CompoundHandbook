/*
During the validation process, the Compound Handbook may discover a particular problem,
warning, or informational condition associated with the chemical information being checked.

Simply knowing that validation has produced an issue would not provide enough information
to describe what kind of issue occurred, how serious that issue is, what message should
be provided about the issue, or where the issue occurred.

This is why, ValidationIssue class is being created so that all of the information describing
one particular validation issue can be stored together inside one object.

A ValidationIssue contains four pieces of information:
(i)   Code     : Identifies the particular type of validation issue that occurred.
(ii)  Severity : Describes how serious the validation issue is.
(iii) Message  : Contains a human-readable explanation of the validation issue.
(iv)  Location : Describes where the validation issue occurred.

For example, if a MolecularGraph contains two Atom objects with the same Id, a ValidationIssue
could use DuplicateAtomId as its ValidationCode, assign an appropriate ValidationSeverity,
provide a message explaining the duplicate Atom Id, and use Location to identify where the
problem was discovered.

Multiple ValidationIssue objects can later be collected together inside a ValidationResult
so that the Compound Handbook can return all of the issues discovered during a particular
validation operation.
*/

/*
The following ValidationIssue class represents one particular issue discovered during
the validation of chemical information inside the Compound Handbook.

ValidationIssue object = Code + Severity + Message + Location

All four of these are read-only properties because they contain only a 'getter' accessor.

Therefore, these properties can be read from outside of the class, but they cannot be directly
changed from outside of the class after the ValidationIssue object has been constructed.

The following class also contains a constructor that receives the ValidationCode,
ValidationSeverity, message, and location required to initialize a new ValidationIssue object.
*/

namespace CompoundHandbook.Validation 
{
    // The following class represents one particular issue discovered during a validation process.
    public class ValidationIssue 
    {
        /*
        Read-only property that stores the type of validation issue that was discovered.

        ValidationCode is an enum itself, but is being used as the datatype of this property.
        Therefore, the value of Code must be one of the named values defined inside the
        ValidationCode enumeration.
        */
        public ValidationCode Code { get; }

        /*
        Read-only property that stores the severity level assigned to this validation issue.

        ValidationSeverity is an enum itself, but is being used as the datatype of this property.
        Therefore, the value of Severity must be one of the named values defined inside the
        ValidationSeverity enumeration.
        */
        public ValidationSeverity Severity { get; }

        /*
        Read-only property that stores the human-readable explanation of the validation issue.

        The datatype here is string.

        This message can provide additional information describing the particular problem,
        warning, or informational condition that was discovered during validation.
        */
        public string Message { get; }

        /*
        Read-only property that stores information describing where the validation issue occurred.

        The datatype here is string.

        Location can be used to identify the part of the chemical information or structure
        associated with the validation issue.
        */
        public string Location { get; }

        /*
        The following constructor will be called whenever a new ValidationIssue object gets created.

        The constructor receives a ValidationCode, ValidationSeverity, message, and location
        as parameters.

        The supplied arguments are then assigned to their corresponding read-only properties
        of the ValidationIssue object.
        */
        public ValidationIssue(ValidationCode code, ValidationSeverity severity, string message, string location) 
        {
            // Stores the supplied ValidationCode value in the Code property.
            Code = code;

            // Stores the supplied ValidationSeverity value in the Severity property.
            Severity = severity;

            // Stores the supplied human-readable validation message in the Message property.
            Message = message;

            // Stores the supplied location information in the Location property.
            Location = location;
        }
    }
}