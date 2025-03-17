using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;
using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Inheritors;
using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Inheritors.Converters;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments;

internal static class DocumentNumberingSegmentInternalConverter
{
    internal static DocumentNumberingSegmentInternal FromDomain(DocumentNumberingSegment segment)
    {
        DocumentNumberingSegmentDataInternal data = DocumentNumberingSegmentDataInternalConverter.FromDomain(segment.Data);

        DocumentNumberingSegmentInternal result = segment switch
        {
            DocumentConstantNumberingSegment constant => DocumentConstantNumberingSegmentInternalConverter.FromDomain(data, constant),
            DocumentCounterNumberingSegment counter => DocumentCounterNumberingSegmentInternalConverter.FromDomain(data, counter),
            DocumentDateNumberingSegment => DocumentDateNumberingSegmentInternalConverter.FromDomain(data),
            _ => throw new ArgumentTypeOutOfRangeException(segment)
        };

        return result;
    }

    internal static DocumentNumberingSegment ToDomain(DocumentNumberingSegmentInternal segment)
    {
        DocumentNumberingSegmentData data = DocumentNumberingSegmentDataInternalConverter.ToDomain(segment.Data);

        DocumentNumberingSegment result = segment switch
        {
            DocumentConstantNumberingSegmentInternal constant => DocumentConstantNumberingSegmentInternalConverter.ToDomain(data, constant),
            DocumentCounterNumberingSegmentInternal counter => DocumentCounterNumberingSegmentInternalConverter.ToDomain(data, counter),
            DocumentDateNumberingSegmentInternal => DocumentDateNumberingSegmentInternalConverter.ToDomain(data),
            _ => throw new ArgumentTypeOutOfRangeException(segment)
        };

        return result;
    }
}
