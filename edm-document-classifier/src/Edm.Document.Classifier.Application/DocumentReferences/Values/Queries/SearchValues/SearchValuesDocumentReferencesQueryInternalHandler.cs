using Edm.Document.Classifier.Application.DocumentReferences.Services;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.Values;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.CustomReferences;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values.CustomReferenceValue;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Contracts.QueryParams;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Values;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues;

[UsedImplicitly]
internal sealed class SearchValuesDocumentReferencesQueryInternalHandler
    : IRequestHandler<SearchValuesDocumentReferencesQueryInternal, SearchValuesDocumentReferencesQueryResponseInternal>
{
    public SearchValuesDocumentReferencesQueryInternalHandler(
        IEnumerable<DocumentReferenceService> references,
        IDocumentReferenceValueRepository documentReferenceValueRepository)
    {
        _documentReferenceValueRepository = documentReferenceValueRepository;
        ReferencesById = references.ToDictionary(r => r.Type.Id);
    }

    private Dictionary<DocumentReferenceTypeId, DocumentReferenceService> ReferencesById { get; }
    private readonly IDocumentReferenceValueRepository _documentReferenceValueRepository;

    public async Task<SearchValuesDocumentReferencesQueryResponseInternal> Handle(SearchValuesDocumentReferencesQueryInternal query, CancellationToken cancellationToken)
    {
        Id<DocumentReferenceTypeId> referenceTypeId = query.SearchParams.Key.ReferenceTypeId;

        int id = IdConverterTo.ToInt(referenceTypeId);

        DocumentReferenceValueInternal[] staticReferences = await GetStaticReferences(query, id, cancellationToken);

        DocumentReferenceValueInternal[] dbReferences = await GetDbReferences(query, referenceTypeId, cancellationToken);

        DocumentReferenceValueInternal[] values = staticReferences.Concat(dbReferences).GroupBy(x => x.Id).Select(x => x.First()).ToArray();

        var result = new SearchValuesDocumentReferencesQueryResponseInternal(values);

        return result;
    }

    private async Task<DocumentReferenceValueInternal[]> GetDbReferences(
        SearchValuesDocumentReferencesQueryInternal query,
        Id<DocumentReferenceTypeId> referenceTypeId,
        CancellationToken cancellationToken)
    {
        Id<ReferenceType> referenceType = IdConverterFrom<ReferenceType>.From(referenceTypeId);

        var queryParams = new GetAllDocumentReferenceTypesQueryParams(
            query.SearchParams.Search,
            query.SearchParams.Limit,
            query.SearchParams.Skip,
            query.SearchParams.Ids);

        ReferenceValue[] referenceValues = await _documentReferenceValueRepository.GetAll(referenceType, queryParams, showHidden: false, cancellationToken);

        DocumentReferenceValueInternal[] result = referenceValues.Select(DocumentReferenceValueInternalConverter.FromDomain).ToArray();

        return result;
    }

    private async Task<DocumentReferenceValueInternal[]> GetStaticReferences(
        SearchValuesDocumentReferencesQueryInternal query,
        int id,
        CancellationToken cancellationToken)
    {
        DocumentReferenceTypeId referenceTypeId = (DocumentReferenceTypeId)id;

        DocumentReferenceService? reference = ReferencesById.GetValueOrDefault(referenceTypeId);

        if (reference is null)
        {
            return [];
        }

        DocumentReferenceValue[] values = await reference.Search(query.SearchParams, cancellationToken);

        DocumentReferenceValueInternal[] result = values.Select(DocumentReferenceValueInternalConverter.FromDomain).ToArray();

        return result;
    }
}
