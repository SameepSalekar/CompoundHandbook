/*
The value of a chemical or physical property can depend upon the conditions under which
that property was measured.

For example, properties can be measured under particular temperatures, pressures, or
other experimental conditions.

Simply storing the value of a property would therefore not provide information about the
conditions under which that particular value applies.

This is why, PropertyConditions class is being created so that the conditions associated
with a particular property value can be described and stored inside the Compound Handbook.
*/

/*
The following PropertyConditions class represents the conditions associated with a particular
chemical or physical property inside the Compound Handbook.

Description is a read-only property because it contains only a 'getter' accessor.
Therefore, this property can be read from outside of the class, but it cannot be directly
changed from outside of the class after the PropertyConditions object has been constructed.

The following class also contains a constructor that receives the Description required
to initialize a new PropertyConditions object.
*/

namespace CompoundHandbook.Domain 
{
    // The following class represents the conditions associated with a particular property.
    public class PropertyConditions 
    {
        // Read-only property that stores the description of the conditions.
        // The datatype here is string.
        public string Description { get; }

        /*
        The following constructor will be called whenever a new PropertyConditions object gets created.
        The constructor will recieve the provided parameter, that is then assigned to
        its corresponding property of this object.
        */
        public PropertyConditions( string description) 
        {
            // Stores the supplied description in the Description property.
            Description = description;
        }
    }
}