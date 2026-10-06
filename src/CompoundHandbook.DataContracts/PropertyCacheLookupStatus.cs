/*
When the Compound Handbook searches its experimental-property cache, the program needs
more information than simply whether a CachedPropertyEntry was returned.

The program also needs to know the outcome of the cache lookup.

As defined by CacheLookupStatus, a cache lookup has the three possible outcomes of HitFresh, HitStale, and Miss.

Therefore, the result of a cache lookup needs to bring together:
(i)  The CacheLookupStatus describing what happened during the lookup.
(ii) The CachedPropertyEntry associated with the lookup.

This is why PropertyCacheLookupResult is being created.

A PropertyCacheLookupResult represents the result produced after the Compound Handbook
searches its experimental-property cache.

The PropertyCacheLookupResult itself does not search the cache.
It also does not determine whether a cached property is fresh or stale.
Instead, it acts as a result object that carries the outcome of the cache lookup
and the CachedPropertyEntry associated with that lookup to other parts of the
Compound Handbook
*/

/*
The following PropertyCacheLookupResult class represents the result of searching
the experimental-property cache.

PropertyCacheLookupResult = CacheLookupStatus + CachedPropertyEntry
(i) Status: Stores the CacheLookupStatus describing the outcome of the cache lookup.
(ii) Entry: Stores the CachedPropertyEntry associated with the cache lookup.

Both of these are read-only properties because they contain only a 'getter' accessor.

Therefore, these properties can be read from outside of the class, but they cannot
be directly changed from outside of the class after the PropertyCacheLookupResult
object has been constructed.

The following class also contains a constructor that receives the CacheLookupStatus
and CachedPropertyEntry required to initialize a new PropertyCacheLookupResult object.
*/

namespace CompoundHandbook.DataContracts 
{
    // The following class represents the result produced after searching the experimental-property cache.
    public class PropertyCacheLookupResult 
    {

        /*
        Read-only property that stores the outcome of the cache lookup.

        CacheLookupStatus is an enum itself, but is being used as the datatype
        of this property.

        This property therefore tells the rest of the Compound Handbook what
        happened when the cache lookup was performed.        
        */
        public CacheLookupStatus Status { get; }

        /*
        Read-only property that stores the CachedPropertyEntry associated
        with the cache lookup.

        CachedPropertyEntry is a class itself, but is being used as the
        datatype of this property.

        A CachedPropertyEntry contains:
        (i)   The cached ExperimentalProperty.
        (ii)  The date and time at which it was retrieved.
        (iii) The date and time at which it expires.

        Therefore, while Status describes the outcome of the lookup,
        Entry provides the cached-property information associated with
        that lookup.                
        */
        public CachedPropertyEntry Entry { get; }

        /*
        The following constructor will be called whenever a new
        PropertyCacheLookupResult object gets created.

        The constructor receives:
        (i)  A CacheLookupStatus describing the outcome of the cache lookup.
        (ii) A CachedPropertyEntry associated with that lookup.

        The supplied arguments are then assigned to their corresponding
        read-only properties of the PropertyCacheLookupResult object.
        */
        public PropertyCacheLookupResult(CacheLookupStatus status, CachedPropertyEntry entry) 
        {
            // Stores the supplied cache-lookup status in the Status property.
            Status = status;

            // Stores the supplied cached-property entry in the Entry property.
            Entry = entry;
        }
    }
}