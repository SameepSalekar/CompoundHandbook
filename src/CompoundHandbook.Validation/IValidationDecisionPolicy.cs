/*
Validation determines whether chemical information satisfies the rules required by the
Compound Handbook and produces a ValidationResult containing the overall validation state
and any ValidationIssue objects that were discovered.

However, discovering validation issues is not the same thing as deciding what the program
should do after those issues have been discovered.

The appropriate decision can also depend upon the chemical operation that the user is
trying to perform.

For example, a particular validation concern may prevent one operation from safely
continuing while still allowing another operation to proceed.

Therefore, the Compound Handbook needs a separate policy that can examine both:
(i)  The ValidationResult produced by the validation process.
(ii) The ChemicalOperation that the program is attempting to perform.

The policy can then determine whether that particular operation should:
(i)   Continue normally.
(ii)  Continue while preserving validation warnings.
(iii) Stop because the chemical information is invalid.
(iv)  Stop because the chemical case or operation is unsupported.

This is why, IValidationDecisionPolicy interface is being created to define the contract
for converting a ValidationResult and requested ChemicalOperation into a ValidationDecision.

The returned ValidationDecision contains:
(i)  Kind     : The ValidationDecisionKind describing what should happen next.
(ii) Messages : The collection of explanatory messages associated with that decision.

Separating this decision-making policy from the validators themselves is important.

A validator is responsible for discovering and reporting validation issues.

The validation decision policy is responsible for interpreting those results in the context
of the requested ChemicalOperation and deciding whether processing should continue or stop.
*/

/*
The following IValidationDecisionPolicy is an interface.

An interface defines a contract that specifies which functionality an implementing class
must provide without specifying how that functionality must be implemented.

In C#, interface names conventionally begin with the letter 'I'.

I am using an interface here because the rest of the Compound Handbook should be able to
request a validation decision without depending directly upon one particular decision-policy
implementation.

This also keeps the validation rules separate from the policy that determines how the
program should respond to their results.

Any class that implements IValidationDecisionPolicy must provide the Decide() method
defined by this interface.
*/

using CompoundHandbook.Classification;

namespace CompoundHandbook.Validation 
{
    /*
    The following interface defines the contract for deciding what the Compound Handbook
    should do after validation for a particular ChemicalOperation.
    */
    public interface IValidationDecisionPolicy 
    {
        /*
        The following Decide() method receives a ValidationResult and a ChemicalOperation.

        It uses these two pieces of information to determine whether the requested operation
        should continue, continue with warnings, stop because the information is invalid,
        or stop because the chemical case is unsupported.

        (i) ValidationResult

        ValidationResult is the datatype of the first parameter.
        result is the name of the first parameter.
        Therefore, the result parameter represents the outcome produced by the validation process.
        The ValidationResult contains:
        [1] IsValid : The overall Boolean validation state.
        [2] Issues  : The collection of ValidationIssue objects discovered during validation.


        (ii) ChemicalOperation operation

        ChemicalOperation is the datatype of the second parameter.
        operation is the name of the second parameter.
        Therefore, the operation parameter represents the particular chemical operation
        for which the validation result is being considered.
        This parameter is important because the consequences of a validation issue can
        depend upon which operation the Compound Handbook is attempting to perform.


        (iii) ValidationDecision
        ValidationDecision is the return type of this method.
        This means that after the ValidationResult has been interpreted in the context
        of the requested ChemicalOperation, the method returns a ValidationDecision object.
        That ValidationDecision contains:
        [1] Kind     : Describes whether processing should continue or stop.
        [2] Messages : Contains the explanatory messages associated with that decision.



        Therefore; ValidationResult + ChemicalOperation => IValidationDecisionPolicy => ValidationDecision

        Since this is an interface method, there is no method body here. The actual decision-making logic 
        will be supplied by a class that implements IValidationDecisionPolicy.
        */
        ValidationDecision Decide(ValidationResult result, ChemicalOperation operation);
    }
}