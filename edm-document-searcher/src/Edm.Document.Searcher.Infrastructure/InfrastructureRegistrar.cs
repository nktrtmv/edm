using Dapper;

using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.Document.Searcher.Infrastructure;

public static class InfrastructureRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        DefaultTypeMap.MatchNamesWithUnderscores = true;

        services.AddSingleton<ISearchDocumentsRepository, SearchDocumentsRepository>();
    }
}
