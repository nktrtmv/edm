using Edm.Document.Searcher.Presentation.Abstractions;

namespace Edm.Document.Classifier.ExternalServices.DocumentsSearchers.Searches.Factories.Queries.SearchesByRegistrationsNumbers;

internal static class SearchByRegistrationNumberQueryFactory
{
    private const int ContractsRegistrationNumberRole = 1;

    internal static SearchDocumentsQuery CreateFrom(string registrationNumber, int limit, int skip)
    {
        var contains = new SearchDocumentsQueryContainsFilter
        {
            Values =
            {
                new SearchDocumentsQueryFilterValue
                {
                    AsString = new SearchDocumentsQueryFilterStringValue
                    {
                        Value = registrationNumber
                    }
                }
            }
        };

        var filter = new SearchDocumentsQueryFilter
        {
            RegistryRolesIds = { ContractsRegistrationNumberRole },
            Contains = contains
        };

        SearchDocumentsQuery result = SearchDocumentsQueryFactory.CreateFrom(limit, skip, filter);

        return result;
    }
}
