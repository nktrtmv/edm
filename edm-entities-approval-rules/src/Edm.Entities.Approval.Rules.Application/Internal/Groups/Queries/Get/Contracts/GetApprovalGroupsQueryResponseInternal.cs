using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tokens.Concurrency;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Queries.Get.Contracts;

public sealed class GetApprovalGroupsQueryResponseInternal
{
    internal GetApprovalGroupsQueryResponseInternal(
        ApprovalGroupInternal group,
        EntityTypeAttributeInternal[] attributes,
        ConcurrencyToken<GetApprovalGroupsQueryResponseInternal> concurrencyToken)
    {
        Group = group;
        Attributes = attributes;
        ConcurrencyToken = concurrencyToken;
    }

    public ApprovalGroupInternal Group { get; }
    public EntityTypeAttributeInternal[] Attributes { get; }
    public ConcurrencyToken<GetApprovalGroupsQueryResponseInternal> ConcurrencyToken { get; }
}
