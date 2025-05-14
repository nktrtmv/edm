using Edm.Document.Searcher.Application;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier;
using Edm.Document.Searcher.ExternalServices.DocumentGenerators;
using Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows;
using Edm.Document.Searcher.ExternalServices.Entities.Signing.Workflows;
using Edm.Document.Searcher.GenericSubdomain.Configuration;
using Edm.Document.Searcher.GenericSubdomain.Options.Kafka;
using Edm.Document.Searcher.Infrastructure;
using Edm.Document.Searcher.Infrastructure.Abstractions;
using Edm.Document.Searcher.Presentation.Consumers.DocumentGenerator.Events;
using Edm.Document.Searcher.Presentation.Consumers.EntitiesApprovalWorkflows.Events;
using Edm.Document.Searcher.Presentation.Consumers.EntitiesSigningWorkflows.Events;
using Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails;
using Edm.Document.Searcher.Presentation.Controllers.SearchDocuments;
using Edm.Document.Searcher.Presentation.Producers;

using KafkaFlow;
using KafkaFlow.Retry;

namespace Edm.Document.Searcher.Presentation;

internal sealed class Startup(IConfiguration configuration)
{
    public void ConfigureServices(IServiceCollection services)
    {
        var assembly = typeof(DocumentStatusInternal).Assembly;

        services.AddControllers();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        services.AddGrpc(options => { options.EnableDetailedErrors = true; });
        services.AddLogging();
        services.AddMemoryCache();

        var kafkaOptions = ConfigurationValueFetcher.GetRequired<KafkaOptions>(configuration);

        services.AddKafka(
            kafka => kafka.AddCluster(
                cluster =>
                    cluster
                        .WithBrokers([kafkaOptions.Broker])
                        .AddConsumer(
                            consumer => consumer
                                .Topic(kafkaOptions.EdmEntitiesApprovalWorkflowsEventsTopic)
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
                                                    .AddHandler<EntitiesApprovalWorkflowsEventsHandler>())))
                        .AddConsumer(
                            consumer => consumer
                                .Topic(kafkaOptions.EdmEntitiesSigningWorkflowsEventsTopic)
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
                                                    .AddHandler<EntitiesSigningWorkflowsEventsHandler>())))
                        .AddConsumer(
                            consumer => consumer
                                .Topic(kafkaOptions.EdmDocumentGeneratorEventsTopic)
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
                                                    .AddHandler<DocumentGeneratorEventsHandler>())))
                        .AddProducer<SearcherEventsProducer>(producer => producer.DefaultTopic(kafkaOptions.DocumentSearcherEventsTopic))));
        services.AddSingleton<ISearcherEventsProducer, SearcherEventsProducer>();

        DocumentsClientRegistrar.Configure(services);
        DocumentClassifierRegistrar.Configure(services);
        ApprovalWorkflowsClientRegistrar.Configure(services);
        SigningClientsRegistrar.Configure(services);

        ApplicationServicesRegistrar.Configure(services);
        InfrastructureRegistrar.Configure(services);
    }

    public static void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
    {
        app.UseRouting();

        app.UseEndpoints(
            endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGrpcService<SearchDocumentsController>();
                endpoints.MapGrpcService<DocumentsDetailsController>();
            });

        var eventBus = app.ApplicationServices.CreateKafkaBus();

        lifetime.ApplicationStarted.Register(() => eventBus.StartAsync(lifetime.ApplicationStopped));
    }
}
