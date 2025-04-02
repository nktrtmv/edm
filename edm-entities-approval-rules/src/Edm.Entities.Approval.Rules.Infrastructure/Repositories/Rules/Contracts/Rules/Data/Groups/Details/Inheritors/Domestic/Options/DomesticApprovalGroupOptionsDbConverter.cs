using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Options;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.ValueObjects.Options.Factories;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Groups.Details.Inheritors.Domestic.Options;

internal static class DomesticApprovalGroupOptionsDbConverter
{
    internal static DomesticApprovalGroupOptionsDb FromDomain(DomesticApprovalGroupOptions options)
    {
        var result = new DomesticApprovalGroupOptionsDb
        {
            MultipleParticipantsAreAllowed = options.MultipleParticipantsAreAllowed,
            EmptyGroupIsAllowed = options.EmptyGroupIsAllowed
        };

        return result;
    }

    internal static DomesticApprovalGroupOptions ToDomain(DomesticApprovalGroupOptionsDb options)
    {
        DomesticApprovalGroupOptions result =
            DomesticApprovalGroupOptionsFactory.CreateFromDb(
                options.MultipleParticipantsAreAllowed,
                options.EmptyGroupIsAllowed);

        return result;
    }
}
