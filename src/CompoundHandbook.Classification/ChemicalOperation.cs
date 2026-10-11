/*
After the Compound Handbook identifies and classifies a ChemicalEntity, it needs to determine
what chemical operations can meaningfully be performed for that entity.

Not every operation is appropriate for every type of chemical entity.

For example, a Molecule can potentially have a molecular formula, Lewis structure, condensed
structure, and skeletal structure.

However, an IonicSolid does not consist of individual discrete molecules. Therefore, representing
an ionic solid using a formula unit is more appropriate than treating it as a molecule.

Similarly, a Polymer can contain a very large number of repeating structural units. Therefore,
showing its repeat unit can be more useful than attempting to represent the entire polymer chain.

This is why ChemicalOperation is being created.

ChemicalOperation represents the different chemical operations that the Compound Handbook
can perform for a ChemicalEntity.

Like ChemicalCategory, these values are NOT mutually exclusive.

A ChemicalEntity can have multiple applicable ChemicalOperation values at the same time.

ChemicalCategory and ChemicalOperation therefore answer two different questions.

ChemicalCategory answers what chemical classifications apply to the entity and
ChemicalOperation answers what the Compound Handbook can meaningfully do with that entity.

The Classification system can use the ChemicalEntityType and ChemicalCategory values of an
entity to determine which ChemicalOperation values are applicable.

This will prevent the Compound Handbook from offering operations that are chemically
inappropriate for a particular type of chemical entity.
*/


/*
The following ChemicalOperation is an enumeration.

An enumeration is a value type that defines a fixed set of named constants.

I do not want the different chemical operations being represented by arbitrary strings.
Instead, I want the Compound Handbook to use these chemical operations as pre-defined values.
This is why I created this enum.

Enumeration will reduce ambiguity and will give the Classification system a consistent set
of operations that it can associate with chemical entities.

At the same time, defining an operation inside this enum does not mean that the operation is
applicable to every ChemicalEntity.

The Classification system will determine which ChemicalOperation values are applicable to
each chemical entity.
*/

namespace CompoundHandbook.Classification 
{

    public enum ChemicalOperation 
    {
        // Represents the operation of calculating the molar mass of a chemical substance        
        CalculateMolarMass,
        /*
        Molar mass represents the mass of one mole of a chemical substance and is commonly
        expressed in grams per mole (g/mol).

        One mole corresponds to approximately 6.022 x 10^23 specified entities.

        The molar mass of a substance can be calculated from its chemical formula by adding
        the atomic-weight contributions of all elements represented in that formula.
        
        This operation uses the elemental composition of a ChemicalFormula together
        with the atomic-weight information associated with its Elements.
        */


        // Represents the operation of calculating the percent composition of a chemical substance.
        CalculatePercentComposition,
        /*
        Percent composition describes the percentage of the total mass of a chemical substance
        that is contributed by each element present in that substance.

        Percent composition is significant because it connects a chemical formula to the actual
        mass contribution of its constituent elements.

        Two chemical substances can contain the same elements but contain them in different
        proportions. Their percent compositions can therefore help distinguish their elemental
        makeup quantitatively.

        Percent composition is also useful in experimental chemistry because measured elemental
        percentages can be compared with theoretically calculated percentages to help determine
        or verify the composition of a substance.

        Therefore, this operation allows the Compound Handbook to go beyond simply stating which
        elements are present and instead describe how much each element contributes to the total
        mass of the chemical substance.
        */


        // Represents the operation of generating the molecular formula of a chemical entity.        
        GenerateMolecularFormula,
        /*
        A molecular formula shows the actual number of atoms of each element present in one
        molecule of a chemical substance.

        The molecular formula is significant because it provides the exact elemental composition
        of a molecule while remaining much more compact than a complete structural representation.

        It also distinguishes substances whose empirical formulas may be identical even though
        their actual molecular compositions are different.

        This operation allows the Compound Handbook to provide the actual elemental
        composition of a Molecule when sufficient information about that molecule is available.
        */


        // Represents the operation of generating a Lewis structure of a chemical entity.
        GenerateLewisStructure,
        /*
        A Lewis structure represents the arrangement of valence electrons, chemical bonds,
        lone pairs, and formal charges within a chemical structure.

        Lewis structures are significant because a chemical formula alone does not explain
        how valence electrons are distributed between the atoms of a chemical species.

        Understanding this electron distribution helps explain important chemical features such
        as bonding, multiple bonds, lone pairs, formal charges, and resonance.

        Lewis structures can also provide the foundation for reasoning about molecular geometry
        and other structural characteristics of a molecule.

        Therefore, this operation allows the Compound Handbook to move beyond elemental
        composition and provide an electron-level representation of an applicable chemical
        structure.
        */


