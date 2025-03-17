using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.Factories;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates.Contracts.Data.Prototypes.Numberings.Segments;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates.Contracts.Data.Prototypes.Numberings;

internal static class DocumentNumberingDbConverter
{
    internal static DocumentNumberingDb FromDomain(DocumentNumbering numbering)
    {
        DocumentNumberingSegmentDb[] segments = numbering.Segments
            .Select(DocumentNumberingSegmentDbConverter.FromDomain)
            .ToArray();

        var result = new DocumentNumberingDb
        {
            Segments = { segments }
        };

        return result;
    }

    internal static DocumentNumbering ToDomain(DocumentNumberingDb? numbering)
    {
        DocumentNumberingSegment[] segments = numbering is null
            ? Array.Empty<DocumentNumberingSegment>()
            : numbering.Segments
                .Select(DocumentNumberingSegmentDbConverter.ToDomain)
                .ToArray();

        DocumentNumbering result = DocumentNumberingFactory.CreateFromDb(segments);

        return result;
    }
}
