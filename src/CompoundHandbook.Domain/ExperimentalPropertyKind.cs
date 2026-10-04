/*
Experimental properties are chemical or physical properties whose values can be determined
through experimental measurements.

The Compound Handbook can contain different types of experimental properties, such as the
melting point, boiling point, and density of a chemical substance.

These properties are important because they provide measurable information about how a substance
behaves and can help distinguish one chemical substance from another.

The Compound Handbook therefore needs a way to describe what type of experimental property is
being stored, and this is done by the ExperimentalPropertyKind enumeration.
*/

/*
The following ExperimentalPropertyKind is an enumeration.
An enumeration is a value type that defines a fixed set of named constants.

I do not want the different experimental property types being represented by arbitrary strings,
instead I want the Compound Handbook to use these property types as pre-defined values.
This is why I decided to create this enum.

The Other value is also included so that experimental properties outside of the explicitly
defined categories can still be represented.
*/

namespace CompoundHandbook.Domain 
{
    /*
    ExperimentalPropertyKind is the datatype that is being created here.
    A variable or property whose datatype is ExperimentalPropertyKind can use one of the named
    values defined inside this enumeration.
    */
    public enum ExperimentalPropertyKind 
    {
        // Represents the melting point of a chemical substance.
        MeltingPoint,
        /*
        Melting point is the temperature at which the solid and liquid phases of a substance
        can exist in equilibrium at a specified pressure.

        Melting point is an important physical property because it provides information about
        the strength and nature of the interactions holding the particles together in the solid.

        Substances with stronger attractive interactions generally require more thermal energy
        to disrupt their organized solid structure, although crystal structure and other factors
        can also strongly influence the melting point.

        Melting point is also useful for identifying substances and evaluating purity because
        a pure crystalline substance commonly melts over a relatively narrow temperature range,
        while impurities can change and broaden that melting behavior.
        */


        // Represents the boiling point of a chemical substance. 
        BoilingPoint,
        /*
        Boiling point is the temperature at which the vapor pressure of a liquid becomes equal
        to the external pressure acting on the liquid.

        At this point, vapor bubbles can form throughout the liquid rather than evaporation
        occurring only at the surface.

        Boiling point is an important physical property because it provides information about
        the intermolecular attractions that must be overcome for molecules to enter the gas phase.

        It is also important when comparing and separating substances because differences in
        boiling points make processes such as distillation possible.
        */


        // Represents the density of a chemical substance.
        Density,
        /*
        Density describes the amount of mass contained within a particular volume of a substance.

        Density is an important physical property because it relates the measurable mass of a
        substance to the amount of space that substance occupies.

        Different substances can have significantly different densities because their particles
        have different masses and can be packed together differently.

        Density is therefore useful for identifying and comparing substances and for converting
        between the mass and volume of a material when its density is known.
        */


        // Represents an experimental property that does not belong to the categories defined above.
        Other
        /*
        The Compound Handbook may later store experimental properties other than melting point,
        boiling point, and density.

        The Other value allows such a property to still be represented without incorrectly
        classifying it as one of the explicitly defined property types above.
        */
    }
}