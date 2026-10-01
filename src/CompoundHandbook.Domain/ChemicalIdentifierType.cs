/* 
A chemical substance can be identified in several different ways.

For example, water is the common/traditional name of the substance.
Using systematic chemical nomenclature, H2O can also be described as 
'dihydrogen monoxide.' Its molecular formula, H2O, provides another
way of identifying its chemical composition.

Enumeration is a value type that defines a fixed set of named constants.

'ChemicalIdentifierType' enum defines the different categories of chemical identifiers 
recognized by the Compound Handbook
*/


namespace CompoundHandbook.Domain
{
    public enum ChemicalIdentifierType 
    {
        // A commonly used name for a chemical entity
        CommonName,

        // A systematic name based on chemical nomenclature rules
        SystematicName,

        // SMILES: Small Molecular Input Line Entry System
        // Represents molecular structure using a compact ASCII string
        Smiles,

        // InChI : International Chemical Identifier
        // A standardized textual identifier representing chemical structure
        InChI,

        // A shorter, fixed-length identifier derived from an InChI
        // Specefically used for database searching and indexing
        InChIKey,

        // Identifies the corresponding record for this chemical entity in an external database
        ExternalDatabaseId
    }
}