        // Represents the operation of generating a condensed structural formula.
        GenerateCondensedStructure,
        /*
        A condensed structural formula represents the connectivity of atoms within a molecule
        without explicitly drawing every individual chemical bond.

        Condensed structures are significant because molecular formulas can tell us which atoms
        are present but cannot completely describe how those atoms are connected.

        This becomes especially important for compounds that have the same molecular formula
        but different atomic connectivity.

        Therefore, this operation allows the Compound Handbook to provide structural information
        about a molecule while keeping the representation compact and readable.
        */


        // Represents the operation of generating a skeletal structure of a chemical entity.
        GenerateSkeletalStrucuture,
        /*
        A skeletal structure, also called a line-angle structure, is a simplified structural
        representation in which the carbon framework of a molecule is primarily represented
        using lines and vertices.

        Skeletal structures are significant because explicitly showing every carbon atom,
        hydrogen atom, and chemical bond can make larger organic structures difficult to read.

        By simplifying the carbon and hydrogen framework while preserving important connectivity,
        skeletal structures make the overall architecture of many organic molecules much easier
        to recognize and analyze.

        They are especially useful for recognizing carbon chains, branches, rings, functional
        groups, and other important structural features.

        Therefore, this operation allows the Compound Handbook to provide a compact visual
        representation of applicable molecular structures without losing their important
        structural connectivity.
        */


        // Represents the operation of detecting functional groups within a chemical structure.        
        DetectFunctionalGroups,
        /*
        A functional group is a particular arrangement of atoms and bonds within a molecule
        that is associated with characteristic chemical properties and chemical behavior.

        Functional groups are significant because molecules containing similar functional groups
        can often undergo similar types of chemical reactions even when the remainder of their
        molecular structures are different.

        Identifying functional groups can therefore provide useful information about how a
        chemical substance may be classified and how parts of its structure may behave chemically.

        However, detecting a structural feature does not automatically determine the classification
        of the entire chemical entity because the surrounding chemical environment must also be
        considered.

        Therefore, this operation allows the Compound Handbook to recognize chemically meaningful
        structural patterns that can contribute to the classification and analysis of a molecule.
        */        


        // Represents the operation of retrieving experimentally measured properties of a chemical entity.
        RetrieveExperimentalProperties,
        /*
        Experimental properties are chemical or physical properties whose values are obtained
        from experimental measurement.

        Examples include melting point, boiling point, density, and other measurable properties
        of chemical substances.

        Experimental properties are significant because knowing the composition and structure
        of a chemical entity does not by itself provide every property that a user may want
        to know about that substance.

        These properties also connect the theoretical representation of a chemical entity to
        how the substance actually behaves and is observed under real physical conditions.

        Because experimental values can depend upon measurement conditions and data sources,
        this information can also require associated conditions, units, and source information.

        Therefore, this operation allows the Compound Handbook to supplement its calculated and
        structural information with experimentally determined information about a chemical entity.
        */        


        // Represents the operation of showing the formula unit of a chemical substance.
        ShowFormulaUnit,
        /*
        A formula unit represents the simplest whole-number ratio of constituent particles in
        a substance that does not exist as individual discrete molecules.

        Formula units are significant because not every chemical substance should be described
        using the concept of a molecule.

        For example, sodium chloride forms an extended ionic lattice rather than existing as
        separate NaCl molecules within the solid.

        NaCl therefore represents the simplest ratio of sodium ions to chloride ions rather
        than one individual sodium chloride molecule.

        This distinction prevents the Compound Handbook from applying molecular terminology
        to substances whose structures are better described as extended lattices.

        Therefore, this operation allows the Compound Handbook to display an appropriate
        compositional representation for chemical entities such as ionic solids.
        */


        // Represents the operation of showing the repeating structural unit of a polymer.
        ShowRepeatUnit
        /*
        A repeat unit is the structural unit whose repetition describes the characteristic
        chain structure of a polymer.
        
        Repeat units are significant because polymer molecules can contain extremely large
        numbers of atoms, making it impractical and often unnecessary to represent the entire
        polymer chain atom-by-atom.

        The number of repeating units can also vary between polymer chains, meaning that one
        fixed molecular formula may not be the most useful way to communicate the structure
        of a polymer sample.

        Showing the repeat unit instead captures the characteristic structural pattern of the
        polymer in a compact and chemically meaningful form.

        Therefore, this operation allows the Compound Handbook to provide an appropriate
        structural representation for polymers without requiring the complete macromolecular
        chain to be displayed.
        */
    }
}