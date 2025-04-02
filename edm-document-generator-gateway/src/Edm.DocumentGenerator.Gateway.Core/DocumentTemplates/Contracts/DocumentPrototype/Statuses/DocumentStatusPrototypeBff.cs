using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters;
using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Types;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Statuses;

public sealed class DocumentStatusPrototypeBff
{
    public required string Id { get; init; }
    public DocumentStatusTypeBff Type { get; init; }
    public required DocumentStatusParameterBff[] Parameters { get; init; }
    public string SystemName { get; init; } = string.Empty;
    public required string DisplayName { get; init; }
}
