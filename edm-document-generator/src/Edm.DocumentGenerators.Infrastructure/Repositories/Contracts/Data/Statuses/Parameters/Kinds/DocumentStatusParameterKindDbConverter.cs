using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Statuses.Parameters.Kinds;

internal static class DocumentStatusParameterKindDbConverter
{
    internal static DocumentStatusParameterKindDb FromDomain(DocumentStatusParameterKind kind)
    {
        DocumentStatusParameterKindDb result = kind switch
        {
            DocumentStatusParameterKind.ApprovalGraphTag => DocumentStatusParameterKindDb.ApprovalGraphTag,
            DocumentStatusParameterKind.ApprovalExitApprovedWithRemarkIsOff => DocumentStatusParameterKindDb.ApprovalExitApprovedWithRemarkIsOff,
            DocumentStatusParameterKind.StageOwner => DocumentStatusParameterKindDb.StageOwner,
            DocumentStatusParameterKind.SetCurrentUserToAttribute => DocumentStatusParameterKindDb.SetCurrentUserToAttribute,
            DocumentStatusParameterKind.IsBacklog => DocumentStatusParameterKindDb.IsBacklog,
            DocumentStatusParameterKind.BusinessErrorHandlingStatus => DocumentStatusParameterKindDb.BusinessErrorHandlingStatus,
            DocumentStatusParameterKind.UnifiedNextAutoStatus => DocumentStatusParameterKindDb.UnifiedNextAutoStatus,
            DocumentStatusParameterKind.Watchers => DocumentStatusParameterKindDb.Watchers,
            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        return result;
    }

    internal static DocumentStatusParameterKind ToDomain(DocumentStatusParameterKindDb kind)
    {
        DocumentStatusParameterKind result = kind switch
        {
            DocumentStatusParameterKindDb.ApprovalGraphTag => DocumentStatusParameterKind.ApprovalGraphTag,
            DocumentStatusParameterKindDb.ApprovalExitApprovedWithRemarkIsOff => DocumentStatusParameterKind.ApprovalExitApprovedWithRemarkIsOff,
            DocumentStatusParameterKindDb.StageOwner => DocumentStatusParameterKind.StageOwner,
            DocumentStatusParameterKindDb.SetCurrentUserToAttribute => DocumentStatusParameterKind.SetCurrentUserToAttribute,
            DocumentStatusParameterKindDb.IsBacklog => DocumentStatusParameterKind.IsBacklog,
            DocumentStatusParameterKindDb.BusinessErrorHandlingStatus => DocumentStatusParameterKind.BusinessErrorHandlingStatus,
            DocumentStatusParameterKindDb.UnifiedNextAutoStatus => DocumentStatusParameterKind.UnifiedNextAutoStatus,
            DocumentStatusParameterKindDb.Watchers => DocumentStatusParameterKind.Watchers,
            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        return result;
    }
}
