/*
When the Compound Handbook needs to create a graphical representation of a molecular
structure, knowing which atoms exist and how those atoms are bonded is not enough.

The MolecularGraph from the Domain layer describes the connectivity of the molecular
structure. It contains the atoms and the bonds that connect those atoms.

However, a graphical representation also needs to know where each atom should be placed
in two-dimensional space.

For example, when drawing a molecule, one atom may need to appear toward the left side
of the structure while another atom may need to appear toward the right side or above
another atom.

Each atom therefore needs a two-dimensional position consisting of:
(i)  An X coordinate that describes its horizontal position.
(ii) A Y coordinate that describes its vertical position.

The Compound Handbook also needs to know which particular atom those coordinates belong to.

This is why AtomPosition2D contains an AtomId together with the X and Y coordinates.

The AtomId connects the position information back to a particular Atom from the molecular
structure, while X and Y describe where that atom should be positioned in a two-dimensional
layout.

AtomPosition2D therefore does not represent an atom itself.

Instead, it represents the two-dimensional position assigned to a particular atom during
the layout of a molecular structure.
*/

/*
The following AtomPosition2D class contains three read-only properties:
(i)   AtomId: Stores the unique identifier of the atom whose position is being described.
(ii)  X: Stores the horizontal coordinate assigned to that atom.
(iii) Y: Stores the vertical coordinate assigned to that atom.

The AtomId property uses Guid as its datatype because the Atom class identifies individual
atoms using Guid values.

The X and Y properties use double as their datatype because coordinates may require
fractional values rather than being restricted to whole-number positions.

All three properties contain only 'getter' accessors.

Therefore, their values can be read from outside of the object, but they cannot be directly
reassigned from outside of the class after the AtomPosition2D object has been constructed.

AtomPosition2D is also declared using the 'sealed' keyword.

A sealed class cannot be inherited by another class.

Therefore, AtomPosition2D is intended to directly represent one atom's two-dimensional
position rather than serving as a base class for additional position types.
*/

using System;
using CompoundHandbook.Domain;

namespace CompoundHandbook.StructureGeneration 
{
    /*
    The following class represents the two-dimensional position assigned to one atom
    when constructing a molecular layout.

    It associates an atom's unique identifier with an X coordinate and a Y coordinate.

    The 'sealed' keyword prevents another class from inheriting from AtomPosition2D.
    */
    public sealed class AtomPosition2D 
    {
        /*
        Read-only property that stores the unique identifier of the atom associated
        with this position.

        Guid is being used as the datatype because atoms in the Domain model are
        identified using Guid values.

        Storing the AtomId instead of storing another complete Atom object allows this
        position object to refer back to the atom that already exists inside the
        molecular structure.
        */
        public Guid AtomId { get; }

        /*
        Read-only property that stores the X coordinate of the atom.

        The X coordinate describes the atom's horizontal position within the
        two-dimensional molecular layout.

        The datatype is double because a coordinate may contain a fractional value and
        therefore should not be restricted to whole numbers.
        */
        public double X { get; }
        
        /*
        Read-only property that stores the Y coordinate of the atom.

        The Y coordinate describes the atom's vertical position within the
        two-dimensional molecular layout.

        Like X, the datatype is double because the coordinate may contain a fractional
        value.
        */
        public double Y { get; }
        
        /*
        The following constructor will be called whenever a new AtomPosition2D object
        gets created.

        The constructor receives all three pieces of information required to describe
        one atom's position (atomId, x, and y)
        These supplied values are then assigned to their corresponding read-only properties.
        */
        public AtomPosition2D(Guid atomId, double x, double y)
        {
            // Stores the supplied atom identifier in the AtomId property.
            AtomId = atomId;

            // Stores the supplied horizontal coordinate in the X property.
            X = x;

            // Stores the supplied vertical coordinate in the Y property.
            Y = y;
        }
    }
}