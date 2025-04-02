using Edm.Entities.Approval.Rules.Domain.Entities.Graphs;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Factories;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Keys;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tokens.Concurrency;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Audits;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Entities.Types.Attributes;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Graphs;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Groups;

using Google.Protobuf;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules;

internal static class ApprovalRuleDbConverter
{
    internal static ApprovalRuleDb FromDomain(ApprovalRule rule)
    {
        EntityTypeKeyDb entityTypeKey = EntityTypeKeyDbConverter.FromDomain(rule.EntityType.Key);

        EntityTypeAttributeDb[] attributes =
            rule.EntityType.Attributes.Select(EntityTypeAttributeDbFromDomainConverter.FromDomain).ToArray();

        ApprovalGraphDb[] graphs =
            rule.Graphs.Select(ApprovalGraphDbConverter.FromDomain).ToArray();

        ApprovalGroupDb[] groups =
            rule.Groups.Select(ApprovalGroupDbConverter.FromDomain).ToArray();

        ApprovalRuleAuditDb audit = ApprovalRuleAuditDbConverter.FromDomain(rule.Audit);

        var data = new ApprovalRuleDataDb
        {
            Attributes = { attributes },
            Graphs = { graphs },
            Groups = { groups },
            AuditRecords = { audit.Records }
        };

        byte[] byteData = data.ToByteArray();

        var concurrencyToken = ConcurrencyTokenConverterTo.ToDateTime(rule.ConcurrencyToken);

        var result = new ApprovalRuleDb
        {
            DomainId = entityTypeKey.DomainId,
            EntityTypeId = entityTypeKey.EntityTypeId,
            EntityTypeUpdatedDate = entityTypeKey.EntityTypeUpdatedDate,
            Version = rule.Version,
            OriginalVersion = rule.OriginalVersion,
            IsActive = rule.IsActive,
            DisplayName = rule.EntityType.DisplayName,
            Data = byteData,
            CreatedBy = audit.Brief.CreatedBy,
            UpdatedBy = audit.Brief.UpdatedBy,
            CreatedAt = audit.Brief.CreatedAt,
            UpdatedAt = audit.Brief.UpdatedAt,
            ConcurrencyToken = concurrencyToken,
            IsDeleted = rule.IsDeleted
        };

        return result;
    }

    internal static ApprovalRule ToDomain(ApprovalRuleDb rule)
    {
        EntityTypeKey entityTypeKey = EntityTypeKeyDbConverter.ToDomain(rule.DomainId, rule.EntityTypeId, rule.EntityTypeUpdatedDate);

        ApprovalRuleDataDb data = ApprovalRuleDataDb.Parser.ParseFrom(rule.Data);

        EntityTypeAttribute[] attributes =
            data.Attributes.Select(EntityTypeAttributeDbToDomainConverter.ToDomain).ToArray();

        ApprovalGraph[] graphs =
            data.Graphs.Select(ApprovalGraphDbConverter.ToDomain).ToArray();

        ApprovalGroup[] groups =
            data.Groups.Select(ApprovalGroupDbConverter.ToDomain).ToArray();

        var entityType = new EntityType(entityTypeKey, attributes, rule.DisplayName);

        Audit<ApprovalRule> audit = ApprovalRuleAuditDbConverter.ToDomain(rule, data.AuditRecords);

        ConcurrencyToken<ApprovalRule> concurrencyToken =
            ConcurrencyTokenConverterFrom<ApprovalRule>.FromUnspecifiedUtcDateTime(rule.ConcurrencyToken);

        ApprovalRule result = ApprovalRuleFactory.CreateFromDb(
            entityType,
            rule.OriginalVersion,
            rule.Version,
            rule.IsActive,
            graphs,
            groups,
            audit,
            concurrencyToken,
            rule.IsDeleted);

        return result;
    }
}
