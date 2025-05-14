using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Microsoft.Extensions.DependencyInjection;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Services.GetAvailableActions;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Services.GetWorkflows;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details;

internal static class SigningWorkflowsDetailsClientRegistrar
{
    internal static void Configure(IServiceCollection services)
    {
        services.AddSingleton<GetSigningWorkflowDocumentWorkflowsService>();
        services.AddSingleton<GetSigningWorkflowAvailableActionsService>();

        const string serviceUri = "http://edm-entities-signing-workflows:5008";

        services.AddGrpcClient<SigningDetailsService.SigningDetailsServiceClient>(o => o.Address = new Uri(serviceUri));
        services.AddSingleton<ISigningWorkflowsDetailsClient, SigningWorkflowsDetailsClient>();
    }
}
