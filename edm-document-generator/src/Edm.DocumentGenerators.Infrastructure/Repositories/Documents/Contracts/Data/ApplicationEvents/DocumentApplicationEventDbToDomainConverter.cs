using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.DocumentGenerator.Events;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.DocumentNotifier.Requests;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesApprovalWorkflows.Requests;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesSigningWorkflows.Requests;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents;

internal static class DocumentApplicationEventDbToDomainConverter
{
    internal static DocumentApplicationEvent ToDomain(DocumentApplicationEventDb applicationEvent)
    {
        DocumentApplicationEvent result = applicationEvent.EventCase switch
        {
            DocumentApplicationEventDb.EventOneofCase.AsDocumentGeneratorEvent =>
                DocumentGeneratorEventDocumentApplicationEventDbConverter.ToDomain(applicationEvent.AsDocumentGeneratorEvent),

            DocumentApplicationEventDb.EventOneofCase.AsDocumentNotifierRequest =>
                DocumentNotifierRequestDocumentApplicationEventDbConverter.ToDomain(applicationEvent.AsDocumentNotifierRequest),

            DocumentApplicationEventDb.EventOneofCase.AsEntitiesApprovalWorkflowsRequest =>
                EntitiesApprovalWorkflowsRequestDocumentApplicationEventDbConverter.ToDomain(applicationEvent.AsEntitiesApprovalWorkflowsRequest),

            DocumentApplicationEventDb.EventOneofCase.AsEntitiesSigningWorkflowsRequest =>
                EntitiesSigningWorkflowsRequestDocumentApplicationEventDbConverter.ToDomain(applicationEvent.AsEntitiesSigningWorkflowsRequest),

            _ => throw new ArgumentTypeOutOfRangeException(applicationEvent.EventCase)
        };

        return result;
    }
}
