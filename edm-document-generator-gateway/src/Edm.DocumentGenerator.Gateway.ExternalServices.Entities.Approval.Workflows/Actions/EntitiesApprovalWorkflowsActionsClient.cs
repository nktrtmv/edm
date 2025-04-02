using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Actions.Converters.Commands.AddParticipant;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Actions.Converters.Commands.Complete;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Actions.Converters.Commands.Delegate;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Actions.Converters.Commands.TakeInWork;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Actions.Converters.Queries.GetAvailable;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Commands.AddParticipant;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Commands.Complete;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Commands.Delegate;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Commands.TakeInWork;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Queries.GetAvailable;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Actions;

internal sealed class EntitiesApprovalWorkflowsActionsClient : IEntitiesApprovalWorkflowsActionsClient
{
    public EntitiesApprovalWorkflowsActionsClient(EntitiesApprovalWorkflowsActionsService.EntitiesApprovalWorkflowsActionsServiceClient actions)
    {
        Actions = actions;
    }

    private EntitiesApprovalWorkflowsActionsService.EntitiesApprovalWorkflowsActionsServiceClient Actions { get; }

    async Task<GetAvailableEntitiesApprovalWorkflowsActionsQueryResponseExternal> IEntitiesApprovalWorkflowsActionsClient.GetAvailableActions(
        GetAvailableEntitiesApprovalWorkflowsActionsQueryExternal query,
        CancellationToken cancellationToken)
    {
        var request =
            GetAvailableEntitiesApprovalWorkflowsActionsQueryExternalConverter.ToDto(query);

        var response =
            await Actions.GetAvailableAsync(request, cancellationToken: cancellationToken);

        var result =
            GetAvailableEntitiesApprovalWorkflowsActionsQueryResponseExternalConverter.FromDto(response);

        return result;
    }

    async Task IEntitiesApprovalWorkflowsActionsClient.AddParticipant(
        AddParticipantEntitiesApprovalWorkflowsActionsCommandExternal command,
        CancellationToken cancellationToken)
    {
        var request = AddParticipantEntitiesApprovalWorkflowsActionsCommandExternalConverter.ToDto(command);

        await Actions.AddParticipantAsync(request, cancellationToken: cancellationToken);
    }

    async Task IEntitiesApprovalWorkflowsActionsClient.Complete(CompleteEntitiesApprovalWorkflowsActionsCommandExternal command, CancellationToken cancellationToken)
    {
        var request = CompleteEntitiesApprovalWorkflowsActionsCommandExternalConverter.ToDto(command);

        await Actions.CompleteAsync(request, cancellationToken: cancellationToken);
    }

    async Task IEntitiesApprovalWorkflowsActionsClient.Delegate(DelegateEntitiesApprovalWorkflowsActionsCommandExternal command, CancellationToken cancellationToken)
    {
        var request = DelegateEntitiesApprovalWorkflowsActionsCommandExternalConverter.ToDto(command);

        await Actions.DelegateAsync(request, cancellationToken: cancellationToken);
    }

    async Task IEntitiesApprovalWorkflowsActionsClient.TakeInWork(
        TakeInWorkEntitiesApprovalWorkflowsActionsCommandExternal command,
        CancellationToken cancellationToken)
    {
        var request = TakeInWorkActionsEntitiesApprovalWorkflowsCommandExternalConverter.ToDto(command);

        await Actions.TakeInWorkAsync(request, cancellationToken: cancellationToken);
    }
}
