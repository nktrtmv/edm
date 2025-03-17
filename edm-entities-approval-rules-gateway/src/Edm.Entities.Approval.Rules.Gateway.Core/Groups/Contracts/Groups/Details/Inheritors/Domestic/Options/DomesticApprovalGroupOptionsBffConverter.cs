using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details.Inheritors.Domestic.Options;

internal static class DomesticApprovalGroupOptionsBffConverter
{
    internal static DomesticApprovalGroupOptionsBff FromDto(DomesticApprovalGroupOptionsDto options)
    {
        var result = new DomesticApprovalGroupOptionsBff
        {
            MultipleParticipantsAreAllowed = options.MultipleParticipantsAreAllowed,
            EmptyGroupIsAllowed = options.EmptyGroupIsAllowed
        };

        return result;
    }

    internal static DomesticApprovalGroupOptionsDto ToDto(DomesticApprovalGroupOptionsBff options)
    {
        var result = new DomesticApprovalGroupOptionsDto
        {
            MultipleParticipantsAreAllowed = options.MultipleParticipantsAreAllowed,
            EmptyGroupIsAllowed = options.EmptyGroupIsAllowed
        };

        return result;
    }
}
