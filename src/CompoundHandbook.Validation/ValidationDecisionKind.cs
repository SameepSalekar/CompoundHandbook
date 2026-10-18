/*
After the Compound Handbook performs a validation operation, the program needs to determine
what should happen next.

A ValidationResult can describe whether the information is valid and can contain the individual
ValidationIssue objects discovered during the validation process.

However, the validation result by itself does not describe what decision the Compound Handbook
should make about continuing the requested chemical operation.

For example, some validation results may allow the requested operation to continue normally.
Other results may contain warnings that should be shown to the user while still allowing the
operation to continue.

More serious validation results may require the operation to stop because the supplied chemical
information is invalid or because the requested chemical case is not currently supported by
the Compound Handbook.

This is why, ValidationDecisionKind is being created so that the decision made after evaluating
a validation result can be represented using a specific predefined value.

The four validation decision kinds are:
(i)   Continue             : The requested operation can continue normally.
(ii)  ContinueWithWarnings : The requested operation can continue, but warnings should be preserved.
(iii) StopInvalid          : The requested operation should stop because the information is invalid.
(iv)  StopUnsupported      : The requested operation should stop because the chemical case is unsupported.

ValidationDecisionKind will later be used by ValidationDecision to describe what action should
be taken after the validation result has been evaluated.
*/

/*
The following ValidationDecisionKind is an enumeration.
An enumeration is a value type that defines a fixed set of named constants.

I do not want the decisions produced after validation to be represented using arbitrary strings.
Instead, I want the Compound Handbook to restrict a validation decision to one of the
pre-defined decision categories.

This is why I decided to create this enum.

A variable or property whose datatype is ValidationDecisionKind can use one of the named
values defined inside this enumeration.

It is important that ValidationDecisionKind is different from ValidationSeverity.

ValidationSeverity describes how serious one particular ValidationIssue is, while
ValidationDecisionKind describes what the Compound Handbook should do after the overall
ValidationResult has been evaluated.
*/

namespace CompoundHandbook.Validation 
{
    /*
    ValidationDecisionKind is the datatype that is being created here.
    The following enum provides the different decisions that can be made after
    evaluating the result of a validation operation.
    */
    public enum ValidationDecisionKind 
    {
        /*
        Represents a decision that allows the requested chemical operation to continue normally.
        This value can be used when the validation result does not contain a condition that
        requires the requested operation to stop.
        */
        Continue,

        /*
        Represents a decision that allows the requested chemical operation to continue while
        preserving warnings that should be communicated to the user.

        This allows the Compound Handbook to distinguish between a completely normal continuation
        and a continuation in which validation concerns should still be acknowledged.
        */
        ContinueWithWarnings,
        
        /*
        Represents a decision that stops the requested chemical operation because the supplied
        chemical information has been determined to be invalid.

        This value distinguishes an invalid chemical input or structure from a chemical case
        that is merely unsupported by the current implementation.
        */
        StopInvalid,
        
        /*
        Represents a decision that stops the requested chemical operation because the particular
        chemical case is not currently supported by the Compound Handbook.

        An unsupported case does not necessarily mean that the chemistry itself is invalid.
        Instead, it means that the current implementation does not contain the functionality
        or validation rules required to safely continue that particular operation.
        */
        StopUnsupported
    }
}