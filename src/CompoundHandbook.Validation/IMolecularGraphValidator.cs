/*
A MolecularGraph represents the structural connectivity of a molecule inside the
Compound Handbook.

Inside a MolecularGraph:
(i)  Atom objects represent the vertices/nodes of the graph.
(ii) Bond objects represent the edges/connections between those atoms.

Because other parts of the Compound Handbook may depend upon this molecular graph for
chemical calculations, structure generation, functional-group detection, and other
structure-based operations, the MolecularGraph should first be checked for structural
and chemical validation issues.

For example, molecular graph validation may need to detect problems such as:
(i)    Duplicate Atom Id values.
(ii)   Bonds that reference Atom Id values that do not exist in the graph.
(iii)  A Bond whose two endpoints refer to the same Atom.
(iv)   Duplicate bonds.
(v)    Invalid bond-order information.
(vi)   A MolecularGraph containing disconnected groups of atoms.

These types of problems can make the molecular structure internally inconsistent or
prevent later operations from safely interpreting the connectivity of the molecule.

This is why, IMolecularGraphValidator interface is being created to define the contract
for validating a MolecularGraph.

The validator receives a MolecularGraph object and returns a ValidationResult.

The returned ValidationResult can indicate whether the MolecularGraph is considered valid
and can also contain the collection of ValidationIssue objects discovered while validating
the molecular graph.

The interface only defines what a molecular graph validator must be able to do.
It does not define the particular validation rules or the implementation used to perform
those checks.
*/

/*
The following IMolecularGraphValidator is an interface.

An interface defines a contract that specifies which functionality an implementing class
must provide without specifying how that functionality must be implemented.

I am using an interface here because the rest of the Compound Handbook should be able to
request MolecularGraph validation without depending directly upon one particular validator
implementation.

Any class that implements IMolecularGraphValidator must provide the Validate() method
defined by this interface.
*/
using CompoundHandbook.Domain;


namespace CompoundHandbook.Validation 
{
    // The following interface defines the contract for validating a MolecularGraph.
    public interface IMolecularGraphValidator 
    {
        /*
        The following Validate() method receives a MolecularGraph object and checks it
        according to the molecular-graph validation rules provided by the class that
        implements this interface.

        (i) MolecularGraph graph
        MolecularGraph is the datatype of the parameter.
        graph is the name of the parameter.
        Therefore, the graph parameter represents the MolecularGraph object that needs to be validated.

        (ii) ValidationResult
        ValidationResult is the return type of this method.
        This means that after the MolecularGraph has been validated, 
        the method returns a ValidationResult object.

        The ValidationResult can contain:
        [1] IsValid : The overall Boolean validation state.
        [2] Issues  : The collection of ValidationIssue objects discovered during validation.

        Since this is an interface method, there is no method body here.
        The actual molecular-graph validation logic will be supplied by a class that
        implements IMolecularGraphValidator.
        */
        ValidationResult Validate(MolecularGraph graph);
    }
}
