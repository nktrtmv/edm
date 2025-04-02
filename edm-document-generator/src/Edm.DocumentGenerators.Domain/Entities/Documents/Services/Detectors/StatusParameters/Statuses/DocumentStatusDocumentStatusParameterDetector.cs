using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Fetchers.StatusParameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Fetchers.StatusParameters.Selectors.Inheritors.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Detectors.StatusParameters.Statuses;

public static class DocumentStatusDocumentStatusParameterDetector
{
    public static Id<DocumentStatus>? GetValueOrNull(DocumentStatus status, DocumentStatusParameterKind kind)
    {
        var fetcher = new DocumentStatusParameterFetcher(status);

        var selector = new DocumentStatusDocumentStatusParameterSelector(kind);

        Id<DocumentStatus>? result = fetcher.GetValueOrNull(selector);

        return result;
    }
}
