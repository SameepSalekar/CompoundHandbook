/*
ResolutionStatus represents the possible outcomes that can occur when the Compound Handbook
attempts to resolve the user's chemical input into a particular ChemicalEntity.

Chemical resolution is the process of determining which ChemicalEntity the supplied chemical
input is referring to.

For example, the user may provide a chemical name, chemical formula, or another recognized
chemical identifier. The Resolution system will then attempt to determine which ChemicalEntity
corresponds to that input.

However, the resolution process will not always successfully identify exactly one ChemicalEntity.

The supplied input may:
(i)   Successfully correspond to one ChemicalEntity.
(ii)  Correspond to multiple possible ChemicalEntity objects.
(iii) Fail to correspond to any known ChemicalEntity.
(iv)  Be invalid input that cannot properly be processed.
(v)   Represent a type of input that the current resolution system does not support.

The Compound Handbook therefore needs a way to describe the outcome of the chemical-entity
resolution process, and this is done by the ResolutionStatus enumeration.

ResolutionStatus will later be stored inside ChemicalEntityResolutionResult so that the rest
of the Compound Handbook can determine what happened during the resolution process.
*/

/*
The following ResolutionStatus is an enumeration.
An enumeration is a value type that defines a fixed set of named constants.

I do not want the possible resolution outcomes being represented by arbitrary strings.
Instead, I want the Compound Handbook to use these resolution outcomes as pre-defined values.
This is why I decided to create this enum.

ResolutionStatus is therefore being created as its own datatype.

A variable or property whose datatype is ResolutionStatus can use one of the named values
defined inside this enumeration.
*/

namespace CompoundHandbook.Resolution
{
    /*
    ResolutionStatus is the datatype that is being created here.

    The five values defined inside this enumeration represent the different outcomes that
    can occur when the Compound Handbook attempts to resolve chemical input into a ChemicalEntity.
    */    
    public enum ResolutionStatus 
    {
        /*
        Represents a successful chemical-entity resolution.

        Resolved means that the resolution process was able to determine which particular
        ChemicalEntity corresponds to the supplied chemical input.

        When this status is used, the ChemicalEntityResolutionResult can contain the successfully
        resolved ChemicalEntity.
        */        
        Resolved,

        /*
        Represents a resolution in which more than one possible ChemicalEntity matches the
        supplied chemical input.

        In this situation, the Compound Handbook cannot safely determine which one of the
        matching ChemicalEntity objects the user intended.

        The possible matches can therefore be returned as candidates so that the ambiguity
        can later be resolved.
        */        
        Ambiguous,
        
        /*
        Represents a resolution in which no matching ChemicalEntity could be found.

        The supplied input may be valid and understandable by the resolution system, but the
        available chemical-entity repository does not contain a ChemicalEntity that matches it.
        */        
        NotFound,
        
        /*
        Represents a resolution attempt that could not proceed successfully because the supplied
        chemical input is invalid.

        This status distinguishes invalid input from NotFound.

        NotFound means that the input could be processed but no matching ChemicalEntity was found,
        while InvalidInput means that the supplied input itself is not valid enough for the
        resolution process to properly use.
        */        
        InvalidInput,
        
        /*
        Represents a chemical input or resolution case that the current Compound Handbook
        does not support.

        This is different from NotFound because Unsupported does not necessarily mean that the
        chemical entity does not exist.

        Instead, it means that the current resolution system does not support the particular
        input or resolution case required to resolve it.
        */        
        Unsupported
    }
}