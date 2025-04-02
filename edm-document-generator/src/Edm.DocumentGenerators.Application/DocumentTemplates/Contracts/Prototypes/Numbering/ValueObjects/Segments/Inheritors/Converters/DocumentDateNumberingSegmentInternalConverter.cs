using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Inheritors;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Inheritors.Converters;

public static class DocumentDateNumberingSegmentInternalConverter
{
    internal static DocumentDateNumberingSegmentInternal FromDomain(DocumentNumberingSegmentDataInternal data)
    {
        var result = new DocumentDateNumberingSegmentInternal(data);

        return result;
    }

    internal static DocumentDateNumberingSegment ToDomain(DocumentNumberingSegmentData data)
    {
        var result = new DocumentDateNumberingSegment(data);

        return result;
    }
}
