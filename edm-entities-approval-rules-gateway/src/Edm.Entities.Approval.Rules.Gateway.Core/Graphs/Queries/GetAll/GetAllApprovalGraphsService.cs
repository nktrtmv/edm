using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Queries.GetAll.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Queries.GetAll;

public sealed class GetAllApprovalGraphsService : ApprovalGraphsServiceBase
{
    public GetAllApprovalGraphsService(ApprovalGraphsService.ApprovalGraphsServiceClient graphs) : base(graphs)
    {
    }

    public async Task<GetAllApprovalGraphsQueryResponseBff> GetAll(GetAllApprovalGraphsQueryBff query, CancellationToken cancellationToken)
    {
        var request = GetAllApprovalGraphsQueryBffConverter.ToDto(query);

        var response = await Graphs.GetAllAsync(request, cancellationToken: cancellationToken);

        var result = GetAllApprovalGraphsQueryResponseBffConverter.FromDto(response);

        return result;
    }
}
