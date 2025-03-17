using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.CreateNewVersion.Contracts;
using Edm.Entities.Approval.Rules.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Converters.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Commands.CreateNewVersion;

internal static class CreateNewVersionApprovalRulesCommandInternalConverter
{
    internal static CreateNewVersionApprovalRulesCommandInternal FromDto(CreateNewVersionApprovalRulesCommand command)
    {
        ApprovalRuleKeyInternal key = ApprovalRuleKeyInternalConverter.FromDto(command.OriginalApprovalRuleKey);

        Id<UserInternal> currentUserId = IdConverterFrom<UserInternal>.FromString(command.CurrentUserId);

        var result = new CreateNewVersionApprovalRulesCommandInternal(key, currentUserId);

        return result;
    }
}
