using Edm.Entities.Approval.Rules.Gateway.Core.Conditions.Operators.Queries.GetAttributesOperators.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Conditions.Operators.Queries.GetAttributesOperators;

public sealed class GetAttributesOperatorsApprovalConditionsOperatorsService : ApprovalConditionsOperatorsServiceBase
{
    public GetAttributesOperatorsApprovalConditionsOperatorsService(ApprovalConditionsOperatorsService.ApprovalConditionsOperatorsServiceClient operators)
        : base(operators)
    {
    }

    public async Task<GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseBff> GetAttributesOperators(
        GetAttributesOperatorsApprovalConditionsOperatorsQueryBff query,
        CancellationToken cancellationToken)
    {
        var request =
            GetAttributesOperatorsApprovalConditionsOperatorsQueryBffConverter.ToDto(query);

        var response =
            await Operators.GetAttributesOperatorsAsync(request, cancellationToken: cancellationToken);

        var result =
            GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseBffConverter.FromDto(response);

        return result;
    }
}
