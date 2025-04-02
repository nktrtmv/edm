using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.UpdateOwners;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesApprovalWorkflows.Requests.UpdateOwners;

internal static class UpdateOwnersEntitiesApprovalWorkflowsRequestDbConverter
{
    internal static UpdateOwnersEntitiesApprovalWorkflowsRequestDb FromDomain(UpdateOwnersEntitiesApprovalWorkflowsRequestDocumentApplicationEvent request)
    {
        var ownerId = IdConverterTo.ToString(request.OwnerId);

        var result = new UpdateOwnersEntitiesApprovalWorkflowsRequestDb
        {
            OwnerId = ownerId
        };

        return result;
    }

    internal static UpdateOwnersEntitiesApprovalWorkflowsRequestDocumentApplicationEvent ToDomain(UpdateOwnersEntitiesApprovalWorkflowsRequestDb request)
    {
        Id<User> ownerId = IdConverterFrom<User>.FromString(request.OwnerId);

        var result = new UpdateOwnersEntitiesApprovalWorkflowsRequestDocumentApplicationEvent(ownerId);

        return result;
    }
}
