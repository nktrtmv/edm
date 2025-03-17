using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Events.Contracts;
using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Events.Contracts.Inheritors.Participants;
using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Events.Contracts.Inheritors.Stages;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Publisher.Events.Converters.Values.ParticipantsChanged;
using Edm.Entities.Approval.Workflows.Presentation.Publisher.Events.Converters.Values.StageChanged;

namespace Edm.Entities.Approval.Workflows.Presentation.Publisher.Events.Converters.Values;

internal static class EntitiesApprovalWorkflowsEventsValueConverter
{
    internal static EntitiesApprovalWorkflowsEventsValue FromDomain(EntitiesApprovalWorkflowsEventInternal request)
    {
        var result = request switch
        {
            ParticipantsChangedEntitiesApprovalWorkflowsEventInternal r =>
                ParticipantsChangedEntitiesApprovalWorkflowsEventConverter.FromDomain(r, request.DomainId),

            StageChangedEntitiesApprovalWorkflowsEventInternal r =>
                StageChangedEntitiesApprovalWorkflowsEventConverter.FromDomain(r, request.DomainId),

            _ => throw new ArgumentTypeOutOfRangeException(request)
        };

        return result;
    }
}
