/*
A chemical bond represents an interaction that holds atoms together within a chemical structure.

For covalent bonding, atoms share electrons with each other, and the number and arrangement of
shared electrons affects the type of bond that exists between the atoms.

The Compound Handbook therefore needs a way to describe what type of bond connects two atoms
inside a chemical structure, and this is done by the BondOrder enumeration.

BondOrder enum allows the Compound Handbook to store information about the type of bond connecting two atoms.
*/

/*
The following of the BondOrder is an enumeration.
An enumeration is a value type that defines a fixed set of named constants.

I do not want the bond types being represented by the arbitrary strings, instead I want the Compound
Handbook to use these bond types to be as pre-defined values. This is why I decided to create this enum.

This enum will be helpful because the program has to be restricted to the bond-order categories that have 
been explicitly defined. 
*/

namespace CompoundHandbook.Domain 
{
    /*
    BondOrder is the datatype that is being created here.

    A variable or property whose datatype is BondOrder can use one of the named
    values defined inside this enumeration.
    */
    public enum BondOrder 
    {
        // Represents a single bond.
        Single,
        /*
        Single bond contains one sigma (σ) bond.

        According to valence bond theory, a sigma bond is formed by the head-on overlap
        of atomic orbitals or hybrid orbitals along the internuclear axis connecting the two bonded atoms.

        Because the electron density of a sigma bond is concentrated along the internuclear axis,
        a single bond generally allows rotation around the bond axis, provided that steric or other 
        structural restrictions do not prevent it.

        A single bond is commonly represented in a structural formula using one line.
        */


        // Represents a double bond.
        Double,
        /*
        A double bond contains one sigma (σ) bond and one pi (π) bond.

        The sigma bond is formed by head-on orbital overlap along the internuclear axis.

        The pi bond is formed by the sideways overlap of two parallel, usually unhybridized, p orbitals.
        This produces electron density on opposite sides of the internuclear axis.
        commonly represented in a structural formula using one line.

        Because maintaining the pi bond requires the overlapping p orbitals to remain approximately parallel,
        rotation around a double bond is restricted compared with rotation around an ordinary single bond.

        A double bond is commonly represented in a structural formula using two lines.
        */


        // Represents a triple bond.
        Triple,
        /*
        A triple bond contains one sigma (σ) bond and two pi (π) bonds.

        The sigma bond is formed by head-on orbital overlap along the internuclear axis.

        The two pi bonds arise from sideways overlap involving two different pairs of parallel p orbitals.
        The two pi-bonding systems are oriented approximately perpendicular to each other.

        A triple bond is commonly represented in a structural formula using three lines.
        */


        // Represents a bond belonging to an aromatic bonding system. 
        Aromatic
        /*
        An aromatic bond belongs to an aromatic system in which pi electrons are delocalized across multiple
        connected atoms rather than being confined to one particular localized double bond.

        For example, benzene contains a sigma-bond framework together with a delocalized pi-electron system
        extending around the six-membered carbon ring.

        Although benzene can be drawn using alternating single and double bonds, these drawings are resonance
        representations and should not be interpreted as three permanently localized single bonds and three
        permanently localized double bonds.

        The Aromatic value therefore allows the Compound Handbook to distinguish aromatic bonding from an ordinary 
        localized Single or Double bond.
        */
    }
}