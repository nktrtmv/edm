using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.References;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.References.Types;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Abstractions.Single;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.Contexts;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.ValueObjects.RegistryRoles.Ids;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows;
using Edm.Document.Searcher.ExternalServices.Markers;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Inheritors.Participants.Approvals.
    Current;

internal sealed class ApprovalParticipantsSearchDocumentAttributesValuesCollector : SingleAttributesValuesCollector
{
    public ApprovalParticipantsSearchDocumentAttributesValuesCollector(IApprovalWorkflowsClient approvalWorkflows)
        : base(SearchDocumentRegistryRoleId.ApprovalParticipants)
    {
        ApprovalWorkflows = approvalWorkflows;
    }

    private IApprovalWorkflowsClient ApprovalWorkflows { get; }

    protected override async Task<SearchDocumentAttributeValueInternal?> Collect(
        SearchDocumentUpdaterContext context,
        SearchDocumentRegistryRoleInternal registryRole,
        CancellationToken cancellationToken)
    {
        string[]? values = await DetectCurrentParticipants(context, cancellationToken);

        if (values is null)
        {
            return null;
        }

        var result = new SearchDocumentReferenceAttributeValueInternal(
            registryRole,
            values,
            SearchDocumentReferenceAttributeValueTypeInternal.Employees);

        return result;
    }

    private async Task<string[]?> DetectCurrentParticipants(
        SearchDocumentUpdaterContext context,
        CancellationToken cancellationToken)
    {
        Id<EntityExternal> entityId = IdConverterFrom<EntityExternal>.From(context.Document.Id);

        string[] result = await ApprovalWorkflows.GetCurrentEntityApproversIds(entityId, cancellationToken);

        if (result.Length == 0)
        {
            return null;
        }

        return result;
    }
}
