/*
The Compound Handbook may encounter a chemical-resolution situation in which more
than one ChemicalEntity is a possible match for the caller's input.

When this happens, the application can present the possible candidates and allow the
caller to select the intended ChemicalEntity.

After a candidate has been selected, the chemical-analysis workflow needs to continue
using that selected entity.

ISelectChemicalCandidateUseCase defines the application-level contract for performing
that continuation.

The caller provides a SelectChemicalCandidateRequest.

The request identifies the selected ChemicalEntity candidate, the chemical operations
that should be performed on that entity, and the experimental chemical properties that 
should be retrieved.

The implementation then continues the chemical-analysis workflow and returns an
AnalyzeChemicalResponse.

SelectChemicalCandidateRequest -> Execute() -> AnalyzeChemicalResponse

This interface provides a clean application boundary between the caller and
the implementation responsible for continuing chemical analysis. 
*/

/*
ISelectChemicalCandidateUseCase is declared as an interface.

An interface defines a contract.

It describes what operation an implementing class must provide without containing the
complete implementation of that operation itself.

The interface contains one method and that method has three important parts:
(i)   Return type: Specifies the type of object returned after the selected candidate has been analyzed.
(ii)  Execute: Represents execution of the candidate-selection use case
(iii) Parameter: This supplies the selected candidate identifier together with the chemical
operations and experimental properties requested by the caller.

A concrete class such as SelectChemicalCandidateUseCase can implement this interface
and provide the actual workflow.

Other application code can therefore depend on the interface rather than requiring
knowledge of the concrete implementation.
*/

namespace CompoundHandbook.Application
{
    /*
    ISelectChemicalCandidateUseCase defines the application-level operation for
    continuing chemical analysis after a caller has selected a ChemicalEntity candidate.
    */
    public interface ISelectChemicalCandidateUseCase
    {
        /*
        Execute continues the chemical-analysis workflow using the candidate
        identified by the supplied request.

        'request' is a SelectChemicalCandidateRequest containing the selected entity identifier,
        requested chemical operations, and requested experimental properties.

        'AnalyzeChemicalResponse' contains the results produced by continuing analysis 
        with the selected ChemicalEntity.
        */
        AnalyzeChemicalResponse Execute(SelectChemicalCandidateRequest request);
    }
}