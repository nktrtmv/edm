using Edm.Document.Searcher.ExternalServices.Markers;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetAllExecutors;

internal static class GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryConverter
{
    public static GetAllExecutorsEntitiesApprovalWorkflowsDetailsQuery FromExternal(Id<EntityExternal> entityIdExternal)
    {
        var entityId = IdConverterTo.ToString(entityIdExternal);

        var result = new GetAllExecutorsEntitiesApprovalWorkflowsDetailsQuery
        {
            EntityId = entityId
        };

        return result;
    }
}
