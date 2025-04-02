using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Queries.GetAll.Contracts.Groups;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Queries.GetAll.Contracts;

internal static class GetAllApprovalGroupsQueryResponseBffConverter
{
    internal static GetAllApprovalGroupsQueryResponseBff FromDto(GetAllApprovalGroupsQueryResponse response)
    {
        GetAllApprovalGroupsQueryResponseGroupBff[] groups =
            response.Groups.Select(GetAllApprovalGroupsQueryResponseGroupBffConverter.FromDto).ToArray();

        var result = new GetAllApprovalGroupsQueryResponseBff
        {
            Groups = groups
        };

        return result;
    }
}
