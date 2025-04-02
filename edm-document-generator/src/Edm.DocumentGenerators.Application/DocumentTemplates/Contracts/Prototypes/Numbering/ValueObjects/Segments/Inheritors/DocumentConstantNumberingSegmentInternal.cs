using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Inheritors;

public sealed class DocumentConstantNumberingSegmentInternal : DocumentNumberingSegmentInternal
{
    public DocumentConstantNumberingSegmentInternal(DocumentNumberingSegmentDataInternal data, string value) : base(data)
    {
        Value = value;
    }

    public string Value { get; }
}
