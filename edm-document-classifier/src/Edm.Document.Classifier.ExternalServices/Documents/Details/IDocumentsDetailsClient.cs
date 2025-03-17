using Edm.Document.Classifier.ExternalServices.Documents.Contracts;

namespace Edm.Document.Classifier.ExternalServices.Documents.Details;

public interface IDocumentsDetailsClient
{
    Task<DocumentDetailsEx[]> GetDetails(string[] documentsIds, CancellationToken cancellationToken);
}
