/*
ChemicalIdentifier = Identifier Type + Identifier Value
(i)  Type:  Tells us the kind of identifier it is
(ii) Value: Contains the identifier text

Example no. 1: 
Type: ChemicalIdentifierType.CommonName
Value: "Slaked lime"

Example no. 2:
Type: ChemicalIdentifierType.SystematicName
Value: "Calcium hydroxide"

The following ChemicalIdentifier class contains two read-only properties to store these two pieces of
information.

These are read-only properties because they only contain a 'getter' accessor.

The Type and Value of a ChemicalIdentifier object cannot be changed directly from outside
of the class after the object has been constructed. 

The following class also contains the constructor, which is basically a special class member that initializes
a new object when it is created. 
*/

namespace CompoundHandbook.Domain
{
    public class ChemicalIdentifier
    {
        // Read-only property that stores the 'Type' using the ChemicalIdentifierType enum
        // Therefore, ChemicalIdentifierType is the data type here, and the value must come from that enum
        public ChemicalIdentifierType Type { get; }

        // Read-only property that stores the 'Value' associated with that identifier
        // The datatype here is string
        public string Value { get; }

        // The following constructor will be called whenever a new ChemicalIdentifierType object gets created
        /* 
        The following constructor also contains two parameters whose supplied arguments are then assigned
        to their corresponding read-only properties of the object
        */
        public ChemicalIdentifier(ChemicalIdentifierType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}