using Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Update.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Commands.Update.Rules;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Commands.Update;

internal static class UpdateApprovalRulesCommandResponseInternalConverter
{
    internal static UpdateApprovalRulesCommandResponse ToDto(UpdateApprovalRulesCommandResponseInternal response)
    {
        UpdateApprovalRulesCommandResponseFailedDuringUpdateApprovalRule[] failedDuringUpdateApprovalRules =
            response.FailedDuringUpdateApprovalRules.Select(UpdateApprovalRulesCommandResponseFailedDuringUpdateApprovalRuleInternalConverter.ToDto).ToArray();

        var result = new UpdateApprovalRulesCommandResponse
        {
            FailedDuringUpdateApprovalRules = { failedDuringUpdateApprovalRules }
        };

        return result;
    }
}
