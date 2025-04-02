using Edm.Document.Searcher.Presentation.Consumers.EntitiesApprovalWorkflows.Events.Converters.Values.ParticipantsChanged;
using Edm.Document.Searcher.Presentation.Consumers.EntitiesApprovalWorkflows.Events.Converters.Values.StageChanged;

using MediatR;

using EntitiesApprovalWorkflowsEventsValue = Edm.Entities.Approval.Workflows.Presentation.Abstractions.EntitiesApprovalWorkflowsEventsValue;

namespace Edm.Document.Searcher.Presentation.Consumers.EntitiesApprovalWorkflows.Events.Converters;

internal static class EntitiesApprovalWorkflowsEventsValueConverter
{
    internal static IRequest? ToInternal(EntitiesApprovalWorkflowsEventsValue value)
    {
        IRequest? result = value.EventCase switch
        {
            EntitiesApprovalWorkflowsEventsValue.EventOneofCase.AsParticipantsChanged =>
                ParticipantsChangedEntitiesApprovalWorkflowsEventConverter.ToInternal(value.AsParticipantsChanged, value.DomainId),

            EntitiesApprovalWorkflowsEventsValue.EventOneofCase.AsStageChanged =>
                StageChangedEntitiesApprovalWorkflowsEventConverter.ToInternal(value.AsStageChanged, value.DomainId),

            _ => null
        };

        return result;
    }
}
