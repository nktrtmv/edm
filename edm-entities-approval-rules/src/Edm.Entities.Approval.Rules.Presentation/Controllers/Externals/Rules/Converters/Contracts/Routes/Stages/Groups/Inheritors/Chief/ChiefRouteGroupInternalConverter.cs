using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules.Converters.Contracts.Routes.Stages.Groups.Inheritors.Chief;

internal static class ChiefRouteGroupInternalConverter
{
    internal static ApprovalRouteGroupDto ToDto()
    {
        var asChief = new ChiefApprovalRouteGroupDto();

        var result = new ApprovalRouteGroupDto
        {
            AsChief = asChief
        };

        return result;
    }
}
