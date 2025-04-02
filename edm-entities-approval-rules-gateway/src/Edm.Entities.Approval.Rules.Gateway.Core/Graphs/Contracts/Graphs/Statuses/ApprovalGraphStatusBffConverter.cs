using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Statuses;

internal static class ApprovalGraphStatusBffConverter
{
    internal static ApprovalGraphStatusBff FromDto(ApprovalGraphStatusDto status)
    {
        var result = status switch
        {
            ApprovalGraphStatusDto.Draft => ApprovalGraphStatusBff.Draft,
            ApprovalGraphStatusDto.Active => ApprovalGraphStatusBff.Active,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    internal static ApprovalGraphStatusDto ToDto(ApprovalGraphStatusBff status)
    {
        var result = status switch
        {
            ApprovalGraphStatusBff.Draft => ApprovalGraphStatusDto.Draft,
            ApprovalGraphStatusBff.Active => ApprovalGraphStatusDto.Active,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
