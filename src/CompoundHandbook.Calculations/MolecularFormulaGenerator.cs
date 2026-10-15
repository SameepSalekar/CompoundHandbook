/*
The Compound Handbook needs to be able to generate a molecular formula from the
structural information stored inside a MolecularGraph.

A MolecularGraph contains the Atom objects that make up a molecule.

Each Atom is associated with an Element, and therefore the collection of atoms
inside the graph can be examined to determine:

(i)   Which chemical elements are present.
(ii)  How many atoms of each element are present.

The atoms can be grouped according to their corresponding Element and then these elements can be converted
into the molecular-formula text. This is the purpose of MolecularFormulaGenerator.

MolecularFormulaGenerator implements the IMolecularFormulaGenerator interface
and provides the actual logic required by its Generate() method.

The overall process performed by Generate() is:
MolecularGraph -> Group atoms according to their Element -> Count the atoms belonging to each Element ->
Create ElementCount objects -> Generate the textual chemical formula -> Create and return a ChemicalFormula.
*/

/*
The following MolecularFormulaGenerator class implements
IMolecularFormulaGenerator.

The colon ':' following the class name indicates that
MolecularFormulaGenerator implements the IMolecularFormulaGenerator interface.

Because IMolecularFormulaGenerator declares:

ChemicalFormula Generate(MolecularGraph graph);

MolecularFormulaGenerator must provide an implementation of that Generate()
method.

Unlike the interface, which only specifies what operation must exist, this class
contains the actual logic describing how a ChemicalFormula is generated from
a MolecularGraph.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.Calculations 
{    
    public class MolecularFormulaGenerator : IMolecularFormulaGenerator 
    {
        /*
        The following Generate() method generates a ChemicalFormula from the
        MolecularGraph supplied through the graph parameter.

        MolecularGraph is the datatype of the graph parameter.

        ChemicalFormula is the return datatype of the method.
        
        The following method performs three major operations:
        (i)   Groups the atoms according to their chemical element.
        (ii)  Converts those groups into ElementCount objects containing each Element and the number of atoms belonging to that Element.
        (iii) Uses the ElementCount objects to construct the textual molecular formula.

        Finally, the method creates and returns a ChemicalFormula whose FormulaKind is Molecular.
        */
        public ChemicalFormula Generate(MolecularGraph graph)
        {
            /*
            The following statement groups the Atom objects contained inside
            graph.Atoms according to the atomic number of their Element.

            'var' tells C# to infer the datatype of elementGroups from the value
            returned by the expression on the right side of the assignment.

            graph.Atoms accesses the collection of Atom objects stored inside
            the MolecularGraph.

            GroupBy() is a LINQ method.

            LINQ provides methods that allow collections of objects to be
            queried, grouped, filtered, transformed, and otherwise processed.

            GroupBy() organizes the objects in a collection into groups according
            to a specified key.

            The following expression:
            atom => atom.Element.AtomicNumber
            is a lambda expression (compact way of describing a function)
            'atom' means each Atom being examined from graph.Atoms and '=>' means produces
            The whole expression says: "For each atom, use the AtomicNumber of its Element as the grouping key."
            */            
            var elementGroups = graph.Atoms.GroupBy(atom => atom.Element.AtomicNumber);

            /*
            The following statement transforms each element group into an
            ElementCount object and then stores all of those ElementCount objects
            inside an array.

            ElementCount[] means that elementCounts is an array whose elements
            have the ElementCount datatype.

            elementGroups.Select(...)

            uses the LINQ Select() method.

            Select() transforms each item from one collection into another form.

            In this case, each 'group' is transformed into a new
            ElementCount object.
            
            group => new ElementCount(...) means "For each group, create a new ElementCount object."

            group.First() uses the LINQ method, First(), in order to retrieve the first Atom contained
            inside the current group.
            Since every Atom in that group belongs to the same Element, the
            Element associated with the first Atom can be used to identify the
            Element represented by the entire group.
            group.First().Element obtains the Element represented by the group.

            group.Count() counts how many Atom objects are contained inside the group.

            new ElementCount(group.First().Element, group.Count()) creates an ElementCount containing:
            (i)  The Element represented by the group.
            (ii) The number of atoms belonging to that Element.

            .ToArray() converts the results produced by Select() into an array.
            */
            ElementCount[] elementCounts = elementGroups.Select(group => new ElementCount(group.First().Element, group.Count())).ToArray();

            /*
            The following statement constructs the textual representation of the
            molecular formula from the ElementCount objects.

            string is the datatype of formulaText.

            string.Concat() joins multiple pieces of textual information together
            into one string.

            Before string.Concat() combines the text, Select() transforms every
            ElementCount into the piece of formula text associated with that
            particular element.

            The following expression of 'elementCount.Element.Symbol' obtains the chemical symbol of the Element.

            The expression of '(elementCount.Count == 1 ? string.Empty : elementCount.Count.ToString())'
            is using the ternary operator, in which elementCount.Count.ToString() converts the integer count
            into its textual string representation.

            string.Concat() joins all of these pieces together.
            */            
            string formulaText = string.Concat(elementCounts.Select(elementCount => elementCount.Element.Symbol + (elementCount.Count == 1 ? string.Empty : elementCount.Count.ToString())));

            /*
            The following statement creates and returns the completed
            ChemicalFormula object.

            The 'new' keyword creates a new instance of the ChemicalFormula class.

            Three arguments are supplied to the ChemicalFormula constructor:
            (i)   formulaText: The textual molecular formula generated above
            (ii)  FormulaKind.Molecular: FormulaKind is an enum used to describe what type of chemical formula is being represented.
            (iii) elementCounts: The array of ElementCount objects describing which Elements are present and how many atoms of each Element occur in the graph.

            The 'return' keyword sends the newly created ChemicalFormula object back to the code that called Generate().
            Therefore, the returned ChemicalFormula contains both the generated
            formula text and the underlying element-count information.           
            */
            return new ChemicalFormula(formulaText, FormulaKind.Molecular, elementCounts);
        }
    }
}