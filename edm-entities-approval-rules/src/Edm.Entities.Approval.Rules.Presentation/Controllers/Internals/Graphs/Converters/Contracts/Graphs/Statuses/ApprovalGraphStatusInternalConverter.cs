using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Statuses;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Contracts.Graphs.Statuses;

internal static class ApprovalGraphStatusInternalConverter
{
    internal static ApprovalGraphStatusDto ToDto(ApprovalGraphStatusInternal status)
    {
        ApprovalGraphStatusDto result = status switch
        {
            ApprovalGraphStatusInternal.Draft => ApprovalGraphStatusDto.Draft,
            ApprovalGraphStatusInternal.Active => ApprovalGraphStatusDto.Active,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    internal static ApprovalGraphStatusInternal FromDto(ApprovalGraphStatusDto status)
    {
        ApprovalGraphStatusInternal result = status switch
        {
            ApprovalGraphStatusDto.Draft => ApprovalGraphStatusInternal.Draft,
            ApprovalGraphStatusDto.Active => ApprovalGraphStatusInternal.Active,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
