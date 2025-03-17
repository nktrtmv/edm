using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources.Inheritors;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources.Attributes;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources.Users;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources;

internal static class DomesticApprovalGroupParticipantSourceDtoConverter
{
    public static DomesticApprovalGroupParticipantSourceDto FromInternal(DomesticApprovalGroupParticipantSourceInternal source)
    {
        DomesticApprovalGroupParticipantSourceDto result = source switch
        {
            UserDomesticApprovalGroupParticipantSourceInternal asUser =>
                UserDomesticApprovalGroupParticipantSourceDtoConverter.FromInternal(asUser),

            AttributeDomesticApprovalGroupParticipantSourceInternal asAttribute =>
                AttributeDomesticApprovalGroupParticipantSourceDtoConverter.FromInternal(asAttribute),

            _ => throw new ArgumentTypeOutOfRangeException(source)
        };

        return result;
    }

    public static DomesticApprovalGroupParticipantSourceInternal ToInternal(DomesticApprovalGroupParticipantSourceDto source)
    {
        DomesticApprovalGroupParticipantSourceInternal result = source.ValueCase switch
        {
            DomesticApprovalGroupParticipantSourceDto.ValueOneofCase.AsUser =>
                UserDomesticApprovalGroupParticipantSourceDtoConverter.ToInternal(source.AsUser),

            DomesticApprovalGroupParticipantSourceDto.ValueOneofCase.AsAttribute =>
                AttributeDomesticApprovalGroupParticipantSourceDtoConverter.ToInternal(source.AsAttribute),

            _ => throw new ArgumentTypeOutOfRangeException(source)
        };

        return result;
    }
}
