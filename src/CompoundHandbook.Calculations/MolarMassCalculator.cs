/*
The Compound Handbook needs to be able to calculate the molar mass of a chemical
substance from its ChemicalFormula.

Molar mass represents the mass of one mole of a chemical substance and is
commonly expressed using the unit g/mol.

A ChemicalFormula contains ElementCount objects that describe:
(i)  Which chemical Elements are present.
(ii) How many atoms of each Element are present.

Each Element also contains its StandardAtomicWeight.

The mass contributions of all Elements in the ChemicalFormula can then be
added together to determine the total molar mass.

This is the purpose of MolarMassCalculator.

MolarMassCalculator implements the IMolarMassCalculator interface and provides
the actual calculation logic required by its Calculate() method.

The overall process performed by Calculate() is:
ChemicalFormula -> Examine every ElementCount -> Obtain the StandardAtomicWeight of the Element ->
Multiply the atomic weight by the Element count -> Add the mass contribution to the total molar mass ->
Create a ChemicalQuantity in g/mol -> Place the ChemicalQuantity inside a successful CalculationResult ->
Return the CalculationResult
*/

/*
The following MolarMassCalculator class implements IMolarMassCalculator.

The colon ':' following the class name indicates that MolarMassCalculator
implements the IMolarMassCalculator interface.

Because IMolarMassCalculator declares:

CalculationResult Calculate(ChemicalFormula formula);

MolarMassCalculator must provide an implementation of that Calculate() method.

The interface defines the contract for molar-mass calculation, while this class
provides the actual mathematical and programming logic used to perform that
calculation.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.Calculations
{
    public class MolarMassCalculator : IMolarMassCalculator
    {
        /*
        The following Calculate() method calculates the molar mass of the
        ChemicalFormula supplied through the formula parameter.

        ChemicalFormula is the datatype of the formula parameter.

        CalculationResult is the return datatype of this method.
        
        The returned CalculationResult will contain a ChemicalQuantity
        representing the calculated molar mass in g/mol.
        */
        public CalculationResult Calculate(ChemicalFormula formula)
        {
            /*
            The following variable stores the running total of the molar mass.
            double is the datatype of molarMass.
            
            The variable begins at 0.0 because no Element mass contributions have been added yet.
            As the foreach loop processes each ElementCount, its mass contribution will be added to molarMass.
            */
            double molarMass = 0.0;

            /*
            The following foreach loop examines every ElementCount contained
            inside formula.ElementCounts.

            A foreach loop performs the statements inside its body once for
            every object contained in a collection.

            ElementCount is the datatype of elementCount.

            elementCount is the loop variable representing the current
            ElementCount being examined.

            formula.ElementCounts is the collection being traversed.

            Therefore, each pass through the loop processes one Element contained
            in the ChemicalFormula.
            */
            foreach (ElementCount elementCount in formula.ElementCounts)
            {
                /*
                The following statement obtains the StandardAtomicWeight of the
                Element represented by the current ElementCount.

                elementCount.Element accesses the Element associated with the current ElementCount.

                .StandardAtomicWeight then accesses the StandardAtomicWeight property belonging to
                that Element.

                The value is stored inside the double variable atomicWeight.
                */                
                double atomicWeight = elementCount.Element.StandardAtomicWeight;

                // Mass Contribution is being calculated by the statement below.
                double massContribution = elementCount.Count * atomicWeight;

                /*
                The following statement adds the current Element's mass
                contribution to the running total stored inside molarMass.

                Each pass through the foreach loop adds another Element's mass
                contribution to the total.

                After every ElementCount has been processed, molarMass contains
                the total molar mass of the ChemicalFormula.
                */
                molarMass += massContribution;
            } 

            /*
            The following statement creates a ChemicalQuantity object containing
            the calculated molar mass.

            ChemicalQuantity is used because a numerical chemical measurement
            should contain both, numerical value and a unit associated with it.

            A new ChemicalQuantity object is being created here by the keyword 'new'.
            The two arguments that are being supplied to its constructor are:
            (i)  molarMass: The numerical molar-mass value calculated by the foreach loop
            (ii) "g/mol": A string representing the unit grams per mole
            The newly created ChemicalQuantity object will be stored inside the quantity variable.
            */
            ChemicalQuantity quantity = new ChemicalQuantity(molarMass, "g/mol");

            /*
            The following statement creates and immediately returns a new
            instance of CalculationResult.

            Three arguments are supplied to its constructor:
            (i)   true: Supplied to the Success property because this execution of the method should be represented as successful calculation.
            (ii)  quantity: The ChemicalQuantity containing the calculated molar mass and the "g/mol" unit.
            (iii) Array.Empty<string>(): Creates an empty string array

            Array is a .NET class containing methods for working with arrays.
            Empty<T>() returns an empty array whose elements would have the datatype specified by T.

            Array.Empty<string>() returns an empty string array. This is being used because there are 
            no calculation messages being returned by this successful calculation.

            An empty string array can be supplied because an array implements IReadOnlyCollection<T>, 
            which is the datatype expected by the Messages parameter of CalculationResult.

            The return keyword then sends the newly created CalculationResult
            back to the code that called Calculate().
            */
            return new CalculationResult(true, quantity, Array.Empty<string>());
        }
    }
}