/*
The Compound Handbook can use multiple classification rules when determining the chemical
categories and applicable operations of a ChemicalEntity.

A single classification rule does not necessarily determine the complete classification
of the chemical entity.

Instead, one rule may identify only a particular part of the classification.

For example, one classification rule may determine that a chemical entity belongs to the
Organic category, while another rule may determine that the same entity belongs to the
Aromatic category.

A classification rule may also determine that certain ChemicalOperation values should
be applicable based upon the chemical information recognized by that rule.

Therefore, each classification rule needs a way to return the categories and operations
that it contributes to the overall classification process.

This is why ChemicalClassificationContribution is being created.

A ChemicalClassificationContribution object represents the classification information
contributed by one classification rule.

The ChemicalClassificationContribution itself does not represent the complete final
classification of a ChemicalEntity.

Instead, it acts as a container for the ChemicalCategory and ChemicalOperation values
contributed by a classification rule.

The Classification system can then combine the contributions produced by different
classification rules when constructing the complete ChemicalClassificationResult.
*/

/*
ChemicalClassificationContribution = Categories + Operations

(i) Categories : Stores a collection of ChemicalCategory values contributed by a classification rule.
(ii) Operations : Stores a collection of ChemicalOperation values contributed by a classification rule.

Both of these are read-only properties because they contain only a 'getter' accessor.

Therefore, these properties can be read from outside of the class, but they cannot be
directly changed from outside of the class after the ChemicalClassificationContribution
object has been constructed.

Collections are used because one classification rule may contribute more than one
ChemicalCategory or ChemicalOperation.

The following class also contains a constructor that receives the collection of
ChemicalCategory values and the collection of ChemicalOperation values required to
initialize a new ChemicalClassificationContribution object.
*/

namespace CompoundHandbook.Classification 
{
    // The following class represents the classification information contributed by a classification rule.
    public class ChemicalClassificationContribution
    {
        /*
        Read-only property that stores the ChemicalCategory values contributed by a
        classification rule.

        IReadOnlyCollection<T> is a .NET generic interface that represents a collection
        whose elements can be accessed but cannot be added or removed through this interface.

        ChemicalCategory is an enum itself, but is being used as the datatype of the
        values contained inside this collection.

        Therefore, IReadOnlyCollection<ChemicalCategory> represents a read-only collection
        containing the chemical categories contributed by the classification rule.

        A collection is used because one classification rule may contribute multiple
        ChemicalCategory values.
        */        
        public IReadOnlyCollection<ChemicalCategory> Categories { get; }

        /*
        Read-only property that stores the ChemicalOperation values contributed by a
        classification rule.

        ChemicalOperation is an enum itself, but is being used as the datatype of the
        values contained inside this collection.

        Therefore, IReadOnlyCollection<ChemicalOperation> represents a read-only collection
        containing the chemical operations contributed by the classification rule.

        A collection is used because one classification rule may contribute multiple
        ChemicalOperation values.
        */
        public IReadOnlyCollection<ChemicalOperation> Operations { get; }

        /*
        The following constructor will be called whenever a new
        ChemicalClassificationContribution object gets created.

        The constructor receives:
        (i)  The collection of ChemicalCategory values contributed by the classification rule.
        (ii) The collection of ChemicalOperation values contributed by the classification rule.

        The supplied arguments are then assigned to their corresponding read-only
        properties of the ChemicalClassificationContribution object.
        */
        public ChemicalClassificationContribution(IReadOnlyCollection<ChemicalCategory> categories, IReadOnlyCollection<ChemicalOperation> operations) 
        {
            // Stores the supplied collection of ChemicalCategory values in the Categories property.
            Categories = categories;

            // Stores the supplied collection of ChemicalOperation values in the Operations property.
            Operations = operations;
        }
    }
}