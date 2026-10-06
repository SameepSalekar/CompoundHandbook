/*
When the Compound Handbook retrieves an experimental property from a property provider,
it may be useful to temporarily store that retrieved property so that the same information
does not have to be retrieved again every time it is requested.

This temporarily stored information is referred to as cached information.

However, when the Compound Handbook later searches the cache, it needs a way to identify
exactly which cached property it is looking for.

Knowing only the ChemicalEntity is not sufficient because one chemical entity can have
multiple experimental properties.

For example, the same chemical entity could have cached information for:
(i)   Melting point
(ii)  Boiling point
(iii) Density

Knowing only the type of experimental property is also not sufficient because the same
property type can belong to many different chemical entities.

The Compound Handbook may also obtain property information from different providers.
Therefore, the provider associated with the cached property must also be distinguishable.

This is why PropertyCacheKey is being created.

The PropertyCacheKey itself does not store the experimental property value.

Instead, it provides the identifying information that can be used when looking up
the corresponding cached property entry.
*/

/*
The following PropertyCacheKey class represents the identifying key used for an
experimental-property cache entry inside the Compound Handbook.

PropertyCacheKey = EntityId + PropertyKind + ProviderKey

(i) EntityId: Stores the Id of the ChemicalEntity associated with the cached property.
(ii) PropertyKind: Stores the ExperimentalPropertyKind identifying the type of experimental property.
(iii) ProviderKey: Stores a string used to identify the property provider associated with the cached information.

All three of these are read-only properties because they contain only a 'getter' accessor.

Therefore, these properties can be read from outside of the class, but they cannot be
directly changed from outside of the class after the PropertyCacheKey object has
been constructed.

The following class also contains a constructor that receives the EntityId,
ExperimentalPropertyKind, and ProviderKey required to initialize a new
PropertyCacheKey object.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.DataContracts 
{
    // The following class represents the identifying key used when accessing an experimental-property cache entry.
    public class PropertyCacheKey
    {
        /*
        Read-only property that stores the Id of the ChemicalEntity associated
        with the cached experimental property.

        The datatype here is string.

        Instead of storing the entire ChemicalEntity object inside the cache key,
        this property stores the entity's identifying string.
        */        
        public string EntityId { get; }

        /*
        Read-only property that stores the type of experimental property
        associated with this cache key.

        ExperimentalPropertyKind is an enum itself, but is being used as the
        datatype of this property.

        Therefore, the value of PropertyKind must be one of the named values
        defined inside the ExperimentalPropertyKind enumeration, such as
        MeltingPoint, BoilingPoint, Density, or Other.
        */
        public ExperimentalPropertyKind PropertyKind { get; }

        /*
        Read-only property that stores the key identifying the property provider
        associated with this cached information.

        The datatype here is string.

        This allows cached information associated with different property providers
        to be distinguished even when the EntityId and PropertyKind are the same.
        */
        public string ProviderKey { get; }

        /*
        The following constructor will be called whenever a new PropertyCacheKey
        object gets created.

        The constructor receives:
        (i)   A string containing the ChemicalEntity Id.
        (ii)  An ExperimentalPropertyKind identifying the type of property.
        (iii) A string containing the provider key.

        The supplied arguments are then assigned to their corresponding read-only
        properties of the PropertyCacheKey object.
        */
        public PropertyCacheKey(string entityId, ExperimentalPropertyKind propertyKind, string providerKey) 
        {
            // Stores the supplied ChemicalEntity identifier in the EntityId property.
            EntityId = entityId;

            // Stores the supplied ExperimentalPropertyKind value in the PropertyKind property.
            PropertyKind = propertyKind;

            // Stores the supplied property-provider identifier in the ProviderKey property.
            ProviderKey = providerKey;
        }
    }
}