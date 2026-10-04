/*
An ElementCount represents one chemical element together with the number of atoms 
or units of that element that are present inside a chemical formula.

A chemical formula is made up of chemical symbols together with numerical subscripts 
that describe how many atoms of each element are represented.

The Compound Handbook needs a way to associate an Element object with the number of times
that element occurs in a chemical formula.
*/

/*
The following ElementCount class represents one element and its corresponding count inside
a chemical formula.

ElementCount object = Element + Count

Element is an object of the Element class that contains information about the particular chemical
element, such as its atomic number, symbol, name, and standard atomic weight.

Count is an integer that represents how many atoms or units of that element are represented
inside the chemical formula.

Both properties are read-only properties because they contain only a 'getter' accessor.

Therefore, these properties can be read from outside of the class, but they cannot be directly
changed from outside of the class after the ElementCount object has been constructed.

The following class also contains a constructor that receives the Element and Count required
to initialize a new ElementCount object.
*/
namespace CompoundHandbook.Domain 
{
    /*
    The following class represents one chemical element and its corresponding count
    inside the chemical formula.
    */ 
    public class ElementCount 
    {
        /*
        Read-only property that stores the Element associated with this ElementCount object.
        Element is a class itself, but is being used as the datatype of this property.
        The property will reference an Element object containing information about a 
        particular chemical element.
        */
        public Element Element { get; }

        /*
        Read-only property that stores the number of atoms or units of the Element
        represented inside the chemical formula.
        The datatype here is int.
        */
        public int Count { get; }

        /*
        The following constructor will be called whenever a new ElementCount object gets created.
        The constructor receives an Element object and an integer count as parameters.
        The supplied arguments are then assigned to their corresponding properties of the 
        ElementCount object.
        */
        public ElementCount(Element element, int count)
        {
            // Stores the supplied Element object in the Element property.
            Element = element;

            // Stores the supplied number of atoms or units in the Count property.
            Count = count;
        }
    }
}