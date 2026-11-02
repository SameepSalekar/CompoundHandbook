/*
The Compound Handbook application layer needs a clearly defined operation for performing
a complete chemical analysis.

The actual implementation of that operation may need to coordinate several different
parts of the Compound Handbook, including:
1. chemical input parsing,
2. chemical formula validation,
3. chemical entity resolution,
4. chemical entity validation,
5. chemical classification,
6. molecular formula generation,
7. molar-mass calculation,
8. elemental percent-composition calculation,
9. chemical structure generation,
10. experimental chemical-property retrieval.

The simple conceptual form of this application is:
AnalyzeChemicalRequest -> Execute() -> AnalyzeChemicalResponse
*/

/*
IAnalyzeChemicalUseCase is declared as an interface.

An interface defines a contract that another class can implement.

Unlike a normal class, this interface does not contain the actual chemical-analysis
workflow.

Instead, it states what operation an implementing class must provide.

The return type of this interface will specify what the method is giving back to the caller.

The parameter of this method's interface will provide the information to required to
perform the requested chemical analysis.

A concrete implementation, such as AnalyzeChemicalUseCase, can then implement this
interface and provide the actual workflow.

This separation allows callers to depend on the use-case contract rather than being
tightly coupled to one particular implementation.
*/

namespace CompoundHandbook.Application 
{
    /*
    IAnalyzeChemicalUseCase defines the application-level contract for executing
    a complete chemical analysis.
    Any class implementing this interface must provide an Execute method having
    the signature defined below.
    */

    public interface IAnalyzeChemicalUseCase
    {
        // 'Execute' performs the chemical-analysis use case represented by the supplied AnalyzeChemicalRequest
        // 'request' is the parameter that contains the chemical input, its input kind, requested chemical operations/experimental properties.
        // 'AnalyzeChemicalResponse' contains the combined results produced by the analysis workflow.
        AnalyzeChemicalResponse Execute(AnalyzeChemicalRequest request); 
    }
}