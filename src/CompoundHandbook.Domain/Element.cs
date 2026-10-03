/*
Element is basically a type of an atom.

The number of protons in an atom is represented by the atomic number, 
and the atomic number is what fundamentally identifies which 
chemical element the atom belongs to.

The chemical symbol provides the short notation used to represent the element
inside chemical formulas and chemical structures.

The standard atomic weight represents the weighted average of the relative 
atomic masses of the isotopes of an element, taking their natural abundances 
into account as conventionally defined.

The Compound Handbook needs information about individual elements because many 
other chemical objects and calculations depend upon elemental information.

For example, when the Compound Handbook later analyzes a chemical formula such as H2O,
it needs to recognize H as hydrogen and O as oxygen.

The standard atomic weights of these elements can also later be used when calculating 
quantities such as the molar mass and percent composition of a chemical substance.
*/

/*
The following Element class represents one chemical element inside the Compound Handbook.

An Element object contains four pieces of information:
(i)   AtomicNumber         : Stores the atomic number of the element.
(ii)  Symbol               : Stores the chemical symbol of the element.
(iii) Name                 : Stores the name of the element.
(iv)  StandardAtomicWeight : Stores the standard atomic weight of the element.

All four of these are read-only properties because they contain only a 'getter' accessor.
Therefore, these properties can be read from outside of the class, but they cannot be directly
changed from outside of the class after the Element object has been constructed.

The following class also contains a constructor, which is a special class member that initializes
a new Element object when it is created.

The constructor receives the atomic number, symbol, name, and standard atomic weight as parameters.

The supplied arguments are then assigned to their corresponding read-only properties of the
Element object.
*/
namespace CompoundHandbook.Domain
{
    // The following class represents a chemical element inside the Compound Handbook.
    public class Element 
    {
        /*
        Read-only property that stores the atomic number of the element.
        The atomic number represents the number of protons in the nucleus of an atom of this element.
        The datatype is 'int' because an atomic number is always a whole number.
        */
        public int AtomicNumber { get; }

        // Read-only property that stores the chemical symbol of the element.
        // The datatype here is a string.
        public string Symbol { get; }

        // Read-only property that stores the name of the chemical element.
        // The datatype here is a string.
        public string Name { get; }

        // Read-only property that stores the standard atomic weight of the element.
        // The datatype here is double because the standard atomic weights of all elements are decimal values.
        public double StandardAtomicWeight { get; }

        // The following constructor will be called whenever a new Element object gets created.
        // The constructor assigns each supplied argument to its corresponding read-only property.
        public Element( int atomicNumber, string symbol, string name, double standardAtomicWeight) 
        {
            // Assigns the supplied atomic number to the AtomicNumber property of this Element object.
            AtomicNumber = atomicNumber;

            // Assigns the supplied chemical symbol to the Symbol property of this Element object.
            Symbol = symbol;

            // Assigns the supplied element name to the Name property of this Element object.
            Name = name;

            // Assigns the supplied standard atomic weight to the StandardAtomicWeight property.
            StandardAtomicWeight = standardAtomicWeight;
        }
    }
}