using System.Reflection;

using Edm.DocumentGenerators.Application;
using Edm.DocumentGenerators.Application.Contracts.Statuses;
using Edm.DocumentGenerators.Domain;
using Edm.DocumentGenerators.ExternalServices.DocumentsClassifier;
using Edm.DocumentGenerators.ExternalServices.DocumentsNotifier;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows;
using Edm.DocumentGenerators.ExternalServices.EntitiesCounters;
using Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows;
using Edm.DocumentGenerators.GenericSubdomain.Configuration.Fetchers;
using Edm.DocumentGenerators.GenericSubdomain.Options.Kafka;
using Edm.DocumentGenerators.Infrastructure;
using Edm.DocumentGenerators.Presentation.Consumers.EntitiesApprovalWorkflows.Results;
using Edm.DocumentGenerators.Presentation.Consumers.EntitiesSigningWorkflows.Events;
using Edm.DocumentGenerators.Presentation.Consumers.EntitiesSigningWorkflows.Results;
using Edm.DocumentGenerators.Presentation.Controllers.Documents;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsDetails;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsStatusesParameters;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsTech;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplatesDetails;
using Edm.DocumentGenerators.Presentation.Publisher;

using KafkaFlow;

namespace Edm.DocumentGenerators.Presentation;

internal sealed class Startup(IConfiguration configuration)
{
    public void ConfigureServices(IServiceCollection services)
    {
        Assembly assembly = typeof(DocumentStatusInternal).Assembly;

        services.AddControllers();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        services.AddGrpc(options => { options.EnableDetailedErrors = true; });
        services.AddLogging();

        var kafkaOptions = ConfigurationValueFetcher.GetRequired<KafkaOptions>(configuration);

        services.AddKafka(
            kafka => kafka.AddCluster(
                cluster =>
                    cluster
                        .WithBrokers(new[] { kafkaOptions.Broker })
                        .AddConsumer(
                            consumer => consumer
                                .Topic(kafkaOptions.EntitiesApprovalWorkflowsResultsTopic)
                                .WithGroupId(kafkaOptions.ConsumerGroup)
                                .WithBufferSize(10000)
                                .AddMiddlewares(
                                    middlewares => middlewares
                                        .AddTypedHandlers(
                                            handlers =>
                                                handlers
                                                    .WithHandlerLifetime(InstanceLifetime.Singleton)
                                                    .AddHandler<EntitiesApprovalWorkflowsResultsHandler>())))
                        .AddConsumer(
                            consumer => consumer
                                .Topic(kafkaOptions.EntitiesSigningWorkflowsResultsTopic)
                                .WithGroupId(kafkaOptions.ConsumerGroup)
                                .WithBufferSize(10000)
                                .AddMiddlewares(
                                    middlewares => middlewares
                                        .AddTypedHandlers(
                                            handlers =>
                                                handlers
                                                    .WithHandlerLifetime(InstanceLifetime.Singleton)
                                                    .AddHandler<EntitiesSigningWorkflowsResultsHandler>())))
                        .AddConsumer(
                            consumer => consumer
                                .Topic(kafkaOptions.EntitiesSigningWorkflowsEventsTopic)
                                .WithGroupId(kafkaOptions.ConsumerGroup)
                                .WithBufferSize(10000)
                                .AddMiddlewares(
                                    middlewares => middlewares
                                        .AddTypedHandlers(
                                            handlers =>
                                                handlers
                                                    .WithHandlerLifetime(InstanceLifetime.Singleton)
                                                    .AddHandler<EntitiesSigningWorkflowsEventsHandler>())))
                        .ConfigurePublisher(services, kafkaOptions)
                        .ConfigureDocumentNotifier(services, kafkaOptions)
                        .ConfigureEntitiesApprovalWorkflows(services, kafkaOptions)
                        .ConfigureEntitiesSigningWorkflows(services, kafkaOptions)));

        ApplicationServicesRegistrar.Configure(services);
        InfrastructureRegistrar.Configure(services);
        EntitiesCountersIncrementerClientRegistrar.Configure(services);
        EntitiesApprovalRulesRegistrar.Configure(services);
        DocumentClassifierRegistrar.Configure(services);
    }

    public static void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
    {
        app.UseRouting();

        app.UseEndpoints(
            endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGrpcService<DocumentController>();
                endpoints.MapGrpcService<DocumentsTemplatesController>();
                endpoints.MapGrpcService<DocumentsTemplatesDetailsController>();
                endpoints.MapGrpcService<DocumentsDetailsController>();
                endpoints.MapGrpcService<DocumentsStatusesParametersController>();
                endpoints.MapGrpcService<DocumentsTechController>();
            });

        IKafkaBus? eventBus = app.ApplicationServices.CreateKafkaBus();

        lifetime.ApplicationStarted.Register(() => eventBus.StartAsync(lifetime.ApplicationStopped));

        using IServiceScope scope = app.ApplicationServices.CreateScope();

        var warmUpService = scope.ServiceProvider.GetRequiredService<IRoleAdapter>();
        warmUpService.WarmUp(CancellationToken.None).GetAwaiter().GetResult();
    }
}
