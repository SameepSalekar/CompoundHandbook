/*
Valence describes the combining capacity of an Element and is closely related to how an Atom
participates in chemical bonding.

When the Compound Handbook evaluates whether the bonding arrangement around an Atom is
chemically reasonable, the validation process needs a compact description of the chemical
information that is relevant to that valence evaluation.

In this validation system, three pieces of information are being grouped together:
(i)   Element      : Identifies which chemical Element the Atom belongs to.
(ii)  FormalCharge : Stores the formal charge assigned to the Atom.
(iii) BondOrderSum : Stores the sum of the bond orders associated with the Atom.

The Element is important because different elements can have different expected or acceptable
bonding behavior.

The FormalCharge is important because the charge assigned to an Atom can affect how its
bonding environment should be interpreted.

The BondOrderSum provides a numerical description of the total bond order surrounding the Atom.
For example, a single bond contributes a bond order of 1, while a double bond contributes
a bond order of 2 and a triple bond contributes a bond order of 3.

By grouping these pieces of information together, the valence-validation system can pass
one ValenceContext object to a valence rule instead of passing each value separately.

This is why, ValenceContext class is being created to represent the chemical context needed
when evaluating valence rules inside the Compound Handbook.
*/

/*
The following ValenceContext class represents the information required to evaluate
the valence situation of an Atom.

ValenceContext object = Element + FormalCharge + BondOrderSum

All three of these are read-only properties because they contain only a 'getter' accessor.

Therefore, these properties can be read from outside of the class, but they cannot be directly
changed from outside of the class after the ValenceContext object has been constructed.

The following class also contains a constructor that receives the Element, formal charge,
and bond-order sum required to initialize a new ValenceContext object.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.Validation 
{
    /* 
    The following class represents the chemical context that will be 
    supplied when evaluating an Atom against a valence rule. 
    */
    public class ValenceContext 
    {
        /*
        Read-only property that stores the Element associated with the Atom whose
        valence is being evaluated.

        Element is a class defined inside the Domain layer of the Compound Handbook.

        The Element provides information about which chemical element is being considered,
        which is necessary because acceptable bonding behavior can depend upon the identity
        of the element.
        */
        public Element Element { get; }

        /*
        Read-only property that stores the formal charge associated with the Atom.

        The datatype here is int because formal charge is represented as an integer value.
        
        Formal charge is included in the ValenceContext because the charge state of an Atom
        can affect how its bonding and valence situation should be evaluated.
        */
        public int FormalCharge { get; }

        /*
        Read-only property that stores the sum of the bond orders surrounding the Atom.

        The datatype here is double.

        BondOrderSum provides a numerical summary of the bonding associated with the Atom
        so that a valence rule can use this information while evaluating whether the
        Atom's bonding situation is acceptable.
        */
        public double BondOrderSum { get; }

        /*
        The following constructor will be called whenever a new ValenceContext object gets created.

        The constructor receives an Element, an integer formal charge, and a double bond-order
        sum as parameters.

        These supplied values are then assigned to their corresponding read-only properties
        of the ValenceContext object.
        */
        public ValenceContext(Element element, int formalCharge, double bondOrderSum) 
        {
            // Stores the supplied Element object in the Element property.
            Element = element;

            // Stores the supplied integer formal-charge value in the FormalCharge property.
            FormalCharge = formalCharge;

            // Stores the supplied bond-order sum in the BondOrderSum property.
            BondOrderSum = bondOrderSum;
        }
    }
}