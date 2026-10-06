/*
When the Compound Handbook requests an experimental property, the program may first
check its property cache before retrieving the property again from an external
property provider.

After searching the cache, the Compound Handbook needs to know the result of that
cache lookup.

There are three possible situations:
(i)   The requested property exists in the cache and the cached information is still fresh.
(ii)  The requested property exists in the cache, but the cached information has become stale.
(iii) The requested property does not exist in the cache.

This is why CacheLookupStatus is being created.

CacheLookupStatus represents the possible outcomes of searching the property cache
for a particular cached experimental property.

CacheLookupStatus itself does not perform the cache lookup and does not determine
whether a CachedPropertyEntry is fresh or stale.

Instead, it provides a set of named values that can be used to describe the result
of a cache lookup.
*/

/*
The following CacheLookupStatus is an enum.

An enum, or enumeration, is a C# type that defines a fixed set of named values.

Using an enum is useful here because the result of a cache lookup should belong
to one of a small number of predefined states.

Compound Handbook can use strongly named CacheLookupStatus values.

This makes the possible cache-lookup states explicit and reduces the possibility
of using inconsistent string values throughout the program.
*/
namespace CompoundHandbook.DataContracts 
{
    // The following enum defines the possible outcomes of searching the experimental-property cache for a requested cache entry. 
    public enum CacheLookupStatus 
    {
        /*
        HitFresh means that the requested cache entry was successfully found
        and the cached information is still considered fresh.

        "Hit" means that the cache lookup successfully found an entry corresponding
        to the requested PropertyCacheKey.

        "Fresh" means that the cached information is still considered suitable
        for use according to the cache-freshness rules of the Compound Handbook.
        */        
        HitFresh,
        
        /*
        HitStale means that the requested cache entry was successfully found,
        but the cached information is considered stale.

        Therefore, the cache does contain information for the requested property,
        but that information is no longer considered fresh according to the
        cache-freshness rules of the Compound Handbook.

        The presence of a stale cache entry is different from a cache miss because
        an entry was actually found.
        */        
        HitStale,

        /*
        Miss means that the requested cache entry was not found.
        In other words, the cache does not currently contain an entry corresponding
        to the requested PropertyCacheKey.
        */        
        Miss
    }
}