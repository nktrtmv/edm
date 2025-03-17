using Edm.Document.Classifier.Application.DocumentClassifications.Queries.Search.Contracts;
using Edm.Document.Classifier.Application.DocumentsTemplates.Queries.GetDetails.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifications;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.Markers;
using Edm.Document.Classifier.ExternalServices.DocumentsTemplates.Contracts.Queries.GetDetails;
using Edm.Document.Classifier.ExternalServices.DocumentsTemplates.Details;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentClassifications;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentClassifications.Contracts;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentClassifications.Queries.Search;

[UsedImplicitly]
internal sealed class SearchDocumentClassificationQueryInternalHandler
    : IRequestHandler<SearchDocumentClassificationQueryInternal, SearchDocumentClassificationQueryInternalResponse>
{
    private readonly IDocumentClassificationRepository _documentClassificationRepository;
    private readonly IDocumentsTemplatesDetails _documentsTemplatesDetails;

    public SearchDocumentClassificationQueryInternalHandler(
        IDocumentClassificationRepository documentClassificationRepository,
        IDocumentsTemplatesDetails documentsTemplatesDetails)
    {
        _documentClassificationRepository = documentClassificationRepository;
        _documentsTemplatesDetails = documentsTemplatesDetails;
    }

    public async Task<SearchDocumentClassificationQueryInternalResponse> Handle(SearchDocumentClassificationQueryInternal request, CancellationToken cancellationToken)
    {
        DocumentClassificationSearchParams searchParam = SearchDocumentClassificationQueryInternalConverter.ToSearchParams(request);

        DocumentClassification[] classifications = await _documentClassificationRepository.Search(searchParam, cancellationToken);

        Id<DocumentTemplate>[] documentTemplateIds = classifications.Select(c => c.DocumentTemplateId).ToArray();

        GetDetailsDocumentsTemplatesQueryExternal query = GetDetailsDocumentsTemplatesQueryExternalConverter.FromDomain(documentTemplateIds);

        GetDetailsDocumentsTemplatesQueryExternalResponse response = await _documentsTemplatesDetails.GetDetails(query, cancellationToken);

        Id<DocumentTemplate>[] notDeletedTemplateIds = GetDetailsDocumentsTemplatesQueryExternalResponseConverter.ToDomain(response);

        classifications = classifications.Where(c => notDeletedTemplateIds.Contains(c.DocumentTemplateId)).ToArray();

        SearchDocumentClassificationQueryInternalResponse result = SearchDocumentClassificationQueryInternalResponseConverter.FromDomain(classifications);

        return result;
    }
}
