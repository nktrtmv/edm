using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values;

namespace Edm.Document.Classifier.Application.DocumentReferences.Services;

public abstract class DocumentReferenceService
{
    public abstract DocumentReferenceType Type { get; }

    public abstract Task<DocumentReferenceValue[]> Search(DocumentReferenceSearchParamsInternal searchParams, CancellationToken cancellationToken);
}
