using Edm.DocumentGenerators.Application.Documents.Commands.Create.ByClassification.Services.Filters;
using Edm.DocumentGenerators.Application.Documents.Commands.Create.ByClassification.Services.Searchers;
using Edm.DocumentGenerators.Application.Documents.Commands.Create.Services.Creators;
using Edm.DocumentGenerators.Application.Documents.Commands.Create.Services.Creators.Numbering.Counters;
using Edm.DocumentGenerators.Application.Documents.Services;
using Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Preparers.Publish.EntitiesApprovalWorkflows.Requests;
using Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.DocumentGenerator.Events;
using Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.DocumentNotifier.Requests.SendNotification;
using Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.EntitiesApprovalWorkflows.Requests;
using Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.EntitiesSigningWorkflows.Requests;
using Edm.DocumentGenerators.Application.DocumentTemplates.Services;
using Edm.DocumentGenerators.Domain;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.GenericSubdomain.Application.Events.Preparers;
using Edm.DocumentGenerators.GenericSubdomain.Application.Events.Preparers.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain.Application.Events.Processors;
using Edm.DocumentGenerators.GenericSubdomain.Application.Events.Processors.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.DocumentGenerators.Application;

public static class ApplicationServicesRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        services.AddSingleton<TemplatesIdsByClassificationSearcherService>();
        services.AddSingleton<TemplatesIdsByReadyForDocumentCreationFilterService>();
        services.AddSingleton<IDocumentNumberingCounters, DocumentNumberingCounters>();
        services.AddSingleton<DocumentsCreatorService>();

        ConfigureApplicationEvents(services);

        services.AddSingleton<DocumentsFacade>();
        services.AddSingleton<DocumentsTemplatesFacade>();

        services.AddSingleton<RoleAdapter>();
        services.AddSingleton<IRoleAdapter, RoleAdapter>();
    }

    private static void ConfigureApplicationEvents(IServiceCollection services)
    {
        services.AddSingleton<IApplicationEventPreparer<Document>, CreateWorkflowEntitiesApprovalWorkflowsRequestDocumentApplicationEventPreparer>();

        services.AddSingleton<ApplicationEventsPreparer<Document>>();

        services.AddSingleton<IApplicationEventProcessor<Document>, SendNotificationDocumentNotifierRequestDocumentApplicationEventProcessor>();

        services.AddSingleton<IApplicationEventProcessor<Document>, DocumentGeneratorEventDocumentApplicationEventProcessor>();

        services.AddSingleton<IApplicationEventProcessor<Document>, EntitiesApprovalWorkflowsRequestDocumentApplicationEventProcessor>();
        services.AddSingleton<IApplicationEventProcessor<Document>, EntitiesSigningWorkflowsRequestDocumentApplicationEventProcessor>();

        services.AddSingleton<ApplicationEventsProcessor<Document>>();
    }
}
