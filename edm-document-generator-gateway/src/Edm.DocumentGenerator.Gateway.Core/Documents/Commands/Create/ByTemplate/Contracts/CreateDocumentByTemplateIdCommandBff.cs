namespace Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Create.ByTemplate.Contracts;

public sealed class CreateDocumentByTemplateIdCommandBff
{
    public required string DomainId { get; init; }
    public required string TemplateId { get; init; }
}
