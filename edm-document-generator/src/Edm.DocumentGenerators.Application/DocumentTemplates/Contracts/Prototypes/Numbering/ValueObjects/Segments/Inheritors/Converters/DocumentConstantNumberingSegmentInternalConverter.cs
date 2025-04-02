using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Inheritors;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Inheritors.Converters;

public static class DocumentConstantNumberingSegmentInternalConverter
{
    internal static DocumentConstantNumberingSegmentInternal FromDomain(DocumentNumberingSegmentDataInternal data, DocumentConstantNumberingSegment segment)
    {
        var result = new DocumentConstantNumberingSegmentInternal(data, segment.Value);

        return result;
    }

    internal static DocumentConstantNumberingSegment ToDomain(DocumentNumberingSegmentData data, DocumentConstantNumberingSegmentInternal segment)
    {
        var result = new DocumentConstantNumberingSegment(data, segment.Value);

        return result;
    }
}
