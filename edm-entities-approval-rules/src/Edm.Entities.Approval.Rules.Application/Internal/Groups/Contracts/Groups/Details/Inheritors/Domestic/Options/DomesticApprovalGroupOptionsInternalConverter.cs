using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Options;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Options.Factories;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic.Options;

internal static class DomesticApprovalGroupOptionsInternalConverter
{
    internal static DomesticApprovalGroupOptionsInternal FromDomain(DomesticApprovalGroupOptions options)
    {
        var result = new DomesticApprovalGroupOptionsInternal(
            options.MultipleParticipantsAreAllowed,
            options.EmptyGroupIsAllowed);

        return result;
    }

    internal static DomesticApprovalGroupOptions ToDomain(DomesticApprovalGroupOptionsInternal options)
    {
        DomesticApprovalGroupOptions result = DomesticApprovalGroupOptionsFactory.CreateFrom(
            options.MultipleParticipantsAreAllowed,
            options.EmptyGroupIsAllowed);

        return result;
    }
}
