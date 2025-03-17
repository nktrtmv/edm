using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Inheritors;

public sealed class DocumentConstantNumberingSegment : DocumentNumberingSegment
{
    public DocumentConstantNumberingSegment(DocumentNumberingSegmentData data, string value) : base(data)
    {
        Value = value;
    }

    public string Value { get; }
}
