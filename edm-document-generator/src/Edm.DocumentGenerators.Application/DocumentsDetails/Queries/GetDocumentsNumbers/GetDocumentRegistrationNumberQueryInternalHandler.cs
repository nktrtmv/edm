using Edm.DocumentGenerators.Application.Documents.Services;
using Edm.DocumentGenerators.Application.DocumentsDetails.Queries.GetDocumentsNumbers.Contracts;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Services.Fetchers;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.ValueObjects.DocumentsRoles;
using Edm.DocumentGenerators.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.DocumentGenerators.Application.DocumentsDetails.Queries.GetDocumentsNumbers;

[UsedImplicitly]
internal sealed class GetDocumentRegistrationNumberQueryInternalHandler
    : IRequestHandler<GetDocumentRegistrationNumberQueryInternal, GetDocumentRegistrationNumberQueryInternalResponse>
{
    public GetDocumentRegistrationNumberQueryInternalHandler(DocumentsFacade documents)
    {
        Documents = documents;
    }

    private DocumentsFacade Documents { get; }

    public async Task<GetDocumentRegistrationNumberQueryInternalResponse> Handle(GetDocumentRegistrationNumberQueryInternal request, CancellationToken cancellationToken)
    {
        Id<Document> documentId = IdConverterFrom<Document>.From(request.DocumentId);

        Document document = await Documents.GetRequired(documentId, true, cancellationToken);

        string? registrationNumber =
            DocumentAttributeValueStringByRoleFetcher.FetchFirstOrDefaultValue(document, (int)DocumentAttributeDocumentRole.DocumentRegistrationNumber);

        var result = new GetDocumentRegistrationNumberQueryInternalResponse(registrationNumber);

        return result;
    }
}
