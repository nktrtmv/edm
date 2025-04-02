using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Fetchers.StatusParameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Fetchers.StatusParameters.Selectors.Inheritors.Boolean;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Detectors.StatusParameters.Boolean;

public static class BooleanStatusParameterDetector
{
    public static bool IsSet(DocumentStatus status, DocumentStatusParameterKind kind)
    {
        var fetcher = new DocumentStatusParameterFetcher(status);

        var selector = new BooleanDocumentStatusParameterSelector(kind);

        bool? value = fetcher.GetValueOrNull(selector);

        bool result = value == true;

        return result;
    }
}
