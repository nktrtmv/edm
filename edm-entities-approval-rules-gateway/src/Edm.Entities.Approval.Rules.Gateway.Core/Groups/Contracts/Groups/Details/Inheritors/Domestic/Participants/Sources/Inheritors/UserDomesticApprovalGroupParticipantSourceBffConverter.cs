using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Persons;
using Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Contexts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources.Inheritors;

internal static class UserDomesticApprovalGroupParticipantSourceBffConverter
{
    public static UserDomesticApprovalGroupParticipantSourceBff FromDto(UserDomesticApprovalGroupParticipantSourceDto source, ApprovalEnrichersContext context)
    {
        var person = PersonBffConverter.FromDto(source.UserId, context);

        var result = new UserDomesticApprovalGroupParticipantSourceBff(person);

        return result;
    }

    public static DomesticApprovalGroupParticipantSourceDto ToDto(UserDomesticApprovalGroupParticipantSourceBff source)
    {
        var asUser = new UserDomesticApprovalGroupParticipantSourceDto
        {
            UserId = source.User.Id
        };

        var result = new DomesticApprovalGroupParticipantSourceDto
        {
            AsUser = asUser
        };

        return result;
    }
}
