/*
A property source represents the source from which the information about a chemical or physical
property was obtained.

Simply storing a property value would not provide information about where that particular
property information came from.

This is why, PropertySource class is being created so that the name of the information provider
and the corresponding reference can be stored together inside one object.
*/

/*
The following PropertySource class represents one source of property information inside the
Compound Handbook.

PropertySource = Provider Name + Reference

Both of these are read-only properties because they contain only a 'getter' accessor.
Therefore, these properties can be read from outside of the class, but they cannot be directly
changed from outside of the class after the PropertySource object has been constructed.

The following class also contains a constructor that receives the ProviderName and Reference
required to initialize a new PropertySource object.
*/

namespace CompoundHandbook.Domain 
{
    // The following class represents the source from which a property information was obtained.
    public class PropertySource 
    {
        // Read-only property that stores the name of the provider of the property information.
        // The datatype here is string.
        public string ProviderName { get; }

        // Read-only property that stores the reference associated with the property information.
        // The datatype here is string. 
        public string Reference { get; }

        /*
        The following constructor will be called whenever a new PropertySource object gets created.
        The constructor will recieve the provided parameters, that are then assigned to their
        corresponding properties of this object.
        */
        public PropertySource(string providerName, string reference) 
        {
            // Stores the supplied provider name in the ProviderName property.
            ProviderName = providerName;

            // Stores the supplied reference in the Reference property.
            Reference = reference;
        }

    }
}