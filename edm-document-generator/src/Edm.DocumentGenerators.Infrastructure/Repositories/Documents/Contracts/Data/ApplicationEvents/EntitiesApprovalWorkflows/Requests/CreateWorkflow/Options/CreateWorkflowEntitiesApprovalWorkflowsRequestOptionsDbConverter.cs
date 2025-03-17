using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow.ValueObjects.Options;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents.EntitiesApprovalWorkflows.Requests.CreateWorkflow.Options;

internal static class CreateWorkflowEntitiesApprovalWorkflowsRequestOptionsDbConverter
{
    internal static CreateWorkflowEntitiesApprovalWorkflowsRequestOptionsDb FromDomain(DocumentApprovalOptions options)
    {
        string[] watchersIds = options.WatchersIds.Select(IdConverterTo.ToString).ToArray();

        var result = new CreateWorkflowEntitiesApprovalWorkflowsRequestOptionsDb
        {
            ApprovingWithRemarkIsDisabled = options.ApprovingWithRemarkIsDisabled,
            AutoInProgressAssignmentsIsDisabled = options.AutoInProgressAssignmentsIsDisabled,
            WatchersIds = { watchersIds }
        };

        return result;
    }

    internal static DocumentApprovalOptions ToDomain(CreateWorkflowEntitiesApprovalWorkflowsRequestOptionsDb options)
    {
        Id<User>[] watchersIds = options.WatchersIds?.Select(IdConverterFrom<User>.FromString).ToArray() ?? [];

        var result = new DocumentApprovalOptions(options.ApprovingWithRemarkIsDisabled, options.AutoInProgressAssignmentsIsDisabled, watchersIds);

        return result;
    }
}
