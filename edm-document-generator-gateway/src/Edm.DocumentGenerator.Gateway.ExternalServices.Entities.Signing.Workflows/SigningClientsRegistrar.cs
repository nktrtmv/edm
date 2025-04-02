using Microsoft.Extensions.DependencyInjection;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Actions;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows;

public static class SigningClientsRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        SigningWorkflowsActionsClientRegistrar.Configure(services);

        SigningWorkflowsDetailsClientRegistrar.Configure(services);
    }
}
