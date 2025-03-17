namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Commands.Delete.Contracts;

public sealed class DeleteDocumentTemplateCommandBff
{
    public required string Id { get; init; }
    public required string DomainId { get; init; }
}
