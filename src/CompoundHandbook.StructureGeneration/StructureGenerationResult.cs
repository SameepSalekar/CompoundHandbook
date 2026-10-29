/*
After the Structure Generation system attempts to generate a requested chemical-structure
representation, the Compound Handbook needs more information than simply the generated
representation itself.

The Compound Handbook needs to know:

(i)   What happened during the structure-generation operation.
(ii)  What chemical-structure representation was generated, if one was successfully produced.
(iii) What additional messages were produced during the generation process.

The StructureGenerationStatus describes the outcome of the generation attempt.

For example, the status can indicate that the requested representation was successfully
Generated, was NotApplicable to the chemical entity, was Unsupported by the current
implementation, could not be generated because of an InvalidStructure, or simply Failed.

The ChemicalStructureRepresentation contains the actual generated representation when one
exists.

However, not every StructureGenerationResult will contain a representation.

For example, if the generation status is Unsupported or InvalidStructure, the Structure
Generation system may have no generated representation to return.

This is why the Representation property is allowed to contain null.

Finally, the Messages collection allows the Structure Generation system to return additional
information explaining the result of the operation.

StructureGenerationResult therefore groups all of the information produced by one
structure-generation attempt into a single result object.
*/

/*
The following StructureGenerationResult is a result class.

Instead of returning several separate values from a structure-generation operation, this
class packages the status, optional generated representation, and messages into one object.

StructureGenerationResult = Status + Representation + Messages

Status stores the StructureGenerationStatus describing the outcome of the operation.
Representation stores the generated ChemicalStructureRepresentation when one exists.
Messages stores the read-only collection of string messages associated with the generation result.

All of these are read-only properties as they only contain the 'getter' accessors.
their values can be read from outside of the object, but they cannot be directly
reassigned from outside of the class after the StructureGenerationResult has been constructed.

The following class is a sealed class (cannot be inherited by the another class)
StructureGenerationResult is intended to be directly used as the result object
returned by the Structure Generation system rather than being used as a base class for
additional result classes.
*/

using System.Collections.Generic;

namespace CompoundHandbook.StructureGeneration 
{
    /*
    The following class represents the complete result of one attempt to generate a
    chemical-structure representation.

    It combines the operation's status, the optional generated representation, and any
    messages associated with the generation process.
    */
    public sealed class StructureGenerationResult 
    {
        /*
        Read-only property that stores the outcome of the structure-generation operation.

        StructureGenerationStatus is an enum itself, but is being used here as the datatype
        of the Status property.
        */
        public StructureGenerationStatus Status { get; }
        
        /*
        Read-only property that stores the chemical-structure representation produced by
        the structure-generation operation.

        ChemicalStructureRepresentation is an abstract class, but it can still be used as
        the datatype of this property.

        This allows Representation to reference an object belonging to a concrete class
        derived from ChemicalStructureRepresentation.
        
        ChemicalStructureRepresentation? means that this property is allowed to contain
        a null value.

        The null value is necessary because not every structure-generation attempt produces
        a representation.
        */
        public ChemicalStructureRepresentation? Representation { get; }

        /*
        Read-only property that stores the messages associated with the
        structure-generation result.

        IReadOnlyCollection<string> is being used as the datatype.
        IReadOnlyCollection<T> is a generic collection interface.
        This property represents a collection whose individual elements are strings.

        The messages can provide additional information about what happened during the
        generation process.

        For example, they can explain why a representation was not generated or provide
        other information associated with the result.

        IReadOnlyCollection<string> exposes the collection for reading without exposing
        collection-modification operations through this property.
        */
        public IReadOnlyCollection<string> Messages { get; }

        /*
        The following constructor will be called whenever a new StructureGenerationResult
        object gets created.
        The supplied values (status, representation, and messages)
        are then assigned to their corresponding properties.
        */
        public StructureGenerationResult(StructureGenerationStatus status, ChemicalStructureRepresentation? representation, IReadOnlyCollection<string> messages) 
        {
            // Stores the supplied generation status in the Status property.
            Status = status;

            // Stores the supplied chemical-structure representation in the Representation property.
            Representation = representation;

            // Stores the supplied collection of messages in the Messages property.
            Messages = messages;
        }

    }
}