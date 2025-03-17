using System.Transactions;

using Edm.Entities.Approval.Rules.Domain.Entities.Domains.ValueObjects;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Keys;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Keys;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tokens.Concurrency;

namespace Edm.Entities.Approval.Rules.Infrastructure.Abstractions.Repositories.Rules;

public interface IApprovalRulesRepository
{
    Task<ConcurrencyToken<ApprovalRule>> Upsert(ApprovalRule rule, CancellationToken cancellationToken);
    Task<ApprovalRule[]> GetAll(DomainId domainId, bool isActiveRequired, CancellationToken cancellationToken);
    Task<ApprovalRule[]> GetAllLatest(DomainId domainId, string? query, CancellationToken cancellationToken);
    Task<ApprovalRuleKey[]> GetAllVersions(EntityTypeKey entityTypeKey, bool isDeletedIncluded, CancellationToken cancellationToken);
    Task<ApprovalRule[]> GetActualVersions(EntityTypeKey entityTypeKey, CancellationToken cancellationToken);
    Task<ApprovalRule> GetRequired(ApprovalRuleKey approvalRuleKey, CancellationToken cancellationToken);
    Task<ApprovalRule> GetRequired(EntityTypeKey entityTypeKey, CancellationToken cancellationToken);
    Task<ApprovalRule> GetRequiredActive(EntityTypeKey entityTypeKey, CancellationToken cancellationToken);
    Task Delete(EntityTypeKey entityTypeKey, Audit<ApprovalRule> audit, CancellationToken cancellationToken);
}
