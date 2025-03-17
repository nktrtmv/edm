using Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.CreateNewVersion.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Converters.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Commands.CreateNewVersion;

internal static class CreateNewVersionApprovalRulesCommandResponseInternalConverter
{
    internal static CreateNewVersionApprovalRulesCommandResponse ToDto(CreateNewVersionApprovalRulesCommandResponseInternal response)
    {
        ApprovalRuleKeyDto key = ApprovalRuleKeyInternalConverter.ToDto(response.Key);

        var result = new CreateNewVersionApprovalRulesCommandResponse
        {
            Key = key
        };

        return result;
    }
}
