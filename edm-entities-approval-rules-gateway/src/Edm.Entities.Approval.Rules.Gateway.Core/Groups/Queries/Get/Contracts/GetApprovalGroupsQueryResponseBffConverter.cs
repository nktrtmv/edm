using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups;
using Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Contexts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Queries.Get.Contracts;

internal static class GetApprovalGroupsQueryResponseBffConverter
{
    internal static GetApprovalGroupsQueryResponseBff FromDto(GetApprovalGroupsQueryResponse response, ApprovalEnrichersContext context)
    {
        var group = ApprovalGroupBffConverter.FromDto(response.Group, context);

        var result = new GetApprovalGroupsQueryResponseBff
        {
            Group = group,
            ConcurrencyToken = response.ConcurrencyToken
        };

        return result;
    }
}
