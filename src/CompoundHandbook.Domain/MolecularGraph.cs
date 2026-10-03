/*
A molecular structure can be represented mathematically using a graph.

In graph theory, a graph consists of vertices and the edges connecting those vertices.

For the MolecularGraph:
(i)  Atom = Node or Vertex
(ii) Bond = Edge

The MolecularGraph therefore stores a collection of Atom objects and a collection of 
Bond objects to represent both the atoms present in a molecule and the connectivity 
between those atoms.

This graph representation will later allow the Compound Handbook to analyze molecular connectivity,
such as finding neighboring atoms, determining which bonds belong to an atom, validating molecular
structures, and generating structural representations.
*/

/*
The MolecularGraph internally stores the Atom and Bond objects using two List collections.

The actual Lists are private so that other classes cannot directly modify the internal collections.

The Atoms and Bonds properties expose these collections as IReadOnlyCollection<T>.

The class also provides methods for:
(i)   Adding atoms and bonds
(ii)  Finding an atom from its Id
(iii) Finding the neighboring atoms of an atom
(iv)  Finding the bonds connected to an atom
(v)   Checking whether an atom exists
*/

namespace CompoundHandbook.Domain 
{
    public class MolecularGraph 
    {
        // Private Lists that internally store the atoms and bonds of the molecular graph.
        private readonly List<Atom> _atoms = new();
        private readonly List<Bond> _bonds = new();

        // Exposes the atoms and bonds as read-only collections.
        public IReadOnlyCollection<Atom> Atoms => _atoms;
        public IReadOnlyCollection<Bond> Bonds => _bonds;

        // Adds an Atom object to the molecular graph.
        public void AddAtom(Atom atom) 
        {
            _atoms.Add(atom);
        } 
        
        // Adds a Bond object to the molecular graph.
        public void AddBond(Bond bond) 
        {
            _bonds.Add(bond);
        }

        /*
        Searches for an Atom using its Id.
        FirstOrDefault() returns the first Atom satisfying the condition.
        If no matching Atom exists, it returns null, which is why the return datatype is nullable
        */
        public Atom? GetAtom(int atomId) 
        {
            return _atoms.FirstOrDefault(atom => atom.Id == atomId);
        }

        /*
        Finds the neighboring atoms that are directly connected to the requested Atom.

        Each Bond contains two Atom Ids. If atomId appears on one side of the Bond,
        the Atom Id on the opposite side is the neighbor.
        */
        public IReadOnlyCollection<Atom> GetNeighbors(int atomId)
        {
            List<Atom> neighbors = new();

            // Checks every Bond in the molecular graph.
            foreach (Bond bond in _bonds)
            {
                int neighborId;
                if (bond.Atom1Id == atomId) 
                {
                    neighborId = bond.Atom2Id;
                }
                else if (bond.Atom2Id == atomId) 
                {
                    neighborId = bond.Atom1Id;
                }
                else 
                {
                    // This Bond does not involve the requested Atom.
                    continue;
                }

                // Retrieves the actual Atom object corresponding to the neighboring Atom Id.
                Atom? neighbor = GetAtom(neighborId);

                if (neighbor != null)
                {
                    neighbors.Add(neighbor);
                }
            }

            return neighbors;
        }
        
        // Finds all Bonds connected to the requested Atom.
        // Where() filters _bonds and keeps every Bond where atomId appears as either endpoint.
        public IReadOnlyCollection<Bond> GetBondsForAtom(int atomId)
        {
            return _bonds.Where(bond => bond.Atom1Id == atomId || bond.Atom2Id == atomId).ToList();
        }

        // Checks whether an Atom with the requested Id exists.
        // Any() returns true if at least one Atom satisfies the given condition.    
        public bool ContainsAtom(int atomId) 
        {
            return _atoms.Any(atom => atom.Id == atomId);
        }
    }
}