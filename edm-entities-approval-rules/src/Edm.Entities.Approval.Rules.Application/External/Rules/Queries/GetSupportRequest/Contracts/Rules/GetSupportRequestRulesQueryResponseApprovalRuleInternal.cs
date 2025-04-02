using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes;
using Edm.Entities.Approval.Rules.Application.External.Rules.Commands.UpsertEntityType.Contracts.EntitiesTypes;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tokens.Concurrency;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Queries.GetSupportRequest.Contracts.Rules;

public sealed record GetSupportRequestRulesQueryResponseApprovalRuleInternal(
    Id<EntityTypeInternal> EntityTypeId,
    string DisplayName,
    string CreatedBy,
    string UpdatedBy,
    DateTime EntityTypeUpdatedDate,
    DateTime EntityTypeCreatedDatetime,
    EntityTypeAttributeInternal[] Attributes,
    bool IsActive,
    ConcurrencyToken<ApprovalRule> ConcurrencyToken);
