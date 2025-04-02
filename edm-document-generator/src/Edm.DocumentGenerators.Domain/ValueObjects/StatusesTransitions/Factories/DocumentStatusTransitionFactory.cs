using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.ValueObjects.Permissions;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.Factories;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.Services.Validators;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Types;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.Factories;

public static class DocumentStatusTransitionFactory
{
    public static DocumentStatusTransition CreateManualTransition(Document document, Id<DocumentStatus> statusIdFrom, Id<DocumentStatus> statusIdTo)
    {
        DocumentStatus[] statuses = document.StatusStateMachine.Transitions
            .SelectMany(t => new[] { t.From, t.To })
            .ToArray();

        DocumentStatus statusFrom = statuses.First(s => s.Id == statusIdFrom);

        DocumentStatus statusTo = statuses.First(s => s.Id == statusIdTo);

        DocumentStatusTransition result = CreateFrom(DocumentStatusTransitionType.Manual, statusFrom, statusTo);

        return result;
    }

    public static DocumentStatusTransition CreateFrom(
        DocumentStatusTransitionType type,
        DocumentStatus from,
        DocumentStatus to)
    {
        var id = Id<DocumentStatusTransition>.CreateNew();

        DocumentStatusTransitionValidator.Validate(from, to);

        DocumentStatusTransition result = CreateFrom(id, type, from, to, [], [], string.Empty, string.Empty);

        return result;
    }

    public static DocumentStatusTransition CreateFrom(
        Id<DocumentStatusTransition> id,
        DocumentStatusTransitionType type,
        DocumentStatus from,
        DocumentStatus to,
        DocumentStatusTransitionParameter[] parameters,
        DocumentPermission[] permissions,
        string systemName,
        string displayName)
    {
        DocumentStatusTransitionValidator.Validate(from, to);

        DocumentStatusTransition result = CreateFromDb(id, type, from, to, parameters, permissions, systemName, displayName);

        return result;
    }

    public static DocumentStatusTransition CreateFromDb(
        Id<DocumentStatusTransition> id,
        DocumentStatusTransitionType type,
        DocumentStatus from,
        DocumentStatus to,
        DocumentStatusTransitionParameter[] parameters,
        DocumentPermission[] permissions,
        string systemName,
        string displayName)
    {
        var result = new DocumentStatusTransition(id, type, from, to, parameters, permissions, systemName, displayName);

        return result;
    }

    public static DocumentStatusTransition[] CreateDefaultTransitions()
    {
        DocumentStatus draft = DocumentStatusFactory.CreateNew(DocumentStatusType.Initial, "Draft", "Черновик");

        DocumentStatus cancelled = DocumentStatusFactory.CreateNew(DocumentStatusType.Cancelled, "Cancelled", "Отменен");

        DocumentStatus inEffect = DocumentStatusFactory.CreateNew(DocumentStatusType.Completed, "InEffect", "Действует");

        DocumentStatusTransition[] result =
        {
            CreateManual(draft, cancelled, "Отменить"),
            CreateManual(draft, inEffect, "Ввести в действие")
        };

        return result;
    }

    private static DocumentStatusTransition CreateManual(DocumentStatus draft, DocumentStatus cancelled, string displayName)
    {
        DocumentStatusTransition result = CreateNew(
            DocumentStatusTransitionType.Manual,
            draft,
            cancelled,
            "",
            displayName);

        return result;
    }

    private static DocumentStatusTransition CreateNew(
        DocumentStatusTransitionType type,
        DocumentStatus from,
        DocumentStatus to,
        string systemName,
        string displayName)
    {
        var id = Id<DocumentStatusTransition>.CreateNew();

        DocumentStatusTransitionParameter[] parameters = Array.Empty<DocumentStatusTransitionParameter>();

        DocumentPermission[] permissions = Array.Empty<DocumentPermission>();

        DocumentStatusTransition result = CreateFrom(id, type, from, to, parameters, permissions, systemName, displayName);

        return result;
    }
}
