using Dapper;

using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.Entities;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects;
using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Configuration.Configuration.Fetchers;
using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Repositories.Workflows;
using Edm.Entities.Approval.Workflows.Infrastructure.Options;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts;

using Microsoft.Extensions.Configuration;

using Npgsql;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows;

internal sealed class ApprovalWorkflowsRepository : IApprovalWorkflowsRepository
{
    public ApprovalWorkflowsRepository(IConfiguration configuration)
    {
        Options = ConfigurationValueFetcher.GetRequired<DbOptions>(configuration);
    }

    private DbOptions Options { get; }

    public async Task<Id<ApprovalWorkflow>[]> GetIds(Id<ApprovalWorkflowEntity> id, CancellationToken cancellationToken)
    {
        await using var connection = await GetAndOpenConnection();

        var query = ApprovalWorkflowsRepositoryQueries.GetIds(id.Value, cancellationToken);
        IEnumerable<string> workflowsIds = await connection.QueryAsync<string>(query);

        Id<ApprovalWorkflow>[] result = workflowsIds.Select(IdConverterFrom<ApprovalWorkflow>.FromString).ToArray();

        return result;
    }

    public async Task<ApprovalWorkflow?> Get(Id<ApprovalWorkflow> id, CancellationToken cancellationToken)
    {
        await using var connection = await GetAndOpenConnection();

        var query = ApprovalWorkflowsRepositoryQueries.GetBatch([id.Value], cancellationToken);
        var workflow = await connection.QuerySingleOrDefaultAsync<ApprovalWorkflowDb>(query);

        if (workflow is null)
        {
            return null;
        }

        var result = NullableConverter.Convert(workflow, ApprovalWorkflowDbConverter.ToDomain);

        return result;
    }

    public async Task<ApprovalWorkflow[]> GetBatch(Id<ApprovalWorkflow>[] ids, CancellationToken cancellationToken)
    {
        await using var connection = await GetAndOpenConnection();

        var query = ApprovalWorkflowsRepositoryQueries.GetBatch(ids.Select(x => x.Value).ToArray(), cancellationToken);
        IEnumerable<ApprovalWorkflowDb> workflows = await connection.QueryAsync<ApprovalWorkflowDb>(query);

        ApprovalWorkflow[] result = workflows.Select(ApprovalWorkflowDbConverter.ToDomain).ToArray();

        return result;
    }

    public async Task<ApprovalWorkflow> GetRequired(Id<ApprovalWorkflow> id, CancellationToken cancellationToken)
    {
        var result = await Get(id, cancellationToken);

        if (result is null)
        {
            throw new ApplicationException($"Approval workflow is not found (id: {id})");
        }

        return result;
    }

    public async Task Delete(DomainId domainId, HashSet<EntityId> ids, CancellationToken cancellationToken)
    {
        await using var connection = await GetAndOpenConnection();

        var query = ApprovalWorkflowsRepositoryQueries.Delete(domainId, ids, cancellationToken);
        await connection.ExecuteAsync(query);
    }

    public async Task Upsert(ApprovalWorkflow workflow, CancellationToken cancellationToken)
    {
        await using var connection = await GetAndOpenConnection();

        var workflowDb = ApprovalWorkflowDbConverter.FromDomain(workflow);
        var query = ApprovalWorkflowsRepositoryQueries.Upsert(workflowDb, cancellationToken);
        await connection.QuerySingleAsync<string>(query);

        await Task.CompletedTask;
    }

    public async Task<Id<ApprovalWorkflow>[]> GetAllActiveIds(UtcDateTime<ApprovalWorkflowState> actualizeDate, CancellationToken cancellationToken)
    {
        await using var connection = await GetAndOpenConnection();

        var query = ApprovalWorkflowsRepositoryQueries.GetAllActive(actualizeDate.Value, cancellationToken);
        IEnumerable<string> workflowsIds = await connection.QueryAsync<string>(query);

        Id<ApprovalWorkflow>[] result = workflowsIds.Select(IdConverterFrom<ApprovalWorkflow>.FromString).ToArray();

        return result;
    }

    private async Task<NpgsqlConnection> GetAndOpenConnection()
    {
        var connection = new NpgsqlConnection(Options.ConnectionString);

        await connection.OpenAsync();

        await connection.ReloadTypesAsync();

        return connection;
    }
}
