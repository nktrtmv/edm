using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Statuses;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Graphs.Statuses;

internal static class ApprovalGraphStatusDbConverter
{
    internal static ApprovalGraphStatusDb FromDomain(ApprovalGraphStatus status)
    {
        ApprovalGraphStatusDb result = status switch
        {
            ApprovalGraphStatus.Draft => ApprovalGraphStatusDb.Draft,
            ApprovalGraphStatus.Active => ApprovalGraphStatusDb.Active,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    internal static ApprovalGraphStatus ToDomain(ApprovalGraphStatusDb status)
    {
        ApprovalGraphStatus result = status switch
        {
            ApprovalGraphStatusDb.Draft => ApprovalGraphStatus.Draft,
            ApprovalGraphStatusDb.Active => ApprovalGraphStatus.Active,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
