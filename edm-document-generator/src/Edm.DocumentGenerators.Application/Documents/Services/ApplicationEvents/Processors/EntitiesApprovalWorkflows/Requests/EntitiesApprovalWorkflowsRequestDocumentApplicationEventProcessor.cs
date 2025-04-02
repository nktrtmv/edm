using Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.EntitiesApprovalWorkflows.Requests.Converters;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Contracts;
using Edm.DocumentGenerators.GenericSubdomain.Application.Events.Processors.Abstractions;

using Microsoft.Extensions.Logging;

namespace Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.EntitiesApprovalWorkflows.Requests;

internal sealed class EntitiesApprovalWorkflowsRequestDocumentApplicationEventProcessor
    : ApplicationEventProcessorGeneric<Document, EntitiesApprovalWorkflowsRequestDocumentApplicationEvent>
{
    public EntitiesApprovalWorkflowsRequestDocumentApplicationEventProcessor(
        IEntitiesApprovalWorkflowsRequestsSender sender,
        ILogger<EntitiesApprovalWorkflowsRequestDocumentApplicationEventProcessor> logger)
        : base(logger)
    {
        Sender = sender;
    }

    private IEntitiesApprovalWorkflowsRequestsSender Sender { get; }

    protected override async Task OnProcess(
        EntitiesApprovalWorkflowsRequestDocumentApplicationEvent applicationEvent,
        Document document,
        CancellationToken cancellationToken)
    {
        EntitiesApprovalWorkflowsRequestExternal? request = EntitiesApprovalWorkflowsRequestExternalConverter.FromDomain(applicationEvent, document);

        await Sender.Send(request, cancellationToken);
    }
}
