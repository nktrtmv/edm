using Edm.Entities.Approval.Rules.Gateway.Core.GroupsDetails.Domestic.Queries.GetParticipantSourceAttributes.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.GroupsDetails.Domestic.Queries.GetParticipantSourceAttributes;

public sealed class GetParticipantSourceAttributesApprovalGroupsDetailsQueryBffService(ApprovalGroupsDetailsService.ApprovalGroupsDetailsServiceClient details)
{
    public async Task<GetParticipantSourceAttributesApprovalGroupsDetailsQueryResponseBff> GetParticipantSourceAttributes(
        GetParticipantSourceAttributesApprovalGroupsDetailsQueryBff query,
        CancellationToken cancellationToken)
    {
        var request =
            GetParticipantSourceAttributesApprovalGroupsDetailsQueryBffConverter.ToDto(query);

        var response =
            await details.GetParticipantSourceAttributesAsync(request, cancellationToken: cancellationToken);

        var result =
            GetParticipantSourceAttributesApprovalGroupsDetailsQueryResponseBffConverter.FromDto(response);

        return result;
    }
}
