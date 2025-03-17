using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Fetchers.StatusParameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Fetchers.StatusParameters.Selectors.Inheritors.ReferenceAttributes;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Detectors.StatusParameters.ReferenceAttributes;

public static class ReferenceAttributeStatusParameterDetector
{
    public static Id<DocumentAttribute>? GetValueOrNull(DocumentStatus status, DocumentStatusParameterKind kind)
    {
        var fetcher = new DocumentStatusParameterFetcher(status);

        var selector = new ReferenceAttributeDocumentStatusParameterSelector(kind);

        Id<DocumentAttribute>? result = fetcher.GetValueOrNull(selector);

        return result;
    }

    public static Id<DocumentAttribute>[] GetValues(DocumentStatus status, DocumentStatusParameterKind kind)
    {
        var fetcher = new DocumentStatusParameterFetcher(status);

        var selector = new ReferenceAttributeDocumentStatusParameterSelector(kind);

        Id<DocumentAttribute>[] result = fetcher.GetValues(selector);

        return result;
    }
}
