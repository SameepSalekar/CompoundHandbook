/*
I have made a separate Polymer category because a polymer cannot always be represented in the same
way as an ordinary small, discrete molecule.

A polymer is a substance composed of macromolecules, which are very large molecules containing
many atoms that are usually constructed from repeating structural units connected through
covalent bonds.

These repeating units in an individual polymer chain can vary.

Different polymer chains within a material can contain different numbers of repeating units and
therefore can have different molecular masses.

A polymer can still contain covalent bonds that can be represented using Lewis structures,
structural formulas, and skeletal structures.

However, drawing every atom of a large polymer chain would often be impractical.

Instead, polymer structures are commonly represented by drawing a repeating structural unit
inside brackets and using 'n' to indicate that the structure repeats.
For Example:
Polyethylene -> [-CH2-CH2-]n

Therefore, Polymer needs to be treated as a separate ChemicalEntity category so that the
Compound Handbook can recognize that the entity may require repeat-unit information, polymer
chain information, and other polymer-specific structural information rather than treating it
exactly like an ordinary small molecule.
*/

/*
The following Polymer class represents a specific type of ChemicalEntity whose chemical entity
is a polymer.

This class inherits from the ChemicalEntity base class.
Polymer will receive the common properties that were defined inside ChemicalEntity.

This will allow a Polymer object to contain the same basic identifying information as every other
ChemicalEntity while still allowing the Compound Handbook to recognize it as a specific polymer
chemical-entity type.

The constructor in here has a 'public' access modifier, therefore a Polymer object can be directly
created from outside of the class.

The Polymer constructor receives the same three pieces of information required by ChemicalEntity.

The base(...) call then passes these 3 arguments to the ChemicalEntity constructor, which will
initialize the inherited properties.
*/
namespace CompoundHandbook.Domain
{
    // Polymer inherits from the ChemicalEntity abstract base class
    public class Polymer : ChemicalEntity
    {
        // The following constructor will be called whenever a new Polymer object gets created.
        /*
        The arguments will be received by the Polymer constructor and are passed upwards to the
        ChemicalEntity constructor, which is being called by base(...).
        */
        public Polymer(string id, string displayName, IReadOnlyCollection<ChemicalIdentifier> identifiers) : base(id, displayName, identifiers)
        {
            /*
            The body of the Polymer constructor is empty because all three properties
            are initialized by the ChemicalEntity constructor.
            */
        }
    }
}