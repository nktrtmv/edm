using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Commands.AddParticipant;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Commands.Complete;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Commands.Delegate;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Commands.TakeInWork;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Queries.GetAvailable;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions;

public interface IEntitiesApprovalWorkflowsActionsClient
{
    Task<GetAvailableEntitiesApprovalWorkflowsActionsQueryResponseExternal> GetAvailableActions(
        GetAvailableEntitiesApprovalWorkflowsActionsQueryExternal query,
        CancellationToken cancellationToken);

    Task AddParticipant(AddParticipantEntitiesApprovalWorkflowsActionsCommandExternal command, CancellationToken cancellationToken);
    Task Complete(CompleteEntitiesApprovalWorkflowsActionsCommandExternal command, CancellationToken cancellationToken);
    Task Delegate(DelegateEntitiesApprovalWorkflowsActionsCommandExternal command, CancellationToken cancellationToken);
    Task TakeInWork(TakeInWorkEntitiesApprovalWorkflowsActionsCommandExternal command, CancellationToken cancellationToken);
}
