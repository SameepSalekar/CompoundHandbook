/*
Atom is the basic unit of a chemical element that retains the chemical identity of that element.

The Element class that was created previously represents general information about a chemical
element, such as its atomic number, chemical symbol, name, and standard atomic weight.

An Atom object represents a particular atom that is being used inside a chemical structure.

For example, a water molecule contains two hydrogen atoms and one oxygen atom.
Both hydrogen atoms belong to the same chemical element, Hydrogen, and therefore they can both
reference the same Element information. However, they are still two different atoms inside 
the molecular structure.

An Atom object also contains a reference to an Element object, which will then provide the information
pieces of the Element object

The entire purpose of doing this, is to prevent every individual Atom object from having 
to separately store another copy of the atomic number, symbol, name, and standard atomic weight.

Instead, the Atom object represents the particular atom, while the Element object describes
which chemical element that atom belongs to.

The Atom class also stores the formal charge of the atom.

Formal charge is a bookkeeping charge assigned to an atom when analyzing the distribution of
valence electrons in a chemical structure.

An atom with a FormalCharge of 0 is represented as having no formal charge. A positive FormalCharge
represents a positive formal charge, while a negative FormalCharge represents a negative formal charge.
Formal charge will later be useful when the Compound Handbook represents and validates chemical
structures in which atoms may carry formal charges.
*/

/*
The following Atom class represents one particular atom inside a chemical structure in the Compound Handbook

Atom object = Id + Element + FormalCharge

Id stores an integer identifier used to distinguish this atom from other atoms 
inside the same chemical structure.

Stores a reference to the Element object that describes which chemical element this atom belongs to.

All three of this object are read-only properties because they contain only a 'getter' accessor.

Therefore, these properties can be read from outside of the class, but they cannot be directly
changed from outside of the class after the Atom object has been constructed.

The following class also contains a constructor that receives the Id, Element, and FormalCharge
required to initialize a new Atom object.
*/

namespace CompoundHandbook.Domain 
{
    // The following class represents one particular atom inside a chemical structure.
    public class Atom 
    {
        // Read-only property that stores the identifier of a particular atom
        // The datatype of this will be int.
        public int Id { get; }

        /* 
        Read-only property that stores the Element associated with this atom.
        Element is a class itself, but is being used as a datatype in here.
        The property references an Element object containing the elemental information associated
        with a particular atom.
        */
        public Element Element { get; }

        // Read-only property that stores the formal charge assigned to this particular atom.
        // The datatype of this property is int. 
        public int FormalCharge { get; }

        // The following constructor will be called whenever a new Atom object gets created.
        public Atom (int id, Element element, int formalCharge) 
        {
            // Stores the supplied atom identifier in the Id property.
            Id = id;

            // Stores the supplied Element object in the Element property.
            Element = element;

            // Stores the supplied formal charge in the FormalCharge property.
            FormalCharge = formalCharge;
        } 
    }
}