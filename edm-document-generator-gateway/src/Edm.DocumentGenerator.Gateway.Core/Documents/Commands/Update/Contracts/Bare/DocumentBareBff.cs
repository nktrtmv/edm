using JetBrains.Annotations;

using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.AttributesValues;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare;

[UsedImplicitly]
public sealed class DocumentBareBff
{
    public required string DomainId { get; init; }

    public required string Id { get; init; }

    public required string StatusId { get; init; }

    public required DocumentAttributeValueBareBff[] AttributesValues { get; init; }

    public required string ConcurrencyToken { get; init; }
}
