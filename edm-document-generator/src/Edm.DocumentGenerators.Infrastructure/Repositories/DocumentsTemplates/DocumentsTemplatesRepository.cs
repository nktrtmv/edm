using Dapper;

using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Configuration.Fetchers;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.DocumentsTemplates;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.DocumentsTemplates.Contracts;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.DocumentsTemplates.Contracts.QueryParams;
using Edm.DocumentGenerators.Infrastructure.Options;
using Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates.Contracts.QueryParams;

using Microsoft.Extensions.Configuration;

using Npgsql;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates;

internal sealed class DocumentsTemplatesRepository : IDocumentsTemplatesRepository
{
    public DocumentsTemplatesRepository(IConfiguration configuration)
    {
        Options = ConfigurationValueFetcher.GetRequired<DbOptions>(configuration);
    }

    private DbOptions Options { get; }

    public async Task Upsert(DocumentTemplate template, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        DocumentTemplateDb? db = DocumentTemplateDbFromDomainConverter.FromDomain(template);

        await connection.QuerySingleAsync<string>(DocumentsTemplatesRepositoryQueries.Upsert(db, cancellationToken));
    }

    public async Task Delete(DocumentTemplate template, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection? connection = await GetAndOpenConnection();

        DocumentTemplateDb? templateDb = DocumentTemplateDbFromDomainConverter.FromDomain(template);

        await connection.QueryAsync(DocumentsTemplatesRepositoryQueries.Delete(templateDb, cancellationToken));
    }

    public async Task<DocumentTemplate?> Get(DomainId domainId, Id<DocumentTemplate> templateId, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection? connection = await GetAndOpenConnection();

        var id = IdConverterTo.ToString(templateId);

        var template = await connection.QuerySingleOrDefaultAsync<DocumentTemplateDb>(DocumentsTemplatesRepositoryQueries.GetById(domainId, id, cancellationToken));

        DocumentTemplate? result = NullableConverter.Convert(template, DocumentTemplateDbToDomainConverter.ToDomain);

        return result;
    }

    public async Task<DocumentTemplate> GetRequired(DomainId domainId, SystemName systemName, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection? connection = await GetAndOpenConnection();

        var result = await connection.QuerySingleOrDefaultAsync<DocumentTemplateDb>(
            DocumentsTemplatesRepositoryQueries.GetBySystemName(domainId, systemName, cancellationToken));

        if (result is null)
        {
            throw new BusinessLogicApplicationException($"Required document template with domainId '{domainId.Value}' and systemName '{systemName.Value}' wasn't found.");
        }

        DocumentTemplate? template = DocumentTemplateDbToDomainConverter.ToDomain(result);

        return template;
    }

    public async Task<DocumentTemplate> GetRequired(DomainId domainId, Id<DocumentTemplate> templateId, CancellationToken cancellationToken)
    {
        DocumentTemplate? result = await Get(domainId, templateId, cancellationToken);

        if (result is null)
        {
            throw new BusinessLogicApplicationException($"Required document template with domainId '{domainId.Value}' and id '{templateId}' wasn't found.");
        }

        return result;
    }

    public async Task<DocumentTemplate[]> Search(DomainId domainId, GetAllDocumentsTemplatesQueryParams queryParams, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection? connection = await GetAndOpenConnection();

        GetAllDocumentsTemplatesQueryParamsDb? queryParamsDb = GetAllDocumentsTemplatesQueryParamsDbConverter.FromDomain(queryParams);

        IEnumerable<DocumentTemplateDb>? templates =
            await connection.QueryAsync<DocumentTemplateDb>(DocumentsTemplatesRepositoryQueries.Search(domainId, queryParamsDb, cancellationToken));

        DocumentTemplate[]? result = templates.Select(DocumentTemplateDbToDomainConverter.ToDomain).ToArray();

        return result;
    }

    public async Task<DocumentTemplate[]> GetByIds(DomainId domainId, Id<DocumentTemplate>[] ids, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection? connection = await GetAndOpenConnection();

        string[]? templateIds = ids.Select(IdConverterTo.ToString).ToArray();

        IEnumerable<DocumentTemplateDb>? templates =
            await connection.QueryAsync<DocumentTemplateDb>(DocumentsTemplatesRepositoryQueries.GetByIds(domainId, templateIds, cancellationToken));

        DocumentTemplate[]? result = templates.Select(DocumentTemplateDbToDomainConverter.ToDomain).ToArray();

        return result;
    }

    public async Task<Id<DocumentTemplate>[]> GetAllIds(DomainId domainId, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection? connection = await GetAndOpenConnection();

        IEnumerable<string>? ids = await connection.QueryAsync<string>(DocumentsTemplatesRepositoryQueries.GetAllIds(domainId, cancellationToken));

        Id<DocumentTemplate>[]? result = ids.Select(IdConverterFrom<DocumentTemplate>.FromString).ToArray();

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
