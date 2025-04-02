using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering.ValueObjects.Segments;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Numbering;

public sealed class DocumentNumberingInternal
{
    public DocumentNumberingInternal(DocumentNumberingSegmentInternal[] segments)
    {
        Segments = segments;
    }

    public DocumentNumberingSegmentInternal[] Segments { get; }
}
