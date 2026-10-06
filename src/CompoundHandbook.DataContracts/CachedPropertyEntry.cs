/*
When the Compound Handbook retrieves an experimental property from a property provider,
it may store that property inside a cache so that the same information does not have
to be retrieved again every time it is requested.

However, simply storing the ExperimentalProperty object is not enough.

The Compound Handbook also needs to know when that property information was retrieved
and when the cached information should be considered expired.

This is important because experimental-property information obtained from a provider
may be cached for a limited period of time.

The Compound Handbook therefore needs a way to store:
(i)   The ExperimentalProperty that was retrieved.
(ii)  The time at which the property was retrieved.
(iii) The time at which the cached property expires.

This is why CachedPropertyEntry is being created.

A CachedPropertyEntry represents one experimental property that has been stored
inside the property cache together with timing information associated with that
cached value.

The CachedPropertyEntry itself does not determine whether the cached information
is currently fresh or stale.

Instead, it stores the information required for another part of the Compound Handbook
to make that decision.
*/

/*
The following CachedPropertyEntry class represents one experimental-property entry
stored inside the property cache.

CachedPropertyEntry = ExperimentalProperty + RetrievedAt + ExpiresAt

(i) Property: Stores the ExperimentalProperty that has been cached.
(ii) RetrievedAt: Stores the date and time at which the experimental property was retrieved.
(iii) ExpiresAt: Stores the date and time at which the cached property expires.

All three of these are read-only properties because they contain only a 'getter' accessor.

Therefore, these properties can be read from outside of the class, but they cannot
be directly changed from outside of the class after the CachedPropertyEntry object
has been constructed.

The following class also contains a constructor that receives the ExperimentalProperty,
retrieval time, and expiration time required to initialize a new CachedPropertyEntry object.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.DataContracts 
{
    // The following class represents one experimental property stored in the cache together with the timestamps associated with that cached property.
    public class CachedPropertyEntry 
    {
        /*
        Read-only property that stores the experimental property contained
        inside this cache entry.

        ExperimentalProperty is a class itself, but is being used as the
        datatype of this property.

        Therefore, the Property property references an ExperimentalProperty
        object containing the experimental-property information that was cached.
        */        
        public ExperimentalKind Property { get; }

        /*
        Read-only property that stores the date and time at which the
        experimental property was retrieved.

        DateTimeOffset is a .NET value type used to represent a date and time
        together with its offset from Coordinated Universal Time (UTC).

        This timestamp allows the Compound Handbook to know when the cached
        property information was originally retrieved.
        */
        public DateTimeOffset RetrievedAt { get; }

        /*
        Read-only property that stores the date and time at which this
        cached property entry expires.

        DateTimeOffset is also used here so that the expiration moment is
        represented together with its offset from UTC.

        This timestamp can later be used when determining whether the cached
        property information should still be treated as fresh or has become stale.
        */
        public DateTimeOffset ExpiresAt { get; }

        /*
        The following constructor will be called whenever a new
        CachedPropertyEntry object gets created.

        The constructor receives:
        (i)   An ExperimentalProperty object containing the property being cached.
        (ii)  A DateTimeOffset representing when the property was retrieved.
        (iii) A DateTimeOffset representing when the cached property expires.

        The supplied arguments are then assigned to their corresponding
        read-only properties of the CachedPropertyEntry object.
        */
        public CachedPropertyEntry(ExperimentalKind property, DateTimeOffset retrievedAt, DateTimeOffset expiresAt) 
        {
            // Stores the supplied ExperimentalProperty object in the Property property.
            Property = property;

            // Stores the supplied retrieval date and time in the RetrievedAt property.
            RetrievedAt = retrievedAt;

            // Stores the supplied expiration date and time in the ExpiresAt property.
            ExpiresAt = expiresAt;
        }
    }
}