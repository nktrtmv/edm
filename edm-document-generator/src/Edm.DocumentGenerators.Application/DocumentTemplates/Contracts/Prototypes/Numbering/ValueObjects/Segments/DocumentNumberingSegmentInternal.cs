using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments;

public abstract class DocumentNumberingSegmentInternal
{
    protected DocumentNumberingSegmentInternal(DocumentNumberingSegmentDataInternal data)
    {
        Data = data;
    }

    public DocumentNumberingSegmentDataInternal Data { get; }
}
