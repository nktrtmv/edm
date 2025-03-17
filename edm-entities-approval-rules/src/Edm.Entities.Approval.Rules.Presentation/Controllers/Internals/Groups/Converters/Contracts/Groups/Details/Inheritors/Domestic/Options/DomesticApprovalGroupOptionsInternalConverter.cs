using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic.Options;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Contracts.Groups.Details.Inheritors.Domestic.Options;

internal static class DomesticApprovalGroupOptionsInternalConverter
{
    internal static DomesticApprovalGroupOptionsInternal FromDto(DomesticApprovalGroupOptionsDto options)
    {
        var result = new DomesticApprovalGroupOptionsInternal(
            options.MultipleParticipantsAreAllowed,
            options.EmptyGroupIsAllowed);

        return result;
    }

    internal static DomesticApprovalGroupOptionsDto ToDto(DomesticApprovalGroupOptionsInternal options)
    {
        var result = new DomesticApprovalGroupOptionsDto
        {
            MultipleParticipantsAreAllowed = options.MultipleParticipantsAreAllowed,
            EmptyGroupIsAllowed = options.EmptyGroupIsAllowed
        };

        return result;
    }
}
