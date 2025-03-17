using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources.Inheritors;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources.Users;

internal static class UserDomesticApprovalGroupParticipantSourceDtoConverter
{
    public static DomesticApprovalGroupParticipantSourceDto FromInternal(UserDomesticApprovalGroupParticipantSourceInternal source)
    {
        var asUser = new UserDomesticApprovalGroupParticipantSourceDto
        {
            UserId = source.UserId
        };

        var result = new DomesticApprovalGroupParticipantSourceDto
        {
            AsUser = asUser
        };

        return result;
    }

    public static UserDomesticApprovalGroupParticipantSourceInternal ToInternal(UserDomesticApprovalGroupParticipantSourceDto source)
    {
        var result = new UserDomesticApprovalGroupParticipantSourceInternal(source.UserId);

        return result;
    }
}
