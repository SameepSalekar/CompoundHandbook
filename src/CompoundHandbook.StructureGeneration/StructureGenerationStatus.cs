/*
The process of generating a chemical-structure representation does not always result in a
successfully generated structure.

For example, the Compound Handbook may successfully generate the requested representation,
the requested representation may not apply to the particular chemical entity, or the
Compound Handbook may not currently support generating that particular structure.

Structure generation can also be prevented when the supplied chemical structure is invalid,
or the generation process itself may fail for some other reason.

Simply returning a generated representation would therefore not provide enough information
about what happened during the structure-generation process when a representation could
not be produced.

This is why StructureGenerationStatus is being created so that the result of a
structure-generation attempt can explicitly describe the outcome of that operation.

The status can then be stored inside a StructureGenerationResult together with the generated
representation, when one exists, and any messages associated with the generation process.
*/

/*
The following StructureGenerationStatus is an enumeration.

An enumeration is a value type that defines a fixed set of named constants.

I do not want the different possible outcomes of structure generation being represented
using arbitrary strings. Instead, I want the Compound Handbook to restrict the status of a
structure-generation operation to one of the predefined values.

This is why I decided to create this enum.

StructureGenerationStatus is therefore being created as its own datatype.

A variable or property whose datatype is StructureGenerationStatus can use one of the named
values defined inside this enumeration.
*/

namespace CompoundHandbook.StructureGeneration
{
    /*
    StructureGenerationStatus is the datatype that is being created here.
    The values defined inside this enumeration describe the outcome of an attempt to generate
    a chemical-structure representation.
    */
    public enum StructureGenerationStatus
    {
        // Represents a structure-generation operation that successfully generated the requested representation.
        Generated,


        // Represents a requested structure representation that does not apply to the particular chemical entity.
        NotApplicable,
        /*
        The NotApplicable value indicates that the requested type of structure representation
        is not appropriate for the particular chemical entity being processed.

        This is different from a failure because the Compound Handbook did not necessarily
        encounter an error while attempting to generate the structure.

        Instead, the requested representation does not apply to that chemical entity.
        */


        // Represents a structure-generation operation that the Compound Handbook does not currently support.
        Unsupported,
        /*
        The Unsupported value indicates that the requested structure-generation operation cannot
        currently be performed by the Compound Handbook.

        The requested representation may conceptually be applicable to the chemical entity,
        but the required generation capability has not been implemented or supported for that
        particular case.

        Therefore, Unsupported is different from NotApplicable. NotApplicable means that the
        requested representation does not apply to the chemical entity, while Unsupported means
        that the requested operation cannot currently be handled by the available implementation.        
        */


        // Represents a structure-generation operation that cannot continue because the structure is invalid.
        InvalidStructure,
        /*
        The InvalidStructure value indicates that the chemical structure required for the
        generation operation did not satisfy the required structural validation.

        For example, the molecular graph or another structural representation may contain
        information that prevents the requested representation from being reliably generated.

        This status allows the Structure Generation system to distinguish invalid structural
        information from a representation that is merely unsupported or not applicable.
        */


        // Represents a structure-generation operation that failed while attempting to generate the representation.
        Failed
        /*
        The Failed value indicates that the structure-generation process was applicable and
        was attempted, but the requested representation could not be successfully generated.

        This value represents a general generation failure that is not more specifically
        described by NotApplicable, Unsupported, or InvalidStructure.

        Additional information about the reason for the failure can be stored in the messages
        associated with the StructureGenerationResult.
        */
    }
}
