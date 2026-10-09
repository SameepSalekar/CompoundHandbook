/*
The chemical-entity resolution process is responsible for attempting to determine which
ChemicalEntity corresponds to the chemical input supplied to the Compound Handbook.
The information required for this process is stored inside a ChemicalResolutionRequest.
After the resolution process has been performed, its outcome is represented using a
ChemicalEntityResolutionResult.

Instead of making the rest of the Compound Handbook depend directly upon one particular
class that performs chemical-entity resolution, I want the chemical-entity resolution
operation to be represented through its own contract.

This is why, IChemicalEntityResolver is being created.

IChemicalEntityResolver defines an operation that receives a ChemicalResolutionRequest
and returns a ChemicalEntityResolutionResult.

The actual logic used to perform the chemical-entity resolution is not defined inside this interface.
That logic will instead be provided by a separate class that implements IChemicalEntityResolver.

This allows other parts of the Compound Handbook to depend upon the chemical-entity resolution contract 
rather than depending directly upon one particular implementation of the resolver.
*/

/*
The following IChemicalEntityResolver is an interface.

An interface defines a contract that describes what operations an implementing class
must provide without defining the actual implementation of those operations here.

The 'I' at the beginning of IChemicalEntityResolver follows the common C# naming
convention of beginning interface names with the letter 'I'.

IChemicalEntityResolver defines the operation of resolving a ChemicalResolutionRequest and 
returning a ChemicalEntityResolutionResult. 

The method inside this interface contains a method declaration but does not contain a method body.
Interface specifies that chemical-entity resolution must be available,nbut it does not specify exactly 
how the resolution process is performed.

It will be the responsibility of the class that implements IChemicalEntityResolver to provide the actual 
method body and to define the rules used to resolve a ChemicalResolutionRequest.
*/

namespace CompoundHandbook.Resolution 
{
    /*
    The following interface defines the operation that must be provided by a
    chemical-entity resolver used by the Compound Handbook.

    The 'public' access modifier allows this interface to be accessed from outside
    of the CompoundHandbook.Resolution namespace.

    The 'interface' keyword specifies that IChemicalEntityResolver is an interface
    rather than a class.
    */
    public interface IChemicalEntityResolver 
    {
        /*
        The following Resolve() method represents the chemical-entity
        resolution operation.

        ChemicalResolutionRequest is the datatype of the parameter named request.

        Therefore, Resolve() receives a ChemicalResolutionRequest object containing
        the information required for the chemical-entity resolution process.

        This request can contain the original input text, its ChemicalInputKind,
        a parsed ChemicalFormula, and a recognized ChemicalIdentifier.

        ChemicalEntityResolutionResult is the return datatype of this method.

        Therefore, after the chemical-entity resolution process has been performed,
        Resolve() is expected to return a ChemicalEntityResolutionResult object
        describing the outcome of that resolution attempt.

        The returned ChemicalEntityResolutionResult can contain:
        (i)   The ResolutionStatus.
        (ii)  The successfully resolved ChemicalEntity.
        (iii) Possible ChemicalEntityCandidate objects.
        (iv)  Messages associated with the resolution process.

        This interface only declares the Resolve() operation.

        The actual steps used to search for, compare, normalize, or otherwise
        determine the corresponding ChemicalEntity will be defined by the class
        that implements IChemicalEntityResolver.
        */        
        ChemicalEntityResolutionResult Resolve(ChemicalResolutionRequest request);
    }
}