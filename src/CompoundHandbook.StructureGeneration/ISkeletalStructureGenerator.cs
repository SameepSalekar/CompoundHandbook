/*
A skeletal structure represents a molecular structure by emphasizing the connectivity and
geometry of the molecular framework.

For the Compound Handbook to generate a skeletal structure, it first needs information
about the atoms in the molecule and the bonds connecting those atoms.

Within the Compound Handbook, this underlying molecular information is represented by
MolecularGraph.

MolecularGraph contains the atoms belonging to the molecular structure and the bonds
that describe how those atoms are connected.

A skeletal-structure generator can analyze this molecular connectivity and use it to
produce an appropriate chemical-structure representation.

The resulting representation is returned as a ChemicalStructureRepresentation.

ChemicalStructureRepresentation is the common abstract base class used by the Structure
Generation system for generated chemical-structure representations.

The Compound Handbook needs a clearly defined contract for any component that performs
this operation.

This is why ISkeletalStructureGenerator is being created.

ISkeletalStructureGenerator defines what a skeletal-structure generator must be able to
do without defining the particular algorithm or implementation used to generate the
skeletal representation.
*/

/*
The following ISkeletalStructureGenerator is an interface.

An interface defines a contract that implementing classes agree to follow.

This interface does not contain the actual algorithm responsible for generating a
skeletal structure from a MolecularGraph.

Instead, it declares the Generate method that an implementing class must provide.

This separates the definition of the required capability from the particular
implementation of that capability.

Therefore, other parts of the Compound Handbook can depend upon
ISkeletalStructureGenerator rather than depending directly upon one specific
skeletal-structure-generator implementation.

Any class that implements ISkeletalStructureGenerator must provide a Generate method that:
(i)  Accepts a MolecularGraph as its input.
(ii) Returns a ChemicalStructureRepresentation as its output.

ChemicalStructureRepresentation is an abstract base class.

Therefore, the Generate method does not need to return an object whose concrete type is
literally ChemicalStructureRepresentation.

Instead, it can return an object belonging to a concrete class that inherits from
ChemicalStructureRepresentation.

This allows the interface to define the general concept of producing a chemical-structure
representation without forcing the interface itself to specify one concrete representation
class.
*/


using CompoundHandbook.Domain;

namespace CompoundHandbook.StructureGeneration
{
    /*
    The following interface defines the contract for a component capable of generating
    a skeletal chemical-structure representation from a molecular graph.

    The name begins with the letter 'I', which is the conventional C# naming pattern
    used for interfaces.

    ISkeletalStructureGenerator does not specify HOW the skeletal structure must be
    generated.

    It specifies WHAT operation a skeletal-structure generator must provide.
    */
    public interface ISkeletalStructureGenerator
    {
        /*
        The following Generate method defines the operation required from every class
        that implements ISkeletalStructureGenerator.

        The method receives MolecularGraph graph
        MolecularGraph is the datatype of the graph parameter.
        The supplied MolecularGraph contains the atoms and bonds describing the
        molecular structure from which the skeletal representation will be generated.

        The return type of the method is ChemicalStructureRepresentation, which is
        an abstract class of the different chemical-structure-representation types 
        used by the Structure Generation system.

        Therefore, an implementing class can return an appropriate concrete object that
        inherits from ChemicalStructureRepresentation.

        For example, with the representation classes currently defined in this project,
        a generator could return an SvgStructureGeneration object because
        SvgStructureGeneration inherits from ChemicalStructureRepresentation.

        Because the method's declared return type is the base type, the calling code can
        work with the returned object through the common ChemicalStructureRepresentation
        abstraction rather than being tightly coupled to one concrete representation
        class.

        Because this is an interface method declaration, there is no method body here.

        The semicolon at the end of the declaration indicates that the interface defines
        the required method signature while a concrete implementing class will provide
        the actual skeletal-structure-generation logic.
        */
        ChemicalStructureRepresentation Generate(MolecularGraph graph);
    }
}