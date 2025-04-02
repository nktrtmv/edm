using Edm.Entities.Approval.Rules.Domain.Entities.Groups.Services.Validators.GroupIsValid.Details.Domestic;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Groups.Services.Validators.GroupIsValid;

internal static class GroupIsValidApprovalGroupValidator
{
    internal static void Validate(ApprovalGroup group, ApprovalRule approvalRule)
    {
        None _ = group.Details switch
        {
            DomesticApprovalGroupDetails d => DetailsAreValidDomesticApprovalGroupDetailsValidator.Validate(d, approvalRule),
            _ => throw new ArgumentTypeOutOfRangeException(group)
        };
    }
}
