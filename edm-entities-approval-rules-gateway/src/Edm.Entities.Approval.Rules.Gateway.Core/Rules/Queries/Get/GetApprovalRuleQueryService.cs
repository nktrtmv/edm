using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Get.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Get;

public sealed class GetApprovalRuleQueryService(ApprovalRulesService.ApprovalRulesServiceClient rules) : ApprovalRulesServiceBase(rules)
{
    public async Task<GetApprovalRuleQueryResponseBff> Get(GetApprovalRuleQueryBff query, CancellationToken cancellationToken)
    {
        var request = GetApprovalRuleQueryBffConverter.ToDto(query);

        var response = await Rules.GetAsync(request, cancellationToken: cancellationToken);

        var result = GetApprovalRuleQueryResponseBffConverter.FromDto(response);

        return result;
    }
}
