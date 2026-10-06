/*
When the Compound Handbook retrieves experimental-property information, it may store
that information inside a cache.

A cache allows previously retrieved property information to be reused instead of
requiring the Compound Handbook to retrieve the same information from a property
provider every time it is requested.

For example, suppose the boiling point of a particular chemical entity has already
been retrieved from a property provider.

Instead of immediately contacting that provider again when the same property is
requested, the Compound Handbook can first search the cache to determine whether
a previously retrieved value is available.

The property-cache system therefore needs to support two fundamental operations:
(i)  Looking for an existing cached property.
(ii) Storing a property inside the cache so that it can be found later.

This is why IChemicalPropertyCache is being created.

IChemicalPropertyCache defines the common contract that any experimental-property
cache implementation must follow.
This interface defines the operations of Lookup(PropertyCacheKey key) and Set(PropertyCacheKey key, CachedPropertyEntry entry)

The interface itself does not determine how the cached information is actually stored.

For example, one implementation could store cached information temporarily in memory,
while another implementation could store cached information in a database.

Both implementations can still be used through the same IChemicalPropertyCache
interface as long as they provide the Lookup() and Set() operations defined here.

This separates the Core Chemistry code from the specific technology used to
implement the cache.
*/

/*
The following IChemicalPropertyCache is an interface.

An interface defines a contract describing the operations that an implementing
class must provide.

The 'I' at the beginning of IChemicalPropertyCache follows the common C# naming
convention of beginning interface names with the letter 'I'.

IChemicalPropertyCache defines two methods, in which Lookup() searches for the cached experimental property
and Set() stores a cached experimental property.

These methods work with the cache-related Data Contract classes like:
PropertyCacheKey
CachedPropertyEntry
PropertyCacheLookupResult
that have already been defined

PropertyCacheKey identifies which cached property is being referenced.
CachedPropertyEntry contains the ExperimentalProperty together with its RetrievedAt and ExpiresAt timestamps.

PropertyCacheLookupResult contains the result of a cache lookup, including the CacheLookupStatus 
and the CachedPropertyEntry associated with the lookup.

The interface defines what operations a property cache must provide without
specifying how the cache internally performs those operations.
*/
namespace CompoundHandbook.DataContracts 
{
    /*
    The following interface defines the operations that must be provided by
    an experimental-property cache used by the Compound Handbook.

    The 'public' access modifier allows this interface to be accessed from
    outside of the CompoundHandbook.DataContracts namespace.

    The 'interface' keyword specifies that IChemicalPropertyCache is an
    interface rather than a class.
    */    
    public interface IChemicalPropertyCache 
    {
        /*
        The following Lookup() method searches the property cache for an entry
        corresponding to the supplied PropertyCacheKey.

        PropertyCacheKey is the datatype of the key parameter.

        The PropertyCacheKey identifies the requested cached property using:
        (i)   EntityId
        (ii)  PropertyKind
        (iii) ProviderKey

        PropertyCacheLookupResult is the return datatype of this method.

        Therefore, after the cache has been searched, Lookup() returns a
        PropertyCacheLookupResult describing the outcome of that search.

        The returned result can use CacheLookupStatus to indicate whether
        the lookup produced is HitFresh, HitStale, or a Miss.

        This interface only declares that a cache implementation must provide
        this operation.

        The actual mechanism used to search the cache will be defined by the
        class that implements IChemicalPropertyCache.
        */        
        PropertyCacheLookupResult Lookup(PropertyCacheKey key);

        /*
        The following Set() method stores a CachedPropertyEntry inside the
        property cache.

        This method receives two parameters:
        (i)  key: A PropertyCacheKey identifying where or under what identity the cached property should be stored.
        (ii) entry: A CachedPropertyEntry containing the ExperimentalProperty and its associated retrieval and expiration timestamps.
        
        The return datatype of this method is void, which means that the method does not return a value to the code that called it.

        Therefore, Set() receives the information required to store a cache
        entry but does not return another object as its result.

        The following association gets created by this operation:
        PropertyCacheKey -> CachedPropertyEntry

        The actual mechanism used to store this association will be defined
        by the class that implements IChemicalPropertyCache.
        */
        void Set(PropertyCacheKey key, CachedPropertyEntry entry);
    }
}