using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Microsoft.Extensions.DependencyInjection;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Actions;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Workflows;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows;

public static class ApprovalWorkflowsRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        const string serviceUri = "http://edm-entities-approval-workflows:5007";

        services.AddGrpcClient<EntitiesApprovalWorkflowsDetailsService.EntitiesApprovalWorkflowsDetailsServiceClient>(o => o.Address = new Uri(serviceUri));
        services.AddGrpcClient<EntitiesApprovalWorkflowsService.EntitiesApprovalWorkflowsServiceClient>(o => o.Address = new Uri(serviceUri));
        services.AddGrpcClient<EntitiesApprovalWorkflowsActionsService.EntitiesApprovalWorkflowsActionsServiceClient>(o => o.Address = new Uri(serviceUri));

        services.AddSingleton<IEntitiesApprovalWorkflowsDetailsClient, EntitiesApprovalWorkflowsDetailsClient>();
        services.AddSingleton<IEntitiesApprovalWorkflowsActionsClient, EntitiesApprovalWorkflowsActionsClient>();
        services.AddSingleton<IWorkflowsServiceClient, WorkflowsServiceClient>();
    }
}
