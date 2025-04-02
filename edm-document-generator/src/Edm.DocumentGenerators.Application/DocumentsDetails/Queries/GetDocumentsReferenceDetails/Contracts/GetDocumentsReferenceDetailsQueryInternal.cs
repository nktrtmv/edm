using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

using MediatR;

namespace Edm.DocumentGenerators.Application.DocumentsDetails.Queries.GetDocumentsReferenceDetails.Contracts;

public sealed class GetDocumentsReferenceDetailsQueryInternal : IRequest<GetDocumentsReferenceDetailsQueryInternalResponse>
{
    public GetDocumentsReferenceDetailsQueryInternal(Id<DocumentInternal>[] documentsIds)
    {
        DocumentsIds = documentsIds;
    }

    internal Id<DocumentInternal>[] DocumentsIds { get; }
}
