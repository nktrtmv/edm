using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tokens.Concurrency;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Queries.Get.Contracts;

internal static class GetApprovalGroupsQueryResponseInternalConverter
{
    internal static GetApprovalGroupsQueryResponseInternal FromDomain(ApprovalGroup group, ApprovalRule rule)
    {
        ApprovalGroupInternal groupInternal =
            ApprovalGroupInternalConverter.FromDomain(group);

        EntityTypeAttributeInternal[] attributes =
            rule.EntityType.Attributes.Select(EntityTypeAttributeInternalFromDomainConverter.FromDomain).ToArray();

        ConcurrencyToken<GetApprovalGroupsQueryResponseInternal> concurrencyToken =
            ConcurrencyTokenConverterFrom<GetApprovalGroupsQueryResponseInternal>.From(rule.ConcurrencyToken);

        var result = new GetApprovalGroupsQueryResponseInternal(groupInternal, attributes, concurrencyToken);

        return result;
    }
}
