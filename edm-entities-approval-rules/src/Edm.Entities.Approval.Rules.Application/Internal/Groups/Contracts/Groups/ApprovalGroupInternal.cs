using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Data;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups;

public sealed class ApprovalGroupInternal
{
    public ApprovalGroupInternal(ApprovalGroupDataInternal data, ApprovalGroupDetailsInternal details)
    {
        Data = data;
        Details = details;
    }

    public ApprovalGroupDataInternal Data { get; }
    public ApprovalGroupDetailsInternal Details { get; }
}
