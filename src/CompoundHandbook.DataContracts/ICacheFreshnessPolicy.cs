/*
A cached experimental property may eventually become outdated or expire.

CachedPropertyEntry stores the experimental property together with timing information,
but the Compound Handbook still needs a way to determine whether that cached information
should currently be considered fresh.

This is why ICacheFreshnessPolicy is being created.

ICacheFreshnessPolicy defines the contract for deciding whether a CachedPropertyEntry
is still fresh at a particular point in time.
*/

/*
The following ICacheFreshnessPolicy is an interface.

It defines one method:

IsFresh(CachedPropertyEntry entry, DateTimeOffset now)

The method receives the cached entry being evaluated and the current date and time.
It returns a bool value:

true  -> The cached entry is considered fresh.
false -> The cached entry is not considered fresh.

The interface only defines the required operation. The actual freshness rule will
be provided by a class that implements ICacheFreshnessPolicy.
*/
namespace CompoundHandbook.DataContracts 
{
    // Interface for determining whether a cached property entry is still fresh.
    public interface ICacheFreshnessPolicy 
    {
        /*
        Checks the supplied CachedPropertyEntry against the supplied current time.

        CachedPropertyEntry entry -> The cached property being evaluated.
        DateTimeOffset now        -> The current date and time used for the evaluation.
        
        TRUE will be returned if it is fresh and if not then it will return FALSE.
        */
        bool IsFresh(CachedPropertyEntry entry, DateTimeOffset now);
    }
}