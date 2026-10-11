/*
After the Compound Handbook determines the type and ChemicalCategory values of a
ChemicalEntity, it still needs to determine which ChemicalOperation values are
actually appropriate for that entity.

Not every chemical operation is meaningful for every type of chemical entity.

For example, a Molecule may support operations such as generating a molecular formula,
Lewis structure, condensed structure, or skeletal structure.

However, an IonicSolid is better represented using a formula unit because it forms an
extended ionic lattice rather than existing as individual discrete molecules.

Similarly, a Polymer may be more appropriately represented using a repeat unit rather
than attempting to represent the complete macromolecular chain.

The ChemicalCategory values of an entity can also provide information that affects which
operations are meaningful.

Therefore, the applicability of an operation can depend upon both:
(i)  The ChemicalEntity being analyzed.
(ii) The ChemicalCategory values that have been determined for that entity.

I do not want the decision about which operations are applicable to be scattered throughout
the different parts of the Compound Handbook.

Instead, I want a common contract for the part of the Classification system responsible
for making these applicability decisions.

This is why IEntityApplicabilityPolicy is being created.

IEntityApplicabilityPolicy defines the common contract for determining which
ChemicalOperation values are applicable to a classified ChemicalEntity.

Any class that implements IEntityApplicabilityPolicy must provide a
GetApplicableOperations() method that receives the ChemicalEntity and its collection of
ChemicalCategory values and returns the ChemicalOperation values that are applicable.

The IEntityApplicabilityPolicy itself does not contain the actual rules for determining
operation applicability.

Instead, the actual applicability logic will be contained inside a class that implements
this interface.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.Classification
{
    /*
    The following interface defines the common contract for determining which
    ChemicalOperation values are applicable to a ChemicalEntity.

    An interface defines the members that an implementing class is required to provide.

    IEntityApplicabilityPolicy does not perform the applicability decision itself.

    Instead, a class that implements this interface will contain the actual rules used
    to determine which operations are chemically appropriate for an entity.

    The 'I' at the beginning of IEntityApplicabilityPolicy follows the common C#
    naming convention of beginning interface names with the letter 'I'.
    */
    public interface IEntityApplicabilityPolicy
    {
        /*
        The following GetApplicableOperations() method represents the operation that an
        entity-applicability policy must perform.

        The method receives two parameters:
        (i) ChemicalEntity entity
        (ii) IReadOnlyCollection<ChemicalCategory> categories

        ChemicalEntity entity represents the chemical entity whose applicable operations need to be determined.
        ChemicalEntity is an abstract class itself, but it is being used as the parameter datatype here.
        Therefore, this parameter can reference an object belonging to one of the specific classes that 
        inherits from ChemicalEntity, such as Molecule, IonicSolid, NetworkCovalentSolid, Metal, or Polymer.


        IReadOnlyCollection<ChemicalCategory> categories represents the ChemicalCategory values that have 
        already been determined to apply to the chemical entity.

        IReadOnlyCollection<T> is a .NET generic interface that represents a collection
        whose elements can be accessed but cannot be added or removed through this interface.

        ChemicalCategory is an enum itself, but is being used as the datatype of the
        values contained inside this collection.

        Therefore, IReadOnlyCollection<ChemicalCategory> represents a read-only collection
        containing the categories that can be considered when determining which operations
        are appropriate for the entity.

        IReadOnlyCollection<ChemicalOperation> is the return type of the method.

        ChemicalOperation is an enum itself, but is being used as the datatype of the
        values contained inside the returned collection.

        Therefore, the method returns a read-only collection containing all of the
        ChemicalOperation values determined to be applicable to the supplied chemical entity.

        Because this method is declared inside an interface without an implementation,
        a class that implements IEntityApplicabilityPolicy must provide the actual
        implementation of GetApplicableOperations().
        */

        IReadOnlyCollection<ChemicalOperation> GetApplicableOperations(ChemicalEntity entity, IReadOnlyCollection<ChemicalCategory> categories);
    }
}