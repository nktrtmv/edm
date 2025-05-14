using Edm.Entities.Approval.Workflows.Application;
using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Configuration.Configuration.Fetchers;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Options.Kafka;
using Edm.Entities.Approval.Workflows.Infrastructure;
using Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests;
using Edm.Entities.Approval.Workflows.Presentation.Controllers;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Actions;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Details;
using Edm.Entities.Approval.Workflows.Presentation.Publisher;

using KafkaFlow;
using KafkaFlow.Retry;

namespace Edm.Entities.Approval.Workflows.Presentation;

internal sealed class Startup(IConfiguration configuration)
{
    public void ConfigureServices(IServiceCollection services)
    {
        var assembly = typeof(ApprovalWorkflowInternal).Assembly;

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
                                .Topic(kafkaOptions.EntitiesApprovalWorkflowsRequestsTopic)
                                .WithGroupId(kafkaOptions.ConsumerGroup)
                                .WithBufferSize(10000)
                                .AddMiddlewares(
                                    middlewares => middlewares
                                        .RetryForever(options => options
                                            .WithTimeBetweenTriesPlan(TimeSpan.FromSeconds(5))
                                            .HandleAnyException()
                                        )
                                        .AddTypedHandlers(
                                            handlers =>
                                                handlers
                                                    .WithHandlerLifetime(InstanceLifetime.Singleton)
                                                    .AddHandler<EntitiesApprovalWorkflowsRequestsHandler>())))
                        .ConfigurePublisher(services, kafkaOptions)));

        ApplicationRegistrar.Configure(services);
        InfrastructureRegistrar.Configure(services);
    }

    public static void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
    {
        app.UseRouting();

        app.UseEndpoints(
            endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGrpcService<EntitiesApprovalWorkflowsActionsController>();
                endpoints.MapGrpcService<EntitiesApprovalWorkflowsDetailsController>();
                endpoints.MapGrpcService<EntitiesApprovalWorkflowsController>();
            });

        var eventBus = app.ApplicationServices.CreateKafkaBus();

        lifetime.ApplicationStarted.Register(() => eventBus.StartAsync(lifetime.ApplicationStopped));
    }
}
