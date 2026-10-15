/*
The Compound Handbook needs to be able to calculate the molar mass of a chemical
substance from its chemical formula.

Molar mass represents the mass of one mole of a substance and is determined from
the elements present in the chemical formula, the number of atoms of each element,
and their corresponding atomic masses.

However, I do not want other parts of the Compound Handbook to depend directly
upon one particular class that performs the molar-mass calculation.

Instead, I want the molar-mass calculation operation to be represented through
its own contract.

This is why IMolarMassCalculator is being created.

IMolarMassCalculator defines the common contract that a molar-mass calculator
inside the Compound Handbook must follow.

Any class that implements IMolarMassCalculator must provide a Calculate() method
that receives a ChemicalFormula and returns a CalculationResult.

The interface itself does not define the actual mathematical steps used to
calculate the molar mass.

Those steps will instead be provided by a class that implements
IMolarMassCalculator.

This allows other parts of the Compound Handbook to depend upon the
molar-mass-calculation contract rather than depending directly upon one
particular implementation of the calculator.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.Calculations
{
    /*
    The following IMolarMassCalculator is an interface.

    An interface defines a contract describing the operations that an implementing
    class must provide.

    The 'I' at the beginning of IMolarMassCalculator follows the common C#
    naming convention of beginning interface names with the letter 'I'.

    IMolarMassCalculator defines the operation of calculating the molar mass
    associated with a ChemicalFormula.

    The method inside this interface contains a method declaration but does not
    contain a method body.

    Therefore, this interface specifies that molar-mass calculation must be
    available, but it does not specify exactly how the calculation is performed.

    It will be the responsibility of a class that implements IMolarMassCalculator
    to provide the actual method body and the calculation logic.
    */
    public interface IMolarMassCalculator 
    {
        /*
        The following Calculate() method represents the operation that a
        molar-mass calculator must perform.

        ChemicalFormula formula is the parameter representing the chemical formula
        whose molar mass needs to be calculated.

        ChemicalFormula is a class itself, but is being used as the datatype of
        the formula parameter.

        The ChemicalFormula object contains information about the elemental
        composition of the chemical formula, including the elements present and
        their corresponding element counts.

        CalculationResult is the return datatype of this method.

        Therefore, after Calculate() performs the molar-mass calculation, it
        returns a CalculationResult describing the result of that calculation.

        The returned CalculationResult can contain:
        (i)   Whether the calculation was successful.
        (ii)  The calculated ChemicalQuantity.
        (iii) Messages associated with the calculation.

        Because this method is declared inside an interface without an
        implementation, a class that implements IMolarMassCalculator must provide
        the actual implementation of Calculate().
        */
        CalculationResult Calculate(ChemicalFormula formula);
    }
}