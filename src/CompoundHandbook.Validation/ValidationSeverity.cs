/*
Validation is the process of checking whether chemical data, molecular structures, formulas,
or other information inside the Compound Handbook satisfies the rules expected by the program.

However, not every issue discovered during validation has the same level of importance.

Some validation results may simply provide useful information to the user, while others may
indicate a possible concern or an actual error that can prevent an operation from continuing.

This is why, ValidationSeverity is being created so that every validation issue can be assigned
a level that describes how serious that particular issue is.

The three validation severity levels are:
(i)   Info    : Represents informational feedback that does not indicate an error.
(ii)  Warning : Represents a potential problem or concern that should be brought to the user's attention.
(iii) Error   : Represents a validation problem serious enough to indicate that something is invalid.

ValidationSeverity will later be used by ValidationIssue so that each validation issue can store
both information about what went wrong and the severity of that issue.
*/

/*
The following ValidationSeverity is an enumeration.
An enumeration is a value type that defines a fixed set of named constants.

I do not want the severity of validation issues to be represented using arbitrary strings.
Instead, I want the Compound Handbook to restrict validation severity to one of the
pre-defined severity levels.

This is why I decided to create this enum.

A variable or property whose datatype is ValidationSeverity can use one of the named
values defined inside this enumeration.
*/

namespace CompoundHandbook.Validation 
{
    /*
    ValidationSeverity is the datatype that is being created here.
    The following enum provides the different severity levels that can be assigned
    to validation issues produced by the Compound Handbook.
    */    
    public enum ValidationSeverity 
    {
        /*
        Represents an informational validation message.
        Info can be used when the validation process needs to provide useful information
        without indicating that the chemical data or structure is necessarily invalid.
        An informational issue does not by itself represent a validation failure.
        */
        Info,

        /*
        Represents a validation warning.
        Warning can be used when the validation process discovers a possible problem or
        concern that should be brought to the user's attention.
        A warning is more significant than an informational message, but it does not
        necessarily mean that the requested operation must stop.
        */
        Warning,

        /*
        Represents a validation error.
        Error can be used when the validation process discovers a problem that indicates
        that the supplied chemical data, structure, or other validated information is invalid.
        An error represents the highest severity level currently defined by this enumeration.
        */
        Error
    }
}