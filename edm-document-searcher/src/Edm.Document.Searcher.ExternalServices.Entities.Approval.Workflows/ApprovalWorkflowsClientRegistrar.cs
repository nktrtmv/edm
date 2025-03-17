using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows;

public static class ApprovalWorkflowsClientRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        const string serviceUri = "http://edm-entities-approval-workflows:5007";

        services.AddGrpcClient<EntitiesApprovalWorkflowsDetailsService.EntitiesApprovalWorkflowsDetailsServiceClient>(o => o.Address = new Uri(serviceUri));

        services.AddSingleton<IApprovalWorkflowsClient, ApprovalWorkflowsClient>();
    }
}
