using Edm.DocumentGenerators.Application.Contracts.Permissions;
using Edm.DocumentGenerators.Application.Contracts.Statuses;
using Edm.DocumentGenerators.Application.Contracts.StatusesTransitions.Parameters;
using Edm.DocumentGenerators.Application.Contracts.StatusesTransitions.Types;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.StatusesTransitions;

public sealed class DocumentStatusTransitionDetailedInternal
{
    internal DocumentStatusTransitionDetailedInternal(
        DocumentStatusInternal status,
        DocumentStatusTransitionTypeInternal type,
        DocumentStatusTransitionParameterInternal[] parameters,
        DocumentPermissionInternal[] permissions,
        string displayName)
    {
        Status = status;
        Type = type;
        Parameters = parameters;
        Permissions = permissions;
        DisplayName = displayName;
    }

    public DocumentStatusInternal Status { get; }
    public DocumentStatusTransitionTypeInternal Type { get; }
    public DocumentStatusTransitionParameterInternal[] Parameters { get; }
    public DocumentPermissionInternal[] Permissions { get; }
    public string DisplayName { get; }
}
