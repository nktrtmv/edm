using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents.Inheritors.SendContractorSigned;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents.Inheritors.SendDocumentsToEdx;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents.Inheritors.SendSelfSigned;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents.Inheritors.SendWorkflowCompleted;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Edm.Entities.Signing.Workflows.Application;

public static class ApplicationRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        services.AddSingleton<ISigningApplicationEventProcessor, SendDocumentsToEdxSigningApplicationEventProcessor>();
        services.AddSingleton<ISigningApplicationEventProcessor, SendSelfSignedSigningApplicationEventProcessor>();
        services.AddSingleton<ISigningApplicationEventProcessor, SendWorkflowCompletedSigningApplicationEventProcessor>();
        services.AddSingleton<ISigningApplicationEventProcessor, SendContractorSignedSigningApplicationEventProcessor>();

        services.AddSingleton<SigningWorkflowsFacade>();
    }
}
