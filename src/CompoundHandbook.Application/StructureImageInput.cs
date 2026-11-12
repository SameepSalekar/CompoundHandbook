/*
StructureImageInput represents an image supplied to the Compound Handbook for
optical chemical structure recognition.

Optical Chemical Structure Recognition (OCSR) is the process of examining an image
containing a drawn chemical structure and attempting to convert that visual structure
into machine-readable chemical information.

Before an OCSR provider can perform that work, however, the application needs a
simple way to provide the image itself.

StructureImageInput serves that purpose. It contains two pieces of information:
1. Content: The actual binary data of the supplied image.
2. ContentType: A textual description of the image's media/content type.

StructureImageInput's responsibility is simply to carry the image data required by the optical
chemical structure recognition workflow.
*/

/*
StructureImageInput is declared as a sealed class.

The sealed keyword prevents another class from inheriting from StructureImageInput.

This is appropriate because this class represents a specific application-level
input contract rather than a base class intended for specialization.

The Content property has the type: byte[]
The type byte represents an 8-bit unsigned integer. Here it is an array of bytes.

Files such as PNG or JPEG images are ultimately stored as binary data, so a byte
array provides a way to carry that image data through the application.
*/

namespace CompoundHandbook.Application
{
    /*
    StructureImageInput packages the binary image data and its content type into
    one object that can be supplied to the optical chemical structure recognition system.
    */
    public sealed class StructureImageInput 
    {
        /*
        Content stores the binary content of the chemical structure image.
        Each byte can hold a value from 0 through 255.
        Together, the bytes represent the encoded contents of the supplied image file.
        The OCSR provider can receive this byte array and pass the image data to the
        recognition implementation that it uses.
        */
        public byte[] Content { get; }

        /*
        ContentType identifies the type of image represented by Content.
        This is useful because the byte array itself does not communicate the
        image format in an obvious application-level way.
        For example, ContentType could contain a value representing a PNG or JPEG image.
        The property is represented by string because the content type is textual information.
        */
        public string ContentType { get; }

        // The constructor creates a StructureImageInput.
        public StructureImageInput(byte[] content, string contentType)
        {
            // Store the supplied binary image data.
            Content = content;

            // Store the supplied image content type.
            ContentType = contentType;
        }
    }
}