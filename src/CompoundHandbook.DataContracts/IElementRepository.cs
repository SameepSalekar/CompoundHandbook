/*
IElementRepository is being created to provide the Compound Handbook 
with a standard way of retrieving Element objects.

The Element class itself belongs to the Domain and represents one chemical element
that contains the following information:
(i)   AtomicNumber
(ii)  Symbol
(iii) Name
(iv)  StandardAtomicWeight

The Element class only describes what information an Element object contains.
It does not describe where the Compound Handbook should obtain those Element objects from.

Elemental information could potentially be stored:
(i)   Directly inside the program as embedded data.
(ii)  Inside a local file.
(iii) Inside a database.
(iv)  Through some other external data source.

The Core Chemistry code should not have to know which particular storage method is being used
whenever it needs information about an element.

This is why IElementRepository is being created.

The repository acts as an abstraction between the code that needs Element objects and the
code that actually stores or retrieves the elemental information.

The Compound Handbook will contain different parts of the program that require access to
elemental information. These parts of the program should not need to know how or where the 
elemental data is stored in order to retrieve the Element objects that they require. Instead, 
they can request the required Element objects through IElementRepository.

IElementRepository defines a common contract for accessing elemental information
without defining the particular way in which that information is stored or retrieved.

The actual retrieval of the elemental data will be handled by a separate class that implements
this interface.

This separation allows the parts of the Compound Handbook that require elemental information
to depend upon the IElementRepository contract instead of depending directly upon a particular
data-storage implementation.
*/

/*
The following IElementRepository is an interface.

An interface defines a contract that describes what operations an implementing class must
provide without defining the actual implementation of those operations here.

The 'I' at the beginning of IElementRepository follows the common C# naming convention
of beginning interface names with the letter 'I'.

IElementRepository defines three operations:
(i)   Find an Element using its atomic number.
(ii)  Find an Element using its chemical symbol.
(iii) Retrieve all available Element objects.

The methods inside this interface contain method declarations but do not contain method bodies.

It does not specify how the Element is actually found.

A class that implements IElementRepository will provide the actual method bodies and therefore
decide how the elemental information is retrieved.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.DataContracts 
{
    /*
    The following interface defines the operations that must be provided by an elemental-data
    repository used by the Compound Handbook

    The 'public'  access modifier allows this interface to be accessed from outside of the
    CompoundHandbook.DataContracts namespace.

    The 'interface' keyword specifies that IElementRepository is an interface rather than a class.
    */
    public interface IElementRepository
    {
        /* 
        The following method is used to find an Element using its atomic number
        The return datatype is Element.
        Therefore, when this method is called with an atomic number, the repository is expected
        to return the corresponding Element object.
        This interface only declares the operation.The actual process used to search for and 
        retrieve the Element will be defined by the class that implements IElementRepository.
        */
        Element FindByAtomicNumber (int atomicNumber);

        /*
        The following method is used to find an Element using its chemical symbol.
        The return datatype is Element.
        Therefore, when this method is called with a chemical symbol, the repository is expected
        to return the corresponding Element object.
        This interface only declares the operation. The actual process used to search for and
        retrieve the Element will be defined by the class that implements IElementRepository.
        */
        Element FindBySymbol (string symbol);

        /*
        The following method is used to retrieve all of the Element objects available through
        the repository.
        The return datatype is IReadOnlyCollection<Element>.

        IReadOnlyCollection is a .NET generic interface that represents a collection whose
        elements can be accessed but cannot be added or removed through this interface.

        Element is the datatype of the objects contained inside this collection.
        Therefore, IReadOnlyCollection<Element> represents a read-only collection of
        Element objects.

        This interface only declares the operation. The actual process used to retrieve the
        collection of Element objects will be defined by the class that implements
        IElementRepository.
        */
        IReadOnlyCollection<Element> GetAll();
    }
}