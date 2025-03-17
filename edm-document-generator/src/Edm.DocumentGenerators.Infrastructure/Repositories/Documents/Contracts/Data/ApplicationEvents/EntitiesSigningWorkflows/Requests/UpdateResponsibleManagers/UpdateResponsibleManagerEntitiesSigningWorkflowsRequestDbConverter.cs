using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesSigningWorkflows.Requests.UpdateResponsibleManagers;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesSigningWorkflows.Requests.UpdateResponsibleManagers;

internal static class UpdateResponsibleManagerEntitiesSigningWorkflowsRequestDbConverter
{
    internal static UpdateResponsibleManagerEntitiesSigningWorkflowsRequestDb FromDomain(
        UpdateResponsibleManagerEntitiesSigningWorkflowsRequestDocumentApplicationEvent request)
    {
        var responsibleManagerId = IdConverterTo.ToString(request.ResponsibleManagerId);

        var result = new UpdateResponsibleManagerEntitiesSigningWorkflowsRequestDb
        {
            ResponsibleManagerId = responsibleManagerId
        };

        return result;
    }

    internal static UpdateResponsibleManagerEntitiesSigningWorkflowsRequestDocumentApplicationEvent ToDomain(
        UpdateResponsibleManagerEntitiesSigningWorkflowsRequestDb request)
    {
        Id<User> responsibleManagerId = IdConverterFrom<User>.FromString(request.ResponsibleManagerId);

        var result = new UpdateResponsibleManagerEntitiesSigningWorkflowsRequestDocumentApplicationEvent(responsibleManagerId);

        return result;
    }
}
