namespace Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Create.ByClassification.Contracts;

public sealed class CreateByClassificationCommandBff
{
    public required string DomainId { get; init; }
    public required string BusinessSegmentId { get; init; }
    public required string DocumentCategoryId { get; init; }
    public required string DocumentTypeId { get; init; }
    public required string DocumentKindId { get; init; }
}
