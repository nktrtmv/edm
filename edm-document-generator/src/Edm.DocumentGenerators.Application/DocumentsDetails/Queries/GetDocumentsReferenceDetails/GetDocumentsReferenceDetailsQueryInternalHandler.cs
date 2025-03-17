using Edm.DocumentGenerators.Application.Documents.Services;
using Edm.DocumentGenerators.Application.DocumentsDetails.Queries.GetDocumentsReferenceDetails.Contracts;
using Edm.DocumentGenerators.Application.DocumentsDetails.Queries.GetDocumentsReferenceDetails.Contracts.Contracts.DocumentReferenceDetails;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.DocumentGenerators.Application.DocumentsDetails.Queries.GetDocumentsReferenceDetails;

[UsedImplicitly]
internal sealed class GetDocumentsReferenceDetailsQueryInternalHandler
    : IRequestHandler<GetDocumentsReferenceDetailsQueryInternal, GetDocumentsReferenceDetailsQueryInternalResponse>
{
    public GetDocumentsReferenceDetailsQueryInternalHandler(DocumentsFacade documents)
    {
        Documents = documents;
    }

    private DocumentsFacade Documents { get; }

    public async Task<GetDocumentsReferenceDetailsQueryInternalResponse> Handle(GetDocumentsReferenceDetailsQueryInternal request, CancellationToken cancellationToken)
    {
        Id<Document>[] documentsIds = request.DocumentsIds.Select(IdConverterFrom<Document>.From).ToArray();

        var documents = new List<Document>();

        foreach (Id<Document> documentId in documentsIds)
        {
            Document document = await Documents.GetRequired(documentId, cancellationToken);

            documents.Add(document);
        }

        DocumentReferenceDetailsInternal[] documentsNumbersInternal = documents.Select(DocumentReferenceDetailsInternalConverter.FromDomain).ToArray();

        var result = new GetDocumentsReferenceDetailsQueryInternalResponse(documentsNumbersInternal);

        return result;
    }
}
