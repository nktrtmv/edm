using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups;

public abstract class ApprovalGroupsServiceBase
{
    protected ApprovalGroupsServiceBase(ApprovalGroupsService.ApprovalGroupsServiceClient groups)
    {
        Groups = groups;
    }

    protected ApprovalGroupsService.ApprovalGroupsServiceClient Groups { get; }
}
