using Edm.Entities.Approval.Rules.Gateway.Core.GroupsDetails.Domestic.Queries.GetParticipantSourceAttributes;
using Edm.Entities.Approval.Rules.Gateway.Core.GroupsDetails.Domestic.Queries.GetParticipantSourceAttributes.Contracts;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Edm.Entities.Approval.Rules.Gateway.Presentation.Controllers.GroupsDetails;

[Authorize]
[Route("groups-details/[Action]")]
[ApiController]
public sealed class ApprovalGroupsDetailsController(
    GetParticipantSourceAttributesApprovalGroupsDetailsQueryBffService getParticipantSourceAttributesQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<GetParticipantSourceAttributesApprovalGroupsDetailsQueryResponseBff> GetParticipantSourceAttributes(
        GetParticipantSourceAttributesApprovalGroupsDetailsQueryBff query,
        CancellationToken cancellationToken)
    {
        var response =
            await getParticipantSourceAttributesQueryService.GetParticipantSourceAttributes(query, cancellationToken);

        return response;
    }
}
