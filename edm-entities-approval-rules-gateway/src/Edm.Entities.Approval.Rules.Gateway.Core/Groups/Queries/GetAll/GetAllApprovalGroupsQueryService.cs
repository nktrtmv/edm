using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Queries.GetAll.Contracts;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Queries.GetAll.Contracts.Filtering;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Queries.GetAll;

public sealed class GetAllApprovalGroupsQueryService : ApprovalGroupsServiceBase
{
    public GetAllApprovalGroupsQueryService(ApprovalGroupsService.ApprovalGroupsServiceClient groups) : base(groups)
    {
    }

    public async Task<GetAllApprovalGroupsQueryResponseBff> GetAll(
        GetAllApprovalGroupsQueryBff query,
        FilteringParametersDto filtering,
        int skip,
        int limit,
        CancellationToken cancellationToken)
    {
        var request = GetAllApprovalGroupsQueryBffConverter.ToDto(query, filtering, skip, limit);

        var response = await Groups.GetAllAsync(request, cancellationToken: cancellationToken);

        var result = GetAllApprovalGroupsQueryResponseBffConverter.FromDto(response);

        return result;
    }
}
