using Edm.Entities.Approval.Rules.Domain.Entities.Groups.Services.Validators.GroupIsValid.Details.Domestic.CorrectParticipantSources;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.Services.Validators.GroupIsValid.Details.Domestic.SingleParticipant;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Groups.Services.Validators.GroupIsValid.Details.Domestic;

internal static class DetailsAreValidDomesticApprovalGroupDetailsValidator
{
    internal static None Validate(DomesticApprovalGroupDetails details, ApprovalRule approvalRule)
    {
        if (details.Options.MultipleParticipantsAreAllowed)
        {
            return default;
        }

        DuplicationConditionsSingleParticipantDomesticApprovalGroupDetailsValidator.Validate(details);

        NoConditionsSingleParticipantDomesticApprovalGroupDetailsValidator.Validate(details);

        CorrectParticipantSourcesDomesticApprovalGroupDetailsValidator.Validate(details, approvalRule);

        return default;
    }
}
