using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Inheritors;

public sealed class DocumentDateNumberingSegmentInternal : DocumentNumberingSegmentInternal
{
    public DocumentDateNumberingSegmentInternal(DocumentNumberingSegmentDataInternal data) : base(data)
    {
    }
}
