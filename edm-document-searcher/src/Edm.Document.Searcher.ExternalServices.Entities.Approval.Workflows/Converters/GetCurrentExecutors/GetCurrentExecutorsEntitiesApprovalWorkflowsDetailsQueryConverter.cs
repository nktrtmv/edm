using Edm.Document.Searcher.ExternalServices.Markers;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetCurrentExecutors;

internal static class GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryConverter
{
    public static GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQuery FromExternal(Id<EntityExternal> entityIdExternal)
    {
        var entityId = IdConverterTo.ToString(entityIdExternal);

        var result = new GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQuery
        {
            EntityId = entityId
        };

        return result;
    }
}
