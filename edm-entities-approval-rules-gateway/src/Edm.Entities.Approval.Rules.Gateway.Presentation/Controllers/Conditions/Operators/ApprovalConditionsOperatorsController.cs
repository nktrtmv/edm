using Edm.Entities.Approval.Rules.Gateway.Core.Conditions.Operators.Queries.GetAttributesOperators;
using Edm.Entities.Approval.Rules.Gateway.Core.Conditions.Operators.Queries.GetAttributesOperators.Contracts;
using Edm.Entities.Approval.Rules.Gateway.Core.Conditions.Operators.Queries.GetLogicalOperators;
using Edm.Entities.Approval.Rules.Gateway.Core.Conditions.Operators.Queries.GetLogicalOperators.Contracts;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Edm.Entities.Approval.Rules.Gateway.Presentation.Controllers.Conditions.Operators;

[Authorize]
[ApiController]
[Route("conditions/operators/[Action]")]
public sealed class ApprovalConditionsOperatorsController(
    GetLogicalOperatorsApprovalConditionsOperatorsService getLogicalOperatorsService,
    GetAttributesOperatorsApprovalConditionsOperatorsService getAttributesOperatorsService) : ControllerBase
{
    [HttpPost]
    public async Task<GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseBff> GetAttributesOperators(
        GetAttributesOperatorsApprovalConditionsOperatorsQueryBff query,
        CancellationToken cancellationToken)
    {
        var response =
            await getAttributesOperatorsService.GetAttributesOperators(query, cancellationToken);

        return response;
    }

    [HttpPost]
    public async Task<GetLogicalOperatorsApprovalConditionsOperatorsQueryResponseBff> GetLogicalOperators(
        GetLogicalOperatorsApprovalConditionsOperatorsQueryBff query,
        CancellationToken cancellationToken)
    {
        var response =
            await getLogicalOperatorsService.GetLogicalOperators(query, cancellationToken);

        return response;
    }
}
