using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Fetchers.StatusParameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Fetchers.StatusParameters.Selectors.Inheritors.Strings;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Detectors.StatusParameters.Strings;

public static class StringStatusParameterDetector
{
    public static string GetTrimmedValueOrEmpty(DocumentStatus status, DocumentStatusParameterKind kind)
    {
        string result = GetTrimmedValueOrNull(status, kind) ?? string.Empty;

        return result;
    }

    public static string? GetTrimmedValueOrNull(DocumentStatus status, DocumentStatusParameterKind kind)
    {
        var fetcher = new DocumentStatusParameterFetcher(status);

        var selector = new StringDocumentStatusParameterSelector(kind);

        string? result = fetcher.GetValueOrNull(selector);

        if (result is null)
        {
            return null;
        }

        result = result.Trim();

        return result;
    }
}
