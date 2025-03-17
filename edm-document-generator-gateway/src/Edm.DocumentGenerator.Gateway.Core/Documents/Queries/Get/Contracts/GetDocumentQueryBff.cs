namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts;

public sealed class GetDocumentQueryBff
{
    public required string DomainId { get; init; }
    public required string Id { get; init; }
    public bool SkipProcessing { get; set; } = false;
}
