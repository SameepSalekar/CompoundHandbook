/*
When the Compound Handbook attempts to retrieve experimental properties for a chemical entity,
the result of that operation needs to contain more information than only the property values.

The property-retrieval process may successfully retrieve one or more experimental properties,
such as:
(i)   Melting point
(ii)  Boiling point
(iii) Density
(iv)  Other experimental properties

However, the retrieval process may also need to provide additional information about what
happened while retrieving those properties.

For example, messages could later be used to describe situations in which certain requested
properties could not be found, only some of the requested properties were retrieved, or other
information needs to be communicated by the property-retrieval process.

The Compound Handbook therefore needs a single object that can contain:
(i)  The experimental properties that were retrieved.
(ii) Messages associated with the property-retrieval operation.

This is why PropertyRetrievalResult is being created.

A PropertyRetrievalResult object represents the result produced after an experimental-property
retrieval operation.

The PropertyRetrievalResult itself does not perform the retrieval of experimental properties.

Instead, it acts as a container for the information produced by that retrieval operation so
that another part of the Compound Handbook can receive and use the result.
*/

/*
The following PropertyRetrievalResult class represents the result of an experimental-property
retrieval operation inside the Compound Handbook.

PropertyRetrievalResult = Collection of Experimental Properties + Collection of Messages

(i) Properties: Stores the collection of ExperimentalProperty objects that were retrieved.
(ii) Messages: Stores a collection of text messages associated with the property-retrieval operation.

Both of these are read-only properties because they contain only a 'getter' accessor.

Therefore, these properties can be read from outside of the class, but they cannot be directly
changed from outside of the class after the PropertyRetrievalResult object has been constructed.

The following class also contains a constructor that receives the collection of
ExperimentalProperty objects and the collection of messages required to initialize a new
PropertyRetrievalResult object.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.DataContracts 
{
    // The following class represents the result produced by an experimental-property retrieval operation.
    public class PropertyRetrievalResult 
    {
        /*
        Read-only property that stores the experimental properties that were retrieved.

        IReadOnlyCollection<T> is a .NET generic interface that represents a collection
        whose elements can be accessed but cannot be added or removed through this interface.

        ExperimentalProperty is a class itself, but is being used as the datatype of the
        objects contained inside this collection.

        Therefore, IReadOnlyCollection<ExperimentalProperty> represents a read-only
        collection containing ExperimentalProperty objects.

        Each ExperimentalProperty object represents one experimental-property measurement
        associated with the requested chemical entity.
        */        
        public IReadOnlyCollection<ExperimentalKind> Properties { get; }

        /*
        Read-only property that stores messages associated with the property-retrieval operation.

        IReadOnlyCollection<string> represents a read-only collection whose individual
        elements have the string datatype.

        Each string can contain a message produced during the property-retrieval process.
        */
        public IReadOnlyCollection<string> Messages { get; }

        /*
        The following constructor will be called whenever a new PropertyRetrievalResult
        object gets created.
        The constructor will recieve all the experimental properties that were retrieved,
        and messages associated with the retrieval operation.
        The supplied arguments are then assigned to their corresponding read-only properties of 
        the PropertyRetrievalResult object.
        */
        public PropertyRetrievalResult(IReadOnlyCollection<ExperimentalKind> properties, IReadOnlyCollection<string> messages) 
        {
            // Stores the supplied collection of ExperimentalKind objects in the Properties property.
            Properties = properties;

            // Stores the supplied collection of messages in the Messages property.
            Messages = messages;
        }
    }
}