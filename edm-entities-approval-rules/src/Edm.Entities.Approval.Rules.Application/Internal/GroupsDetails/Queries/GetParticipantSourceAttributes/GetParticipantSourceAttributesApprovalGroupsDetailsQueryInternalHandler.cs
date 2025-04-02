using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes;
using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.GroupsDetails.Queries.GetParticipantSourceAttributes.Contracts;
using Edm.Entities.Approval.Rules.Domain.Constants;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Keys;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Reference;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.Infrastructure.Abstractions.Repositories.Rules;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.GroupsDetails.Queries.GetParticipantSourceAttributes;

[UsedImplicitly]
internal sealed class GetParticipantSourceAttributesApprovalGroupsDetailsQueryInternalHandler(IApprovalRulesRepository rules)
    : IRequestHandler<GetParticipantSourceAttributesApprovalGroupsDetailsQueryInternal,
        GetParticipantSourceAttributesApprovalGroupsDetailsQueryResponseInternal>
{
    public async Task<GetParticipantSourceAttributesApprovalGroupsDetailsQueryResponseInternal> Handle(
        GetParticipantSourceAttributesApprovalGroupsDetailsQueryInternal request,
        CancellationToken cancellationToken)
    {
        ApprovalRuleKey approvalRuleKey = ApprovalRuleKeyInternalConverter.ToDomain(request.ApprovalRuleKey);

        ApprovalRule rule = await rules.GetRequired(approvalRuleKey, cancellationToken);

        EntityTypeReferenceAttribute[] attributes = rule.EntityType.Attributes
            .OfType<EntityTypeReferenceAttribute>()
            .Where(a => MetadataConverterTo.ToString(a.ReferenceTypeId) == ReferenceTypeConstants.Employees)
            .ToArray();

        EntityTypeAttributeInternal[] attributesInternal = attributes.Select(EntityTypeAttributeInternalFromDomainConverter.FromDomain).ToArray();

        var result = new GetParticipantSourceAttributesApprovalGroupsDetailsQueryResponseInternal(attributesInternal);

        return result;
    }
}
