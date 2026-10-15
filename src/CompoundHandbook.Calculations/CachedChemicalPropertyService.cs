/*
The Compound Handbook can retrieve experimental chemical properties such as
melting point, boiling point, and density from chemical-property providers.

Some of these properties may come from external data sources.

However, repeatedly requesting the same chemical property from an external
provider can be inefficient.

For example, suppose the melting point of the same chemical substance is requested
multiple times. If a previously retrieved value is already stored and is still
sufficiently recent, the Compound Handbook should be able to reuse that stored
value instead of requesting the same information from the property provider again.

This is the purpose of caching.

A cache temporarily stores previously retrieved information so that the
information can potentially be reused later.

However, storing a chemical property in a cache introduces another question:

"Is the cached property still fresh enough to use?"

A cached property may eventually become stale depending upon how long it has
been stored.

Therefore, the Compound Handbook needs:
(i)   A cache that stores previously retrieved chemical properties.
(ii)  A freshness policy that determines whether cached information is still fresh.
(iii) A property provider that can retrieve chemical properties when necessary.
(iv)  A provider key that identifies the provider associated with the cached data.
(v)   A cache lifetime that represents how long cached information should remain valid.

This is why CachedChemicalPropertyService is being created.

CachedChemicalPropertyService brings these components together so that the
Compound Handbook can eventually coordinate the retrieval and caching of
chemical-property information.
*/

/*
The following CachedChemicalPropertyService class represents the service responsible
for coordinating cached chemical-property retrieval.

CachedChemicalPropertyService depends upon several other components:

CachedChemicalPropertyService = IChemicalPropertyCache + ICacheFreshnessPolicy + IChemicalPropertyProvider + Provider Key + Cache Lifetime

Instead of creating these dependencies inside the class, the required objects
and configuration values are supplied through the constructor.

This programming technique is known as constructor dependency injection.

Constructor dependency injection allows a class to receive the components that
it depends upon from outside of the class.

The supplied dependencies are then stored inside private readonly fields.

These fileds can only be directly accessed from inside the
CachedChemicalPropertyService class, and once these fields have been assigned during construction
of the object, they cannot normally be reassigned afterward.

This allows the CachedChemicalPropertyService object to retain the same cache,
freshness policy, property provider, provider key, and cache-lifetime configuration
that were supplied when the object was created.
*/

using CompoundHandbook.DataContracts;
using CompoundHandbook.Domain;

namespace CompoundHandbook.Calculations
{
    // The following class coordinates the components required for cached chemical-property retrieval.
    public class CachedChemicalPropertyService 
    {
        /*
        The following private readonly field stores the chemical-property cache
        used by CachedChemicalPropertyService.

        IChemicalPropertyCache is an interface and is being used as the datatype
        of the _cache field.

        The cache represents the component responsible for looking up and storing
        cached chemical-property information.

        Because IChemicalPropertyCache is an interface, this class depends upon
        the cache contract rather than depending upon one particular cache
        implementation.

        The underscore at the beginning of _cache follows a common C# naming
        convention for private fields.
        */
        private readonly IChemicalPropertyCache _cache;
        
        /*
        The following private readonly field stores the freshness policy used by
        CachedChemicalPropertyService.

        ICacheFreshnessPolicy is an interface and is being used as the datatype
        of the _freshnessPolicy field.

        The purpose of the freshness policy is to determine whether a cached
        chemical property is still sufficiently fresh to use.

        This keeps the decision about cache freshness separate from the component
        that actually stores the cached information.
        */
        private readonly ICacheFreshnessPolicy _freshnessPolicy;

        /*
        The following private readonly field stores the chemical-property provider.

        IChemicalPropertyProvider is an interface and is being used as the datatype
        of the _propertyProvider field.

        The property provider represents a component capable of retrieving
        chemical-property information.

        This provider can eventually be used when the required chemical-property
        information cannot appropriately be obtained from the cache.
        */
        private readonly IChemicalPropertyProvider _propertyProvider;

        /*
        The following private readonly field stores a key identifying the
        chemical-property provider.

        string is the datatype of the _providerKey field.
        
        The provider key allows cached information to be associated with the
        particular property provider connected to this service.

        This becomes useful because chemical-property information could potentially
        come from different providers.
        */
        private readonly string _providerKey;

        /*
        The following private readonly field stores the configured lifetime of
        cached chemical-property information.

        TimeSpan is a .NET structure used to represent a duration of time.

        For example, a TimeSpan can represent a duration measured in days, hours,
        minutes, seconds, or combinations of these units.

        TimeSpan represents a duration rather than one particular date and time.

        Therefore, _cacheLifetime can be used to represent how long cached
        chemical-property information should remain valid.        
        */
        private readonly TimeSpan _cacheLifetime;

        /*
        The following constructor will be called whenever a new
        CachedChemicalPropertyService object gets created.

        The constructor receives five parameters:
        (i)   IChemicalPropertyCache cache: Receives the chemical-property cache that the service will use.
        (ii)  ICacheFreshnessPolicy freshnessPolicy: Receives the policy responsible for determining whether cached information is still fresh.
        (iii) IChemicalPropertyProvider propertyProvider: Receives the provider capable of retrieving chemical-property information.
        (iv)  string providerKey: Receives the textual key used to identify the property provider.
        (v)   TimeSpan cacheLifetime: Receives the duration representing the configured lifetime of cached information.
        
        These objects and configuration values are supplied from outside of the
        class rather than being constructed inside CachedChemicalPropertyService.
        (An example of the constructor dependency injection)

        The supplied arguments are then assigned to their corresponding private
        readonly fields so that they can later be used by the service.
        */
        public CachedChemicalPropertyService(IChemicalPropertyCache cache, ICacheFreshnessPolicy freshnessPolicy, IChemicalPropertyProvider propertyProvider, string providerKey, TimeSpan cacheLifetime)
        {
            // Stores the supplied IChemicalPropertyCache object inside the _cache field.
            _cache = cache;

            // Stores the supplied ICacheFreshnessPolicy object inside the _freshnessPolicy field.
            _freshnessPolicy = freshnessPolicy;

            // Stores the supplied IChemicalPropertyProvider object inside the _propertyProvider field.
            _propertyProvider = propertyProvider;

            // Stores the supplied provider-identification string inside the _providerKey field.
            _providerKey = providerKey;

            // Stores the supplied TimeSpan representing the cache lifetime inside the _cacheLifetime field.
            _cacheLifetime = cacheLifetime;
        }
    }
}