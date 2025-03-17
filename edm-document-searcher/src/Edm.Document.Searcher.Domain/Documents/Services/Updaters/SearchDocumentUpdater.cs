using Edm.Document.Searcher.Domain.Documents.Services.Updaters.AttributesValues.Watchers;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.ValueObjects.RegistryRoles.Ids;

namespace Edm.Document.Searcher.Domain.Documents.Services.Updaters;

public static class SearchDocumentUpdater
{
    public static void UpdateApprovalParticipants(SearchDocument document, string[] currentApproversIds, string[] allApproversIds)
    {
        SearchDocumentWatcherAttributeValueUpdater.Update(document, SearchDocumentRegistryRoleId.ApprovalParticipants, currentApproversIds);

        SearchDocumentWatcherAttributeValueUpdater.Update(document, SearchDocumentRegistryRoleId.ApprovalCumulativeParticipants, allApproversIds);
    }
}
