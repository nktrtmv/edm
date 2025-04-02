using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.Factories;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Options;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Participants;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Groups.Details.Inheritors.Domestic.Options;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Groups.Details.Inheritors.Domestic.Participants;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Groups.Details.Inheritors.Domestic;

internal static class DomesticApprovalGroupDetailsDbConverter
{
    internal static ApprovalGroupDetailsDb FromDomain(DomesticApprovalGroupDetails details)
    {
        DomesticApprovalGroupOptionsDb options =
            DomesticApprovalGroupOptionsDbConverter.FromDomain(details.Options);

        DomesticApprovalGroupParticipantDb[] participants =
            details.Participants.Select(DomesticApprovalGroupParticipantDbConverter.FromDomain).ToArray();

        var asDomestic = new DomesticApprovalGroupDetailsDb
        {
            Options = options,
            Participants = { participants }
        };

        var result = new ApprovalGroupDetailsDb
        {
            AsDomestic = asDomestic
        };

        return result;
    }

    internal static DomesticApprovalGroupDetails ToDomain(DomesticApprovalGroupDetailsDb details)
    {
        DomesticApprovalGroupOptions options =
            DomesticApprovalGroupOptionsDbConverter.ToDomain(details.Options);

        DomesticApprovalGroupParticipant[] participants =
            details.Participants.Select(DomesticApprovalGroupParticipantDbConverter.ToDomain).ToArray();

        DomesticApprovalGroupDetails result =
            DomesticApprovalGroupDetailsFactory.CreateFromDb(options, participants);

        return result;
    }
}
