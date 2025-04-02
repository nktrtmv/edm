using Edm.DocumentGenerators.Application.Contracts.Permissions;
using Edm.DocumentGenerators.Application.Contracts.Statuses;
using Edm.DocumentGenerators.Application.Contracts.StatusesTransitions.Parameters;
using Edm.DocumentGenerators.Application.Contracts.StatusesTransitions.Types;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.StatusesTransitions;

internal static class DocumentStatusTransitionDetailedInternalConverter
{
    internal static DocumentStatusTransitionDetailedInternal FromDomain(DocumentStatusTransition transition)
    {
        DocumentStatusInternal status =
            DocumentStatusInternalConverter.FromDomain(transition.To);

        DocumentStatusTransitionTypeInternal type =
            DocumentStatusTransitionTypeInternalConverter.FromDomain(transition.Type);

        DocumentStatusTransitionParameterInternal[] parameters =
            transition.Parameters.Select(DocumentStatusTransitionParameterInternalConverter.FromDomain).ToArray();

        DocumentPermissionInternal[] permissions =
            transition.Permissions.Select(DocumentPermissionInternalConverter.FromDomain).ToArray();

        var result = new DocumentStatusTransitionDetailedInternal(status, type, parameters, permissions, transition.DisplayName);

        return result;
    }
}
