using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data.Factories;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates.Contracts.Data.Prototypes.Numberings.Segments.Abstractions.Data;

internal static class DocumentNumberingSegmentDataDbConverter
{
    internal static DocumentNumberingSegmentDataDb FromDomain(DocumentNumberingSegmentData data)
    {
        var id = IdConverterTo.ToString(data.Id);

        var result = new DocumentNumberingSegmentDataDb
        {
            Id = id,
            Format = data.Format
        };

        return result;
    }

    internal static DocumentNumberingSegmentData ToDomain(DocumentNumberingSegmentDataDb data)
    {
        Id<DocumentNumberingSegment> id = IdConverterFrom<DocumentNumberingSegment>.FromString(data.Id);

        return DocumentNumberingSegmentDataFactory.Create(id, data.Format);
    }
}
