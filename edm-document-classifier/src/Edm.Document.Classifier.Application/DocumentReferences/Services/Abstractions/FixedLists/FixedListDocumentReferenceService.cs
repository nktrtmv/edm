using Edm.Document.Classifier.Application.DocumentReferences.Services.Abstractions.FixedLists.Validators.DuplicatesReferencesValues;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values;

namespace Edm.Document.Classifier.Application.DocumentReferences.Services.Abstractions.FixedLists;

public abstract class FixedListDocumentReferenceService : FixedListDocumentReferenceBaseService
{
    protected abstract DocumentReferenceValue[] Values { get; }

    public override Task<DocumentReferenceValue[]> Search(DocumentReferenceSearchParamsInternal searchParams, CancellationToken cancellationToken)
    {
        DuplicatesReferencesValuesValidator.Validate(Values, Type);

        DocumentReferenceValue[] result = Search(Values, searchParams);

        return Task.FromResult(result);
    }
}
