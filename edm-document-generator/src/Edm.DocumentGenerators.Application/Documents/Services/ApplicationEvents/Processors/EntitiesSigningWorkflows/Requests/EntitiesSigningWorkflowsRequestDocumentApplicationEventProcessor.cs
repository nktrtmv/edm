using Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.EntitiesSigningWorkflows.Requests.Converters;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests;
using Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests;
using Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Contracts;
using Edm.DocumentGenerators.GenericSubdomain.Application.Events.Processors.Abstractions;

using Microsoft.Extensions.Logging;

namespace Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.EntitiesSigningWorkflows.Requests;

internal sealed class EntitiesSigningWorkflowsRequestDocumentApplicationEventProcessor
    : ApplicationEventProcessorGeneric<Document, EntitiesSigningWorkflowsRequestDocumentApplicationEvent>
{
    public EntitiesSigningWorkflowsRequestDocumentApplicationEventProcessor(
        IEntitiesSigningWorkflowsRequestsSender sender,
        ILogger<EntitiesSigningWorkflowsRequestDocumentApplicationEventProcessor> logger)
        : base(logger)
    {
        Sender = sender;
    }

    private IEntitiesSigningWorkflowsRequestsSender Sender { get; }

    protected override async Task OnProcess(
        EntitiesSigningWorkflowsRequestDocumentApplicationEvent applicationEvent,
        Document document,
        CancellationToken cancellationToken)
    {
        EntitiesSigningWorkflowsRequestExternal? request = EntitiesSigningWorkflowsRequestExternalConverter.FromDomain(applicationEvent, document);

        await Sender.Send(request, cancellationToken);
    }
}
