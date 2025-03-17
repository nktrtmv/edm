using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants.Sources.Inheritors;
using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Groups.Details.Inheritors.Domestic.Participants.Sources.Users;

internal static class UserDomesticApprovalGroupParticipantSourceDbConverter
{
    public static UserDomesticApprovalGroupParticipantSource ToDomain(UserDomesticApprovalGroupParticipantSourceDb source)
    {
        Id<User> userId = IdConverterFrom<User>.FromString(source.UserId);

        var result = new UserDomesticApprovalGroupParticipantSource(userId);

        return result;
    }

    public static DomesticApprovalGroupParticipantSourceDb FromDomain(UserDomesticApprovalGroupParticipantSource source)
    {
        var userId = IdConverterTo.ToString(source.UserId);

        var asUser = new UserDomesticApprovalGroupParticipantSourceDb
        {
            UserId = userId
        };

        var result = new DomesticApprovalGroupParticipantSourceDb
        {
            AsUser = asUser
        };

        return result;
    }
}
