using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed;
using Edm.DocumentGenerators.Application.Documents.Services;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Detectors.Classifications;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects.Classifications;
using Edm.DocumentGenerators.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get;

[UsedImplicitly]
internal sealed class GetDocumentQueryInternalHandler(DocumentsFacade documents) : IRequestHandler<GetDocumentQueryInternal, GetDocumentQueryInternalResponse>
{
    public async Task<GetDocumentQueryInternalResponse> Handle(GetDocumentQueryInternal request, CancellationToken cancellationToken)
    {
        Id<Document>? documentId = IdConverterFrom<Document>.From(request.DocumentId);

        Document? document = await documents.Get(documentId, request.SkipProcessing, cancellationToken);

        if (document == null)
        {
            return new GetDocumentQueryInternalResponse(null);
        }

        DocumentClassification? classification = null;

        if (document.DomainId.Value == DomainId.Contracts)
        {
            var fetcher = new DocumentAttributesValuesFetcher(document.AttributesValues);
            classification = DocumentClassificationDetector.Detect(fetcher);
        }

        DocumentDetailedInternal? documentInternal = DocumentDetailedInternalFromDomainConverter.FromDomain(document, classification);

        var result = new GetDocumentQueryInternalResponse(documentInternal);

        return result;
    }
}
