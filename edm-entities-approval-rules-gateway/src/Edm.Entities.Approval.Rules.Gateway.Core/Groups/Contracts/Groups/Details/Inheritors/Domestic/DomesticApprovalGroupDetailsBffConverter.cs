using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details.Inheritors.Domestic.Options;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details.Inheritors.Domestic.Participants;
using Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Contexts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details.Inheritors.Domestic;

internal static class DomesticApprovalGroupDetailsBffConverter
{
    internal static DomesticApprovalGroupDetailsBff FromDto(DomesticApprovalGroupDetailsDto details, ApprovalEnrichersContext context)
    {
        var options =
            DomesticApprovalGroupOptionsBffConverter.FromDto(details.Options);

        DomesticApprovalGroupParticipantBff[] participants =
            details.Participants.Select(p => DomesticApprovalGroupParticipantBffConverter.FromDto(p, context)).ToArray();

        var result = new DomesticApprovalGroupDetailsBff
        {
            Options = options,
            Participants = participants
        };

        return result;
    }

    internal static ApprovalGroupDetailsDto ToDto(DomesticApprovalGroupDetailsBff details)
    {
        var options =
            DomesticApprovalGroupOptionsBffConverter.ToDto(details.Options);

        DomesticApprovalGroupParticipantDto[] participants =
            details.Participants.Select(DomesticApprovalGroupParticipantBffConverter.ToDto).ToArray();

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
}
