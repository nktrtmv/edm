using Edm.Document.Classifier.ExternalServices.DocumentGenerators.Converters;
using Edm.Document.Classifier.ExternalServices.Documents.Contracts;
using Edm.Document.Classifier.ExternalServices.Documents.Details;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.Document.Classifier.ExternalServices.DocumentGenerators.Details;

internal sealed class DocumentsDetailsClient : IDocumentsDetailsClient
{
    public DocumentsDetailsClient(DocumentsDetailsService.DocumentsDetailsServiceClient documentsDetails)
    {
        DocumentsDetails = documentsDetails;
    }

    private DocumentsDetailsService.DocumentsDetailsServiceClient DocumentsDetails { get; }

    async Task<DocumentDetailsEx[]> IDocumentsDetailsClient.GetDetails(string[] documentsIds, CancellationToken cancellationToken)
    {
        var request = new GetDocumentsReferenceDetailsQuery
        {
            DocumentsIds = { documentsIds }
        };

        var response = await DocumentsDetails.GetReferenceDetailsAsync(request, cancellationToken: cancellationToken);

        DocumentDetailsEx[] result = response.Details.Select(DocumentDetailsExConverter.FromDto).ToArray();

        return result;
    }
}
