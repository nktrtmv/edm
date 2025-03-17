using Edm.Entities.Approval.Rules.Gateway.Core.Conditions.Operators.Queries.GetLogicalOperators.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Conditions.Operators.Queries.GetLogicalOperators;

public sealed class GetLogicalOperatorsApprovalConditionsOperatorsService : ApprovalConditionsOperatorsServiceBase
{
    public GetLogicalOperatorsApprovalConditionsOperatorsService(ApprovalConditionsOperatorsService.ApprovalConditionsOperatorsServiceClient operators)
        : base(operators)
    {
    }

    public async Task<GetLogicalOperatorsApprovalConditionsOperatorsQueryResponseBff> GetLogicalOperators(
        GetLogicalOperatorsApprovalConditionsOperatorsQueryBff _,
        CancellationToken cancellationToken)
    {
        var request = new GetLogicalOperatorsApprovalConditionsOperatorsQuery();

        var response =
            await Operators.GetLogicalOperatorsAsync(request, cancellationToken: cancellationToken);

        var result =
            GetLogicalOperatorsApprovalConditionsOperatorsQueryResponseBffConverter.FromDto(response);

        return result;
    }
}
