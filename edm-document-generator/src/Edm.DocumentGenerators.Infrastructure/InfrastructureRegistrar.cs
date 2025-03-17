using Dapper;

using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.Documents;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.DocumentStatusParameters;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.DocumentsTemplates;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents;
using Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsStatusesParameters;
using Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.DocumentGenerators.Infrastructure;

public static class InfrastructureRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        DefaultTypeMap.MatchNamesWithUnderscores = true;

        services.AddSingleton<IDocumentsTemplatesRepository, DocumentsTemplatesRepository>();
        services.AddSingleton<IDocumentsRepository, DocumentsRepository>();
        services.AddSingleton<IDocumentsStatusesParametersRepository, DocumentsStatusesParametersRepository>();
    }
}
