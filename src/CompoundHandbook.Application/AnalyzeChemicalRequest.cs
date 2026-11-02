/*
The Compound Handbook needs a way for a caller to describe what chemical information
should be analyzed.

For example, a caller may provide a chemical input such as a chemical name, formula,
or another supported chemical identifier.

However, supplying the chemical input alone is not enough.

The caller may also want the Compound Handbook to perform particular operations on
the resolved chemical entity.

Examples can include:
(i)   generating a Lewis structure,
(ii)  generating a condensed structure,
(iii) generating a skeletal structure,
(iv)  retrieving particular experimental chemical properties.

AnalyzeChemicalRequest represents this collection of information as one application-level
request object.

The request therefore acts as the starting data package for the chemical-analysis
application workflow.

It contains:
1) InputText: The actual chemical input supplied by the caller
2) InputKind: Information describing how the supplied input should be interpreted.
3) RequestedOperations: The collection of chemical operations requested by the caller.
4) RequestedProperties: The collection of experimental chemical properties requested by the caller.

AnalyzeChemicalRequest does not perform parsing, resolution, classification,
calculation, structure generation, or property retrieval itself.

Its responsibility is only to carry the information required by the application layer
to coordinate those operations.
*/

/*
AnalyzeChemicalRequest is declared as a sealed class.

A class provides a user-defined reference type that can contain related data and behavior.

The sealed keyword prevents another class from inheriting from AnalyzeChemicalRequest.

This is appropriate because AnalyzeChemicalRequest represents a specific application
request contract rather than a base class intended to support specialized subclasses.

There is no public set accessor in this class, therefore the outside code cannot
replace the property value after the AnalyzeChemicalRequest object has been constructed.

The constructor receives all of the information required by the request and assigns that
information to the corresponding properties.

This creates an application-level request object whose references cannot be reassigned
through its public API after construction.
*/

using System.Collections.Generic;
using CompoundHandbook.Classification;
using CompoundHandbook.Domain;
using CompoundHandbook.Parsing;

namespace CompoundHandbook.Application
{
    /*
    AnalyzeChemicalRequest represents the input supplied to the application-level
    chemical-analysis workflow.
    It collects the caller's chemical input and requested operations into one object
    that can be passed to the chemical-analysis use case.
    */
    public sealed class AnalyzeChemicalRequest
    {
        // InputText stores the actual chemical input supplied by the caller.
        public string InputText { get; }

        /*
        InputKind describes how InputText should be interpreted by the parsing system.
        ChemicalInputKind is an enum defined by the Parsing portion of the Compound Handbook.
        Keeping InputText and InputKind separate allows the application to carry both,
        the supplied text and the meaning assigned to that text.
        */
        public ChemicalInputKind InputKind { get; }

        /*
        RequestedOperations contains the chemical operations requested by the caller.
        
        IReadOnlyCollection<T> is a generic read-only collection interface. Here it
        represents a collection of ChemicalOperation values that consumers can read
        without exposing collection-modification operations through this property.

        ChemicalOperation describes WHAT operation should be performed.
        This distinction is important.

        StructureRepresentationKind describes the FORMAT of a generated representation,
        such as Text or Svg.

        ChemicalOperation instead describes the requested chemical operation itself,
        such as generating a Lewis, condensed, or skeletal structure.
        */
        public IReadOnlyCollection<ChemicalOperation> RequestedOperations { get; }

        /*
        RequestedProperties contains the experimental chemical properties requested
        by the caller.

        ExperimentalPropertyKind identifies the particular type of experimental
        property being requested.

        IReadOnlyCollection<ExperimentalPropertyKind> allows the caller to request
        multiple property kinds within one chemical-analysis operation.
        */
        public IReadOnlyCollection<ExperimentalPropertyKind> RequestedProperties { get; }

        /*
        The following constructor creates a new AnalyzeChemicalRequest
        The constructor requires all 4 pieces of information needed to describe the request:
        1) inputText: The chemical input.
        2) inputKind: How to interpret that chemical input.
        3) requestedOperations: Which chemical operation should be performed.
        4) requestedProperties: Which experimental properties should be retrieved.
        */
        public AnalyzeChemicalRequest(string inputText, ChemicalInputKind inputKind, IReadOnlyCollection<ChemicalOperation> requestedOperations, IReadOnlyCollection<ExperimentalPropertyKind> requestedProperties)
        {
            // Supplied inputText parameter gets assigned to the InputText property.
            InputText = inputText;

            // Supplied inputKind parameter gets assigned to the InputKind property.
            InputKind = inputKind;

            // Supplied requestedOperations parameter gets assigned to the RequestedOperations property.
            RequestedOperations = requestedOperations;

            // Supplied requestedProperties parameter gets assigned to the RequestedProperties property.
            RequestedProperties = requestedProperties;
        }
    }
}