/*
A Lewis structure is a representation of a molecule that communicates information about
the atoms in the molecule and the chemical relationships between those atoms.

For the Compound Handbook to internally represent a generated Lewis structure, it needs
more than just a list of coordinates describing where the atoms should appear.

It also needs the underlying molecular structure that identifies the atoms and the bonds
connecting those atoms.

The MolecularGraph provides this chemical-connectivity information.
It describes which atoms belong to the molecular structure and which bonds connect those atoms.
However, the MolecularGraph by itself does not describe where those atoms should appear
when the Lewis structure is displayed in two-dimensional space.

For this purpose, the Structure Generation system also uses MolecularLayout2D.

MolecularLayout2D contains the two-dimensional positioning information associated with
the atoms in the molecular structure.

Therefore, the two objects have different responsibilities:
MolecularGraph -> Describes WHAT atoms and bonds make up the molecular structure.
MolecularLayout2D -> Describes WHERE the atoms should be positioned in two-dimensional space.

LewisStructureModel combines these two pieces of information into a single object.

This allows the Structure Generation system to keep the chemical structure and its
two-dimensional layout together while constructing, validating, or later rendering a
Lewis-structure representation.
*/

/*
The following LewisStructureModel is a model class used internally by the Structure
Generation system.

LewisStructureModel = Graph + Layout

Graph stores the MolecularGraph containing the atoms and bonds 
that make up the molecular structure.
Layout stores the MolecularLayout2D containing the two-dimensional 
positioning information associated with that molecular structure.

These properties contain only 'getter' accessors, therefore, they are
read-only properties.

Their values can be read from outside of the object, but the references stored
by these properties cannot be directly reassigned from outside of the class after the
LewisStructureModel object has been constructed.

LewisStructureModel is declared using the 'sealed' keyword. A sealed class cannot be 
inherited by another class. Therefore, LewisStructureModel is intended to directly 
represent the internal model of a Lewis structure rather than serving as a base class 
for additional model types.
*/

using CompoundHandbook.Domain;

namespace CompoundHandbook.StructureGeneration 
{
    /*
    The following class represents the internal information needed by the Structure
    Generation system for a Lewis structure.

    It combines the underlying MolecularGraph with the MolecularLayout2D associated
    with that graph.

    The 'sealed' keyword prevents another class from inheriting from
    LewisStructureModel.
    */
    public sealed class LewisStructureModel
    {
        /*
        Read-only property that stores the molecular graph associated with this
        Lewis-structure model.

        MolecularGraph is a class from the CompoundHandbook.Domain namespace and is
        being used here as the datatype of the Graph property.

        The MolecularGraph contains the chemical-connectivity information of the
        structure, including its atoms and the bonds connecting those atoms.

        Therefore, Graph answers the following questions:
        "Which atoms exist in this molecular structure?"
        "Which atoms are connected by bonds?"

        This property represents the chemical-structure portion of LewisStructureModel. 
        */
        public MolecularGraph Graph { get; }

        /*
        Read-only property that stores the two-dimensional layout associated with
        the molecular graph.

        MolecularLayout2D is a class from the Structure Generation module and is
        being used here as the datatype of the Layout property.

        The layout contains the positioning information required to associate atoms
        in the molecular graph with locations in two-dimensional space.

        Therefore, while Graph describes the molecular connectivity, Layout describes
        how that structure is spatially arranged for a two-dimensional representation.

        This property represents the layout portion of the LewisStructureModel.
        */
        public MolecularLayout2D Layout { get; }

        /*
        The following constructor will be called whenever a new LewisStructureModel
        object gets created.

        The constructor receives the two pieces of information required by the model
        that are 'graph' and 'layout'

        'graph' is the MolecularGraph containing the atoms and bonds of the molecular structure
        'layout' is the MolecularLayout2D containing the two-dimensional positioning
        information associated with that molecular structure.
        
        These supplied objects are then assigned to their corresponding read-only properties.
        */
        public LewisStructureModel(MolecularGraph graph, MolecularLayout2D layout)
        {
            // Stores the supplied MolecularGraph object in the Graph property.
            Graph = graph;

            // Stores the supplied MolecularLayout2D object in the Layout property.
            Layout = layout;
        } 
    }
}