/*
The Compound Handbook needs to be able to calculate the percent composition of
a chemical substance from its chemical formula.

Percent composition describes how much each element contributes to the total mass
of a chemical substance, expressed as a percentage.

A chemical formula can contain more than one element. Therefore, a
percent-composition calculation can produce multiple results, with each result
representing the mass-percent contribution of one particular element.

For example, if a chemical formula contains two different elements, the
percent-composition calculation can produce one ElementPercentComposition object
for the first element and another ElementPercentComposition object for the
second element.

However, I do not want other parts of the Compound Handbook to depend directly
upon one particular class that performs the percent-composition calculation.

Instead, I want the percent-composition calculation operation to be represented
through its own contract.

This is why IPercentCompositionCalculator is being created.

IPercentCompositionCalculator defines the common contract that a
percent-composition calculator inside the Compound Handbook must follow.

Any class that implements IPercentCompositionCalculator must provide a Calculate()
method that receives a ChemicalFormula and returns a collection of
ElementPercentComposition objects.

The interface itself does not define the actual mathematical steps used to
calculate the percent composition.

Those steps will instead be provided by a class that implements
IPercentCompositionCalculator.

This allows other parts of the Compound Handbook to depend upon the
percent-composition-calculation contract rather than depending directly upon
one particular implementation of the calculator.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.Calculations
{
    /*
    The following IPercentCompositionCalculator is an interface.

    An interface defines a contract describing the operations that an implementing
    class must provide.

    The 'I' at the beginning of IPercentCompositionCalculator follows the common
    C# naming convention of beginning interface names with the letter 'I'.

    IPercentCompositionCalculator defines the operation of calculating the
    percent composition associated with a ChemicalFormula.

    The method inside this interface contains a method declaration but does not
    contain a method body.

    Therefore, this interface specifies that percent-composition calculation
    must be available, but it does not specify exactly how the calculation
    is performed.

    It will be the responsibility of a class that implements
    IPercentCompositionCalculator to provide the actual method body and the
    calculation logic.
    */
    public interface IPercentCompositionCalculator
    {
        /*
        The following Calculate() method represents the operation that a
        percent-composition calculator must perform.

        ChemicalFormula formula is the parameter representing the chemical formula
        whose percent composition needs to be calculated.

        ChemicalFormula is a class itself, but is being used as the datatype of
        the formula parameter.

        The ChemicalFormula object contains information about the elemental
        composition of the chemical formula, including the elements present and
        their corresponding element counts.

        IReadOnlyCollection<ElementPercentComposition> is the return datatype
        of this method.

        IReadOnlyCollection<T> is a .NET generic interface that represents a
        collection whose elements can be accessed but cannot be added or removed
        through this interface.

        ElementPercentComposition is a class itself, but is being supplied as
        the generic type argument <T>.

        Therefore, IReadOnlyCollection<ElementPercentComposition> represents a
        read-only collection containing ElementPercentComposition objects.

        Each ElementPercentComposition object associates one Element with the
        percentage of the total mass contributed by that element.

        Because a ChemicalFormula can contain multiple different elements, the
        Calculate() method returns a collection rather than returning only one
        ElementPercentComposition object.

        Because this method is declared inside an interface without an
        implementation, a class that implements IPercentCompositionCalculator
        must provide the actual implementation of Calculate().
        */
        IReadOnlyCollection<ElementPercentComposition> Calculate(ChemicalFormula formula);
    }
}