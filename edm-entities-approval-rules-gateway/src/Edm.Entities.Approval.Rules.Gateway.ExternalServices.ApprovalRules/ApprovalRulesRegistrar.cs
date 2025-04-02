using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Enrichers.Sources;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers.Sources;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules;

public static class ApprovalRulesRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        const string serviceUri = "http://edm-document-classifier:5001";

        services.AddGrpcClient<ApprovalReferencesService.ApprovalReferencesServiceClient>(o => o.Address = new Uri(serviceUri));

        services.AddSingleton<IEnricherSource, ApprovalReferenceEnricherSource>();
        services.AddSingleton<IApprovalReferencesClient, ApprovalReferencesClient>();
    }
}
