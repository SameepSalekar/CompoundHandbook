/*
Formal charge is a bookkeeping method used in chemistry to describe how valence electrons
are assigned to an individual Atom within a chemical structure.

An Atom's formal charge cannot always be meaningfully considered without looking at the
chemical environment surrounding that Atom.

Inside the Compound Handbook, an Atom contains its FormalCharge, while the MolecularGraph
provides the structural context containing the atoms and bonds of the molecular structure.

Therefore, when validating the formal charge associated with a particular Atom, the validator
needs access to both:
(i)  The Atom whose formal charge is being validated.
(ii) The MolecularGraph that provides the structural context surrounding that Atom.

This allows the validation process to examine the Atom's formal charge in relation to the
molecular structure in which that Atom appears.

If the formal-charge situation raises a validation concern, the validator can represent
that concern using a ValidationIssue contained inside the returned ValidationResult.

This is why, IFormalChargeValidator interface is being created to define the contract
for validating the formal charge associated with an Atom within a MolecularGraph.

The validator receives an Atom and a MolecularGraph and returns a ValidationResult.

The interface only defines what a formal-charge validator must be able to do.
It does not define the particular formal-charge validation rules or the implementation
used to perform those checks.
*/

/*
The following IFormalChargeValidator is an interface.

An interface defines a contract that specifies which functionality an implementing class
must provide without specifying how that functionality must be implemented.

I am using an interface here because the rest of the Compound Handbook should be able to
request formal-charge validation without depending directly upon one particular validator
implementation.

This also keeps the formal-charge validation responsibility separate from the broader
atom-chemistry and molecular-graph validation responsibilities.

Any class that implements IFormalChargeValidator must provide the Validate() method
defined by this interface.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.Validation 
{
    /* 
    The following interface defines the contract for validating the formal charge 
    associated with an Atom within the context of a MolecularGraph.
    */
    public interface IFormalChargeValidator
    {
        /*
        The following Validate() method receives an Atom and the MolecularGraph containing
        the structural context needed to evaluate the formal charge of that Atom.

        (i) Atom atom
        Atom is the datatype of the first parameter.
        atom is the name of the first parameter.
        Therefore, the atom parameter represents the particular Atom whose formal charge
        needs to be validated.

        (ii) MolecularGraph graph
        MolecularGraph is the datatype of the second parameter.
        graph is the name of the second parameter.
        Therefore, the graph parameter represents the molecular structure that provides
        the structural context surrounding the Atom.

        Providing the MolecularGraph is important because formal-charge validation can
        require information about how the Atom participates in the surrounding molecular
        structure rather than considering the Atom as an isolated object.

        (iii) ValidationResult
        ValidationResult is the return type of this method.
        This means that after the formal charge associated with the Atom has been evaluated,
        the method returns a ValidationResult object.

        The ValidationResult can contain:
        [1] IsValid : The overall Boolean validation state.
        [2] Issues  : The collection of ValidationIssue objects discovered during validation.

        Since this is an interface method, there is no method body here.
        The actual formal-charge validation logic will be supplied by a class that
        implements IFormalChargeValidator.        
        */
        ValidationResult Validate(Atom atom, MolecularGraph graph);
    }
}