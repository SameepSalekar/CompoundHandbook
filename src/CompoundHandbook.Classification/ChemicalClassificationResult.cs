/*
When the Compound Handbook classifies a chemical entity, the result of that classification
needs to contain more information than only the general ChemicalEntityType.

The Classification system also needs to determine which ChemicalOperation values are
applicable to the classified chemical entity.

For example, depending upon the chemical entity, applicable operations could include
calculating molar mass, generating chemical structures, detecting functional groups,
or retrieving experimental properties.

The classification process may also need to return additional messages associated with
the classification result.

The Compound Handbook therefore needs a single object that can contain:
(i)   The general ChemicalEntityType of the entity.
(ii)  The ChemicalCategory values that apply to the entity.
(iii) The ChemicalOperation values that are applicable to the entity.
(iv)  Messages associated with the classification result.

This is why ChemicalClassificationResult is being created.

A ChemicalClassificationResult object represents the result produced after a chemical
entity has been classified.

The ChemicalClassificationResult itself does not perform the classification.

Instead, it acts as a container for the information produced by the Classification system
so that other parts of the Compound Handbook can receive and use the classification result.
*/

/*
ChemicalClassificationResult = EntityType + Categories + ApplicableOperations + Messages

(i)   EntityType           : Stores the general ChemicalEntityType of the classified entity.
(ii)  Categories           : Stores a collection of ChemicalCategory values that apply to the entity.
(iii) ApplicableOperations : Stores a collection of ChemicalOperation values that can be performed for the entity.
(iv)  Messages             : Stores a collection of messages associated with the classification result.

All four of these are read-only properties because they contain only a 'getter' accessor.

Therefore, these properties can be read from outside of the class, but they cannot be directly
changed from outside of the class after the ChemicalClassificationResult object has been constructed.

The following class also contains a constructor that receives the ChemicalEntityType,
collection of ChemicalCategory values, collection of ChemicalOperation values, and collection
of messages required to initialize a new ChemicalClassificationResult object.
*/

namespace CompoundHandbook.Classification 
{
    // The following class represents the result produced by the chemical-classification process.
    public class ChemicalClassificationResult
    {
        /*
        Read-only property that stores the general type of the classified chemical entity.

        ChemicalEntityType is an enum itself, but is being used as the datatype of this property.

        The value of EntityType can therefore represent whether the classified entity is a
        Molecule, IonicSolid, NetworkCovalentSolid, Metal, Polymer, or Unknown.

        Unlike Categories and ApplicableOperations, EntityType stores one value because it
        represents the general type of ChemicalEntity that was determined by the
        Classification system.
        */
        public ChemicalEntityType EntityType { get; }


        /*
        Read-only property that stores the ChemicalCategory values that apply to the
        classified chemical entity.

        IReadOnlyCollection<T> is a .NET generic interface that represents a collection
        whose elements can be accessed but cannot be added or removed through this interface.

        ChemicalCategory is an enum itself, but is being used as the datatype of the
        values contained inside this collection.

        Therefore, IReadOnlyCollection<ChemicalCategory> represents a read-only collection
        containing the chemical categories that apply to the entity.

        A collection is required because one chemical entity can belong to multiple
        ChemicalCategory values at the same time.
        */
        public IReadOnlyCollection<ChemicalCategory> Categories { get; }


        /*
        Read-only property that stores the ChemicalOperation values that are applicable
        to the classified chemical entity.

        ChemicalOperation is an enum itself, but is being used as the datatype of the
        values contained inside this collection.

        Therefore, IReadOnlyCollection<ChemicalOperation> represents a read-only collection
        containing the operations that the Compound Handbook can meaningfully perform for
        the classified entity.

        A collection is required because multiple ChemicalOperation values can be applicable
        to the same chemical entity.
        */
        public IReadOnlyCollection<ChemicalOperation> ApplicableOperations { get; }


        /*
        Read-only property that stores messages associated with the chemical-classification result.

        IReadOnlyCollection<string> represents a read-only collection whose individual
        elements have the string datatype.

        Each string can contain additional information produced during the
        chemical-classification process.

        These messages allow the Classification system to provide additional information
        about the result that is not represented by EntityType, Categories, or
        ApplicableOperations alone.
        */        
        public IReadOnlyCollection<string> Messages { get; }


        /*
        The following constructor will be called whenever a new
        ChemicalClassificationResult object gets created.

        The constructor receives:
        (i)   The ChemicalEntityType determined for the chemical entity.
        (ii)  The collection of ChemicalCategory values that apply to the entity.
        (iii) The collection of ChemicalOperation values that are applicable to the entity.
        (iv)  The collection of messages associated with the classification result.

        The supplied arguments are then assigned to their corresponding read-only
        properties of the ChemicalClassificationResult object.
        */
        public ChemicalClassificationResult(ChemicalEntityType entityType, IReadOnlyCollection<ChemicalCategory> categories, IReadOnlyCollection<ChemicalOperation> applicableOperations, IReadOnlyCollection<string> messages)
        {
            // Stores the supplied ChemicalEntityType in the EntityType property.
            EntityType = entityType;

            // Stores the supplied collection of ChemicalCategory values in the Categories property.
            Categories = categories;

            // Stores the supplied collection of ChemicalOperation values in the ApplicableOperations property.
            ApplicableOperations = applicableOperations;

            // Stores the supplied collection of messages in the Messages property.
            Messages = messages;
        }
    }
}