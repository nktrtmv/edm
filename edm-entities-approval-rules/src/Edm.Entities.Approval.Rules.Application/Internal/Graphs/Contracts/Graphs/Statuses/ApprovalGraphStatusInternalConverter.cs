using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Statuses;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Statuses;

internal static class ApprovalGraphStatusInternalConverter
{
    internal static ApprovalGraphStatusInternal FromDomain(ApprovalGraphStatus status)
    {
        ApprovalGraphStatusInternal result = status switch
        {
            ApprovalGraphStatus.Draft => ApprovalGraphStatusInternal.Draft,
            ApprovalGraphStatus.Active => ApprovalGraphStatusInternal.Active,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    internal static ApprovalGraphStatus ToDomain(ApprovalGraphStatusInternal status)
    {
        ApprovalGraphStatus result = status switch
        {
            ApprovalGraphStatusInternal.Draft => ApprovalGraphStatus.Draft,
            ApprovalGraphStatusInternal.Active => ApprovalGraphStatus.Active,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
