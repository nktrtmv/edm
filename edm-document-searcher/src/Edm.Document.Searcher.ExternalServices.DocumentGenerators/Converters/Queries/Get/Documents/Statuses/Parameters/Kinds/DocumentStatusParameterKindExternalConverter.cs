using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters.Kinds;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.Statuses.Parameters.Kinds;

internal static class DocumentStatusParameterKindExternalConverter
{
    public static DocumentStatusParameterKindExternal FromDto(DocumentStatusParameterKindDto kind)
    {
        DocumentStatusParameterKindExternal result = kind switch
        {
            DocumentStatusParameterKindDto.ApprovalGraphTag => DocumentStatusParameterKindExternal.ApprovalGraphTag,
            DocumentStatusParameterKindDto.ApprovalExitApprovedWithRemarkIsOff => DocumentStatusParameterKindExternal.ApprovalExitApprovedWithRemarkIsOff,
            DocumentStatusParameterKindDto.StageOwner => DocumentStatusParameterKindExternal.StageOwner,
            DocumentStatusParameterKindDto.SetCurrentUserToAttribute => DocumentStatusParameterKindExternal.SetCurrentUserToAttribute,
            DocumentStatusParameterKindDto.IsBacklog => DocumentStatusParameterKindExternal.IsBacklog,
            DocumentStatusParameterKindDto.BusinessErrorHandlingStatus => DocumentStatusParameterKindExternal.BusinessErrorHandlingStatus,
            DocumentStatusParameterKindDto.UnifiedNextAutoStatus => DocumentStatusParameterKindExternal.UnifiedNextAutoStatus,
            DocumentStatusParameterKindDto.Watchers => DocumentStatusParameterKindExternal.Watchers,
            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        return result;
    }
}
