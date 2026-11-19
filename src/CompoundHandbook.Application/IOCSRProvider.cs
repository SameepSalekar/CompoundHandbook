/*
IOCSRProvider defines the contract used by the Compound Handbook application
to perform the OCSR.

OCSR is responsible for examining an image containing a drawn chemical structure
and attempting to convert the visual information into machine-readable chemical
structure information.

At the application level, Compound Handbook should not need to know exactly HOW
that recognition is performed.

Recognition might eventually be performed by an external OCSR web service,
a locally installed chemical-recognition library, a machine-learning model,
or another infrastructure implementation.

The Application layer only needs a contract to recognize chemical structures from
the given chemical structure image. IOCSRProvider provides that contract. Interface
is between the application layer and the infrastructure layer.

Application uses IOCSRProvider implemented by the External OCSR technology, a
Concrete OCSR Adapter.

This follows dependency inversion. The application depends on the abstraction
rather than directly depending on a specific external recognition system.
*/

/*
IOCSRProvider is declared using the interface keyword. An interface defines 
a contract. It specifies WHAT an implementation must provide without 
specifying HOW that operation must be implemented. This interface contains 
one method (i.e. Recognize). The interface method does not contain a method 
body, instead we end it with a semicolon. The semicolon indicates that the 
interface declares the operation while a concrete implementation will later 
provide the actual recognition behavior. 
*/

namespace CompoundHandbook.Application 
{
    // IOCSRProvider defines the application-level abstraction for a component capable of performing OCSR.
    public interface IOCSRProvider 
    {
        /*
        'Recognize' attempts to identify chemical structures from the supplied.
        Parameter here is 'input', contains the binary image data and its content type
        The return value will be 'StructureRecognitionResult', it describes whether recognition 
        succeeded, contains any StructureRecognitionCandidate objects produced,
        and contains messages associated with the recognition operation.
        The interface intentionally does not specify which OCSR technology must perform the recognition.
        */
        StructureRecognitionResult Recognize(StructureImageInput input);
    }
}