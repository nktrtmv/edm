using Edm.Document.Searcher.Application.Documents.Events.ApprovalWorkflows.StageChanged.Contracts;
using Edm.Document.Searcher.Application.Documents.Markers;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.Document.Searcher.Presentation.Consumers.EntitiesApprovalWorkflows.Events.Converters.Values.StageChanged;

internal static class StageChangedEntitiesApprovalWorkflowsEventConverter
{
    internal static StageChangedEntitiesApprovalWorkflowEventInternal ToInternal(
        StageChangedEntitiesApprovalWorkflowsEvent assignmentsChange,
        string domainId)
    {
        var documentId = IdConverterFrom<SearchDocumentInternal>.FromString(assignmentsChange.EntityId);

        var result = new StageChangedEntitiesApprovalWorkflowEventInternal(domainId, documentId);

        return result;
    }
}
