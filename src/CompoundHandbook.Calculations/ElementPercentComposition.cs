/*
When the Compound Handbook calculates the percent composition of a chemical substance,
the result needs to describe how much each element contributes to the total mass of
that substance.

For example, a chemical formula can contain several different elements, and each
element contributes a particular percentage of the total molar mass.

Simply storing the percentage value by itself would not identify which element
that percentage belongs to.

This is why ElementPercentComposition is being created.

ElementPercentComposition allows the Calculations system to associate a particular
Element with the percentage of the total mass contributed by that element.
*/

/*
The following ElementPercentComposition class represents the mass-percent contribution
of one particular element to the total mass of a chemical substance.

ElementPercentComposition = Element + MassPercent

(i)  Element: Stores the Element whose mass contribution is being represented.
(ii) MassPercent: Stores the percentage of the total mass contributed by that element.

Both of these are read-only properties because they contain only a 'getter' accessor.

Therefore, these properties can be read from outside of the class, but they cannot
be directly changed from outside of the class after the ElementPercentComposition
object has been constructed.

The following class also contains a constructor that receives the Element and its
corresponding mass percentage required to initialize a new ElementPercentComposition
object.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.Calculations 
{
    // The following class represents the mass-percent contribution of one element.
    public class ElementPercentComposition 
    {
        /*
        Read-only property that stores the element whose mass-percent contribution
        is being represented.

        Element is a class itself, but is being used as the datatype of this property.

        Therefore, the Element property stores an Element object containing the
        information associated with the particular chemical element.
        */
        public Element Element { get; }

        /*
        Read-only property that stores the percentage of the total mass contributed
        by the corresponding element.

        The datatype here is double.
        */
        public double MassPercent { get; }

        /*
        The following constructor will be called whenever a new
        ElementPercentComposition object gets created.

        The constructor receives:
        (i)  An Element object representing the chemical element.
        (ii) A double value representing the mass percentage contributed by that element.

        The supplied arguments are then assigned to their corresponding read-only
        properties of the ElementPercentComposition object.
        */        
        public ElementPercentComposition(Element element, double massPercent) 
        {
            // Stores the supplied Element object in the Element property.
            Element = element;

            // Stores the supplied mass-percentage value in the MassPercent property.
            MassPercent = massPercent;
        }
    }
}