/*
Knowing the ChemicalEntityType of a chemical entity tells the Compound Handbook what general
kind of chemical entity is being represented.

For example, the ChemicalEntityType can tell the Compound Handbook whether the entity is a:
(i)   Molecule
(ii)  IonicSolid
(iii) NetworkCovalentSolid
(iv)  Metal
(v)   Polymer

However, knowing the general ChemicalEntityType does not completely describe the chemically
important characteristics of that entity.

For example, knowing that benzene is a Molecule does not tell us that benzene is also an
organic compound, a hydrocarbon, and an aromatic compound.

Similarly, knowing that ethanol is a Molecule does not tell us that ethanol is also an
organic compound and an alcohol.

This is why ChemicalCategory is being created.

ChemicalCategory provides additional chemical classifications that can be associated with
a ChemicalEntity after its general ChemicalEntityType has been determined.

An important feature of ChemicalCategory is that these categories are NOT intended to be
mutually exclusive.

One ChemicalEntity can belong to multiple ChemicalCategory values at the same time.

ChemicalEntityType answers what general type of chemical entity is this and 
ChemicalCategory answers what additional chemical classifications apply to that entity.

The different values inside ChemicalCategory also do not necessarily describe the same
classification axis. Organic and Inorganic are broad chemical classifications.
Acid and Base describe acid-base classifications or chemical behavior. 
Hydrocarbon describes a class of organic compounds based upon elemental composition.
Alcohol describes a compound class associated with a particular functional-group 
environment. Aromatic describes an important structural and electronic characteristic.
Biomacromolecule describes a broad class of large chemical entities associated with
biological systems.

All of this is intentional because I want to use ChemicalCategory as a multi-label 
chemical classification system rather than as a list from which exactly one category 
must be selected.

The Classification system can determine which of these categories apply to a ChemicalEntity
and store multiple ChemicalCategory values for the same entity when appropriate.

These classifications will help later help the Compound Handbook determine what information,
operations, calculations, and structural representations are relevant to a particular
chemical entity.
*/

/*
The following ChemicalCategory is an enumeration.

An enumeration is a value type that defines a fixed set of named constants.

I do not want the different chemical categories being represented by arbitrary strings.
Instead, I want the Compound Handbook to use these chemical categories as pre-defined values.
This is why I created this enum. 

Enumeration will reduce ambiguity and will give the Classification system a consistent set of 
chemical categories that it can assign to chemical entities.
At the same time, it does not mean that they are mutually exclusive.
Therefore, a chemical entity can be simultaneously associated with multiple enums.
*/

namespace CompoundHandbook.Classification 
{
    public enum ChemicalCategory 
    {
        // Represents a chemical entity that is classified as an organic chemical substance.
        Organic,
        /*
        Organic chemistry primarily concerns carbon-containing compounds, particularly compounds
        whose structures are based upon carbon frameworks and covalent bonding involving carbon.

        Carbon is especially important in organic chemistry because a carbon atom can form four
        covalent bonds and can bond to other carbon atoms.

        This allows carbon atoms to form:
        (i)   Chains
        (ii)  Branched structures
        (iii) Rings
        (iv)  Large and complex molecular frameworks

        Organic compounds can also contain other elements such as oxygen, nitrogen, sulfur,
        phosphorus, and the halogens.

        However, simply containing carbon does not automatically make a chemical substance organic.

        Certain carbon-containing substances, including carbon monoxide, carbon dioxide,
        carbonates, bicarbonates, and several other classes of carbon compounds are conventionally
        treated as inorganic substances.

        Therefore, the Organic category should represent a chemical classification determined
        by the Classification system rather than simply being assigned whenever carbon is present.

        Organic is a broad classification and can exist together with more specific
        ChemicalCategory values.
        */


        // Represents a chemical entity that is classified as an inorganic chemical substance.
        Inorganic,
        /*
        Inorganic chemistry concerns chemical substances that are not conventionally classified
        as organic compounds.

        Inorganic chemistry includes a very broad range of substances, including many:
        (i)   Salts
        (ii)  Minerals
        (iii) Metals
        (iv)  Metal compounds
        (v)   Acids and bases
        (vi)  Coordination compounds

        Inorganic substances can also involve several different types of chemical bonding,
        including ionic bonding, covalent bonding, and metallic bonding.

        The distinction between organic and inorganic chemistry cannot always be determined
        simply by checking whether carbon is present.

        For example, carbon dioxide and carbonate compounds contain carbon but are conventionally
        treated as inorganic substances.

        The Inorganic category therefore allows the Classification system to explicitly identify
        entities that belong to inorganic chemistry instead of assuming that the presence or
        absence of one particular element is sufficient to make that determination.

        Like the other ChemicalCategory values, Inorganic can coexist with another applicable
        category.
        */


