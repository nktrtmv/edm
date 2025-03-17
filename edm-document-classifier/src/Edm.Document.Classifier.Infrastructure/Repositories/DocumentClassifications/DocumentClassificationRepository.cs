using Dapper;

using Edm.Document.Classifier.Domain.Entities.DocumentClassifications;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.Markers;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.GenericSubdomain.Configuration;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentClassifications;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentClassifications.Contracts;
using Edm.Document.Classifier.Infrastructure.Options;
using Edm.Document.Classifier.Infrastructure.Repositories.DocumentClassifications.Contracts;

using Microsoft.Extensions.Configuration;

using Npgsql;

namespace Edm.Document.Classifier.Infrastructure.Repositories.DocumentClassifications;

internal sealed class DocumentClassificationRepository(IConfiguration configuration) : IDocumentClassificationRepository
{
    private DbOptions Options { get; } = ConfigurationValueFetcher.GetRequired<DbOptions>(configuration);

    public async Task Upsert(DocumentClassification documentClassification, CancellationToken cancellationToken)
    {
        await using var connection = await GetAndOpenConnection();

        var db = DocumentClassificationDbConverter.FromDomain(documentClassification);

        await connection.QuerySingleAsync<string>(DocumentClassificationRepositoryQueries.Upsert(db, cancellationToken));
    }

    public async Task<DocumentClassification> GetRequired(Id<DocumentTemplate> templateId, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(templateId.ToString()))
        {
            throw new ApplicationException("TemplateId can't be empty");
        }

        await using var connection = await GetAndOpenConnection();

        var documentTemplateId = templateId.ToString();

        var db = await connection.QuerySingleOrDefaultAsync<DocumentClassificationDb>(DocumentClassificationRepositoryQueries.Get(documentTemplateId, cancellationToken));

        if (db is null)
        {
            throw new ApplicationException($"DocumentClassification {documentTemplateId} not found");
        }

        var result = DocumentClassificationDbConverter.ToDomain(db);

        return result;
    }

    public async Task<DocumentClassification[]> Search(DocumentClassificationSearchParams searchParams, CancellationToken cancellationToken)
    {
        await using var connection = await GetAndOpenConnection();

        IEnumerable<DocumentClassificationDb> db =
            await connection.QueryAsync<DocumentClassificationDb>(DocumentClassificationRepositoryQueries.Get(null, cancellationToken));

        DocumentClassification[] classifications = db.Select(DocumentClassificationDbConverter.ToDomain).ToArray();

        DocumentClassification[] result = classifications.Where(
                c =>
                    c.DocumentClassifierSubset.BusinessSegmentIds.Contains(searchParams.BusinessSegmentId) &&
                    c.DocumentClassifierSubset.DocumentCategory.Id == searchParams.DocumentCategoryId &&
                    c.DocumentClassifierSubset.DocumentCategory.DocumentTypes.Any(d => d.DocumentTypeId == searchParams.DocumentTypeId) &&
                    c.DocumentClassifierSubset.DocumentCategory.DocumentTypes.Any(d => d.DocumentKindIds.Contains(searchParams.DocumentKindId)))
            .ToArray();

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
