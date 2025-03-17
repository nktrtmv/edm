using Edm.Entities.Approval.Rules.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Update.Contracts.Actions.Inheritors;

public sealed class UpdateApprovalRulesCommandReplacePersonActionInternal : UpdateApprovalRulesCommandActionInternal
{
    public UpdateApprovalRulesCommandReplacePersonActionInternal(Id<UserInternal> personFromId, Id<UserInternal> personToId)
    {
        PersonFromId = personFromId;
        PersonToId = personToId;
    }

    internal Id<UserInternal> PersonFromId { get; }
    internal Id<UserInternal> PersonToId { get; }
}