        // Represents a chemical entity that can be classified as an acid.        
        Acid,
        /*
        An acid is a chemical species that can exhibit acidic behavior according to an applicable
        acid-base theory.

        According to the Bronsted-Lowry definition, an acid is a species that can donate a proton,
        H+, to another species.

        According to Lewis acid-base theory, a Lewis acid is a species that can accept an
        electron pair.

        Therefore, the meaning of an acid can depend upon which acid-base model and chemical
        context are being considered.

        Acid is therefore being represented as a ChemicalCategory rather than as a fundamental
        ChemicalEntityType.

        A chemical entity classified as an Acid can simultaneously belong to other categories.
        */


        // Represents a chemical entity that can be classified as a base.
        Base,
        /*
        A base is a chemical species that can exhibit basic behavior according to an applicable
        acid-base theory.

        According to the Bronsted-Lowry definition, a base is a species that can accept a proton,
        H+, from another species.

        According to Lewis acid-base theory, a Lewis base is a species that can donate an
        electron pair.

        Therefore, like acids, bases can be described using more than one acid-base model,
        and the classification can depend upon the chemical context being considered.

        Base is therefore being represented as a ChemicalCategory rather than as a fundamental
        ChemicalEntityType.

        A chemical entity classified as a Base can simultaneously belong to other categories.
        */
        

        // Represents an organic compound composed only of carbon and hydrogen.
        Hydrocarbon,
        /*
        A hydrocarbon is an organic compound whose elemental composition contains only carbon
        and hydrogen.

        The carbon atoms form the carbon framework of the molecule, while hydrogen atoms
        occupy the remaining appropriate bonding positions.

        Hydrocarbons can contain different carbon-carbon bonding arrangements and can therefore
        belong to several important chemical families.
        
        This includes 
        (i)    Alkanes              : Contain carbon-carbon single bonds
        (ii)   Alkenes              : Contain one or more carbon-carbon double bonds
        (iii)  Alkynes              : Contain one or more carbon-carbon triple bonds
        (iv)   Aromatic hydrocarbons: Contain aromatic carbon frameworks

        Because a hydrocarbon is also an organic compound, Hydrocarbon does not replace
        the Organic classification. Instead, both categories can apply simultaneously.
        */


        // Represents an organic compound that belongs to the alcohol compound class.
        Alcohol,
        /*
        An alcohol is an organic compound containing a hydroxyl functional group (-OH)
        bonded to an appropriate carbon atom.

        The oxygen atom of the hydroxyl group forms bonds with both the hydrogen atom and
        the carbon framework and also contains lone pairs of electrons.

        Because oxygen is more electronegative than both carbon and hydrogen, the bonds
        involving oxygen are polar.

        The hydroxyl group therefore strongly affects the physical and chemical behavior
        of alcohols.

        Because alcohol is a more specific chemical classification than Organic, the
        Alcohol category does not replace the Organic category.

        The Classification system should also distinguish between detecting a structural
        feature and deciding the chemical class of the complete entity.

        For example, the presence of an -OH group does not mean that every structure
        containing that group should automatically be classified as an ordinary alcohol.

        The surrounding chemical environment must also be considered.

        This distinction will become important when the Compound Handbook later performs
        functional-group detection and chemical classification.
        */        


        // Represents a chemical entity containing an aromatic system.
        Aromatic,
        /*
        Aromaticity describes an important structural and electronic property of certain
        cyclic conjugated chemical systems.

        In an aromatic system, pi electrons are delocalized across a cyclic conjugated
        structure rather than being confined to individual localized double bonds.

        For many simple aromatic systems, aromaticity can be understood using Huckel's rule.
        
        A planar, cyclic, fully conjugated system can be aromatic when it contains (4n + 2) pi
        electrons.

        For example, benzene, which is an aromatic compound. Benzene contains six carbon atoms 
        arranged in ring and contains 6 pi electrons participating in delocalized pi-electron system.

        Benzene can be drawn using alternating single and double bonds. However, these drawings 
        are resonance representations and should not be interpreted as three permanently localized 
        single bonds and three permanently localized double bonds. Instead, the pi electrons are 
        delocalized around the aromatic ring. Aromatic therefore represents a structural and electronic 
        classification rather than simply meaning that alternating single and double bonds appear in a 
        drawing.
        */


        // Represents a chemical entity classified as a biological macromolecule.
        Biomacromolecule
        /*
        A biomacromolecule is a very large molecule or macromolecular chemical entity associated
        with biological structure or biological function.

        Important classes of biological macromolecules are:
        (i)   Proteins
        (ii)  Nucleic acids
        (iii) Many large carbohydrate structures

        These chemical entities are often constructed from smaller structural units.
        For example, proteins contain amino-acid residues connected primarily through peptide
        bonds, while nucleic acids contain nucleotide units connected into polynucleotide chains.

        Biomacromolecules can contain very large numbers of atoms and can possess multiple
        levels of structural organization.

        Their properties can depend upon more than their elemental composition.

        Important information can include:
        (i)   Atomic connectivity
        (ii)  Functional groups
        (iii) Three-dimensional conformation
        (iv)  Interactions between different regions of the macromolecule

        Therefore, the Biomacromolecule category allows the Compound Handbook to recognize
        chemical entities for which biological-macromolecular classification is important.
        */
    }
}