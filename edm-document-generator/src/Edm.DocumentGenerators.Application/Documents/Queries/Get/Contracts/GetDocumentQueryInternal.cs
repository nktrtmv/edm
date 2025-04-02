using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

using MediatR;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts;

public sealed class GetDocumentQueryInternal : IRequest<GetDocumentQueryInternalResponse>
{
    public GetDocumentQueryInternal(Id<DocumentInternal> documentId, bool skipProcessing)
    {
        DocumentId = documentId;
        SkipProcessing = skipProcessing;
    }

    internal Id<DocumentInternal> DocumentId { get; }
    internal bool SkipProcessing { get; }
}
