using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentGenerator.Events;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentNotifier.Requests;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.DocumentGenerator.Events;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.DocumentNotifier.Requests;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesApprovalWorkflows.Requests;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesSigningWorkflows.Requests;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents;

internal static class DocumentApplicationEventDbFromDomainConverter
{
    internal static DocumentApplicationEventDb FromDomain(DocumentApplicationEvent applicationEvent)
    {
        var result = new DocumentApplicationEventDb();

        switch (applicationEvent)
        {
            case DocumentGeneratorEventDocumentApplicationEvent e:
                result.AsDocumentGeneratorEvent =
                    DocumentGeneratorEventDocumentApplicationEventDbConverter.FromDomain(e);

                break;

            case DocumentNotifierRequestDocumentApplicationEvent e:
                result.AsDocumentNotifierRequest =
                    DocumentNotifierRequestDocumentApplicationEventDbConverter.FromDomain(e);

                break;

            case EntitiesApprovalWorkflowsRequestDocumentApplicationEvent e:
                result.AsEntitiesApprovalWorkflowsRequest =
                    EntitiesApprovalWorkflowsRequestDocumentApplicationEventDbConverter.FromDomain(e);

                break;

            case EntitiesSigningWorkflowsRequestDocumentApplicationEvent e:
                result.AsEntitiesSigningWorkflowsRequest =
                    EntitiesSigningWorkflowsRequestDocumentApplicationEventDbConverter.FromDomain(e);

                break;

            default:
                throw new ArgumentTypeOutOfRangeException(applicationEvent);
        }

        return result;
    }
}
