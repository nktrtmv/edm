using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data.Factories;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;

internal static class DocumentNumberingSegmentDataInternalConverter
{
    internal static DocumentNumberingSegmentDataInternal FromDomain(DocumentNumberingSegmentData data)
    {
        var id = IdConverterTo.ToString(data.Id);

        var result = new DocumentNumberingSegmentDataInternal(id, data.Format);

        return result;
    }

    internal static DocumentNumberingSegmentData ToDomain(DocumentNumberingSegmentDataInternal data)
    {
        Id<DocumentNumberingSegment> id = IdConverterFrom<DocumentNumberingSegment>.FromString(data.Id);

        DocumentNumberingSegmentData result = DocumentNumberingSegmentDataFactory.Create(id, data.Format);

        return result;
    }
}
