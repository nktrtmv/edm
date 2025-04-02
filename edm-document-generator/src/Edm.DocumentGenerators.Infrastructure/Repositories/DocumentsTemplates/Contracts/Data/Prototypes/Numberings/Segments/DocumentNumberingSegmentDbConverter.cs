using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates.Contracts.Data.Prototypes.Numberings.Segments.Abstractions.Data;
using Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates.Contracts.Data.Prototypes.Numberings.Segments.Inheritors;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates.Contracts.Data.Prototypes.Numberings.Segments;

public static class DocumentNumberingSegmentDbConverter
{
    internal static DocumentNumberingSegmentDb FromDomain(DocumentNumberingSegment segment)
    {
        DocumentNumberingSegmentDataDb data = DocumentNumberingSegmentDataDbConverter.FromDomain(segment.Data);

        DocumentNumberingSegmentDb result = segment switch
        {
            DocumentConstantNumberingSegment constant => DocumentConstantNumberingSegmentDbConverter.FromDomain(data, constant),
            DocumentCounterNumberingSegment counter => DocumentCounterNumberingSegmentDbConverter.FromDomain(data, counter),
            DocumentDateNumberingSegment => DocumentDateNumberingSegmentDbConverter.FromDomain(data),
            _ => throw new ArgumentTypeOutOfRangeException(segment)
        };

        return result;
    }

    internal static DocumentNumberingSegment ToDomain(DocumentNumberingSegmentDb segment)
    {
        DocumentNumberingSegmentData data = DocumentNumberingSegmentDataDbConverter.ToDomain(segment.Data);

        DocumentNumberingSegment result = segment.ValueCase switch
        {
            DocumentNumberingSegmentDb.ValueOneofCase.AsConstant => DocumentConstantNumberingSegmentDbConverter.ToDomain(data, segment.AsConstant),
            DocumentNumberingSegmentDb.ValueOneofCase.AsCounter => DocumentCounterNumberingSegmentDbConverter.ToDomain(data, segment.AsCounter),
            DocumentNumberingSegmentDb.ValueOneofCase.AsDate => DocumentDateNumberingSegmentDbConverter.ToDomain(data),
            _ => throw new ArgumentTypeOutOfRangeException(segment)
        };

        return result;
    }
}
