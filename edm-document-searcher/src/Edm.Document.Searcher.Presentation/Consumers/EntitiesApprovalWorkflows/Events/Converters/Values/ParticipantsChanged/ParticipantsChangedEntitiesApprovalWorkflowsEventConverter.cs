using Edm.Document.Searcher.Application.Documents.Events.ApprovalWorkflows.ParticipantsChanged.Contracts;
using Edm.Document.Searcher.Application.Documents.Markers;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.Document.Searcher.Presentation.Consumers.EntitiesApprovalWorkflows.Events.Converters.Values.ParticipantsChanged;

internal static class ParticipantsChangedEntitiesApprovalWorkflowsEventConverter
{
    internal static ParticipantsChangedEntitiesApprovalWorkflowEventInternal ToInternal(
        ParticipantsChangedEntitiesApprovalWorkflowsEvent assignmentsChange,
        string domainId)
    {
        var documentId = IdConverterFrom<SearchDocumentInternal>.FromString(assignmentsChange.EntityId);

        var result = new ParticipantsChangedEntitiesApprovalWorkflowEventInternal(domainId, documentId);

        return result;
    }
}
