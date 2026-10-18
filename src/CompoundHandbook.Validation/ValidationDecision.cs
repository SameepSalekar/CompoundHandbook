/*
After a ValidationResult has been evaluated, the Compound Handbook needs a way to represent
the decision about whether the requested chemical operation should continue or stop.

ValidationDecisionKind provides the predefined categories for those decisions, such as
Continue, ContinueWithWarnings, StopInvalid, and StopUnsupported.

However, storing only the ValidationDecisionKind would tell the program what decision was made
without providing any explanatory information associated with that decision.

This is why, ValidationDecision class is being created so that the decision and the messages
associated with that decision can be stored together inside one object.

A ValidationDecision contains two pieces of information:
(i)  Kind     : Describes what the Compound Handbook should do after validation.
(ii) Messages : Contains the collection of messages associated with that decision.

For example, if validation discovers concerns that do not require the requested operation
to stop, Kind may contain ContinueWithWarnings while Messages can contain the explanations
that should accompany those warnings.

Similarly, if the requested operation must stop because the chemical case is unsupported,
Kind may contain StopUnsupported while Messages can explain why that particular chemical
case cannot currently be processed.

Therefore, ValidationDecision provides both the control decision needed by the program and
the explanatory messages associated with that decision.
*/

/*
The following ValidationDecision class represents the decision produced after a
ValidationResult has been evaluated.

ValidationDecision object = Kind + Collection of Messages

Both of these are read-only properties because they contain only a 'getter' accessor.

Therefore, these properties can be read from outside of the class, but they cannot be directly
changed from outside of the class after the ValidationDecision object has been constructed.

The following class also contains a constructor that receives the ValidationDecisionKind
and collection of messages required to initialize a new ValidationDecision object.
*/

namespace CompoundHandbook.Validation 
{
    // The following class represents the decision made after evaluating a validation result.
    public class ValidationDecision 
    {
        /*
        Read-only property that stores the type of validation decision that was made.

        ValidationDecisionKind is an enum itself, but is being used as the datatype
        of this property.

        Therefore, the value of Kind must be one of the named values defined inside
        the ValidationDecisionKind enumeration:
        Continue, ContinueWithWarnings, StopInvalid, or StopUnsupported.
        */
        public ValidationDecisionKind Kind { get; }

        /*
        Read-only property that stores the collection of messages associated with
        the validation decision.

        IReadOnlyCollection<T> is a .NET generic interface that represents a collection
        whose elements can be accessed but cannot be added or removed through this interface.

        Therefore, IReadOnlyCollection<string> represents a read-only collection of
        textual messages.

        These messages can provide explanations about warnings, invalid information,
        unsupported chemical cases, or other information associated with the decision
        produced after validation.
        */
        public IReadOnlyCollection<string> Messages { get; }

        /*
        The following constructor will be called whenever a new ValidationDecision
        object gets created.

        The constructor receives a ValidationDecisionKind and an IReadOnlyCollection
        of strings as parameters.

        The supplied arguments are then assigned to their corresponding read-only
        properties of the ValidationDecision object.
        */
        public ValidationDecision(ValidationDecisionKind kind, IReadOnlyCollection<string> messages)
        {
            // Stores the supplied ValidationDecisionKind value in the Kind property.
            Kind = kind;

            // Stores the supplied collection of decision messages in the Messages property.
            Messages = messages;
        }
    }
}