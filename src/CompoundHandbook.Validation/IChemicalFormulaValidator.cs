/*
A ChemicalFormula represents the elemental composition of a chemical substance inside
the Compound Handbook.

For example, a ChemicalFormula can contain information about which Elements are present,
how many of each Element are present, the original formula text, and the FormulaKind
associated with that formula.

However, before other parts of the Compound Handbook rely upon a ChemicalFormula for
operations such as molar-mass calculation, percent-composition calculation, chemical
entity resolution, or other chemistry-related operations, the formula should first
be checked for validation issues.

For example, formula validation may need to determine whether required information is
missing or whether an ElementCount contains an invalid count.

This is why, IChemicalFormulaValidator interface is being created to define the contract
for validating a ChemicalFormula.

The validator receives a ChemicalFormula object and returns a ValidationResult.

The returned ValidationResult can indicate whether the ChemicalFormula is considered valid
and can also contain the collection of ValidationIssue objects discovered while validating
the formula.

The interface only defines what a chemical formula validator must be able to do.
It does not define the particular validation rules or the implementation used to perform
those checks.
*/
using CompoundHandbook.Domain;

/*
The following IChemicalFormulaValidator is an interface.

An interface defines a contract that specifies which functionality an implementing class
must provide without specifying how that functionality must be implemented.

I am using an interface here because the rest of the Compound Handbook should be able to
request ChemicalFormula validation without depending directly upon one particular validator
implementation.

Any class that implements IChemicalFormulaValidator must provide the Validate() method
defined by this interface.
*/

namespace CompoundHandbook.Validation 
{
    // The following interface defines the contract for validating a ChemicalFormula.
    public interface IChemicalFormulaValidator 
    {
        /*
        The following Validate() method receives a ChemicalFormula object and checks it
        according to the chemical-formula validation rules provided by the class that
        implements this interface.
        
        (i) ChemicalFormula formula
        ChemicalFormula is the datatype of the parameter.
        formula is the name of the parameter.
        Therefore, the formula parameter represents the ChemicalFormula object that needs to be validated.

        (ii) ValidationResult
        ValidationResult is the return type of this method.
        This means that after the ChemicalFormula has been validated, 
        the method returns a ValidationResult object.
        
        That ValidationResult can contain:
        [1] IsValid : The overall Boolean validation state.
        [2] Issues  : The collection of ValidationIssue objects discovered during validation.

        Since this is an interface method, there is no method body here.

        The actual validation logic will be supplied by a class that implements
        IChemicalFormulaValidator.
        */
        ValidationResult Validate(ChemicalFormula formula);
    }
}