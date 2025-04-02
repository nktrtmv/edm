using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentClassifiers;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Commands.Create.Contracts;

public sealed class CreateDocumentTemplateCommandBff
{
    public required string DomainId { get; init; }

    public required string Name { get; init; }

    public string? SystemName { get; init; }

    public DocumentClassifierSubsetBff? ClassifierSubset { get; init; }
}
