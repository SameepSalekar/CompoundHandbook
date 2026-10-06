/*
A chemical entity can have many different experimentally measured chemical and physical properties.

For example, a chemical substance may have experimental information describing:
(i)   Melting point
(ii)  Boiling point
(iii) Density
(iv)  Other experimental properties

However, the Compound Handbook may not always need to retrieve every available experimental property
for a particular chemical entity.

For example, the user may only request the melting point and density of a particular chemical entity.

The Compound Handbook therefore needs a way to describe:
(i)  Which ChemicalEntity the experimental-property request is for.
(ii) Which types of experimental properties should be retrieved.

This is why PropertyQuery is being created.

A PropertyQuery object represents a request for particular types of experimental properties
associated with one ChemicalEntity.

The PropertyQuery itself does not retrieve the experimental properties.

Instead, it contains the information describing what properties are being requested.
Another part of the Compound Handbook can then receive this PropertyQuery and use it when
retrieving the requested experimental-property information.
*/

/*
The following PropertyQuery class represents one request for experimental properties
inside the Compound Handbook.

PropertyQuery = ChemicalEntity + Collection of Requested Experimental Property Kinds

(i) Entity: Stores the ChemicalEntity whose experimental properties are being requested.

(ii) RequestedKinds: Stores the collection of ExperimentalPropertyKind values describing which types of experimental properties are being requested.

Both of these are read-only properties because they contain only a 'getter' accessor.

Therefore, these properties can be read from outside of the class, but they cannot be
directly changed from outside of the class after the PropertyQuery object has been constructed.

The following class also contains a constructor that receives the ChemicalEntity and
collection of ExperimentalPropertyKind values required to initialize a new PropertyQuery object.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.DataContracts
{
    // The following class represents a request for particular experimental properties associated with a ChemicalEntity.
    public class PropertyQuery 
    {
        /*
        Read-only property that stores the ChemicalEntity whose experimental properties
        are being requested.

        ChemicalEntity is an abstract class itself, but is being used as the datatype
        of this property.

        Therefore, the Entity property can reference an object belonging to a specific
        class that inherits from ChemicalEntity, such as Molecule, IonicSolid,
        NetworkCovalentSolid, Metal, or Polymer.
        */        
        public ChemicalEntity Entity { get; }

        /*
        Read-only property that stores the types of experimental properties
        being requested.

        IReadOnlyCollection<T> is a .NET generic interface that represents a collection
        whose elements can be accessed but cannot be added or removed through this interface.

        ExperimentalPropertyKind is an enum itself and is being used as the type of
        objects contained inside this collection.

        Therefore, IReadOnlyCollection<ExperimentalPropertyKind> represents a read-only
        collection of ExperimentalPropertyKind values.

        Each value identifies one type of experimental property that should be requested,
        such as MeltingPoint, BoilingPoint, Density, or Other.
        */        
        public IReadOnlyCollection<ExperimentalPropertyKind> RequestedKinds { get; }
        
        /*
        The following constructor will be called whenever a new PropertyQuery object gets created.

        The constructor receives:
        (i)  A ChemicalEntity object representing the chemical entity whose properties are requested.
        (ii) An IReadOnlyCollection<ExperimentalPropertyKind> representing the types of experimental properties being requested.

        The supplied arguments are then assigned to their corresponding read-only properties
        of the PropertyQuery object.
        */        
        public PropertyQuery(ChemicalEntity entity, IReadOnlyCollection<ExperimentalPropertyKind> requestedKinds) 
        {
            // Stores the supplied ChemicalEntity object in the Entity property.
            Entity = entity;

            // Stores the supplied collection of requested experimental-property kinds in the RequestedKinds property.
            RequestedKinds = requestedKinds;
        }
    }
}