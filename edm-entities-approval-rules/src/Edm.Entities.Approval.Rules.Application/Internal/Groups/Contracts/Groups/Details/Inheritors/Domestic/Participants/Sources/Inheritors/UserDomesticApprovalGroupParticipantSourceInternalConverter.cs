using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants.Sources.Inheritors;
using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources.Inheritors;

internal static class UserDomesticApprovalGroupParticipantSourceInternalConverter
{
    public static UserDomesticApprovalGroupParticipantSourceInternal FromDomain(UserDomesticApprovalGroupParticipantSource source)
    {
        var userId = IdConverterTo.ToString(source.UserId);

        var result = new UserDomesticApprovalGroupParticipantSourceInternal(userId);

        return result;
    }

    public static UserDomesticApprovalGroupParticipantSource ToDomain(UserDomesticApprovalGroupParticipantSourceInternal source)
    {
        Id<User> userId = IdConverterFrom<User>.FromString(source.UserId);

        var result = new UserDomesticApprovalGroupParticipantSource(userId);

        return result;
    }
}
