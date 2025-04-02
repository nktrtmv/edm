namespace Edm.Document.Classifier.ExternalServices.DocumentsSearchers;

public interface IDocumentsSearchersClient
{
    Task<string[]> SearchByRegistrationNumber(string registrationNumber, int take, int skip, CancellationToken cancellationToken);
}
