using Edm.Entities.Approval.Rules.Application.Internal.Groups.Queries.GetAll.Contracts.QueryParams;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Queries.GetAll.Contracts.QueryParams;

internal static class GetAllApprovalGroupsQueryParamsInternalConverter
{
    internal static GetAllApprovalGroupsQueryParamsInternal FromDto(GetAllApprovalGroupsQueryParamsDto queryParams)
    {
        var result = new GetAllApprovalGroupsQueryParamsInternal(queryParams.Search, queryParams.ParticipantIds.ToArray(), queryParams.Skip, queryParams.Limit);

        return result;
    }
}
