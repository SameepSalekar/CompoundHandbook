/*
The Compound Handbook needs a way to perform the complete classification of a ChemicalEntity.

The classification process can involve multiple pieces of information.

For example, after a chemical entity has been classified, the Compound Handbook may need to know:
(i)   The general ChemicalEntityType of the entity.
(ii)  The ChemicalCategory values that apply to the entity.
(iii) The ChemicalOperation values that are applicable to the entity.
(iv)  Any additional messages associated with the classification result.

Individual chemical-classification rules can contribute information to this process, but the
rest of the Compound Handbook should not need to individually execute and combine every
classification rule whenever an entity needs to be classified.

Instead, I want a common contract for the part of the Classification system responsible for
performing the overall classification of a ChemicalEntity and returning the completed result.

This is why IChemicalEntityClassifier is being created.

IChemicalEntityClassifier defines the common contract for classifying a ChemicalEntity.

Any class that implements IChemicalEntityClassifier must provide a Classify() method that
receives a ChemicalEntity and returns a ChemicalClassificationResult.

The returned ChemicalClassificationResult can then contain the EntityType, Categories,
ApplicableOperations, and Messages produced by the complete classification process.

The IChemicalEntityClassifier itself does not contain the actual classification logic.

Instead, the actual classification process will be contained inside a class that implements
this interface.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.Classification
{
    /*
    The following interface defines the common contract for performing the overall
    classification of a ChemicalEntity.

    An interface defines the members that an implementing class is required to provide.

    IChemicalEntityClassifier does not perform the chemical classification itself.

    Instead, a class that implements this interface will contain the actual classification
    process and return the completed classification result.

    The 'I' at the beginning of IChemicalEntityClassifier follows the common C# naming
    convention of beginning interface names with the letter 'I'.
    */
    public interface IChemicalEntityClassifier
    {
        /*
        The following Classify() method represents the operation that a chemical-entity
        classifier must perform.

        ChemicalEntity entity is the parameter that represents the chemical entity that needs to be classified.

        ChemicalEntity is an abstract class itself, but is being used as the parameter
        datatype here.

        Therefore, Classify() can receive an object belonging to one of the specific
        classes that inherits from ChemicalEntity, such as Molecule, IonicSolid,
        NetworkCovalentSolid, Metal, or Polymer.

        ChemicalClassificationResult is the return type of the method.

        The returned ChemicalClassificationResult acts as a container for the information
        produced by the complete classification process.

        This can include:
        (i)   The ChemicalEntityType of the entity.
        (ii)  The ChemicalCategory values that apply to the entity.
        (iii) The ChemicalOperation values that are applicable to the entity.
        (iv)  Messages associated with the classification result.

        Because this method is declared inside an interface without an implementation,
        a class that implements IChemicalEntityClassifier must provide the actual
        implementation of Classify().
        */
        ChemicalClassificationResult Classify(ChemicalEntity entity);
    }
}