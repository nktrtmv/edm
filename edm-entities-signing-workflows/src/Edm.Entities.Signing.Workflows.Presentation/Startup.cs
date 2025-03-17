using System.Reflection;

using Edm.Entities.Signing.Workflows.Application;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetStages.Contracts.Stages.States.Statuses;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Configuration;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Options.Kafka;
using Edm.Entities.Signing.Workflows.Infrastructure;
using Edm.Entities.Signing.Workflows.Presentation.Consumers.Requests;
using Edm.Entities.Signing.Workflows.Presentation.Consumers.SigningEdxEvents;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Actions;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Details;
using Edm.Entities.Signing.Workflows.Presentation.Publisher;

using KafkaFlow;

namespace Edm.Entities.Signing.Workflows.Presentation;

internal sealed class Startup(IConfiguration configuration)
{
    public void ConfigureServices(IServiceCollection services)
    {
        Assembly assembly = typeof(SigningStageStatusInternal).Assembly;

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
                                .Topic(kafkaOptions.EntitiesSigningWorkflowsRequestsTopic)
                                .WithGroupId(kafkaOptions.ConsumerGroup)
                                .WithBufferSize(10000)
                                .AddMiddlewares(
                                    middlewares => middlewares
                                        .AddTypedHandlers(
                                            handlers =>
                                                handlers
                                                    .WithHandlerLifetime(InstanceLifetime.Singleton)
                                                    .AddHandler<EntitiesSigningWorkflowsRequestsHandler>())))
                        .AddConsumer(
                            consumer => consumer
                                .Topic(kafkaOptions.EntitiesSigningEdxEventsTopic)
                                .WithGroupId(kafkaOptions.ConsumerGroup)
                                .WithBufferSize(10000)
                                .AddMiddlewares(
                                    middlewares => middlewares
                                        .AddTypedHandlers(
                                            handlers =>
                                                handlers
                                                    .WithHandlerLifetime(InstanceLifetime.Singleton)
                                                    .AddHandler<SigningEdxEventsHandler>())))
                        .ConfigurePublisher(services, kafkaOptions)
                        .ConfigureEntitiesSigningEdx(services, kafkaOptions)));

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
                endpoints.MapGrpcService<SigningActionsController>();
                endpoints.MapGrpcService<SigningDetailsController>();
            });

        IKafkaBus? eventBus = app.ApplicationServices.CreateKafkaBus();

        lifetime.ApplicationStarted.Register(() => eventBus.StartAsync(lifetime.ApplicationStopped));
    }
}
