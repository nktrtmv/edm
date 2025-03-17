using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Updaters.Groups.Fetchers.QueryParams;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Updaters.Groups.Fetchers.QueryParams.Factories;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Queries.GetAll.Contracts.QueryParams;

internal static class GetAllApprovalGroupsQueryParamsInternalConverter
{
    internal static GetAllApprovalGroupsQueryParams ToDomain(GetAllApprovalGroupsQueryParamsInternal? queryParams)
    {
        if (queryParams is null)
        {
            return new GetAllApprovalGroupsQueryParams();
        }

        GetAllApprovalGroupsQueryParams result = GetAllApprovalGroupsQueryParamsFactory.CreateFrom(queryParams.Search, queryParams.ParticipantIds, queryParams.Skip, queryParams.Limit);

        return result;
    }
}
