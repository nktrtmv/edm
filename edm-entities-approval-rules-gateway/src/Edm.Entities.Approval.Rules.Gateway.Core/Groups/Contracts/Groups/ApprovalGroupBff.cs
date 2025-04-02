using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Data;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups;

public sealed class ApprovalGroupBff
{
    public required ApprovalGroupDataBff Data { get; init; }
    public required ApprovalGroupDetailsBff Details { get; init; }
}
