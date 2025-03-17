using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic.Options;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.Factories;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Options;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic;

internal static class DomesticApprovalGroupDetailsInternalConverter
{
    internal static DomesticApprovalGroupDetailsInternal FromDomain(DomesticApprovalGroupDetails details)
    {
        DomesticApprovalGroupOptionsInternal options =
            DomesticApprovalGroupOptionsInternalConverter.FromDomain(details.Options);

        DomesticApprovalGroupParticipantInternal[] participants =
            details.Participants.Select(DomesticApprovalGroupParticipantInternalConverter.FromDomain).ToArray();

        var result = new DomesticApprovalGroupDetailsInternal(options, participants);

        return result;
    }

    internal static DomesticApprovalGroupDetails ToDomain(DomesticApprovalGroupDetailsInternal details)
    {
        DomesticApprovalGroupOptions options =
            DomesticApprovalGroupOptionsInternalConverter.ToDomain(details.Options);

        DomesticApprovalGroupParticipant[] participants =
            details.Participants.Select(DomesticApprovalGroupParticipantInternalConverter.ToDomain).ToArray();

        DomesticApprovalGroupDetails result = DomesticApprovalGroupDetailsFactory.CreateFrom(options, participants);

        return result;
    }
}
