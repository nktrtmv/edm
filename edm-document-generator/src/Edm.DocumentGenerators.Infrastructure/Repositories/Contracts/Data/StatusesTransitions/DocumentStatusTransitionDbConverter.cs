using Edm.DocumentGenerators.Domain.ValueObjects.Permissions;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.Factories;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Types;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Permissions;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Statuses;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.StatusesTransitions.Parameters;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.StatusesTransitions.Types;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.StatusesTransitions;

internal static class DocumentStatusTransitionDbConverter
{
    internal static DocumentStatusTransitionDb FromDomain(DocumentStatusTransition transition)
    {
        var id = IdConverterTo.ToString(transition.Id);

        DocumentStatusTransitionTypeDb type = DocumentStatusTransitionTypeDbConverter.FromDomain(transition.Type);

        DocumentStatusDb from = DocumentStatusDbConverter.FromDomain(transition.From);

        DocumentStatusDb to = DocumentStatusDbConverter.FromDomain(transition.To);

        DocumentStatusTransitionParameterDb[] parameters = transition.Parameters.Select(DocumentStatusTransitionParameterDbConverter.FromDomain).ToArray();

        DocumentPermissionDb[] permissions = transition.Permissions.Select(DocumentPermissionDbConverter.FromDomain).ToArray();

        var result = new DocumentStatusTransitionDb
        {
            Id = id,
            Type = type,
            From = from,
            To = to,
            Parameters = { parameters },
            Permissions = { permissions },
            SystemName = transition.SystemName,
            DisplayName = transition.DisplayName
        };

        return result;
    }

    internal static DocumentStatusTransition ToDomain(DocumentStatusTransitionDb transition)
    {
        Id<DocumentStatusTransition> id = IdConverterFrom<DocumentStatusTransition>.FromString(transition.Id);

        DocumentStatusTransitionType type = DocumentStatusTransitionTypeDbConverter.ToDomain(transition.Type);

        DocumentStatus from = DocumentStatusDbConverter.ToDomain(transition.From);

        DocumentStatus to = DocumentStatusDbConverter.ToDomain(transition.To);

        DocumentStatusTransitionParameter[] parameters = transition.Parameters.Select(DocumentStatusTransitionParameterDbConverter.ToDomain).ToArray();

        DocumentPermission[] permissions = transition.Permissions.Select(DocumentPermissionDbConverter.ToDomain).ToArray();

        DocumentStatusTransition result = DocumentStatusTransitionFactory.CreateFromDb(
            id,
            type,
            from,
            to,
            parameters,
            permissions,
            transition.SystemName,
            transition.DisplayName);

        return result;
    }
}
