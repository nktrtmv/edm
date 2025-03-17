using Dapper;

using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Configuration;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Tokens.Concurrency;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Repositories.SigningWorkflows;
using Edm.Entities.Signing.Workflows.Infrastructure.Options;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts;

using Microsoft.Extensions.Configuration;

using Npgsql;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows;

internal sealed class SigningWorkflowsRepository : ISigningWorkflowsRepository
{
    public SigningWorkflowsRepository(IConfiguration configuration)
    {
        Options = ConfigurationValueFetcher.GetRequired<DbOptions>(configuration);
    }

    private DbOptions Options { get; }

    async Task<ConcurrencyToken<SigningWorkflow>> ISigningWorkflowsRepository.Upsert(SigningWorkflow workflow, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        SigningWorkflowDb workflowDb = SigningWorkflowDbFromDomainConverter.FromDomain(workflow);

        var resultConcurrencyTokenDb = await connection.QuerySingleAsync<DateTime>(SigningWorkflowsRepositoryQueries.Upsert(workflowDb, cancellationToken));

        ConcurrencyToken<SigningWorkflow> result = ConcurrencyTokenConverterFrom<SigningWorkflow>.FromUnspecifiedUtcDateTime(resultConcurrencyTokenDb);

        return result;
    }

    public async Task<SigningWorkflow?> Get(Id<SigningWorkflow> id, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        var workflowId = IdConverterTo.ToString(id);

        var workflow = await connection.QuerySingleOrDefaultAsync<SigningWorkflowDb>(SigningWorkflowsRepositoryQueries.Get(workflowId, cancellationToken));

        SigningWorkflow? result = NullableConverter.Convert(workflow, SigningWorkflowDbToDomainConverter.ToDomain);

        return result;
    }

    public async Task<SigningWorkflow> GetRequired(Id<SigningWorkflow> workflowId, CancellationToken cancellationToken)
    {
        SigningWorkflow? workflow = await Get(workflowId, cancellationToken);

        if (workflow is null)
        {
            throw new ApplicationException($"Workflow was not found (Id: {workflowId}).");
        }

        return workflow;
    }

    private async Task<NpgsqlConnection> GetAndOpenConnection()
    {
        var connection = new NpgsqlConnection(Options.ConnectionString);

        await connection.OpenAsync();

        await connection.ReloadTypesAsync();

        return connection;
    }
}
