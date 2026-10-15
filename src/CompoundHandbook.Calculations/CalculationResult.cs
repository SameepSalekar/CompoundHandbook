/*
The Compound Handbook performs several different types of chemical calculations.

For example, the Calculations system can perform operations such as calculating the
molar mass of a chemical formula.

However, performing a calculation does not only produce a numerical value.

A calculation can also:
(i)   Complete successfully and produce a calculated quantity.
(ii)  Fail because the required calculation could not be completed.
(iii) Produce messages that provide additional information about the calculation.

Simply returning a numerical value would therefore not provide enough information
to describe the complete result of a calculation.

This is why CalculationResult is being created.

CalculationResult allows the Calculations system to return the calculated
ChemicalQuantity together with information describing whether the calculation
was successful and any messages associated with the calculation.
*/

/*
The following CalculationResult class represents the result produced by a chemical
calculation inside the Compound Handbook.

CalculationResult = Success + Quantity + Messages

(i)   Success: Indicates whether the calculation was completed successfully.
(ii)  Quantity: Stores the ChemicalQuantity produced by the calculation.
(iii) Messages: Stores messages associated with the calculation.

All three of these are read-only properties because they contain only a 'getter' accessor.

Therefore, these properties can be read from outside of the class, but they cannot
be directly changed from outside of the class after the CalculationResult object
has been constructed.

The following class also contains a constructor that receives the success status,
calculated ChemicalQuantity, and collection of messages required to initialize
a new CalculationResult object.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.Calculations 
{   
    // The following class represents the result produced by a chemical calculation.
    public class CalculationResult 
    {   
        // Read-only property that stores whether the chemical calculation was successful.
        public bool Success { get; }

        /*
        Read-only property that stores the quantity produced by the chemical calculation.

        ChemicalQuantity is a class itself, but is being used as the datatype of
        the Quantity property.

        A ChemicalQuantity object stores both a numerical value and its corresponding
        unit. Therefore, the result of a calculation can represent a physical or
        chemical quantity together with the unit associated with that value.
        */        
        public ChemicalQuantity Quantity { get; }
        
        /*
        Read-only property that stores the messages associated with the calculation.

        IReadOnlyCollection<T> is a .NET generic interface that represents a collection
        whose elements can be accessed but cannot be added or removed through this interface.
        
        Therefore, IReadOnlyCollection<string> represents a read-only collection whose
        individual elements have the string datatype.

        Each string can contain a message produced during or associated with the
        calculation.
        */        
        public IReadOnlyCollection<string> Messages { get; }

        /*
        The following constructor will be called whenever a new CalculationResult
        object gets created.

        The constructor receives:
        (i)   A bool value indicating whether the calculation was successful.
        (ii)  The ChemicalQuantity produced by the calculation.
        (iii) A collection of messages associated with the calculation.

        The supplied arguments are then assigned to their corresponding read-only
        properties of the CalculationResult object.
        */        
        public CalculationResult(bool success, ChemicalQuantity quantity, IReadOnlyCollection<string> messages)
        {
            // Stores the supplied calculation-success status in the Success property.
            Success = success;

            // Stores the supplied ChemicalQuantity object in the Quantity property.
            Quantity = quantity;

            // Stores the supplied collection of messages in the Messages property.
            Messages = messages;
        }
    }
}