/*
A valence rule evaluates whether a particular chemical valence situation can be handled
by that rule and whether the situation is considered chemically acceptable.

However, these are two different questions.

First, the Compound Handbook needs to know whether the valence rule actually supports
the supplied ValenceContext.

For example, a particular valence rule may only contain the chemical knowledge required
to evaluate certain Elements, formal-charge states, or bonding situations.

If the rule does support the supplied context, the Compound Handbook then needs to know
whether that valence situation is considered acceptable according to the rule.

Therefore, the result of a valence-rule evaluation cannot be represented by only one
Boolean value.

This is why, ValenceRuleResult class is being created to store three pieces of information:
(i)   Supported  : Indicates whether the valence situation is supported by the rule.
(ii)  Acceptable : Indicates whether the supported valence situation is considered acceptable.
(iii) Message    : Provides a human-readable explanation of the result.

It is important to distinguish Supported from Acceptable.

A valence situation that is unsupported does not automatically mean that the chemistry
is invalid. It can instead mean that the particular valence rule does not contain enough
information to evaluate that chemical case.

On the other hand, if the situation is supported but not acceptable, the rule was able
to evaluate the chemistry and determined that the valence situation raises a concern.

This distinction allows the Compound Handbook to avoid incorrectly treating chemistry
that it cannot evaluate as chemistry that is necessarily invalid.
*/

/*
The following ValenceRuleResult class represents the result produced after a valence rule
evaluates a ValenceContext.

ValenceRuleResult object = Supported + Acceptable + Message

All three of these are read-only properties because they contain only a 'getter' accessor.

Therefore, these properties can be read from outside of the class, but they cannot be directly
changed from outside of the class after the ValenceRuleResult object has been constructed.

The following class also contains a constructor that receives the supported state,
acceptable state, and explanatory message required to initialize a new ValenceRuleResult object.
*/

namespace CompoundHandbook.Validation 
{
    // The following class represents the result produced by a valence-rule evaluation.
    public class ValenceRuleResult 
    {
        /*
        Read-only property that stores whether the valence rule supports the chemical
        situation that was supplied to it.

        The datatype here is bool.
        
        An unsupported result does not necessarily mean that the chemistry itself is invalid.
        It means that the rule is not able to evaluate that particular chemical case.
        */
        public bool Supported { get; }

        /*
        Read-only property that stores whether the valence situation is considered acceptable
        according to the valence rule.

        The datatype here is bool
        
        Supported and Acceptable have separate meanings.

        For example, both Supported and Acceptable being true, means that the rule can evaluate 
        the chemical case and considers its valence situation acceptable.
        BUT, if only Supported is true, then,
        the rule can evaluate the chemical case, but the valence situation does not satisfy the rule.

        If Supported is false, Acceptable should not by itself be interpreted as a
        chemical judgment because the rule could not properly evaluate that case.
        */
        public bool Acceptable { get; }

        /*
        Read-only property that stores a human-readable explanation of the
        valence-rule result.

        The datatype here is string.

        The Message can provide additional information explaining why a valence situation
        was considered acceptable, unacceptable, or unsupported by the rule.

        This explanation can later help the validation system communicate the reason
        behind the result instead of returning only Boolean values.
        */
        public string Message { get; }

        /*
        The following constructor will be called whenever a new ValenceRuleResult
        object gets created.

        The constructor receives two Boolean values and a string as parameters.
        (i) bool supported   : Indicates whether the valence rule supports the supplied chemical context.
        (ii) bool acceptable : Indicates whether the evaluated valence situation is considered acceptable.
        (iii) string message : Contains the human-readable explanation associated with the result.

        These supplied values are then assigned to their corresponding read-only
        properties of the ValenceRuleResult object.
        */
        public ValenceRuleResult(bool supported, bool acceptable, string message) 
        {
            // Stores whether the valence rule supports the supplied chemical context.
            Supported = supported;

            // Stores whether the evaluated valence situation is considered acceptable.
            Acceptable = acceptable;

            // Stores the explanatory message associated with the valence-rule result.
            Message = message;
        }
    }
}