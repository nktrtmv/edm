using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Abstractions.Data;
using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments.Inheritors;

public sealed class DocumentCounterNumberingSegmentInternal : DocumentNumberingSegmentInternal
{
    public DocumentCounterNumberingSegmentInternal(DocumentNumberingSegmentDataInternal data, Id<CounterInternal> counterId) : base(data)
    {
        CounterId = counterId;
    }

    public Id<CounterInternal> CounterId { get; }
}
