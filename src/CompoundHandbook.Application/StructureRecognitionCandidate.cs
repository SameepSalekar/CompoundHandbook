/*
StructureRecognitionCandidate represents one possible chemical structure identified
by an Optical Chemical Structure Recognition (OCSR) provider.

An image-recognition system may not always determine one chemical structure with
absolute certainty.

Instead, the recognition provider may identify one or more possible structures.

Each possible structure can therefore be represented as a
StructureRecognitionCandidate.

StructureRecognitionCandidate will contain 3 pieces of information:
(i)   Confidence: A numerical value describing the confidence associated with the recognized candidate.
(ii)  Smiles: The SMILES representation of the recognized chemical structure.
(iii) InChI: The InChI representation of the recognized chemical structure.

StructureRecognitionCandidate does not itself determine whether the candidate is correct.
It simply stores the information returned by the OCSR recognition process.
*/

/*
StructureRecognitionCandidate is declared as a sealed class.
The sealed keyword prevents another class from inheriting from this class.
The class will contain 3 read-only properties.
*/

namespace CompoundHandbook.Application
{
    // StructureRecognitionCandidate represents one possible chemical structure by an OCSR operation
    public sealed class StructureRecognitionCandidate
    {
        /*
        Confidence stores the confidence associated with this recognition candidate.
        The value is represented using double so that fractional numerical confidence values can be stored.
        This class does not define how the confidence value must be interpreted.
        That interpretation belongs to the OCSR provider that produced the candidate.
        */
        public double Confidence { get; }

        // Smiles stores the SMILES representation produced for the recognized chemical structure.
        public string Smiles { get; }

        // InChI stores the InChI representation produced for the recognized chemical structures
        public string InChI { get; }

        // The constructor creates a StructureRecognitionCandidate. 
        // It stores the supplied argument in its corresponding read-only property.
        public StructureRecognitionCandidate(double confidence, string smiles, string inChI)
        {
            // Store the confidence associated with this candidate.
            Confidence = confidence;

            // Store the recognized SMILES representation.
            Smiles = smiles;

            // Store the recognized InChI representation.
            InChI = inChI;

        }

    }
}