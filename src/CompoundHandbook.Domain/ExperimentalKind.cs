/*
An experimental property represents a measured chemical or physical property of a chemical substance.

Simply storing the measured value would not provide enough information about what property was
measured, the conditions under which it was measured, or where that information came from.

This is why, ExperimentalKind class is being created so that it can store the type of experimental
property, its measured value, the conditions associated with that measurement, and its source.
*/

/*
The following ExperimentalKind class represents one experimental property measurement inside
the Compound Handbook.

ExperimentalKind = Kind + Value + Conditions + Source

All four of these are read-only properties because they contain only a 'getter' accessor.
Therefore, these properties can be read from outside of the class, but they cannot be directly
changed from outside of the class after the ExperimentalKind object has been constructed.

The following class also contains a constructor that receives the ExperimentalPropertyKind,
ChemicalQuantity, PropertConditions, and PropertySource objects required to initialize a new
ExperimentalKind object.
*/
namespace CompoundHandbook.Domain 
{
    // The following class represents one experimental property measurement
    public class ExperimentalKind 
    {
        /*
        Read-only property that stores the type of experimental property being represented.
        ExperimentalPropertyKind is an enum itself, but is being used as the datatype of this property.
        Therefore, the value of Kind must be one of the named values defined inside the 
        ExperimentalPropertyKind enumeration.
        */
        public ExperimentalPropertyKind Kind { get; }

        /*
        Read-only property that stores the measured value of the experimental property.
        ChemicalQuantity is a class itself, but is being used as the datatype of this property.
        The ChemicalQuantity object stores both the numerical value and the corresponding unit
        of the experimental measurement.
        */
        public ChemicalQuantity Value { get; }

        /*
        Read-only property that stores the conditions associated with the experimental measurement.
        PropertConditions is a class itself, but is being used as the datatype of this property.
        The PropertConditions object contains the description of the conditions under which
        the property value applies.
        */
        public PropertyConditions Conditions { get; }

        /*
        Read-only property that stores the source from which the experimental property information
        was obtained.
        PropertySource is a class itself, but is being used as the datatype of this property.
        The PropertySource object stores the provider name and the corresponding reference.
        */
        public PropertySource Source { get; }

        /*
        The following constructor will be called whenever a new ExperimentalKind object gets created.
        The constructor will recieve the provided parameters, that are then assigned to
        their corresponding properties of this object.
        */
        public ExperimentalKind( ExperimentalPropertyKind kind, ChemicalQuantity value, PropertyConditions conditions, PropertySource source) 
        {
            // Stores the supplied ExperimentalPropertyKind value in the Kind property.
            Kind = kind;

            // Stores the supplied ChemicalQuantity object in the Value property.
            Value = value;

            // Stores the supplied PropertConditions object in the Conditions property.
            Conditions = conditions;

            // Stores the supplied PropertySource object in the Source property.
            Source = source;
        }
    }
}