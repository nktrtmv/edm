using Edm.DocumentGenerators.Application.DocumentsDetails.Queries.GetDocumentsReferenceDetails.Contracts.Contracts.DocumentReferenceDetails;

namespace Edm.DocumentGenerators.Application.DocumentsDetails.Queries.GetDocumentsReferenceDetails.Contracts;

public sealed class GetDocumentsReferenceDetailsQueryInternalResponse
{
    internal GetDocumentsReferenceDetailsQueryInternalResponse(DocumentReferenceDetailsInternal[] details)
    {
        Details = details;
    }

    public DocumentReferenceDetailsInternal[] Details { get; }
}
