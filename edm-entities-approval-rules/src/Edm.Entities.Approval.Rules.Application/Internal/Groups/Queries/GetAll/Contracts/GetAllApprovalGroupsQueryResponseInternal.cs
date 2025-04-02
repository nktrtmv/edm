using Edm.Entities.Approval.Rules.Application.Internal.Groups.Queries.GetAll.Contracts.Groups;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Queries.GetAll.Contracts;

public sealed class GetAllApprovalGroupsQueryResponseInternal
{
    internal GetAllApprovalGroupsQueryResponseInternal(GetAllApprovalGroupsQueryResponseGroupInternal[] groups)
    {
        Groups = groups;
    }

    public GetAllApprovalGroupsQueryResponseGroupInternal[] Groups { get; }
}
