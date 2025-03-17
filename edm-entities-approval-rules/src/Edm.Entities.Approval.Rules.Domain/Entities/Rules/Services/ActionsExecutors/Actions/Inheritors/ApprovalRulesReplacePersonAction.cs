using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.ActionsExecutors.Actions.Inheritors;

public sealed class ApprovalRulesReplacePersonAction : ApprovalRulesUpdateAction
{
    public ApprovalRulesReplacePersonAction(Id<User> personFromId, Id<User> personToId)
    {
        PersonFromId = personFromId;
        PersonToId = personToId;
    }

    public Id<User> PersonFromId { get; }
    public Id<User> PersonToId { get; }
}
