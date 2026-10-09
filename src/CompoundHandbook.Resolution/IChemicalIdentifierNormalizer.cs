/*
A ChemicalIdentifier represents one way in which a chemical entity can be identified.

Different ChemicalIdentifier objects may contain identifier values that need to be placed
into a consistent form before the Compound Handbook uses them during chemical-entity resolution.

The process of converting a chemical identifier into this consistent form is called normalization.

Normalization is useful because differences in how an identifier is written should not necessarily
prevent the Resolution system from recognizing identifiers that are intended to represent the
same chemical information.

Instead of making the ChemicalEntityResolver itself responsible for defining how every
ChemicalIdentifier should be normalized, I want the normalization process to be represented
through its own contract.

This is why, IChemicalIdentifierNormalizer is being created.

IChemicalIdentifierNormalizer defines an operation that receives a ChemicalIdentifier and
returns a ChemicalIdentifier representing its normalized form.

The ChemicalEntityResolver can therefore depend upon IChemicalIdentifierNormalizer whenever
it needs an identifier to be normalized before using that identifier during the
chemical-entity resolution process.

The actual rules used to normalize a ChemicalIdentifier are not defined by this interface.
Those rules will be provided by a separate class that implements IChemicalIdentifierNormalizer.
*/

/*
The following IChemicalIdentifierNormalizer is an interface.

An interface defines a contract that describes what operations an implementing class must
provide without defining the actual implementation of those operations here.

The 'I' at the beginning of IChemicalIdentifierNormalizer follows the common C# naming
convention of beginning interface names with the letter 'I'.

IChemicalIdentifierNormalizer defines the normalization operation. The method inside this interface 
contains a method declaration but does not contain a method body.

Therefore, this interface specifies that chemical-identifier normalization must be available,
but it does not specify exactly how the normalization process is performed.

It will be the responsibility of the class that implements IChemicalIdentifierNormalizer
to provide the actual method body and to define the rules used to normalize a ChemicalIdentifier.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.Resolution
{
    /*
    The following interface defines the operation that must be provided by a
    chemical-identifier normalizer used by the Compound Handbook.

    The 'public' access modifier allows this interface to be accessed from outside
    of the CompoundHandbook.Resolution namespace.

    The 'interface' keyword specifies that IChemicalIdentifierNormalizer is an
    interface rather than a class.
    */    
    public interface IChemicalIdentifierNormalizer
    {
        /*
        The following method is used to normalize a ChemicalIdentifier.

        ChemicalIdentifier is the datatype of the parameter named identifier.
        Therefore, the method receives a ChemicalIdentifier object that needs
        to be normalized.

        ChemicalIdentifier is also the return datatype of this method.
        Therefore, after Normalize() processes the supplied identifier, it is
        expected to return a ChemicalIdentifier representing the normalized form.

        The ChemicalIdentifier supplied as the argument represents the identifier
        before normalization, while the returned ChemicalIdentifier represents
        the result of the normalization process.

        This interface only declares the operation. The actual rules and steps used
        to normalize the ChemicalIdentifier will be defined by the class that
        implements IChemicalIdentifierNormalizer.
        */
        ChemicalIdentifier Normalize(ChemicalIdentifier identifier);
    }
}