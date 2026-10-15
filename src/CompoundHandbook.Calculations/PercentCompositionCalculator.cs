/*
The Compound Handbook needs to be able to calculate the percent composition
of a chemical substance from its ChemicalFormula.

Percent composition describes what percentage of the total mass of a chemical
substance is contributed by each chemical element present in that substance.

For example, suppose a chemical formula contains multiple different elements.

Each element contributes some amount to the total molar mass depending upon:

(i)  The number of atoms of that element present in the chemical formula.
(ii) The StandardAtomicWeight of that element.

After the mass contribution of every element has been determined, these
contributions can be added together to determine the total molar mass of the
chemical formula

This is the purpose of PercentCompositionCalculator.

PercentCompositionCalculator implements the IPercentCompositionCalculator
interface and provides the actual calculation logic required by its Calculate() method.

The overall process performed by the Calculate():
ChemicalFormula -> Examine every ElementCount -> Calculate the mass contribution of each element
-> Add the contributions to obtain the total molar mass -> Examine every ElementCount again ->
Calculate each element's percentage of the total mass -> Create ElementPercentComposition objects
-> Return the collection of results
*/

/*
The following PercentCompositionCalculator class implements
IPercentCompositionCalculator.

The colon ':' following the class name indicates that
PercentCompositionCalculator implements the IPercentCompositionCalculator
interface.

Because IPercentCompositionCalculator declares:

IReadOnlyCollection<ElementPercentComposition> Calculate(ChemicalFormula formula);

PercentCompositionCalculator must provide an implementation of that Calculate()
method.

Unlike the interface, which only specifies that the percent-composition
calculation must be available, this class contains the actual mathematical and
programming logic used to perform that calculation.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.Calculations 
{    
    public class PercentCompositionCalculator : IPercentCompositionCalculator 
    {
        /*
        The following Calculate() method calculates the percent composition of
        the ChemicalFormula supplied through the formula parameter.

        ChemicalFormula is the datatype of the formula parameter.

        IReadOnlyCollection<ElementPercentComposition> is the return datatype
        of this method.

        Each ElementPercentComposition object represents one Element and the
        percentage of the total mass contributed by that Element.

        This method performs the calculation in two main stages. Inside its first loop, the total
        molar mass of the chemical formula gets calculated, and in its second loop, that total molar
        mass is used in order to calculate the mass percentage of each individual element.
        */        
        public IReadOnlyCollection<ElementPercentComposition> Calculate(ChemicalFormula formula) 
        {
            /*
            The following variable will store the total molar mass calculated
            from all of the elements contained in the ChemicalFormula.

            double is the datatype of totalMolarMass.
            
            totalMolarMass begins at 0.0 because none of the individual element mass contributions have been
            added yet. As the first foreach loop executes, each element's mass contribution
            will be added to this variable.
            */
            double totalMolarMass = 0.0;

            /*
            The following foreach loop examines every ElementCount contained
            inside formula.ElementCounts.

            A foreach loop is used when I want to perform an operation for every
            object contained inside a collection.

            ElementCount is the datatype of elementCount.

            elementCount is the temporary loop variable representing the current
            ElementCount being examined.

            formula.ElementCounts is the collection being traversed.
            */
            foreach(ElementCount elementCount in formula.ElementCounts)
            {
                /*
                The following statement calculates the mass contribution of the
                current element.

                elementCount.Count represents how many atoms of the current Element occur in the
                chemical formula.

                elementCount.Element.StandardAtomicWeight obtains the StandardAtomicWeight of that Element.

                The result is stored inside the double variable massContribution.
                */
                double massContribution = elementCount.Count * elementCount.Element.StandardAtomicWeight;

                /*
                The following statement adds the current element's mass contribution to totalMolarMass.
                Each pass through the loop will increase totalMolarMass by the mass contribution of the current Element.
                After every ElementCount has been processed, totalMolarMass contains the sum of all individual element 
                mass contributions.
                */
                totalMolarMass += massContribution;
            }

            /*
            The following statement creates an empty List that will store the
            ElementPercentComposition objects produced during the second stage
            of the calculation.

            List<ElementPercentComposition> means that the List can contain
            objects whose datatype is ElementPercentComposition.
            
            This will be a target-typed new expression because the datatype has already been 
            specified on the left side.

            C# already knows that new() needs to create a List<ElementPercentComposition>.
            The List initially contains no objects.
            */
            List<ElementPercentComposition> results = new();

            /*
            The following second foreach loop once again examines every
            ElementCount contained inside formula.ElementCounts.

            The first loop was needed to determine the total molar mass.

            Now that totalMolarMass is known, this second loop can determine
            what percentage of that total mass is contributed by each Element.
            */
            foreach (ElementCount elementCount in formula.ElementCounts)
            {
                // The mass contribution of the current Element is calculated again.
                double massContribution = elementCount.Count * elementCount.Element.StandardAtomicWeight;

                // Calculates the percentage of the total molar mass contributed by the current Element.
                double massPercent = (massContribution / totalMolarMass) * 100.0;

                // A new ElementPercentComposition object is created
                /*
                The constructor is recieving two arguments:
                (i)  elementCount.Element: The Element whose percent composition has just been calculated.
                (ii) massPercent: The calculated percentage of the total mass contributed by that Element

                This object will associate the chemical Element with its calculated mass percentage.

                The newly created object is stored temporarily inside the composition variable.
                */
                ElementPercentComposition composition = new ElementPercentComposition(elementCount.Element, massPercent);

                /*
                The following statement adds the newly created
                ElementPercentComposition object to the results List.

                Add() is a method provided by List<T>.

                Every pass through this foreach loop creates one
                ElementPercentComposition object and adds it to results.

                Therefore, after the loop finishes, results contains one
                percent-composition result for every ElementCount contained in
                the ChemicalFormula.
                */
                results.Add(composition);
            }

            /*
            The following statement returns the completed collection of ElementPercentComposition objects:
            Although results was created as List<ElementPercentComposition>, the method's declared return 
            datatype is IReadOnlyCollection<ElementPercentComposition>, List<ElementPercentComposition> implements
            IReadOnlyCollection<ElementPercentComposition>. Therefore, the List can be returned through the
            IReadOnlyCollection<ElementPercentComposition> interface . The code that receives the returned result 
            can therefore treat it as a read-only collection of percent-composition results rather than depending upon
            the concrete List implementation.
            */
            return results;
        }
    }
}