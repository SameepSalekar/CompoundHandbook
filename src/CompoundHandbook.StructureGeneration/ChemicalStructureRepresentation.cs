/*
A chemical structure can be represented in different formats depending upon how the
Compound Handbook needs to store or display that structure.

For example, a chemical-structure representation may contain textual information or it
may contain SVG markup that describes a graphical representation of the structure.

Although these different representations store their actual structural information in
different ways, they still share one common piece of information which is 'StrcuterRepresentationKind',
that tells the CompoundHandbook what type of representation is being stored.

This is why ChemicalStructureRepresentation is being created as a common base class
for the different types of chemical-structure representations.

Instead of requiring every representation class to independently define the common
Kind property, that property can be defined once inside ChemicalStructureRepresentation.

The specific representation classes can then inherit from this class and add the
additional information required by their particular representation format.
*/

/*
The following ChemicalStructureRepresentation is an abstract class.

An abstract class is a class that is designed to act as a base class for other classes.

An object cannot be directly created from an abstract class.

Therefore, the Compound Handbook will not directly create a
ChemicalStructureRepresentation object.

Instead, specific structure-representation classes can inherit from
ChemicalStructureRepresentation and receive the common Kind property defined inside
this class.

The Kind property is a read-only property because it contains only a 'getter' accessor.

Therefore, the Kind value can be read from outside of the object, but it cannot be
directly changed from outside of the class after the object has been constructed.

The following class also contains a constructor that receives the
StructureRepresentationKind required to initialize the Kind property.

The constructor is using the 'protected' access modifier because
ChemicalStructureRepresentation is an abstract base class.

The 'protected' access modifier allows classes that inherit from
ChemicalStructureRepresentation to call this constructor and initialize the common
Kind property when a specific structure-representation object is being created.
*/

namespace CompoundHandbook.StructureGeneration 
{
    /*
    The following abstract class represents the common base of the different
    chemical-structure representations used by the Structure Generation system.
    */
    public abstract class ChemicalStructureRepresentation 
    {
        /*
        Read-only property that stores the kind of chemical-structure representation.
        StructureRepresentationKind is an enum itself, but is being used as the
        datatype of this property.
        */
        public StructureRepresentationKind Kind { get; }

        /*
        The following constructor is intended to be called by the constructors of
        classes that inherit from ChemicalStructureRepresentation.

        The constructor receives a StructureRepresentationKind value that identifies
        the type of representation being created.

        The 'protected' access modifier prevents this constructor from being called
        like an ordinary public constructor from unrelated code, while allowing
        derived classes to call it.
        */
        protected ChemicalStructureRepresentation(StructureRepresentationKind kind)
        {
            // Stores the supplied StructureRepresentationKind value in the Kind property.
            Kind = kind;
        }
    }
}