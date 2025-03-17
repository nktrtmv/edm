namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Validate.Contracts.AttributesErrors;

public sealed class DocumentAttributeErrorBff
{
    public required string AttributeId { get; init; }
    public required string Error { get; init; }
}
