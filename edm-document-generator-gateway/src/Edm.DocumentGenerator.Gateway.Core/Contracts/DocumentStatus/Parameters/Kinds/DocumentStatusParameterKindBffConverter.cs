using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters.Kinds;

internal static class DocumentStatusParameterKindBffConverter
{
    internal static DocumentStatusParameterKindBff FromDto(DocumentStatusParameterKindDto kind)
    {
        var result = kind switch
        {
            DocumentStatusParameterKindDto.ApprovalGraphTag => DocumentStatusParameterKindBff.ApprovalGraphTag,
            DocumentStatusParameterKindDto.ApprovalExitApprovedWithRemarkIsOff => DocumentStatusParameterKindBff.ApprovalExitApprovedWithRemarkIsOff,
            DocumentStatusParameterKindDto.StageOwner => DocumentStatusParameterKindBff.StageOwner,
            DocumentStatusParameterKindDto.SetCurrentUserToAttribute => DocumentStatusParameterKindBff.SetCurrentUserToAttribute,
            DocumentStatusParameterKindDto.IsBacklog => DocumentStatusParameterKindBff.IsBacklog,
            DocumentStatusParameterKindDto.BusinessErrorHandlingStatus => DocumentStatusParameterKindBff.BusinessErrorHandlingStatus,
            DocumentStatusParameterKindDto.UnifiedNextAutoStatus => DocumentStatusParameterKindBff.UnifiedNextAutoStatus,
            DocumentStatusParameterKindDto.Watchers => DocumentStatusParameterKindBff.Watchers,
            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        return result;
    }

    internal static DocumentStatusParameterKindDto ToDto(DocumentStatusParameterKindBff kind)
    {
        var result = kind switch
        {
            DocumentStatusParameterKindBff.ApprovalGraphTag => DocumentStatusParameterKindDto.ApprovalGraphTag,
            DocumentStatusParameterKindBff.ApprovalExitApprovedWithRemarkIsOff => DocumentStatusParameterKindDto.ApprovalExitApprovedWithRemarkIsOff,
            DocumentStatusParameterKindBff.StageOwner => DocumentStatusParameterKindDto.StageOwner,
            DocumentStatusParameterKindBff.SetCurrentUserToAttribute => DocumentStatusParameterKindDto.SetCurrentUserToAttribute,
            DocumentStatusParameterKindBff.IsBacklog => DocumentStatusParameterKindDto.IsBacklog,
            DocumentStatusParameterKindBff.BusinessErrorHandlingStatus => DocumentStatusParameterKindDto.BusinessErrorHandlingStatus,
            DocumentStatusParameterKindBff.UnifiedNextAutoStatus => DocumentStatusParameterKindDto.UnifiedNextAutoStatus,
            DocumentStatusParameterKindBff.Watchers => DocumentStatusParameterKindDto.Watchers,
            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        return result;
    }
}
