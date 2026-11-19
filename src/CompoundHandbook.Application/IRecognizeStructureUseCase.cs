/*
IRecognizeStructureUseCase defines the application-level use case for recognizing
a chemical structure from an image.

This is how the provider-level abstraction:
StructureImageInput -> IOCSRProvider -> StructureRecognitionResult

The provider interface answers:
"What component can perform optical chemical structure recognition?"

The use-case interface answers:
"What operation does the Compound Handbook application expose when a caller 
wants to recognize a chemical structure from an image?"

This distinction is important. IOCSRProvider represents a dependency used by 
the application. IRecognizeStructureUseCase represents an operation offered BY 
the application.

(Caller / UI) -> IRecognizeStructureUseCase -> RecognizeStructureUseCase ->(IOCSRProvider)

The concrete RecognizeStructureUseCase class will implement this interface and
coordinate the recognition workflow.

Keeping the use case behind an interface also means callers do not need to depend
directly on the concrete RecognizeStructureUseCase implementation.
*/

/*
IRecognizeStructureUseCase is declared using the interface keyword.
An interface defines a contract without providing the concrete implementation of
that contract.
This interface contains one method (i.e. Execute)
Execute does not contain a method body. The concrete class that implements 
IRecognizeStructureUseCase will provide the actual method body.
*/

namespace CompoundHandbook.Application 
{
    /* 
    IRecognizeStructureUseCase defines the application-level contract for 
    chemical structure recognition from an image. A caller can depend on this 
    interface without needing to know the details of the concrete 
    RecognizeStructureUseCase implementation.
    */
    public interface IRecognizeStructureUseCase 
    {
        /*
        'Execute' begins the chemical structure recognition workflow. Here the 
        parameter is 'input' which is a StructureImageInput that contains the 
        Content and ContentType. The return value is 'StructureRecognitionResult'
        contains the overall recognition outcome, candidate structures, and 
        associated messages. The interface defines WHAT operation is available.
        The implementing class will define HOW the operation is coordinated.
        */
        StructureRecognitionResult Execute(StructureImageInput input);
    }
}