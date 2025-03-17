using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.UpdateResponsibleManagers;
using Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Contracts.Inheritors.UpdateResponsibleManagers;

namespace Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.EntitiesSigningWorkflows.Requests.Converters.UpdateResponsibleManager;

internal static class UpdateResponsibleManagerEntitiesSigningWorkflowsRequestExternalConverter
{
    internal static UpdateResponsibleManagerEntitiesSigningWorkflowsRequestExternal FromDomain(
        UpdateResponsibleManagerEntitiesSigningWorkflowsRequestDocumentApplicationEvent applicationEvent,
        Document document)
    {
        var result = new UpdateResponsibleManagerEntitiesSigningWorkflowsRequestExternal(document, applicationEvent.ResponsibleManagerId);

        return result;
    }
}
