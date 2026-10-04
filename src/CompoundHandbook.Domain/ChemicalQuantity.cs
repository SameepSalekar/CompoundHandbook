/*
A chemical quantity represents a numerical measurement together with the unit that describes
what that numerical value represents.

Simply storing a numerical value would not provide enough information about a measured
chemical or physical property.

This is why, ChemicalQuantity class is being created so that the numerical value and its
corresponding unit can be stored together inside one object.
*/

/*
The following ChemicalQuantity class represents one measured quantity inside the Compound Handbook.

ChemicalQuantity = Value + Unit

Both of these are read-only properties because they contain only a 'getter' accessor.
Therefore, these properties can be read from outside of the class, but they cannot be directly
changed from outside of the class after the ChemicalQuantity object has been constructed.

The following class also contains a constructor that receives the Value and Unit required
to initialize a new ChemicalQuantity object.
*/
namespace CompoundHandbook.Domain 
{
    // The following class represents a numerical quantity together with its corresponding unit.
    public class ChemicalQuantity 
    {
        // Read-only property that stores the numerical value of the chemical quantity.
        // The datatype here is double because the value can contain decimal values.
        public double Value { get; }

        // Read-only property that stores the unit associated with the numerical value.
        // The datatype here is string.
        public string Unit { get; }
        
        /*
        The following constructor will be called whenever a new ChemicalQuantity object gets created.
        The constructor will recieve the provided parameters, that are then assigned to
        their corresponding properties of this object.
        */
        public ChemicalQuantity(double value, string unit) 
        {
            // Stores the supplied numerical value in the Value property.
            Value = value;

            // Stores the supplied unit in the Unit property.
            Unit = unit;
        }
    }
}