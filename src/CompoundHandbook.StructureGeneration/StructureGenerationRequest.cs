/*
The Structure Generation system needs to know two important pieces of information before
it can attempt to generate a chemical structure:

(i)  Which chemical entity needs a structure to be generated.
(ii) Which structure-generation operation is being requested.

The ChemicalEntity identifies the particular chemical entity whose structure needs to
be generated.

The ChemicalOperation identifies the particular chemical operation that the Structure
Generation system has been asked to perform.

For example, the operation may request the generation of:

(i)   A Lewis structure.
(ii)  A condensed structure.
(iii) A skeletal structure.

This distinction is important because ChemicalOperation and StructureRepresentationKind
represent two different concepts.

ChemicalOperation describes WHAT chemical operation is being requested.

StructureRepresentationKind describes HOW a completed representation is stored.

For example:

ChemicalOperation.GenerateCondensedStructure
describes the operation of generating a condensed structure.

StructureRepresentationKind.Text
describes the fact that the resulting representation is stored as text.

Similarly:

ChemicalOperation.GenerateSkeletalStructure
describes the operation of generating a skeletal structure.

StructureRepresentationKind.Svg
can describe the graphical format in which that generated structure is stored.

Therefore, StructureGenerationRequest should identify the requested chemical operation
rather than using StructureRepresentationKind to choose between Lewis, condensed, and
skeletal structures.

Instead of passing the ChemicalEntity and ChemicalOperation separately throughout the
Structure Generation system, StructureGenerationRequest groups them together inside
one object.

StructureGenerationRequest therefore represents one complete request made to the
Structure Generation system.
*/

/*
StructureGenerationRequest = Entity + Operation

Entity stores the ChemicalEntity whose structure is being processed.

Operation stores the ChemicalOperation that the Structure Generation system has been
asked to perform.

Both properties are read-only properties because they contain only a 'getter' accessor.

Therefore, these properties can be read from outside of the class, but their stored
references or values cannot be directly reassigned from outside of the class after the
StructureGenerationRequest object has been constructed.

StructureGenerationRequest is declared as a sealed class.

A sealed class cannot be inherited by another class.

Therefore, StructureGenerationRequest is intended to be directly used as the request
object rather than serving as a base class for additional request types.
*/

using CompoundHandbook.Classification;
using CompoundHandbook.Domain;

namespace CompoundHandbook.StructureGeneration
{
    /*
    The following class represents one request made to the Structure Generation system.

    It groups together:

    (i)  The ChemicalEntity that needs to be processed.
    (ii) The ChemicalOperation that should be performed.
    */
    public sealed class StructureGenerationRequest
    {
        /*
        Read-only property that stores the chemical entity for which structure generation
        has been requested.

        ChemicalEntity is an abstract class itself, but an abstract class can still be
        used as the datatype of a property.

        Although an object cannot be directly created from an abstract class, a property
        whose datatype is an abstract base class can reference an object belonging to a
        concrete class that inherits from that base class.

        Therefore, Entity can reference a Molecule or another concrete ChemicalEntity
        type supported by the Compound Handbook.

        This allows StructureGenerationRequest to work with the common ChemicalEntity
        abstraction rather than being permanently restricted to one concrete entity type.
        */
        public ChemicalEntity Entity { get; }


        /*
        Read-only property that stores the chemical operation requested from the
        Structure Generation system.

        ChemicalOperation is being used as the datatype of the Operation property.

        The operation identifies WHAT the Structure Generation system has been asked
        to generate.

        For the structure-generation workflow, relevant values include operations such
        as:

            ChemicalOperation.GenerateLewisStructure
            ChemicalOperation.GenerateCondensedStructure
            ChemicalOperation.GenerateSkeletalStructure

        This is different from StructureRepresentationKind.

        ChemicalOperation identifies the requested chemical operation.

        StructureRepresentationKind identifies the output format of an already-created
        ChemicalStructureRepresentation, such as Text or Svg.
        */
        public ChemicalOperation Operation { get; }


        /*
        The following constructor is called whenever a new StructureGenerationRequest
        object is created.

        It receives:

        (i)  ChemicalEntity entity
             The chemical entity that needs to be processed.

        (ii) ChemicalOperation operation
             The structure-generation operation that should be performed.

        ChemicalEntity is the datatype of the 'entity' parameter.

        ChemicalOperation is the datatype of the 'operation' parameter.

        The supplied arguments are then assigned to their corresponding read-only
        properties.
        */
        public StructureGenerationRequest(
            ChemicalEntity entity,
            ChemicalOperation operation)
        {

            // Stores the supplied ChemicalEntity object in the Entity property.
            Entity = entity;



            // Stores the supplied ChemicalOperation value in the Operation property.
            Operation = operation;
        }
    }
}