using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details.Inheritors.Domestic;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details;

internal static class ApprovalGroupDetailsInternalConverter
{
    internal static ApprovalGroupDetailsInternal FromDomain(ApprovalGroupDetails details)
    {
        ApprovalGroupDetailsInternal result = details switch
        {
            DomesticApprovalGroupDetails d => DomesticApprovalGroupDetailsInternalConverter.FromDomain(d),
            _ => throw new ArgumentTypeOutOfRangeException(details)
        };

        return result;
    }

    internal static ApprovalGroupDetails ToDomain(ApprovalGroupDetailsInternal details)
    {
        ApprovalGroupDetails result = details switch
        {
            DomesticApprovalGroupDetailsInternal d => DomesticApprovalGroupDetailsInternalConverter.ToDomain(d),
            _ => throw new ArgumentTypeOutOfRangeException(details)
        };

        return result;
    }
}
