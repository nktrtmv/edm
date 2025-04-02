using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetAll.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetAll;

public sealed class GetAllApprovalRulesQueryService : ApprovalRulesServiceBase
{
    public GetAllApprovalRulesQueryService(ApprovalRulesService.ApprovalRulesServiceClient rules) : base(rules)
    {
    }

    public async Task<GetAllApprovalRulesQueryResponseBff> GetAll(GetAllApprovalRulesQueryBff query, CancellationToken cancellationToken)
    {
        var request = GetAllApprovalRulesEntitiesTypesQueryBffConverter.ToDto(query);

        var response = await Rules.GetAllAsync(request, cancellationToken: cancellationToken);

        var result = GetAllApprovalRulesQueryResponseBffConverter.FromDto(response);

        return result;
    }
}
