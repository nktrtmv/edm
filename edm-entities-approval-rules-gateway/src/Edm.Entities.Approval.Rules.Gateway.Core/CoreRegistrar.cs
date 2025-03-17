using Edm.Entities.Approval.Rules.Gateway.Core.Conditions.Operators.Queries.GetAttributesOperators;
using Edm.Entities.Approval.Rules.Gateway.Core.Conditions.Operators.Queries.GetLogicalOperators;
using Edm.Entities.Approval.Rules.Gateway.Core.Domains.Queries.GetAll;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Commands.Create;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Commands.Delete;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Commands.Update;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Queries.Get;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Queries.GetAll;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Create;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Delete;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Update;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Queries.Get;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Queries.GetAll;
using Edm.Entities.Approval.Rules.Gateway.Core.GroupsDetails.Domestic.Queries.GetParticipantSourceAttributes;
using Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.GetTypes;
using Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.SearchValues;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Activate;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.CreateNewVersion;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Deactivate;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Update;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Get;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetActivationAudit;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetAll;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetVersions;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Search;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.Entities.Approval.Rules.Gateway.Core;

public static class CoreRegistrar
{
    private const string EdmEntitiesApprovalRulesServiceUri = "http://edm-entities-approval-rules:5006";

    public static void Configure(IServiceCollection services)
    {
        ConfigureConditionsOperators(services);
        ConfigureDomains(services);
        ConfigureGraphs(services);
        ConfigureGroups(services);
        ConfigureGroupsDetails(services);
        ConfigureReferences(services);
        ConfigureRules(services);
    }

    private static void ConfigureConditionsOperators(IServiceCollection services)
    {
        services.AddSingleton<GetLogicalOperatorsApprovalConditionsOperatorsService>();
        services.AddSingleton<GetAttributesOperatorsApprovalConditionsOperatorsService>();

        services.AddGrpcClient<ApprovalConditionsOperatorsService.ApprovalConditionsOperatorsServiceClient>(o => o.Address = new Uri(EdmEntitiesApprovalRulesServiceUri));
    }

    private static void ConfigureDomains(IServiceCollection services)
    {
        services.AddSingleton<GetAllApprovalDomainsQueryService>();
    }

    private static void ConfigureGraphs(IServiceCollection services)
    {
        services.AddSingleton<CreateApprovalGraphsCommandService>();
        services.AddSingleton<DeleteApprovalGraphsCommandService>();
        services.AddSingleton<UpdateApprovalGraphsCommandService>();

        services.AddSingleton<GetApprovalGraphsQueryService>();
        services.AddSingleton<GetAllApprovalGraphsService>();

        services.AddGrpcClient<ApprovalGraphsService.ApprovalGraphsServiceClient>(o => o.Address = new Uri(EdmEntitiesApprovalRulesServiceUri));
    }

    private static void ConfigureGroups(IServiceCollection services)
    {
        services.AddSingleton<CreateApprovalGroupsCommandService>();
        services.AddSingleton<DeleteApprovalGroupsCommandService>();
        services.AddSingleton<UpdateApprovalGroupsCommandService>();

        services.AddSingleton<GetApprovalGroupsQueryService>();
        services.AddSingleton<GetAllApprovalGroupsQueryService>();

        services.AddGrpcClient<ApprovalGroupsService.ApprovalGroupsServiceClient>(o => o.Address = new Uri(EdmEntitiesApprovalRulesServiceUri));
    }

    private static void ConfigureGroupsDetails(IServiceCollection services)
    {
        services.AddSingleton<GetParticipantSourceAttributesApprovalGroupsDetailsQueryBffService>();

        services.AddGrpcClient<ApprovalGroupsDetailsService.ApprovalGroupsDetailsServiceClient>(o => o.Address = new Uri(EdmEntitiesApprovalRulesServiceUri));
    }

    private static void ConfigureReferences(IServiceCollection services)
    {
        services.AddSingleton<GetTypesApprovalReferencesQueryService>();
        services.AddSingleton<SearchValuesApprovalReferencesQueryService>();
    }

    private static void ConfigureRules(IServiceCollection services)
    {
        services.AddSingleton<ActivateApprovalRulesCommandService>();
        services.AddSingleton<CreateNewVersionApprovalRulesCommandService>();
        services.AddSingleton<DeactivateApprovalRulesCommandService>();
        services.AddSingleton<UpdateApprovalRulesCommandService>();

        services.AddSingleton<GetActivationAuditApprovalRulesQueryService>();
        services.AddSingleton<GetAllApprovalRulesQueryService>();
        services.AddSingleton<GetVersionsApprovalRulesQueryService>();
        services.AddSingleton<SearchApprovalRulesQueryService>();
        services.AddSingleton<GetApprovalRuleQueryService>();

        services.AddGrpcClient<ApprovalRulesService.ApprovalRulesServiceClient>(o => o.Address = new Uri(EdmEntitiesApprovalRulesServiceUri));
    }
}
