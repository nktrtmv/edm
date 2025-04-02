using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic.Options;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Contracts.Groups.Details.Inheritors.Domestic.Options;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Contracts.Groups.Details.Inheritors.Domestic.Participants;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Contracts.Groups.Details.Inheritors.Domestic;

internal static class DomesticApprovalGroupDetailsInternalConverter
{
    internal static ApprovalGroupDetailsDto ToDto(DomesticApprovalGroupDetailsInternal details)
    {
        DomesticApprovalGroupOptionsDto options =
            DomesticApprovalGroupOptionsInternalConverter.ToDto(details.Options);

        DomesticApprovalGroupParticipantDto[] participants =
            details.Participants.Select(DomesticApprovalGroupParticipantInternalConverter.ToDto).ToArray();

        var asDomestic = new DomesticApprovalGroupDetailsDto
        {
            Options = options,
            Participants = { participants }
        };

        var result = new ApprovalGroupDetailsDto
        {
            AsDomestic = asDomestic
        };

        return result;
    }

    internal static DomesticApprovalGroupDetailsInternal FromDto(DomesticApprovalGroupDetailsDto details)
    {
        DomesticApprovalGroupOptionsInternal options =
            DomesticApprovalGroupOptionsInternalConverter.FromDto(details.Options);

        DomesticApprovalGroupParticipantInternal[] participants =
            details.Participants.Select(DomesticApprovalGroupParticipantInternalConverter.FromDto).ToArray();

        var result = new DomesticApprovalGroupDetailsInternal(options, participants);

        return result;
    }
}
