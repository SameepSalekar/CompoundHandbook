using System.Collections.Generic;

namespace CompoundHandbook.StructureGeneration 
{
    public sealed class MolecularLayout2D
    {
        public IReadOnlyCollection<AtomPosition2D> AtomPositions { get; }
        public MolecularLayout2D(IReadOnlyCollection<AtomPosition2D> atomPositions)
        {
            AtomPositions = atomPositions;
        }
    }
}