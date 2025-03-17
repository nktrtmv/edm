using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.Strings;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Abstractions.Single.Synchronous;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.Contexts;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.ValueObjects.RegistryRoles.Ids;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups.Statuses;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Statuses;

namespace Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Inheritors.Groups.Approvals.Current;

internal sealed class ApprovalGroupsSearchDocumentAttributesValuesCollector()
    : SynchronousSingleAttributesValuesCollector(SearchDocumentRegistryRoleId.ApprovalGroups)
{
    protected override SearchDocumentAttributeValueInternal? Collect(SearchDocumentUpdaterContext context, SearchDocumentRegistryRoleInternal registryRole)
    {
        string[]? values = DetectCurrentGroups(context);

        if (values is null)
        {
            return null;
        }

        var result = new SearchDocumentStringAttributeValueInternal(registryRole, values);

        return result;
    }

    private string[]? DetectCurrentGroups(SearchDocumentUpdaterContext context)
    {
        string[]? result = context.CurrentApprovalWorkflow?.Stages
            .Where(s => s.Status == EntitiesApprovalWorkflowStageStatusExternal.InProgress)
            .SelectMany(s => s.Groups)
            .Where(g => g.Status is EntitiesApprovalWorkflowGroupStatusExternal.InProgress)
            .Select(x => x.Name)
            .ToArray();

        return result;
    }
}
