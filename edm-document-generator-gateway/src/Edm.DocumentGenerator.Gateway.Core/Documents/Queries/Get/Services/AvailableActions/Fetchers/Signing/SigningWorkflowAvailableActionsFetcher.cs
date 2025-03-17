using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.AvailableActions.Contracts.Signing;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.Workflows.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetAvailableActions;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.AvailableActions.Fetchers.Signing;

public sealed class SigningWorkflowAvailableActionsFetcher
{
    public SigningWorkflowAvailableActionsFetcher(ISigningWorkflowsDetailsClient details)
    {
        Details = details;
    }

    private ISigningWorkflowsDetailsClient Details { get; }

    internal async Task<DocumentSigningActions?> Fetch(
        DocumentWorkflows workflows,
        DocumentDetailedDto document,
        UserBff user,
        CancellationToken cancellationToken)
    {
        var workflowId = GetWorkflowId(document);

        if (workflowId is null)
        {
            return null;
        }

        var _ = workflows.Signing.Single(w => w.Id == workflowId);

        // TODO: VALIDATE WORKFLOW IS IN STATUS

        var request = new GetAvailableActionsSigningWorkflowDetailsQueryExternal(workflowId, user.Id, user.IsAdmin);

        var response = await Details.GetAvailableActions(request, cancellationToken);

        var result = new DocumentSigningActions(workflowId, response.Actions);

        return result;
    }

    private static string? GetWorkflowId(DocumentDetailedDto document)
    {
        if (document.Status.Type != DocumentStatusTypeDto.Signing)
        {
            return null;
        }

        var workflow = document.SigningData?.Workflows?.LastOrDefault();

        if (workflow is null)
        {
            throw new ApplicationException($"Failed to find signing workflow (documentId: {document.Id}.");
        }

        if (workflow.Status == DocumentSigningWorkflowStatusDto.Finished)
        {
            throw new ApplicationException(
                $"Failed to find uncompleted signing workflow (documentId: {document.Id}, workflowId: {workflow.Id}, status: {workflow.Status}).");
        }

        var result = workflow.Id;

        return result;
    }
}
