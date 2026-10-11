/*
The Compound Handbook can use multiple classification rules to determine which
ChemicalCategory and ChemicalOperation values apply to a ChemicalEntity.

Different classification rules can examine different chemical characteristics.

For example, one classification rule could determine whether a chemical entity should
be classified as Organic, while another rule could determine whether the entity should
be classified as Aromatic.

I do not want the main Classification system to contain all of these different
classification rules directly inside one large block of code.

Instead, I want each classification rule to be implemented separately while still
following the same basic structure.

Every classification rule needs to:
(i)  Receive a ChemicalEntity that needs to be evaluated.
(ii) Evaluate that chemical entity according to the particular rule.
(iii) Return the ChemicalCategory and ChemicalOperation values contributed by that rule.

This is why IChemicalClassificationRule is being created.

IChemicalClassificationRule defines the common contract that every chemical-classification
rule must follow.

Any class that implements IChemicalClassificationRule must provide an Evaluate() method
that receives a ChemicalEntity and returns a ChemicalClassificationContribution.

This allows the Classification system to work with different classification-rule
implementations through the same interface without needing to know the internal logic
used by each individual rule.

Therefore, new classification rules can later be added to the Compound Handbook by
creating additional classes that implement IChemicalClassificationRule.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.Classification
{
    /*
    The following interface defines the common contract that must be followed by
    chemical-classification rules inside the Compound Handbook.

    An interface defines the members that an implementing class is required to provide.

    IChemicalClassificationRule does not contain the actual chemical-classification
    logic itself.

    Instead, the actual classification logic will be contained inside the classes
    that implement this interface.

    The 'I' at the beginning of IChemicalClassificationRule follows the common C#
    naming convention of beginning interface names with the letter 'I'.
    */
    public interface IChemicalClassificationRule 
    {
        /*
        The following Evaluate() method represents the operation that a
        chemical-classification rule must perform.

        ChemicalEntity entity is the parameter represents the chemical entity that the classification rule
        will evaluate.

        ChemicalEntity is an abstract class itself, but it is being used as the
        parameter datatype here.

        Therefore, Evaluate() can receive an object belonging to one of the specific
        classes that inherits from ChemicalEntity, such as Molecule, IonicSolid,
        NetworkCovalentSolid, Metal, or Polymer.

        ChemicalClassificationContribution is the return type of the method.

        The returned ChemicalClassificationContribution contains the ChemicalCategory
        and ChemicalOperation values contributed by this particular classification rule.

        Because this method is declared inside an interface without an implementation,
        a class that implements IChemicalClassificationRule must provide the actual
        implementation of Evaluate().
        */
        ChemicalClassificationContribution Evaluate(ChemicalEntity entity);
    }
}