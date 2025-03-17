using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.Factories;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering;

internal static class DocumentNumberingInternalConverter
{
    internal static DocumentNumberingInternal FromDomain(DocumentNumbering numbering)
    {
        DocumentNumberingSegmentInternal[] segments = numbering.Segments
            .Select(DocumentNumberingSegmentInternalConverter.FromDomain)
            .ToArray();

        var result = new DocumentNumberingInternal(segments);

        return result;
    }

    internal static DocumentNumbering ToDomain(DocumentNumberingInternal numbering)
    {
        DocumentNumberingSegment[] segments = numbering.Segments
            .Select(DocumentNumberingSegmentInternalConverter.ToDomain)
            .ToArray();

        DocumentNumbering result = DocumentNumberingFactory.CreateFrom(segments);

        return result;
    }
}
