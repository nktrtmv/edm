using Edm.Entities.Approval.Rules.Gateway.Core.Domains.Queries.GetAll;
using Edm.Entities.Approval.Rules.Gateway.Core.Domains.Queries.GetAll.Contracts;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Edm.Entities.Approval.Rules.Gateway.Presentation.Controllers.Domains;

[Authorize]
[Route("domains/[Action]")]
[ApiController]
public sealed class ApprovalDomainsController(GetAllApprovalDomainsQueryService getAllService) : ControllerBase
{
    [HttpPost]
    public async Task<GetAllApprovalDomainsQueryResponseBff> GetAll(
        GetAllApprovalDomainsQueryBff query,
        CancellationToken cancellationToken)
    {
        var response = await getAllService.GetAll(query, cancellationToken);

        return response;
    }
}
