using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources.Inheritors;
using Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Contexts;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants.Sources;

internal static class DomesticApprovalGroupParticipantSourceBffConverter
{
    public static DomesticApprovalGroupParticipantSourceBff FromDto(DomesticApprovalGroupParticipantSourceDto source, ApprovalEnrichersContext context)
    {
        DomesticApprovalGroupParticipantSourceBff result = source.ValueCase switch
        {
            DomesticApprovalGroupParticipantSourceDto.ValueOneofCase.AsUser =>
                UserDomesticApprovalGroupParticipantSourceBffConverter.FromDto(source.AsUser, context),

            DomesticApprovalGroupParticipantSourceDto.ValueOneofCase.AsAttribute =>
                AttributeDomesticApprovalGroupParticipantSourceBffConverter.FromDto(source.AsAttribute, context),

            _ => throw new ArgumentTypeOutOfRangeException(source.ValueCase)
        };

        return result;
    }

    public static DomesticApprovalGroupParticipantSourceDto ToDto(DomesticApprovalGroupParticipantSourceBff source)
    {
        var result = source switch
        {
            UserDomesticApprovalGroupParticipantSourceBff asUser => UserDomesticApprovalGroupParticipantSourceBffConverter.ToDto(asUser),
            AttributeDomesticApprovalGroupParticipantSourceBff asAttribute => AttributeDomesticApprovalGroupParticipantSourceBffConverter.ToDto(asAttribute),
            _ => throw new ArgumentTypeOutOfRangeException(source)
        };

        return result;
    }
}
