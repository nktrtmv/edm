using Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.GetTypes;
using Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.GetTypes.Contracts;
using Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.SearchValues;
using Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.SearchValues.Contracts;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Edm.Entities.Approval.Rules.Gateway.Presentation.Controllers.References;

[Authorize]
[ApiController]
[Route("references/[Action]")]
public sealed class ApprovalReferencesController(
    GetTypesApprovalReferencesQueryService getTypesQueryService,
    SearchValuesApprovalReferencesQueryService searchValuesQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<GetTypesApprovalReferencesQueryResponseBff> GetTypes(
        GetTypesApprovalReferencesQueryBff query,
        CancellationToken cancellationToken)
    {
        var response = await getTypesQueryService.GetTypes(query, cancellationToken);

        return response;
    }

    [HttpPost]
    public async Task<SearchValuesApprovalReferencesQueryResponseBff> SearchValues(
        SearchValuesApprovalReferencesQueryBff query,
        CancellationToken cancellationToken)
    {
        var response = await searchValuesQueryService.SearchValues(query, cancellationToken);

        return response;
    }
}
