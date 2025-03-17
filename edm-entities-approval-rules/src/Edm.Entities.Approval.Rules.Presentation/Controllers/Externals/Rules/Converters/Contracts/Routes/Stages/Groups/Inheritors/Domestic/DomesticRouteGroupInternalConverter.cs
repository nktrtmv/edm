using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes.Stages.Groups.Inheritors.Domestic;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules.Converters.Contracts.Routes.Stages.Groups.Inheritors.Domestic.Participants;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules.Converters.Contracts.Routes.Stages.Groups.Inheritors.Domestic;

internal static class DomesticRouteGroupInternalConverter
{
    internal static ApprovalRouteGroupDto ToDto(DomesticRouteGroupInternal group)
    {
        ApprovalRouteParticipantDto[] participants =
            group.Participants.Select(RouteParticipantInternalConverter.ToDto).ToArray();

        var asDomestic = new DomesticApprovalRouteGroupDto
        {
            Participants = { participants }
        };

        var result = new ApprovalRouteGroupDto
        {
            AsDomestic = asDomestic
        };

        return result;
    }
}
