using Edm.Entities.Approval.Workflows.Application.Workflows.Services;
using Edm.Entities.Approval.Workflows.Application.Workflows.Services.ApplicationEvents;
using Edm.Entities.Approval.Workflows.Application.Workflows.Services.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Events;
using Edm.Entities.Approval.Workflows.Application.Workflows.Services.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Results;
using Edm.Entities.Approval.Workflows.Application.Workflows.Services.StageActivators;
using Edm.Entities.Approval.Workflows.Application.Workflows.Services.StageActivators.AssignmentsManagers;
using Edm.Entities.Approval.Workflows.Application.Workflows.Services.StageActivators.AssignmentsManagers.GroupFacades;
using Edm.Entities.Approval.Workflows.Application.Workflows.Services.StageActivators.AssignmentsManagers.GroupFacades.GroupAdapters;
using Edm.Entities.Approval.Workflows.Application.Workflows.Services.StageActivators.AssignmentsManagers.GroupFacades.GroupAdapters.Inheritors.Domestic;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.Entities.Approval.Workflows.Application;

public static class ApplicationRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        services.AddSingleton<IApprovalWorkflowApplicationEventProcessor, EntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEventProcessor>();
        services.AddSingleton<IApprovalWorkflowApplicationEventProcessor, EntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventProcessor>();

        services.AddSingleton<ApprovalWorkflowsFacade>();

        services.AddSingleton<ApprovalWorkflowStageActivator>();
        services.AddSingleton<ApprovalWorkflowAssignmentsManager>();
        services.AddSingleton<ApprovalWorkflowsGroupsFacade>();

        services.AddSingleton<IApprovalWorkflowGroupAdapter, DomesticApprovalWorkflowGroupAdapter>();
    }
}
