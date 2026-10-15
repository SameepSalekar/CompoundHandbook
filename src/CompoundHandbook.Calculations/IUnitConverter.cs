/*
The Compound Handbook works with chemical quantities that contain both a
numerical value and a unit.

However, the unit in which a quantity is currently represented may not always
be the unit needed by another part of the Compound Handbook or by the user.

For example, a temperature represented in degrees Celsius may need to be
converted into Kelvin.

A unit-conversion operation therefore needs two pieces of information:

(i)  The ChemicalQuantity that needs to be converted.
(ii) The target unit into which that quantity should be converted.

The result of the conversion should still be a ChemicalQuantity because the
converted result must contain both its new numerical value and its corresponding
unit.

However, I do not want other parts of the Compound Handbook to depend directly
upon one particular class that performs unit conversions.

Instead, I want the unit-conversion operation to be represented through its
own contract.

This is why IUnitConverter is being created.

IUnitConverter defines the common contract that a unit converter inside the
Compound Handbook must follow.

Any class that implements IUnitConverter must provide a Convert() method that
receives a ChemicalQuantity and a target unit and returns the converted
ChemicalQuantity.

The interface itself does not define the mathematical conversion formulas or
the specific units that can be converted.

Those details will instead be provided by a class that implements
IUnitConverter.

This allows other parts of the Compound Handbook to depend upon the
unit-conversion contract rather than depending directly upon one particular
implementation of the converter.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.Calculations
{
    /*
    The following IUnitConverter is an interface.

    An interface defines a contract describing the operations that an
    implementing class must provide.

    The 'I' at the beginning of IUnitConverter follows the common C# naming
    convention of beginning interface names with the letter 'I'.

    IUnitConverter defines the operation of converting a ChemicalQuantity
    from its current unit into a requested target unit.

    The method inside this interface contains a method declaration but does not
    contain a method body.

    Therefore, this interface specifies that unit conversion must be available,
    but it does not specify exactly how the conversion is performed.

    It will be the responsibility of a class that implements IUnitConverter to
    provide the actual method body and the unit-conversion logic.
    */    
    public interface IUnitConverter
    {
        /*
        The following Convert() method represents the operation that a unit
        converter must perform.

        The method receives two parameters:
        (i) ChemicalQuantity quantity
        ChemicalQuantity is a class itself, but is being used as the datatype of the quantity parameter.
        This parameter represents the chemical quantity that needs to be converted. A ChemicalQuantity 
        contains both a numerical value and its associated unit.
        (ii) string targetUnit
        targetUnit contains the textual representation of the unit into which the supplied 
        ChemicalQuantity should be converted.

        The returned ChemicalQuantity can contain the converted numerical value
        together with the requested target unit.

        Both the input and output use the ChemicalQuantity datatype.

        The purpose of Convert() is therefore not to change what kind of object
        represents the quantity. Instead, it converts the value-and-unit
        representation from one unit to another.

        Because this method is declared inside an interface without an
        implementation, a class that implements IUnitConverter must provide the
        actual implementation of Convert().
        */
        ChemicalQuantity Convert(ChemicalQuantity quantity, string targetUnit);
    }
}