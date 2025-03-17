using Edm.Document.Classifier.ExternalServices.DocumentsSearchers.Searches.Factories.Queries.SearchesByRegistrationsNumbers;
using Edm.Document.Searcher.Presentation.Abstractions;

namespace Edm.Document.Classifier.ExternalServices.DocumentsSearchers;

internal sealed class DocumentsSearchersClient : IDocumentsSearchersClient
{
    public DocumentsSearchersClient(SearchDocumentsService.SearchDocumentsServiceClient searchDocuments)
    {
        SearchDocuments = searchDocuments;
    }

    private SearchDocumentsService.SearchDocumentsServiceClient SearchDocuments { get; }

    public async Task<string[]> SearchByRegistrationNumber(string registrationNumber, int take, int skip, CancellationToken cancellationToken)
    {
        SearchDocumentsQuery query = SearchByRegistrationNumberQueryFactory.CreateFrom(registrationNumber, take, skip);

        SearchDocumentsQueryResponse response = await SearchDocuments.SearchAsync(query, cancellationToken: cancellationToken);

        string[] result = response.DocumentsIds.ToArray();

        return result;
    }
}
