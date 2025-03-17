using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Commands.Create.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Commands.Create.Contracts.Kinds;
using Edm.Entities.Approval.Rules.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Commands.Create.Kinds;
using Edm.Entities.Approval.Rules.Presentation.Converters.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Commands.Create;

internal static class CreateApprovalGroupsCommandInternalConverter
{
    internal static CreateApprovalGroupsCommandInternal FromDto(CreateApprovalGroupsCommand command)
    {
        ApprovalRuleKeyInternal approvalRuleKey = ApprovalRuleKeyInternalConverter.FromDto(command.ApprovalRuleKey);

        ApprovalGroupKindInternal kind = ApprovalGroupKindInternalConverter.FromDto(command.Kind);

        Id<UserInternal> currentUserId = IdConverterFrom<UserInternal>.FromString(command.CurrentUserId);

        var result = new CreateApprovalGroupsCommandInternal(approvalRuleKey, kind, command.DisplayName, currentUserId);

        return result;
    }
}
