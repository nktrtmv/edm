using Dapper;

using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.CustomReferences;
using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.GenericSubdomain.Configuration;
using Edm.Document.Classifier.GenericSubdomain.Converters;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Contracts.QueryParams;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Types;
using Edm.Document.Classifier.Infrastructure.Options;
using Edm.Document.Classifier.Infrastructure.Repositories.DocumentReferenceTypes.Contracts;
using Edm.Document.Classifier.Infrastructure.Repositories.DocumentReferenceTypes.Contracts.QueryParams;

using Microsoft.Extensions.Configuration;

using Npgsql;

namespace Edm.Document.Classifier.Infrastructure.Repositories.DocumentReferenceTypes;

internal sealed class DocumentReferenceTypeRepository(IConfiguration configuration) : IDocumentReferenceTypeRepository
{
    private DbOptions Options { get; } = ConfigurationValueFetcher.GetRequired<DbOptions>(configuration);

    public async Task<int> Upsert(ReferenceType documentReferenceType, CancellationToken cancellationToken)
    {
        await using var connection = await GetAndOpenConnection();

        var db = DocumentReferenceTypeDbConverter.FromDomain(documentReferenceType);

        var referenceTypeId = await connection.QuerySingleAsync<int>(DocumentReferenceTypeRepositoryQueries.Upsert(db, cancellationToken));

        return referenceTypeId;
    }

    public async Task<ReferenceType?> Get(DomainId? domainId, Id<ReferenceType> referenceTypeId, CancellationToken cancellationToken)
    {
        await using var connection = await GetAndOpenConnection();

        var id = IdConverterTo.ToInt(referenceTypeId);

        var referenceTypeDb =
            await connection.QuerySingleOrDefaultAsync<DocumentReferenceTypeDb>(DocumentReferenceTypeRepositoryQueries.Get(domainId, id, cancellationToken));

        var result = NullableConverter.Convert(referenceTypeDb, DocumentReferenceTypeDbConverter.ToDomain);

        return result;
    }

    public async Task<ReferenceType> GetRequired(DomainId? domainId, Id<ReferenceType> referenceTypeId, CancellationToken cancellationToken)
    {
        var result = await Get(domainId, referenceTypeId, cancellationToken);

        if (result is null)
        {
            throw new ApplicationException($"Required document reference type with domainId '{domainId?.Value}' and id '{referenceTypeId}' wasn't found.");
        }

        return result;
    }

    public async Task<ReferenceType[]> GetAll(DomainId? domainId, GetAllDocumentReferenceTypesQueryParams queryParams, CancellationToken cancellationToken)
    {
        await using var connection = await GetAndOpenConnection();

        var queryParamsDb = GetAllDocumentReferenceTypesQueryParamsDbConverter.FromDomain(queryParams);

        IEnumerable<DocumentReferenceTypeDb> templates =
            await connection.QueryAsync<DocumentReferenceTypeDb>(DocumentReferenceTypeRepositoryQueries.GetAll(domainId, queryParamsDb, cancellationToken));

        ReferenceType[] result = templates.Select(DocumentReferenceTypeDbConverter.ToDomain).ToArray();

        return result;
    }

    public async Task<int?> GetLastReferenceTypeId(CancellationToken cancellationToken)
    {
        await using var connection = await GetAndOpenConnection();

        var result = await connection.QuerySingleOrDefaultAsync<int?>(DocumentReferenceTypeRepositoryQueries.GetLastReferenceTypeId(cancellationToken));

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
