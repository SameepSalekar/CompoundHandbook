/*
FormulaKind represents the different ways in which a chemical formula can describe 
the composition of a chemical substance.

A chemical formula contains the chemical symbols of the elements present in a substance 
together with numerical subscripts that describe the relative numbers of those elements.
The meaning of those numbers can depend upon the type of chemical formula being represented.

For ionic compounds and other substances that do not exist as discrete molecules, a formula 
unit can instead represent the simplest electrically neutral ratio of the ions or elements 
in the substance.

The purpose of this file is to identify what kind of chemical formula is being stored.
*/

/*
The following FormulaKind is an enumeration.
An enumeration is a value type that defines a fixed set of named constants.

I do not want the different types of chemical formulas to be represented using arbitrary 
strings. Instead, I want the Compound Handbook to restrict a chemical formula to one of 
the predefined formula categories whenever its FormulaKind is known.

FormulaKind is therefore being created as its own datatype.

A variable or property whose datatype is FormulaKind can use one of the named values defined
inside this enumeration.

The Unknown value can be used when the type of a chemical formula has not yet been determined.
*/

namespace CompoundHandbook.Domain
{
    public enum FormulaKind 
    {
        /*
        Represents a chemical formula whose particular formula type is currently unknown.
        This value is useful when the Compound Handbook knows the formula itself but has'nt
        yet determined whether that formula should be interpreted as an empirical formula,
        molecular formula, or formula unit. 
        */
        Unknown,

        /*
        Represents an empirical formula.
        An empirical formula describes the simplest whole-number ratio of the elements
        present in a chemical substance.
        For example, hydrogen peroxide has the molecular formula H2O2, but its empirical
        formula is HO because 2:2 can be reduced to the simplest whole-number ratio of 1:1.
        */
        Empricial,

        /*
        Represents a molecular formula.
        A molecular formula describes the actual number of atoms of each element contained
        inside one molecule.
        */
        Molecular,

        /*
        Represents a formula unit.
        A formula unit is useful for substances such as ionic compounds that form extended
        lattices instead of existing as separate discrete molecules.
        For example, NaCl represents the simplest ratio of sodium ions to chloride ions 
        rather than one individual NaCl molecule.
        */
        FormulaUnit
    }
}