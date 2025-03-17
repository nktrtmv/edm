using Edm.DocumentGenerators.Application.Contracts.Permissions;
using Edm.DocumentGenerators.Application.Contracts.StatusesTransitions.Parameters;
using Edm.DocumentGenerators.Application.Contracts.StatusesTransitions.Types;
using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Statuses;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.StatusesTransitions;

public sealed class DocumentStatusTransitionPrototypeInternal
{
    public DocumentStatusTransitionPrototypeInternal(
        string id,
        DocumentStatusTransitionTypeInternal type,
        DocumentStatusPrototypeInternal from,
        DocumentStatusPrototypeInternal to,
        DocumentStatusTransitionParameterInternal[] parameters,
        DocumentPermissionInternal[] permissions,
        string systemName,
        string displayName)
    {
        Id = id;
        Type = type;
        From = from;
        To = to;
        Parameters = parameters;
        Permissions = permissions;
        SystemName = systemName;
        DisplayName = displayName;
    }

    public string Id { get; }
    public DocumentStatusTransitionTypeInternal Type { get; }
    public DocumentStatusPrototypeInternal From { get; private set; }
    public DocumentStatusPrototypeInternal To { get; private set; }
    public DocumentStatusTransitionParameterInternal[] Parameters { get; }
    public DocumentPermissionInternal[] Permissions { get; private set; }
    public string SystemName { get; }
    public string DisplayName { get; private set; }
}
