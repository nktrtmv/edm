using Dapper;

using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentClassifications;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentExternalLinks.Masters;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Types;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentReferenceTypes.Values;
using Edm.Document.Classifier.Infrastructure.Repositories.DocumentClassifications;
using Edm.Document.Classifier.Infrastructure.Repositories.DocumentClassifiers;
using Edm.Document.Classifier.Infrastructure.Repositories.DocumentExternalLinks.Masters;
using Edm.Document.Classifier.Infrastructure.Repositories.DocumentReferenceTypes;
using Edm.Document.Classifier.Infrastructure.Repositories.DocumentReferenceValues;
using Edm.Document.Classifier.Infrastructure.Repositories.Domains;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.Document.Classifier.Infrastructure;

public static class InfrastructureServicesRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        DefaultTypeMap.MatchNamesWithUnderscores = true;

        services.AddSingleton<IDocumentClassificationRepository, DocumentClassificationRepository>();
        services.AddSingleton<IDocumentClassifierRepository, DocumentClassifierRepository>();
        services.AddSingleton<IClassifierMasterDocumentExternalLinkKindsRepository, ClassifierMasterDocumentExternalLinkKindsRepository>();
        services.AddSingleton<IDomainRepository, FileDomainRepository>();
        services.AddSingleton<IDocumentReferenceTypeRepository, DocumentReferenceTypeRepository>();
        services.AddSingleton<IDocumentReferenceValueRepository, DocumentReferenceValueRepository>();
        services.AddSingleton<DomainsWarmUpService>();
    }
}
