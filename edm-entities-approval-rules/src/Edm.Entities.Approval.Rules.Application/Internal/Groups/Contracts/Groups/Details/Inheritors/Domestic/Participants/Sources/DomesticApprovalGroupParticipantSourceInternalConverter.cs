using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources.Inheritors;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants.Sources;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants.Sources.Inheritors;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources;

internal static class DomesticApprovalGroupParticipantSourceInternalConverter
{
    public static DomesticApprovalGroupParticipantSourceInternal FromDomain(DomesticApprovalGroupParticipantSource source)
    {
        DomesticApprovalGroupParticipantSourceInternal result = source switch
        {
            UserDomesticApprovalGroupParticipantSource asUser => UserDomesticApprovalGroupParticipantSourceInternalConverter.FromDomain(asUser),
            AttributeDomesticApprovalGroupParticipantSource asAttribute => AttributeDomesticApprovalGroupParticipantSourceInternalConverter.FromDomain(asAttribute),
            _ => throw new ArgumentTypeOutOfRangeException(source)
        };

        return result;
    }

    public static DomesticApprovalGroupParticipantSource ToDomain(DomesticApprovalGroupParticipantSourceInternal source)
    {
        DomesticApprovalGroupParticipantSource result = source switch
        {
            UserDomesticApprovalGroupParticipantSourceInternal asUser => UserDomesticApprovalGroupParticipantSourceInternalConverter.ToDomain(asUser),
            AttributeDomesticApprovalGroupParticipantSourceInternal asAttribute => AttributeDomesticApprovalGroupParticipantSourceInternalConverter.ToDomain(asAttribute),
            _ => throw new ArgumentTypeOutOfRangeException(source)
        };

        return result;
    }
}
