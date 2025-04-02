using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.Statuses.Parameters.Kinds;

internal static class DocumentStatusParameterKindDtoConverter
{
    internal static DocumentStatusParameterKindDto FromInternal(DocumentStatusParameterKind kind)
    {
        DocumentStatusParameterKindDto result = kind switch
        {
            DocumentStatusParameterKind.ApprovalGraphTag => DocumentStatusParameterKindDto.ApprovalGraphTag,
            DocumentStatusParameterKind.ApprovalExitApprovedWithRemarkIsOff => DocumentStatusParameterKindDto.ApprovalExitApprovedWithRemarkIsOff,
            DocumentStatusParameterKind.StageOwner => DocumentStatusParameterKindDto.StageOwner,
            DocumentStatusParameterKind.SetCurrentUserToAttribute => DocumentStatusParameterKindDto.SetCurrentUserToAttribute,
            DocumentStatusParameterKind.IsBacklog => DocumentStatusParameterKindDto.IsBacklog,
            DocumentStatusParameterKind.BusinessErrorHandlingStatus => DocumentStatusParameterKindDto.BusinessErrorHandlingStatus,
            DocumentStatusParameterKind.UnifiedNextAutoStatus => DocumentStatusParameterKindDto.UnifiedNextAutoStatus,
            DocumentStatusParameterKind.Watchers => DocumentStatusParameterKindDto.Watchers,
            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        return result;
    }

    internal static DocumentStatusParameterKind ToInternal(DocumentStatusParameterKindDto kind)
    {
        DocumentStatusParameterKind result = kind switch
        {
            DocumentStatusParameterKindDto.ApprovalGraphTag => DocumentStatusParameterKind.ApprovalGraphTag,
            DocumentStatusParameterKindDto.ApprovalExitApprovedWithRemarkIsOff => DocumentStatusParameterKind.ApprovalExitApprovedWithRemarkIsOff,
            DocumentStatusParameterKindDto.StageOwner => DocumentStatusParameterKind.StageOwner,
            DocumentStatusParameterKindDto.SetCurrentUserToAttribute => DocumentStatusParameterKind.SetCurrentUserToAttribute,
            DocumentStatusParameterKindDto.IsBacklog => DocumentStatusParameterKind.IsBacklog,
            DocumentStatusParameterKindDto.BusinessErrorHandlingStatus => DocumentStatusParameterKind.BusinessErrorHandlingStatus,
            DocumentStatusParameterKindDto.UnifiedNextAutoStatus => DocumentStatusParameterKind.UnifiedNextAutoStatus,
            DocumentStatusParameterKindDto.Watchers => DocumentStatusParameterKind.Watchers,
            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        return result;
    }
}
