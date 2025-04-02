using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts;

public sealed record SearchValuesDocumentReferencesQueryInternal(DocumentReferenceSearchParamsInternal SearchParams)
    : IRequest<SearchValuesDocumentReferencesQueryResponseInternal>;
