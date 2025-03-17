using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Groups.Details.Inheritors.Domestic;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Groups.Details;

internal static class ApprovalGroupDetailsDbConverter
{
    internal static ApprovalGroupDetailsDb FromDomain(ApprovalGroupDetails details)
    {
        ApprovalGroupDetailsDb result = details switch
        {
            DomesticApprovalGroupDetails d =>
                DomesticApprovalGroupDetailsDbConverter.FromDomain(d),

            _ => throw new ArgumentTypeOutOfRangeException(details)
        };

        return result;
    }

    internal static ApprovalGroupDetails ToDomain(ApprovalGroupDetailsDb details)
    {
        ApprovalGroupDetails result = details.DetailsCase switch
        {
            ApprovalGroupDetailsDb.DetailsOneofCase.AsDomestic =>
                DomesticApprovalGroupDetailsDbConverter.ToDomain(details.AsDomestic),

            _ => throw new ArgumentTypeOutOfRangeException(details)
        };

        return result;
    }
}
