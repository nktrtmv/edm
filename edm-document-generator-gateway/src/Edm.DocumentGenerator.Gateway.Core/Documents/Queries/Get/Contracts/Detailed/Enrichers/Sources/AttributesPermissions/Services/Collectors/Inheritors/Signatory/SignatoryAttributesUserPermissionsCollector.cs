using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Permissions.Types;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Enrichers.Sources.AttributesPermissions.Services.Collectors.Contexts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Statuses;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Enrichers.Sources.AttributesPermissions.Services.Collectors.Inheritors.
    Signatory;

internal sealed class SignatoryAttributesUserPermissionsCollector : IAttributesUserPermissionsCollector
{
    private const string CommercialAuthorizedSignatory = "commercial_authorized_signatory";

    private static readonly Dictionary<DocumentAttributeValueDetailedBff, DocumentPermissionTypeBff[]> NotCollected =
        new Dictionary<DocumentAttributeValueDetailedBff, DocumentPermissionTypeBff[]>();

    public SignatoryAttributesUserPermissionsCollector(IEntitiesApprovalWorkflowsDetailsClient details)
    {
        Details = details;
    }

    private IEntitiesApprovalWorkflowsDetailsClient Details { get; }

    public async Task<Dictionary<DocumentAttributeValueDetailedBff, DocumentPermissionTypeBff[]>> Collect(
        DocumentAttributeValueDetailedBff[] attributesValues,
        AttributesUserPermissionsCollectorContext context,
        CancellationToken cancellationToken)
    {
        if (context.User.Roles.Contains(CommercialAuthorizedSignatory))
        {
            return NotCollected;
        }

        if (context.Document.Status.Type is not DocumentStatusTypeDto.Approval)
        {
            return NotCollected;
        }

        DocumentAttributeValueDetailedBff[] signatoryAttributeValues = attributesValues
            .Where(v => IsAttributeHasEditPermission(v, CommercialAuthorizedSignatory, context.Document.Status.Id))
            .ToArray();

        if (signatoryAttributeValues.Length == 0)
        {
            return NotCollected;
        }

        string[] activeWorkflowAssignments = await FetchActiveWorkflowAssignmentsIds(context.Document, cancellationToken);

        if (!activeWorkflowAssignments.Contains(context.User.Id))
        {
            return NotCollected;
        }

        Dictionary<DocumentAttributeValueDetailedBff, DocumentPermissionTypeBff[]> result = signatoryAttributeValues.ToDictionary(
            value => value,
            _ => new[] { DocumentPermissionTypeBff.Edit });

        return result;
    }

    private static bool IsAttributeHasEditPermission(DocumentAttributeValueDetailedBff attributeValue, string role, string statusId)
    {
        var result = attributeValue.Attribute.Permissions
            .Where(p => p.StatusId == statusId)
            .SelectMany(p => p.Permissions)
            .Where(p => p.Type is DocumentPermissionTypeBff.Edit)
            .SelectMany(p => p.RoleIds)
            .Contains(role);

        return result;
    }

    private async Task<string[]> FetchActiveWorkflowAssignmentsIds(DocumentDetailedDto document, CancellationToken cancellationToken)
    {
        var workflowId = document.ApprovalData.Workflows.Last().Id;

        string[] ids = { workflowId };

        var request = new GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryExternal(ids);

        EntitiesApprovalWorkflowExternal[] response = await Details.GetWorkflows(request, cancellationToken);

        var workflow = response.Single();

        string[] result = workflow.Stages
            .First(s => !s.IsCompleted)
            .Groups
            .Where(g => g.Status is EntitiesApprovalWorkflowGroupStatusExternal.InProgress)
            .SelectMany(g => g.Assignments)
            .Where(a => !a.IsCompleted)
            .Select(a => a.ExecutorId)
            .ToArray();

        return result;
    }
}
