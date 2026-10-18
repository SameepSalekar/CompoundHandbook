/*
The validation system of the Compound Handbook can discover many different types of problems
when checking chemical formulas, molecular graphs, atoms, bonds, and other chemical information.

Simply knowing that a validation issue exists would not provide enough information about
what particular type of problem was discovered.

For example, a molecular graph may contain two atoms with the same Id, a bond may reference
an Atom that does not exist, or the graph may contain an atom whose bonding raises a
valence-related concern.

This is why, ValidationCode is being created so that each type of validation issue can be
identified using a specific predefined code.

The ValidationCode will later be stored inside a ValidationIssue object together with other
information such as the severity and message associated with that validation issue.

This will allow the Compound Handbook to distinguish between different validation problems
without depending only upon the textual validation message.
*/

/*
The following ValidationCode is an enumeration.
An enumeration is a value type that defines a fixed set of named constants.

I do not want the different types of validation issues to be represented using arbitrary
strings. Instead, I want the Compound Handbook to restrict validation codes to the
pre-defined validation categories.

This is why I decided to create this enum.

A variable or property whose datatype is ValidationCode can use one of the named
values defined inside this enumeration.

Each named value represents a particular type of issue that may be discovered during
the validation of chemical information.
*/

namespace CompoundHandbook.Validation 
{
    /*
    ValidationCode is the datatype that is being created here.
    The following enum provides the different codes that can be assigned to
    validation issues produced by the Compound Handbook.
    */ 
    public enum ValidationCode 
    {
        /*
        Represents a validation issue in which information required for a particular
        chemical object or operation has not been provided.

        This code can be used when the validation process expects a required value
        but that value is missing.
        */
        MissingRequiredValue,

        /*
        Represents an invalid number of atoms or units of an Element inside
        a chemical formula.

        An ElementCount is expected to describe a meaningful quantity of an Element.
        Therefore, an invalid count can indicate that the chemical formula contains
        an invalid elemental composition.
        */
        InvalidElementCount,
        
        /*
        Represents a situation in which more than one Atom inside the same
        MolecularGraph uses the same Atom Id.

        Atom Id values are used to distinguish particular atoms from one another.
        Duplicate Atom Id values can therefore make it ambiguous which Atom is being
        referenced by other parts of the molecular graph.
        */
        DuplicateAtomId,

        /*
        Represents a Bond whose endpoint refers to an Atom Id that does not exist
        inside the MolecularGraph.

        Every Bond contains Atom1Id and Atom2Id values that identify the two atoms
        connected by that bond.

        If either of those Id values does not correspond to an existing Atom,
        the Bond contains an unknown endpoint.
        */
        UnknownBondEndpoint,
        
        /*
        Represents a Bond in which both endpoints refer to the same Atom.

        A Bond is intended to describe a connection between two particular atoms.
        Therefore, a bond whose Atom1Id and Atom2Id identify the same Atom is
        treated as a self-bond validation issue.
        */
        SelfBond,
        
        /*
        Represents a situation in which the same bond relationship appears more
        than once inside a MolecularGraph.

        Duplicate bonds can incorrectly represent the connectivity of the molecular
        structure and therefore need to be detected during graph validation.
        */
        DuplicateBond,
        
        /*
        Represents a problem associated with the BondOrder assigned to a Bond.

        BondOrder describes the type of bonding relationship between two atoms.
        Therefore, this validation code can be used when the bond order associated
        with a particular Bond is considered invalid by the validation process.
        */
        InvalidBondOrder,
        
        /*
        Represents a MolecularGraph whose atoms do not all belong to one connected
        molecular structure.

        A disconnected graph contains separate groups of atoms for which no sequence
        of bonds connects one group to another.

        This code allows the validation system to identify that connectivity concern.
        */
        DisconnectedGraph,
        
        /*
        Represents a concern involving the valence of an Atom.

        The number and type of bonds surrounding an Atom can be examined in the
        context of the Element and formal charge associated with that Atom.

        If the bonding arrangement raises a valence-related concern, the validation
        system can identify that issue using this code.
        */        
        ValenceConcern,
        
        /*
        Represents a concern involving the formal charge associated with an Atom
        or the charge information being considered during formula validation.

        Formal charge is used as a bookkeeping method for describing the distribution
        of valence electrons within a chemical structure.

        This code allows the validation system to identify a validation concern
        associated with that charge information.
        */
        FormalChargeConcern,
        
        /*
        Represents a chemical case that the current Compound Handbook validation
        system does not support.

        A chemical case being unsupported does not necessarily mean that the chemistry
        itself is invalid. Instead, it can mean that the current implementation does
        not yet contain the rules required to properly evaluate that particular case.

        This code allows unsupported chemistry to be distinguished from chemistry
        that has actually failed a validation rule.
        */        
        UnsupportedChemicalCase
    }
}