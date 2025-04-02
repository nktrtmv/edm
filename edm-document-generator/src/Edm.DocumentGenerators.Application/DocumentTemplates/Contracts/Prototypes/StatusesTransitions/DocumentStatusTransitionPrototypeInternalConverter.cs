using Edm.DocumentGenerators.Application.Contracts.Permissions;
using Edm.DocumentGenerators.Application.Contracts.StatusesTransitions.Parameters;
using Edm.DocumentGenerators.Application.Contracts.StatusesTransitions.Types;
using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.Statuses;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.ValueObjects.Permissions;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.Factories;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Types;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes.StatusesTransitions;

internal static class DocumentStatusTransitionPrototypeInternalConverter
{
    internal static DocumentStatusTransitionPrototypeInternal FromDomain(DocumentStatusTransition transition, DocumentTemplate template)
    {
        var id = IdConverterTo.ToString(transition.Id);

        DocumentStatusTransitionTypeInternal type = DocumentStatusTransitionTypeInternalConverter.FromDomain(transition.Type);

        DocumentStatusPrototypeInternal? from = DocumentStatusPrototypeInternalConverter.FromDomain(transition.From, template);

        DocumentStatusPrototypeInternal? to = DocumentStatusPrototypeInternalConverter.FromDomain(transition.To, template);

        DocumentStatusTransitionParameterInternal[] parameters = transition.Parameters.Select(DocumentStatusTransitionParameterInternalConverter.FromDomain).ToArray();

        DocumentPermissionInternal[] permissions = transition.Permissions.Select(DocumentPermissionInternalConverter.FromDomain).ToArray();

        var result = new DocumentStatusTransitionPrototypeInternal(id, type, from, to, parameters, permissions, transition.SystemName, transition.DisplayName);

        return result;
    }

    internal static DocumentStatusTransition ToDomain(DocumentStatusTransitionPrototypeInternal transition)
    {
        Id<DocumentStatusTransition>? id = IdConverterFrom<DocumentStatusTransition>.FromString(transition.Id);

        DocumentStatusTransitionType type = DocumentStatusTransitionTypeInternalConverter.ToDomain(transition.Type);

        DocumentStatus? from = DocumentStatusPrototypeInternalConverter.ToDomain(transition.From);

        DocumentStatus? to = DocumentStatusPrototypeInternalConverter.ToDomain(transition.To);

        DocumentStatusTransitionParameter[] parameters = transition.Parameters.Select(DocumentStatusTransitionParameterInternalConverter.ToDomain).ToArray();

        DocumentPermission[] permissions = transition.Permissions.Select(DocumentPermissionInternalConverter.ToDomain).ToArray();

        DocumentStatusTransition? result = DocumentStatusTransitionFactory.CreateFrom(
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
