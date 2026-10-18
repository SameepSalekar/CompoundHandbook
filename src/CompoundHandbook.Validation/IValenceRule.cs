/*
Valence rules provide the chemical logic used by the Compound Handbook to evaluate whether
a particular bonding situation around an Atom is chemically acceptable.

However, one valence rule may not necessarily be capable of evaluating every possible
Element, formal-charge state, or bonding situation.

For example, a particular rule may be designed to evaluate only certain Elements or
particular combinations of Element, FormalCharge, and BondOrderSum.

This is why the valence-rule system needs two separate operations.

First, the Compound Handbook needs to determine whether a particular valence rule is capable
of evaluating the supplied ValenceContext.

If the rule can evaluate that context, the Compound Handbook can then ask the rule to
perform the actual valence evaluation.

This is why, IValenceRule interface is being created to define the contract that every
valence rule inside the Compound Handbook must follow.

The interface defines two methods:
(i)  CanEvaluate() : Determines whether the rule can evaluate a supplied ValenceContext.
(ii) Evaluate()    : Evaluates the supplied ValenceContext and returns a ValenceRuleResult.

ValenceContext contains the chemical information needed by the rule: Element + FormalCharge + BondOrderSum.

ValenceRuleResult then contains the result of applying the rule: Supported + Acceptable + Message.

Separating CanEvaluate() from Evaluate() allows the validation system to determine which
valence rule is appropriate for a particular chemical context before relying upon that
rule for the actual evaluation.
*/

/*
The following IValenceRule is an interface.

An interface defines a contract that specifies which functionality an implementing class
must provide without specifying how that functionality must be implemented.

I am using an interface here because the Compound Handbook may contain different valence-rule
implementations for different chemical situations.

The validation system can work with those implementations through the common IValenceRule
contract instead of depending directly upon one particular valence-rule class.

Any class that implements IValenceRule must provide both the CanEvaluate() and Evaluate()
methods defined by this interface.
*/
namespace CompoundHandbook.Validation 
{
    // The following interface defines the contract that a valence rule must follow.
    public interface IValenceRule 
    {
        /*
        The following CanEvaluate() method determines whether this valence rule is capable
        of evaluating the supplied ValenceContext.
        
        ValenceContext is the datatype of the parameter.
        context is the name of the parameter.
        The ValenceContext contains the chemical information needed for valence evaluation of
        Element, FormalCharge, and BondOrderSum

        Therefore, the context parameter represents the particular chemical situation
        that the rule is being asked whether it can evaluate.

        This method allows the validation system to determine whether a particular rule
        is appropriate before performing the actual valence evaluation.

        Since this is an interface method, there is no method body here.
        The actual logic for determining whether the context can be evaluated will be
        supplied by a class that implements IValenceRule.
        */
        bool CanEvaluate(ValenceContext context);

        /*
        The following Evaluate() method performs the valence-rule evaluation for the
        supplied ValenceContext.

        ValenceContext is the datatype of the parameter.
        context is the name of the parameter.
        Therefore, the context parameter contains the Element, FormalCharge, and
        BondOrderSum that the rule uses when evaluating the valence situation.

        ValenceRuleResult is the return type of this method.
        This means that after the valence rule evaluates the supplied context, the method
        returns a ValenceRuleResult object.

        That ValenceRuleResult contains:
        (i)   Supported  : Indicates whether the chemical situation is supported by the rule.
        (ii)  Acceptable : Indicates whether the evaluated valence situation is acceptable.
        (iii) Message    : Provides a human-readable explanation of the result.

        Since this is an interface method, there is no method body here.
        The actual valence-evaluation logic will be supplied by a class that implements IValenceRule.
        */
        ValenceRuleResult Evaluate(ValenceContext context);
    }
}