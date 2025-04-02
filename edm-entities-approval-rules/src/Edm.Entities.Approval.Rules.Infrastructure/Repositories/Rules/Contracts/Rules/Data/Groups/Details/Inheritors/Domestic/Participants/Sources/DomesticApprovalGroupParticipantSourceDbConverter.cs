using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants.Sources;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants.Sources.Inheritors;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Groups.Details.Inheritors.Domestic.Participants.Sources.AttributeIds;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Groups.Details.Inheritors.Domestic.Participants.Sources.Users;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Groups.Details.Inheritors.Domestic.Participants.Sources;

internal static class DomesticApprovalGroupParticipantSourceDbConverter
{
    public static DomesticApprovalGroupParticipantSource ToDomain(DomesticApprovalGroupParticipantSourceDb source)
    {
        DomesticApprovalGroupParticipantSource result = source.ValueCase switch
        {
            DomesticApprovalGroupParticipantSourceDb.ValueOneofCase.AsUser =>
                UserDomesticApprovalGroupParticipantSourceDbConverter.ToDomain(source.AsUser),

            DomesticApprovalGroupParticipantSourceDb.ValueOneofCase.AsAttribute =>
                AttributeIdDomesticApprovalGroupParticipantSourceDbConverter.ToDomain(source.AsAttribute),

            _ => throw new ArgumentTypeOutOfRangeException(source.ValueCase)
        };

        return result;
    }

    public static DomesticApprovalGroupParticipantSourceDb FromDomain(DomesticApprovalGroupParticipantSource source)
    {
        DomesticApprovalGroupParticipantSourceDb result = source switch
        {
            UserDomesticApprovalGroupParticipantSource asUser =>
                UserDomesticApprovalGroupParticipantSourceDbConverter.FromDomain(asUser),

            AttributeDomesticApprovalGroupParticipantSource asAttribute =>
                AttributeIdDomesticApprovalGroupParticipantSourceDbConverter.FromDomain(asAttribute),

            _ => throw new ArgumentTypeOutOfRangeException(source)
        };

        return result;
    }
}
