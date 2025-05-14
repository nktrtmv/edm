using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Microsoft.Extensions.DependencyInjection;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Actions.Services.GetDocumentsToSign;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Actions;

internal static class SigningWorkflowsActionsClientRegistrar
{
    internal static void Configure(IServiceCollection services)
    {
        services.AddSingleton<GetDocumentsToSignSigningWorkflowActionService>();

        const string serviceUri = "http://edm-entities-signing-workflows:5008";

        services.AddGrpcClient<SigningActionsService.SigningActionsServiceClient>(o => o.Address = new Uri(serviceUri));
        services.AddSingleton<ISigningWorkflowsActionsClient, SigningWorkflowsActionsClient>();
    }
}
