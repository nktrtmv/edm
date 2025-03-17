using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

using MediatR;

namespace Edm.DocumentGenerators.Application.DocumentsDetails.Queries.GetDocumentsNumbers.Contracts;

public sealed class GetDocumentRegistrationNumberQueryInternal : IRequest<GetDocumentRegistrationNumberQueryInternalResponse>
{
    public GetDocumentRegistrationNumberQueryInternal(Id<DocumentInternal> documentId)
    {
        DocumentId = documentId;
    }

    internal Id<DocumentInternal> DocumentId { get; }
}
