/*
A chemical formula represents the elemental composition of a chemical substance using chemical
symbols and numerical subscripts.

Simply storing the original formula as a string would not provide the Compound Handbook
with an organized representation of the information contained inside that formula.

This is why, ChemicalFormula class is being created so that it can store both the original
textual representation of the formula and a structured representation of its elemental composition.

The ChemicalFormula also stores the FormulaKind so that the Compound Handbook can distinguish
between the different ways in which a chemical formula may represent a chemical substance.

ChemicalFormula = Original Text + Formula Kind + Collection of Element Counts
*/

/*
The following ChemicalFormula class represents one chemical formula inside the Compound Handbook.

ChemicalFormula = Original Text + Formula Kind + Collection of Element Counts

All three of these are read-only properties because they contain only a 'getter' accessor.
Therefore, these properties can be read from outside of the class, but they cannot be directly
changed from outside of the class after the ChemicalFormula object has been constructed.

The following class also contains a constructor that receives the OriginalText, FormulaKind,
and collection of ElementCount objects required to initialize a new ChemicalFormula object.
*/

namespace CompoundHandbook.Domain 
{
    // The following class represents a chemical formula and its elemental composition
    public class ChemicalFormula 
    {
        // Read-only property that stores the original textual representation of the chemical formula.
        // The datatype here is string.
        public string OriginalText { get; }

        /*
        Read-only property that stores the kind of chemical formula being represented.
        FormulaKind is an enum itself, but is being used as the datatype of this property.
        Therefore, the value of Kind must be one of the named values defined inside the 
        FormulaKind enumeration.
        */
        public FormulaKind Kind { get; }

        /*
        Read-only property that stores the collection of ElementCount objects associated
        with this chemical formula.
        IReadOnlyCollection<T> is a .NET generic interface that represents a collection
        whose elements can be accessed but cannot be added or removed through this interface.

        IReadOnlyCollection<ElementCount> represents a read-only collection
        containing ElementCount objects.
        Each ElementCount object identifies one Element and the number of atoms or units
        of that element represented by the chemical formula.
        */
        public IReadOnlyCollection <ElementCount> ElementCounts { get; }

        /*
        The following constructor will be called whenever a new ChemicalFormula object gets created.
        The constructor will recieve the provided parameters, that are then assigned to
        their corresponding properties of this object
        */
        public ChemicalFormula (string originalText, FormulaKind kind, IReadOnlyCollection<ElementCount> elementCounts) 
        {
            // Stores the supplied original chemical-formula text in the OriginalText property.
            OriginalText = originalText;

            // Stores the supplied FormulaKind value in the Kind property.
            Kind = kind;

            // Stores the supplied collection of ElementCount objects in the ElementCounts property.
            ElementCounts = elementCounts;
        }
    }
}