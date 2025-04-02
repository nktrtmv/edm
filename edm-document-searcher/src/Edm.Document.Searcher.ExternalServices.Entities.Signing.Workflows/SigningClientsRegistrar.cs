using Microsoft.Extensions.DependencyInjection;
using Edm.Document.Searcher.ExternalServices.Entities.Signing.Workflows.Details;
using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;


namespace Edm.Document.Searcher.ExternalServices.Entities.Signing.Workflows;

public static class SigningClientsRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        const string serviceUri = "http://edm-entities-signing-workflows:5008";

        services.AddGrpcClient<SigningDetailsService.SigningDetailsServiceClient>(o => o.Address = new Uri(serviceUri));

        services.AddSingleton<ISigningWorkflowsDetailsClient, SigningWorkflowsDetailsClient>();
    }
}
