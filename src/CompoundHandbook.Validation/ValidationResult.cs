/*
A validation process may discover zero, one, or multiple issues while checking chemical
information inside the Compound Handbook.

Simply returning the individual validation issues would not immediately tell the rest of
the program whether the overall validation operation considers the supplied information valid.

This is why, ValidationResult class is being created so that the overall validity of the
information and the collection of issues discovered during validation can be stored together
inside one object.

A ValidationResult contains two pieces of information:
(i)  IsValid : Indicates whether the information passed the validation process.
(ii) Issues  : Contains the collection of ValidationIssue objects discovered during validation.

The IsValid property provides the overall result of the validation process.

The Issues collection provides the detailed information associated with that result.
Each ValidationIssue can describe the type of issue, its severity, a human-readable message,
and the location associated with that issue.

Therefore, ValidationResult allows the Compound Handbook to provide both an overall validation
state and the individual validation issues that explain the result.
*/

/*
The following ValidationResult class represents the result produced by a validation operation
inside the Compound Handbook.

ValidationResult object = IsValid + Collection of Validation Issues

Both of these are read-only properties because they contain only a 'getter' accessor.

Therefore, these properties can be read from outside of the class, but they cannot be directly
changed from outside of the class after the ValidationResult object has been constructed.

The following class also contains a constructor that receives the overall validity state
and the collection of ValidationIssue objects required to initialize a new ValidationResult object.
*/

namespace CompoundHandbook.Validation 
{
    // The following class represents the overall result produced by a validation operation.
    public class ValidationResult 
    {
        /*
        Read-only property that stores whether the information being validated is considered valid.
        The datatype here is bool.
        */
        public bool IsValid { get; }

        /*
        Read-only property that stores the collection of validation issues discovered
        during the validation process.

        IReadOnlyCollection<T> is a .NET generic interface that represents a collection
        whose elements can be accessed but cannot be added or removed through this interface.

        IReadOnlyCollection<ValidationIssue> therefore represents a read-only collection
        containing ValidationIssue objects.

        Each ValidationIssue object contains information about one particular issue discovered
        during the validation process.
        */
        public IReadOnlyCollection<ValidationIssue> Issues { get; }

        /*
        The following constructor will be called whenever a new ValidationResult object gets created.

        The constructor receives a Boolean value representing the overall validation state and
        an IReadOnlyCollection containing the ValidationIssue objects discovered during validation.

        The supplied arguments are then assigned to their corresponding read-only properties
        of the ValidationResult object.
        */
        public ValidationResult(bool isValid, IReadOnlyCollection<ValidationIssue> issues) 
        {
            // Stores the supplied Boolean validation state in the IsValid property.
            IsValid = isValid;

            // Stores the supplied collection of ValidationIssue objects in the Issues property.
            Issues = issues;
        }
    }
}