using Dapper;

using Edm.Entities.Approval.Rules.Domain.Entities.Domains.ValueObjects;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Keys;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Keys;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Configuration.Fetchers;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tokens.Concurrency;
using Edm.Entities.Approval.Rules.Infrastructure.Abstractions.Repositories.Rules;
using Edm.Entities.Approval.Rules.Infrastructure.Options;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Audits;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Keys;

using Microsoft.Extensions.Configuration;

using Npgsql;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules;

internal sealed class ApprovalRulesRepository(IConfiguration configuration) : IApprovalRulesRepository
{
    private DbOptions Options { get; } = ConfigurationValueFetcher.GetRequired<DbOptions>(configuration);

    public async Task<ConcurrencyToken<ApprovalRule>> Upsert(ApprovalRule rule, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        ApprovalRuleDb ruleDb = ApprovalRuleDbConverter.FromDomain(rule);

        var concurrencyToken = await connection.QuerySingleOrDefaultAsync<DateTime>(ApprovalRulesRepositoryQueries.Upsert(ruleDb, cancellationToken));

        ConcurrencyToken<ApprovalRule> result = ConcurrencyTokenConverterFrom<ApprovalRule>.FromUnspecifiedUtcDateTime(concurrencyToken);

        return result;
    }

    public async Task<ApprovalRule[]> GetAll(DomainId domainId, bool isActiveRequired, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        IEnumerable<ApprovalRuleDb> rules =
            await connection.QueryAsync<ApprovalRuleDb>(ApprovalRulesRepositoryQueries.GetAll(domainId.Value, isActiveRequired, cancellationToken));

        ApprovalRule[] result = rules.Select(ApprovalRuleDbConverter.ToDomain).ToArray();

        return result;
    }

    public async Task<ApprovalRule[]> GetAllLatest(DomainId domainId, string? search, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        CommandDefinition query = ApprovalRulesRepositoryQueries.GetAllLatest(domainId.Value, search, cancellationToken);

        IEnumerable<ApprovalRuleDb> rules = await connection.QueryAsync<ApprovalRuleDb>(query);

        ApprovalRule[] result = rules.Select(ApprovalRuleDbConverter.ToDomain).ToArray();

        return result;
    }

    public async Task<ApprovalRuleKey[]> GetAllVersions(EntityTypeKey entityTypeKey, bool isDeletedIncluded, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        EntityTypeKeyDb key = EntityTypeKeyDbConverter.FromDomain(entityTypeKey);

        IEnumerable<ApprovalRuleKeyDb> keys =
            await connection.QueryAsync<ApprovalRuleKeyDb>(ApprovalRulesRepositoryQueries.GetAllVersions(key, isDeletedIncluded, cancellationToken));

        ApprovalRuleKey[] result = keys.Select(ApprovalRuleKeyDbConverter.ToDomain).ToArray();

        return result;
    }

    public async Task<ApprovalRule[]> GetActualVersions(EntityTypeKey entityTypeKey, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        EntityTypeKeyDb key = EntityTypeKeyDbConverter.FromDomain(entityTypeKey);

        IEnumerable<ApprovalRuleDb> rules = await connection.QueryAsync<ApprovalRuleDb>(ApprovalRulesRepositoryQueries.GetActualVersions(key, cancellationToken));

        ApprovalRule[] result = rules.Select(ApprovalRuleDbConverter.ToDomain).ToArray();

        return result;
    }

    public async Task<ApprovalRule> GetRequired(EntityTypeKey entityTypeKey, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        EntityTypeKeyDb key = EntityTypeKeyDbConverter.FromDomain(entityTypeKey);

        var rule = await connection.QuerySingleOrDefaultAsync<ApprovalRuleDb>(ApprovalRulesRepositoryQueries.GetLastVersion(key, cancellationToken));

        if (rule is null)
        {
            throw new ApplicationException($"Approval rule is not found.\nEntityTypeKey: {entityTypeKey}");
        }

        ApprovalRule result = ApprovalRuleDbConverter.ToDomain(rule);

        return result;
    }

    public async Task<ApprovalRule> GetRequired(ApprovalRuleKey approvalRuleKey, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        ApprovalRuleKeyDb key = ApprovalRuleKeyDbConverter.FromDomain(approvalRuleKey);

        var rule = await connection.QuerySingleOrDefaultAsync<ApprovalRuleDb>(ApprovalRulesRepositoryQueries.Get(key, cancellationToken));

        if (rule is null)
        {
            throw new ApplicationException($"Approval rule is not found.\nApprovalRuleKey: {approvalRuleKey}");
        }

        ApprovalRule result = ApprovalRuleDbConverter.ToDomain(rule);

        return result;
    }

    public async Task<ApprovalRule> GetRequiredActive(EntityTypeKey entityTypeKey, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        EntityTypeKeyDb key = EntityTypeKeyDbConverter.FromDomain(entityTypeKey);

        var rule = await connection.QuerySingleOrDefaultAsync<ApprovalRuleDb>(ApprovalRulesRepositoryQueries.GetActive(key, cancellationToken));

        if (rule is null)
        {
            throw new ApplicationException($"Active approval rule is not found.\nEntityTypeKey: {entityTypeKey}");
        }

        ApprovalRule result = ApprovalRuleDbConverter.ToDomain(rule);

        return result;
    }

    public async Task Delete(EntityTypeKey entityTypeKey, Audit<ApprovalRule> audit, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        ApprovalRuleAuditDb auditDb = ApprovalRuleAuditDbConverter.FromDomain(audit);

        EntityTypeKeyDb key = EntityTypeKeyDbConverter.FromDomain(entityTypeKey);

        await connection.ExecuteAsync(ApprovalRulesRepositoryQueries.Delete(key, auditDb, cancellationToken));
    }

    private async Task<NpgsqlConnection> GetAndOpenConnection()
    {
        var connection = new NpgsqlConnection(Options.ConnectionString);

        await connection.OpenAsync();

        await connection.ReloadTypesAsync();

        return connection;
    }
}
