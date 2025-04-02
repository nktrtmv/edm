using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Fetchers.StatusParameters.Selectors.Abstractions.ReferenceTypes;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.DocumentStatuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Fetchers.StatusParameters.Selectors.Inheritors.Statuses;

internal sealed class DocumentStatusDocumentStatusParameterSelector
    : DocumentStatusParameterReferenceTypeSelectorGeneric<DocumentStatusDocumentStatusParameter, Id<DocumentStatus>>
{
    internal DocumentStatusDocumentStatusParameterSelector(DocumentStatusParameterKind kind) : base(kind)
    {
    }

    protected override Id<DocumentStatus>? GetSingleValueOrDefault(DocumentStatusDocumentStatusParameter parameter)
    {
        return parameter.Value;
    }
}
