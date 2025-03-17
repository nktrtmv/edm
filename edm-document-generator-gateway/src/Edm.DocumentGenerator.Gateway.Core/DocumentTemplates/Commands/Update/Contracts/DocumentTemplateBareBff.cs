using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Commands.Update.Contracts;

// ReSharper disable once ClassNeverInstantiated.Global
public sealed class DocumentTemplateBareBff
{
    public required string Id { get; init; }

    public required string DomainId { get; init; }

    public string? SystemName { get; init; }

    public required string Name { get; init; }

    public required DocumentPrototypeBff DocumentPrototype { get; init; }

    public required DocumentTemplateStatusBff Status { get; init; }

    public required string FrontMetadata { get; init; }

    public required string ConcurrencyToken { get; init; }
}
