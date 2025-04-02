using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Numbering.Segments;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Numbering;

public sealed class DocumentNumberingBff
{
    public required DocumentNumberingSegmentBff[] Segments { get; init; }
}
