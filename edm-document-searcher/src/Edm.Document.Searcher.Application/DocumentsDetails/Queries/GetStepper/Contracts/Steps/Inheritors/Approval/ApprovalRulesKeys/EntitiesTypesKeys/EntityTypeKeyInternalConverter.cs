using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.ApprovalRulesKeys.EntitiesTypesKeys;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.ApprovalRulesKeys.EntitiesTypesKeys;

internal static class EntityTypeKeyInternalConverter
{
    internal static EntityTypeKeyInternal FromExternal(EntityTypeKeyExternal entityTypeKey)
    {
        var result = new EntityTypeKeyInternal(
            DomainId: entityTypeKey.DomainId,
            EntityTypeId: entityTypeKey.EntityTypeId.Value,
            EntityTypeUpdatedDate: entityTypeKey.EntityTypeUpdatedDate.Value);

        return result;
    }
}
