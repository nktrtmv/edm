using Dapper;

using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.CustomReferences;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values.CustomReferenceValue;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.GenericSubdomain.Configuration;
using Edm.Document.Classifier.GenericSubdomain.Converters;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Contracts.QueryParams;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Values;
using Edm.Document.Classifier.Infrastructure.Options;
using Edm.Document.Classifier.Infrastructure.Repositories.DocumentReferenceTypes.Contracts.QueryParams;
using Edm.Document.Classifier.Infrastructure.Repositories.DocumentReferenceValues.Contracts;

using Microsoft.Extensions.Configuration;

using Npgsql;

namespace Edm.Document.Classifier.Infrastructure.Repositories.DocumentReferenceValues;

internal sealed class DocumentReferenceValueRepository(IConfiguration configuration) : IDocumentReferenceValueRepository
{
    private DbOptions Options { get; } = ConfigurationValueFetcher.GetRequired<DbOptions>(configuration);

    public async Task Insert(ReferenceValue referenceValue, CancellationToken cancellationToken)
    {
        await using var connection = await GetAndOpenConnection();

        var db = DocumentReferenceValueDbConverter.FromDomain(referenceValue);

        try
        {
            await connection.QuerySingleAsync<DateTime>(DocumentReferenceValueRepositoryQueries.Insert(db, cancellationToken));
        }
        catch (PostgresException e) when (e.SqlState == PostgresErrorCodes.UniqueViolation)
        {
            ThrowUniqueViolation(e, referenceValue);
        }
    }

    public async Task Update(ReferenceValue referenceValue, Id<ReferenceValue>? newId, CancellationToken cancellationToken)
    {
        await using var connection = await GetAndOpenConnection();

        var newIdDb = NullableConverter.Convert(newId, IdConverterTo.ToString);

        var db = DocumentReferenceValueDbConverter.FromDomain(referenceValue);

        try
        {
            await connection.QuerySingleAsync<DateTime>(DocumentReferenceValueRepositoryQueries.Update(db, newIdDb, cancellationToken));
        }
        catch (PostgresException e) when (e.SqlState == PostgresErrorCodes.UniqueViolation)
        {
            ThrowUniqueViolation(e, referenceValue);
        }
    }

    public async Task BulkUpsert(ReferenceValue[] referenceValues, CancellationToken cancellationToken)
    {
        await using var connection = await GetAndOpenConnection();

        DocumentReferenceValueDb[] db = referenceValues.Select(DocumentReferenceValueDbConverter.FromDomain).ToArray();

        try
        {
            await connection.QueryAsync<DateTime>(DocumentReferenceValueRepositoryQueries.BulkUpsert(db, cancellationToken));
        }
        catch (PostgresException e) when (e.SqlState == PostgresErrorCodes.UniqueViolation)
        {
            ThrowUniqueViolation(e, referenceValues);
        }
    }

    public async Task<ReferenceValue?> Get(Id<ReferenceType> referenceType, Id<ReferenceValue> referenceValueId, CancellationToken cancellationToken)
    {
        await using var connection = await GetAndOpenConnection();

        var referenceTypeId = IdConverterTo.ToInt(referenceType);

        var id = IdConverterTo.ToString(referenceValueId);

        var referenceTypeDb = await connection.QuerySingleOrDefaultAsync<DocumentReferenceValueDb>(
            DocumentReferenceValueRepositoryQueries.Get(referenceTypeId, id, cancellationToken));

        var result = NullableConverter.Convert(referenceTypeDb, DocumentReferenceValueDbConverter.ToDomain);

        return result;
    }

    public async Task<ReferenceValue[]> GetByIds(Id<ReferenceType> referenceType, Id<ReferenceValue>[] referenceValueIds, CancellationToken cancellationToken)
    {
        await using var connection = await GetAndOpenConnection();

        var referenceTypeId = IdConverterTo.ToInt(referenceType);

        string[] ids = referenceValueIds.Select(IdConverterTo.ToString).ToArray();

        IEnumerable<DocumentReferenceValueDb> values = await connection.QueryAsync<DocumentReferenceValueDb>(
            DocumentReferenceValueRepositoryQueries.GetByIds(referenceTypeId, ids, cancellationToken));

        ReferenceValue[] result = values.Select(DocumentReferenceValueDbConverter.ToDomain).ToArray();

        return result;
    }

    public async Task<ReferenceValue> GetRequired(Id<ReferenceType> referenceTypeId, Id<ReferenceValue> referenceValueId, CancellationToken cancellationToken)
    {
        var result = await Get(referenceTypeId, referenceValueId, cancellationToken);

        if (result is null)
        {
            throw new ApplicationException($"Required document reference value with referenceType '{referenceValueId.Value}' and id '{referenceValueId}' wasn't found.");
        }

        return result;
    }

    public async Task<ReferenceValue[]> GetAll(
        Id<ReferenceType> referenceType,
        GetAllDocumentReferenceTypesQueryParams queryParams,
        bool showHidden,
        CancellationToken cancellationToken)
    {
        await using var connection = await GetAndOpenConnection();

        var referenceTypeId = IdConverterTo.ToInt(referenceType);

        var queryParamsDb = GetAllDocumentReferenceTypesQueryParamsDbConverter.FromDomain(queryParams);

        IEnumerable<DocumentReferenceValueDb> templates = await connection.QueryAsync<DocumentReferenceValueDb>(
            DocumentReferenceValueRepositoryQueries.GetAll(referenceTypeId, queryParamsDb, showHidden, cancellationToken));

        ReferenceValue[] result = templates.Select(DocumentReferenceValueDbConverter.ToDomain).ToArray();

        return result;
    }

    private static void ThrowUniqueViolation(PostgresException e, ReferenceValue referenceValue)
    {
        var exception = new ApplicationException($"Значение \"{referenceValue.DisplayValue}\" уже существует ( {e.MessageText} )");

        throw exception;
    }

    private static void ThrowUniqueViolation(PostgresException e, ReferenceValue[] referenceValues)
    {
        var exception = new ApplicationException($"Значение уже существует ( {e.MessageText} )");

        throw exception;
    }

    private async Task<NpgsqlConnection> GetAndOpenConnection()
    {
        var connection = new NpgsqlConnection(Options.ConnectionString);

        await connection.OpenAsync();

        await connection.ReloadTypesAsync();

        return connection;
    }
}
