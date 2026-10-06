/*
IChemicalPropertyProvider is being created to provide the Compound Handbook with a standard
way of requesting experimental-property information for a chemical entity.

The Compound Handbook may need experimental properties such as:
(i)   Melting point
(ii)  Boiling point
(iii) Density
(iv)  Other experimental properties

However, the code that needs these properties should not have to know exactly where the
property information comes from or how that information is retrieved.

For example, experimental-property information could potentially be obtained from:
(i)   An external chemical database or service.
(ii)  A local database.
(iii) Some other property-information provider.

The parts of the Compound Handbook that request experimental properties should therefore
depend upon a common contract rather than depending directly upon one particular
property-data implementation.

This is why IChemicalPropertyProvider is being created.

IChemicalPropertyProvider acts as an abstraction between the code that requests experimental
properties and the code that actually retrieves those properties.

The request itself is represented using a PropertyQuery object.

The result of the retrieval operation is represented using a PropertyRetrievalResult object.

This is how the general relationship will be represented:
PropertyQuery -> IChemicalPropertyProvider -> PropertyRetrievalResult

The PropertyQuery describes:
(i)  Which ChemicalEntity the properties are being requested for.
(ii) Which ExperimentalPropertyKind values are being requested.

The PropertyRetrievalResult contains:
(i)  The ExperimentalProperty objects that were retrieved.
(ii) Messages associated with the retrieval operation.

IChemicalPropertyProvider only defines the contract for performing this operation.
It does not specify how or from where the experimental-property information is actually retrieved.

The actual retrieval process will be provided by a separate class that implements this interface.
*/

/*
The following IChemicalPropertyProvider is an interface.

An interface defines a contract that describes what operations an implementing class must
provide without defining the actual implementation of those operations here.

The 'I' at the beginning of IChemicalPropertyProvider follows the common C# naming convention
of beginning interface names with the letter 'I'.

IChemicalPropertyProvider defines the operation of GetProperties(PropertyQuery query)
This operation receives a PropertyQuery object describing the requested experimental
properties and returns a PropertyRetrievalResult containing the result of that request.
The method inside this interface contains a method declaration but does not contain
a method body.

IChemicalPropertyProvider specifies what operation must be available without
specifying how that operation retrieves the experimental-property information.

A class that implements IChemicalPropertyProvider will provide the actual method body
and therefore determine how the requested properties are obtained.
*/

namespace CompoundHandbook.DataContracts 
{
    /*
    The following interface defines the operation that must be provided by an
    experimental-property provider used by the Compound Handbook.

    The 'public' access modifier allows this interface to be accessed from outside
    of the CompoundHandbook.DataContracts namespace.

    The 'interface' keyword specifies that IChemicalPropertyProvider is an interface
    rather than a class.
    */    
    public interface IChemicalPropertyProvider 
    {
        /*
        The following method is used to request experimental properties for a
        particular ChemicalEntity.

        PropertyQuery is the datatype of the query parameter.

        The PropertyQuery object contains the information describing:
        (i)  Which ChemicalEntity the experimental properties are being requested for.
        (ii) Which ExperimentalPropertyKind values should be requested.

        PropertyRetrievalResult is the return datatype of this method.

        Therefore, when GetProperties() is called with a PropertyQuery object,
        the provider is expected to return a PropertyRetrievalResult containing
        the retrieved ExperimentalProperty objects and any messages associated
        with the retrieval operation.

        This interface only declares the operation.

        The actual process used to retrieve the experimental-property information
        will be defined by the class that implements IChemicalPropertyProvider.
        */        
        PropertyRetrievalResult GetProperties(PropertyQuery query);
    }
}