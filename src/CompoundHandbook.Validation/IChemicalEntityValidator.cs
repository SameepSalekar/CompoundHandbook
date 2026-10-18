/*
A ChemicalEntity is the general Domain abstraction used by the Compound Handbook to
represent a chemical substance or chemical entity.

Different chemical entities can have different forms and structural characteristics.
For example, the Domain can represent entities such as Molecule, IonicSolid,
NetworkCovalentSolid, Metal, and Polymer through the ChemicalEntity abstraction.

Because these different entity types can later be used by calculations, classification,
structure generation, property retrieval, and other parts of the Compound Handbook,
the chemical entity should be validated before the program relies upon it for a
requested chemical operation.

Validation at this level is different from validating only a ChemicalFormula,
MolecularGraph, or individual Atom.

Instead, chemical-entity validation concerns the ChemicalEntity as the overall chemical
object being processed by the Compound Handbook.

Depending upon the particular type of ChemicalEntity, its validation may involve different
rules or may rely upon more specialized validators for information contained by that entity.

This is why, IChemicalEntityValidator interface is being created to define the contract
for validating a ChemicalEntity.

The validator receives a ChemicalEntity object and returns a ValidationResult.

The returned ValidationResult can indicate whether the ChemicalEntity is considered valid
and can also contain the collection of ValidationIssue objects discovered while validating
that entity.

The interface only defines what a chemical-entity validator must be able to do.
It does not define the particular validation rules or the implementation used to perform
those checks.
*/

/*
The following IChemicalEntityValidator is an interface.

An interface defines a contract that specifies which functionality an implementing class
must provide without specifying how that functionality must be implemented.

I am using an interface here because the rest of the Compound Handbook should be able to
request validation of a ChemicalEntity without depending directly upon one particular
validator implementation.

This also allows the Application layer to work with the validation contract while the
specific validation logic remains inside the Validation system.

Any class that implements IChemicalEntityValidator must provide the Validate() method
defined by this interface.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.Validation 
{
    // The following interface defines the contract for validating a ChemicalEntity inside the Compound Handbook
    public interface IChemicalEntityValidator 
    {
        /*
        The following Validate() method receives a ChemicalEntity object and checks it
        according to the chemical-entity validation rules provided by the class that
        implements this interface.
        
        ChemicalEntity is the datatype of the parameter.
        entity is the name of the parameter.
        Therefore, the entity parameter represents the particular ChemicalEntity object 
        that needs to be validated.

        Since ChemicalEntity is the general abstraction for the chemical entities represented
        by the Compound Handbook, the object supplied through this parameter can represent
        a more specific type of chemical entity.

        ValidationResult is the return type of this method.
        This means that after the ChemicalEntity has been validated, the method returns
        a ValidationResult object.

        That ValidationResult can contain:
        (i)  IsValid : The overall Boolean validation state.
        (ii) Issues  : The collection of ValidationIssue objects discovered during validation.

        Since this is an interface method, there is no method body here.

        The actual chemical-entity validation logic will be supplied by a class that
        implements IChemicalEntityValidator.
        */
        ValidationResult Validate(ChemicalEntity entity);
    }
}