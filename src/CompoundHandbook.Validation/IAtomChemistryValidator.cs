/*
An Atom inside a MolecularGraph does not exist independently from its surrounding
chemical structure.

The chemical acceptability of an Atom can depend upon information about the Atom itself,
such as its Element and FormalCharge, as well as the Bonds connecting that Atom to other
atoms inside the MolecularGraph.

For example, an atom-chemistry validation process may need to examine the bonding environment
surrounding an Atom and determine whether that arrangement raises a valence-related or
other chemistry-related concern.

This means that validating the chemistry of an Atom requires more than simply receiving
the Atom object by itself.

The validator also needs access to the MolecularGraph containing that Atom so that it can
examine the Atom in the context of the molecular structure surrounding it.

This is why, IAtomChemistryValidator interface is being created to define the contract
for validating the chemistry of an Atom within a MolecularGraph.

The validator receives:
(i)  The Atom that needs to be chemically validated.
(ii) The MolecularGraph that provides the structural context surrounding that Atom.

The validator then returns a ValidationResult.

The returned ValidationResult can indicate whether the Atom is considered chemically valid
within that molecular graph and can also contain the collection of ValidationIssue objects
discovered during the validation process.

The interface only defines what an atom chemistry validator must be able to do.
It does not define the particular chemical validation rules or the implementation used
to perform those checks.
*/

/*
The following IAtomChemistryValidator is an interface.

An interface defines a contract that specifies which functionality an implementing class
must provide without specifying how that functionality must be implemented.

I am using an interface here because the rest of the Compound Handbook should be able to
request the chemical validation of an Atom without depending directly upon one particular
validator implementation.

Any class that implements IAtomChemistryValidator must provide the Validate() method
defined by this interface.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.Validation 
{
    /* 
    The following interface defines the contract for validating the 
    chemistry of an Atom within the context of a MolecularGraph. 
    */
    public interface IAtomChemistryValidator 
    {
        /*
        The following Validate() method receives an Atom and the MolecularGraph containing
        the structural context needed to evaluate that Atom.
        
        (i) Atom atom
        Atom is the datatype of the first parameter.
        atom is the name of the first parameter.
        Therefore, the atom parameter represents the particular Atom whose chemistry
        needs to be validated.

        (ii) MolecularGraph graph
        MolecularGraph is the datatype of the second parameter.
        graph is the name of the second parameter.
        Therefore, the graph parameter represents the molecular structure that provides
        the chemical and bonding context surrounding the Atom.

        Providing the MolecularGraph is important because the chemical acceptability of
        an Atom can depend upon the bonds and neighboring atoms surrounding it.

        (iii) ValidationResult
        ValidationResult is the return type of this method.
        This means that after the Atom has been evaluated within the context of the
        MolecularGraph, the method returns a ValidationResult object.

        ValidationResult can contain:
        [1] IsValid : The overall Boolean validation state.
        [2] Issues  : The collection of ValidationIssue objects discovered during validation.

        Since this is an interface method, there is no method body here.
        The actual atom-chemistry validation logic will be supplied by a class that
        implements IAtomChemistryValidator.
        */
        ValidationResult Validate(Atom atom, MolecularGraph graph);
    }
}