using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes.Stages.Groups.Inheritors.Domestic.Participants;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules.Converters.Contracts.Routes.Stages.Groups.Inheritors.Domestic.Participants;

internal static class RouteParticipantInternalConverter
{
    internal static ApprovalRouteParticipantDto ToDto(RouteParticipantInternal person)
    {
        var mainParticipantId =
            IdConverterTo.ToString(person.MainPersonId);

        string[] substitutePersonsIds =
            person.SubstitutePersonsIds.Select(IdConverterTo.ToString).ToArray();

        bool isSubstitutionDisabled = person.IsSubstitutionDisabled;

        var result = new ApprovalRouteParticipantDto
        {
            MainUserId = mainParticipantId,
            SubstituteUsersIds = { substitutePersonsIds },
            IsSubstitutionDisabled = isSubstitutionDisabled
        };

        return result;
    }
}
