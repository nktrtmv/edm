using System.Text.Json.Serialization;

using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Numbering.Segments.Types;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Swagger.Attributes;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Numbering.Segments;

[DiscriminatorType<DocumentNumberingSegmentTypeBff>]
[JsonDerivedType(typeof(DocumentConstantNumberingSegmentBff), nameof(DocumentNumberingSegmentTypeBff.Constant))]
[JsonDerivedType(typeof(DocumentCounterNumberingSegmentBff), nameof(DocumentNumberingSegmentTypeBff.Counter))]
[JsonDerivedType(typeof(DocumentDateNumberingSegmentBff), nameof(DocumentNumberingSegmentTypeBff.Date))]
public abstract class DocumentNumberingSegmentBff
{
    public required string Id { get; init; }
    public required string Format { get; init; }
}
