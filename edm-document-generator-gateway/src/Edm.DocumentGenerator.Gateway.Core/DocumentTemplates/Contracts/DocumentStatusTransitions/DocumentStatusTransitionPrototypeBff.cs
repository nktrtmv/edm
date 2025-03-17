using Edm.DocumentGenerator.Gateway.Core.Contracts.Permissions;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype.Statuses;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentStatusTransitions.Parameters;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentStatusTransitions;

public sealed class DocumentStatusTransitionPrototypeBff
{
    public required string Id { get; init; }
    public required DocumentStatusTransitionTypeTemplateBff Type { get; init; }
    public required DocumentStatusPrototypeBff From { get; init; }
    public required DocumentStatusPrototypeBff To { get; init; }
    public required string DisplayName { get; init; }
    public DocumentPermissionBff[] Permissions { get; init; } = [];

    public DocumentStatusTransitionParameterBff[] Parameters { get; init; } = [];
}
