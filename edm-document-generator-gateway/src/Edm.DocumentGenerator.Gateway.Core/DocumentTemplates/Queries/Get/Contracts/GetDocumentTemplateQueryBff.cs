namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.Get.Contracts;

public sealed class GetDocumentTemplateQueryBff
{
    public required string DomainId { get; init; }

    public required string Id { get; init; }
}
