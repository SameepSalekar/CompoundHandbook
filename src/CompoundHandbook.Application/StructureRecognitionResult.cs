/*
StructureRecognitionResult represents the complete result returned by an OCSR operation.
The recognition process begins with a StructureImageInput containing the binary image data
An OCSR provider then examines that image and attempts to recognize one or more possible chemical structures.
The result of that process needs to communicate more than just a single recognized structure.

It needs to communicate:
1. whether the recognition operation succeeded,
2. the chemical structure candidates produced by the recognition process,
3. any messages produced while performing recognition.

StructureRecognitionResult packages those pieces of information into one application-level result object.
StructureImageInput -> OCSR Provider -> StructureRecognitionResult -(Success)-(Candidates)-(Messages)-

The Candidates collection may contain multiple StructureRecognitionCandidate
objects because an OCSR provider may identify more than one possible interpretation
of the supplied chemical structure image.
*/

/*
StructureRecognitionResult is declared as a sealed class and contains three read-only properties.
The constructor of this class will receive the success value, candidate collection, and message
collection and assigns them to their corresponding properties.
*/

using System.Collections.Generic;

namespace CompoundHandbook.Application 
{
    // StructureRecognitionResult packages the outcome of an OCSR operation.
    public sealed class StructureRecognitionResult
    {
        // Success indicates whether the OCSR succeeded
        public bool Success { get; }

        /*
        Candidates contains the possible chemical structures identified by the recognition 
        operation. Each element of this collection is a StructureRecognitionCandidate.
        IReadOnlyCollection is used because callers should be able to inspect the recognition 
        candidates without this result object exposing collection modification through this property 
        */ 
        public IReadOnlyCollection<StructureRecognitionCandidate> Candidates { get; }

        /*
        Messages contains textual information produced during recognition.
        Depending on the OCSR implementation, these messages can communicate
        information about the recognition operation or explain why recognition
        did not succeed.
        */
        public IReadOnlyCollection<string> Messages { get; }

        // The constructor creates a StructureRecognitionResult and assigns each 
        // supplied argument to its corresponding read-only property.
        public StructureRecognitionResult(bool success, IReadOnlyCollection<StructureRecognitionCandidate> candidates, IReadOnlyCollection<string> messages) 
        {
            // Store the overall recognition success state.
            Success = success;

            // Store the collection of recognized structure candidates.
            Candidates = candidates;

            // Store the messages associated with the recognition operation.
            Messages = messages;
        }
    }
}