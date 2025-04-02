using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Queries.GetAll.Contracts.Groups;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Queries.GetAll.Contracts;

public sealed class GetAllApprovalGroupsQueryResponseBff
{
    public required GetAllApprovalGroupsQueryResponseGroupBff[] Groups { get; init; }
}
