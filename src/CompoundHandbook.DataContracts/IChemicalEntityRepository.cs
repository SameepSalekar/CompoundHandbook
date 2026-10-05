/*
IChemicalEntityRepository is being created to provide the Compound Handbook
with a standard way of retrieving ChemicalEntity objects.

The ChemicalEntity abstract class itself belongs to the Domain and represents the general
idea of a chemical entity that can be stored and identified inside the Compound Handbook.

The different specific types of ChemicalEntity can include:
(i)   Molecule
(ii)  IonicSolid
(iii) NetworkCovalentSolid
(iv)  Metal
(v)   Polymer

The ChemicalEntity class and its derived classes describe how the different chemical entities
are represented inside the Compound Handbook. They do not describe where the Compound Handbook
should obtain those ChemicalEntity objects from.

Chemical-entity information could potentially be stored:
(i)   Directly inside the program as embedded data.
(ii)  Inside a local file.
(iii) Inside a database.
(iv)  Through some other external data source.

The Core Chemistry code should not have to know which particular storage method is being used
whenever it needs information about a chemical entity.

This is why IChemicalEntityRepository is being created.

The repository acts as an abstraction between the code that needs ChemicalEntity objects and
the code that actually stores or retrieves the chemical-entity information.

The Compound Handbook will contain different parts of the program that require access to
chemical-entity information. These parts of the program should not need to know how or where
the chemical-entity data is stored in order to retrieve the ChemicalEntity objects that they
require. Instead, they can request the required ChemicalEntity objects through
IChemicalEntityRepository.

IChemicalEntityRepository defines a common contract for accessing chemical-entity information
without defining the particular way in which that information is stored or retrieved.

The actual retrieval of the chemical-entity data will be handled by a separate class that
implements this interface.

This separation allows the parts of the Compound Handbook that require chemical-entity
information to depend upon the IChemicalEntityRepository contract instead of depending
directly upon a particular data-storage implementation.
*/

/*
The following IChemicalEntityRepository is an interface.

An interface defines a contract that describes what operations an implementing class must
provide without defining the actual implementation of those operations here.

The 'I' at the beginning of IChemicalEntityRepository follows the common C# naming convention
of beginning interface names with the letter 'I'.

IChemicalEntityRepository defines three operations:
(i)   Find a ChemicalEntity using its Id.
(ii)  Find ChemicalEntity objects using a ChemicalIdentifier.
(iii) Find ChemicalEntity objects using a ChemicalFormula.

The methods inside this interface contain method declarations but do not contain method bodies.

It does not specify how the ChemicalEntity objects are actually found.

A class that implements IChemicalEntityRepository will provide the actual method bodies and
therefore decide how the chemical-entity information is retrieved.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.DataContracts
{
    /*
    The following interface defines the operations that must be provided by a chemical-entity-data
    repository used by the Compound Handbook.

    The 'public' access modifier allows this interface to be accessed from outside of the
    CompoundHandbook.DataContracts namespace.

    The 'interface' keyword specifies that IChemicalEntityRepository is an interface rather
    than a class.
    */    
    public interface IChemicalEntityRepository 
    {
        /*
        The following method is used to find a ChemicalEntity using its Id.
        The return datatype is ChemicalEntity.
        Therefore, when this method is called with an Id, the repository is expected to return
        the corresponding ChemicalEntity object.
        This interface only declares the operation. The actual process used to search for and
        retrieve the ChemicalEntity will be defined by the class that implements
        IChemicalEntityRepository.
        */        
        ChemicalEntity FindById(string Id);

        /*
        The following method is used to find ChemicalEntity objects using a ChemicalIdentifier.

        ChemicalIdentifier is a class itself, but is being used as the datatype of the
        identifier parameter.

        The ChemicalIdentifier object contains the type and value of the identifier that will
        be used to search for the corresponding chemical entities.

        The return datatype is IReadOnlyCollection<ChemicalEntity>.

        IReadOnlyCollection is a .NET generic interface that represents a collection whose
        elements can be accessed but cannot be added or removed through this interface.

        ChemicalEntity is the datatype of the objects contained inside this collection.

        Therefore, IReadOnlyCollection<ChemicalEntity> represents a read-only collection of
        ChemicalEntity objects.

        This interface only declares the operation. The actual process used to search for and
        retrieve the ChemicalEntity objects will be defined by the class that implements
        IChemicalEntityRepository.
        */        
        IReadOnlyCollection<ChemicalEntity> FindByIdentifier(ChemicalIdentifier identifier);

        /*
        The following method is used to find ChemicalEntity objects using a ChemicalFormula.

        ChemicalFormula is a class itself, but is being used as the datatype of the
        formula parameter.

        The ChemicalFormula object contains the chemical-formula information that will be used
        to search for the corresponding chemical entities.

        The return datatype is IReadOnlyCollection<ChemicalEntity>.

        IReadOnlyCollection<ChemicalEntity> represents a read-only collection containing
        ChemicalEntity objects.

        The collection is used because a chemical formula may correspond to more than one
        ChemicalEntity stored by the Compound Handbook.

        This interface only declares the operation. The actual process used to search for and
        retrieve the ChemicalEntity objects will be defined by the class that implements
        IChemicalEntityRepository.
        */        
        IReadOnlyCollection<ChemicalEntity> FindByFormula(ChemicalFormula formula);
    }
}