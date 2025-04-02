using Edm.Document.Classifier.Application.DocumentClassifications.Queries.Get.Contracts;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.Markers;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentClassifications;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Classifier.Application.DocumentClassifications.Queries.Get;

[UsedImplicitly]
internal sealed class GetDocumentClassificationQueryInternalHandler
    : IRequestHandler<GetDocumentClassificationQueryInternal, GetDocumentClassificationQueryInternalResponse>
{
    public GetDocumentClassificationQueryInternalHandler(IDocumentClassificationRepository classifications)
    {
        Classifications = classifications;
    }

    private IDocumentClassificationRepository Classifications { get; }

    public async Task<GetDocumentClassificationQueryInternalResponse> Handle(GetDocumentClassificationQueryInternal request, CancellationToken cancellationToken)
    {
        var documentClassificationId = IdConverterFrom<DocumentTemplate>.FromString(request.DocumentTemplateId);

        var documentClassification = await Classifications.GetRequired(documentClassificationId, cancellationToken);

        var response = GetDocumentClassificationQueryInternalResponseConverter.FromDomain(documentClassification);

        return response;
    }
}
