using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Inheritors;

public sealed class DocumentCounterNumberingSegment : DocumentNumberingSegment
{
    public DocumentCounterNumberingSegment(DocumentNumberingSegmentData data, Id<Counter> counterId) : base(data)
    {
        CounterId = counterId;
    }

    public Id<Counter> CounterId { get; }
}
