using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters.Kinds;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Parameters.Kinds;

internal static class DocumentStatusParameterKindInternalConverter
{
    internal static DocumentStatusParameterKindInternal FromExternal(DocumentStatusParameterKindExternal kind)
    {
        DocumentStatusParameterKindInternal result = kind switch
        {
            DocumentStatusParameterKindExternal.ApprovalGraphTag => DocumentStatusParameterKindInternal.ApprovalGraphTag,
            DocumentStatusParameterKindExternal.ApprovalExitApprovedWithRemarkIsOff => DocumentStatusParameterKindInternal.ApprovalExitApprovedWithRemarkIsOff,
            DocumentStatusParameterKindExternal.StageOwner => DocumentStatusParameterKindInternal.StageOwner,
            DocumentStatusParameterKindExternal.SetCurrentUserToAttribute => DocumentStatusParameterKindInternal.SetCurrentUserToAttribute,
            DocumentStatusParameterKindExternal.IsBacklog => DocumentStatusParameterKindInternal.IsBacklog,
            DocumentStatusParameterKindExternal.BusinessErrorHandlingStatus => DocumentStatusParameterKindInternal.BusinessErrorHandlingStatus,
            DocumentStatusParameterKindExternal.UnifiedNextAutoStatus => DocumentStatusParameterKindInternal.UnifiedNextAutoStatus,
            DocumentStatusParameterKindExternal.Watchers => DocumentStatusParameterKindInternal.Watchers,
            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        return result;
    }
}
