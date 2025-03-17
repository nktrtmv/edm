using Edm.Entities.Approval.Rules.Application.Internal.Groups.Queries.GetAll.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Queries.GetAll.Contracts.Groups;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Queries.GetAll;

internal static class GetAllApprovalGroupsQueryResponseInternalConverter
{
    internal static GetAllApprovalGroupsQueryResponse ToDto(GetAllApprovalGroupsQueryResponseInternal response)
    {
        GetAllApprovalGroupsQueryResponseGroup[] groups =
            response.Groups.Select(GetAllApprovalGroupsQueryResponseGroupConverter.ToDto).ToArray();

        var result = new GetAllApprovalGroupsQueryResponse
        {
            Groups = { groups }
        };

        return result;
    }
}
