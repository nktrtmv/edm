using Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters.StatusChanges.StatusesTransitionsParametersValues;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.ValueObjects.StatusChanges;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StatusesStateMachines.ValueObjects.Transitions.ValueObjects.ParametersValues;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters.StatusChanges;

internal static class DocumentStatusChangeConverter
{
    internal static DocumentStatusChange? FromInternal(DocumentUpdateParametersInternal parameters, Document document)
    {
        Id<DocumentStatus> fromStatusId = document.Status.Id;

        Id<DocumentStatus> toStatusId = IdConverterFrom<DocumentStatus>.From(parameters.StatusId);

        if (fromStatusId == toStatusId)
        {
            return null;
        }

        DocumentStatusTransition statusTransition =
            document.StatusStateMachine.GetRequiredTransition(fromStatusId, toStatusId);

        DocumentStatusTransitionParameterValue[] statusTransitionParametersValues =
            DocumentStatusTransitionParameterValueInternalToDomainConverter.ToDomain(parameters.StatusTransitionParametersValues, statusTransition);

        var result = new DocumentStatusChange(statusTransition, statusTransitionParametersValues);

        return result;
    }
}
