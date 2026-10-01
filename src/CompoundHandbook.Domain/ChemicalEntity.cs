/*
Chemical Entity = (Internal ID) + (Display Name) + (Collection of Chemical Identifiers)

A chemical entity represents the general idea of something that can be stored and identified 
inside the Compound Handbook.

Example:-
Id: "CaCO3"
Display Name: Calcium Carbonate
Identifiers:
Common Name     -> "Chalk"
Systematic Name -> "Calcium Carbonate"
SMILES          -> "[Ca+2].[O-]C([O-])=O"
InChI           -> "InChI=1S/CH2O3.Ca/c2-1(3)4;/h(H2,2,3,4);/q;+2/p-2"
InChiKey        -> "VTYYLEPIZMXCLO-UHFFFAOYSA-L"

The following ChemicalEntity class contains three read-only properties to store"
(i)   Id          : Stores the internal ID of the chemical entity
(ii)  DisplayName : Stores the name of the chemical entity that will be displayed to the user
(iii) Identifiers : Stores a collection of ChemicalIdentifier objects associated with the chemical entity

All the above mentioned, are the read-only properties because of them containing the only 'getter' accessor.

All the above mentioned read-only properties also cannot be changed directly from outside of the class after
the object has been constructed

One ChemicalEntity object can be associated with multiple ChemicalIdentifier objects. 

ChemicalEntity class is an abstract class, a class that is designed to act as a base class for other classes.

An object cannot be directly created directly from an abstract class

Therefore, instead of directly creating the object, the different specific class have to inherit from the
ChemicalEntity and receive the common properties and functionality that are defined inside this class.

The following class also contains a constructor, basically a special class member that initializes a new object
when it is created.

The constructor is using the 'protected' access modifier due to this class being an abstract base class.

'protected' access modifier will allow the classes, that inherit from the ChemicalEntity, to call this 
constructor and initialize the properties that every ChemicalEntity must contain.
*/

namespace CompoundHandbook.Domain
{
    public abstract class ChemicalEntity
    {
        // Read-only property that stores the internal 'Id' of the chemical entity
        // The datatype here is string
        public string Id { get; }

        // Read-only property that stores the 'DisplayName' of the chemical entity
        // The datatype here is string
        public string DisplayName { get; }

        /* 
        Read-only property that stores the collection of ChemicalIdentifier objects 
        associated with the chemical entity 
        
        IReadOnlyCollection here is a .NET generic interface that will represent a collection whose elements
        can be accessed but cannot be added or removed through this interface. 
        
        The collection contains ChemicalIdentifier objects.
        */
        public IReadOnlyCollection<ChemicalIdentifier> Identifiers { get; }

        // The supplied arguments in the following contructor are assigned to their corresponding read-only properties
        // This constructor is intended to be called by the contructors of classes that inherit from ChemicalEntity
        protected ChemicalEntity(string id, string displayName, IReadOnlyCollection<ChemicalIdentifier> identifiers)
        {
            Id = id;
            DisplayName = displayName;
            Identifiers = identifiers;
        }
    }
}