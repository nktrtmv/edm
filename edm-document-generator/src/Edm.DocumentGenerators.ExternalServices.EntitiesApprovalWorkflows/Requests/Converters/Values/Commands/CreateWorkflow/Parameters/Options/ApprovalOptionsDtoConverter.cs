using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow.ValueObjects.Options;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Converters.Values.Commands.CreateWorkflow.Parameters.Options;

internal static class ApprovalOptionsDtoConverter
{
    internal static ApprovalOptionsDto FromDomain(DocumentApprovalOptions options)
    {
        string[] watchersIds = options.WatchersIds.Select(IdConverterTo.ToString).ToArray();

        var result = new ApprovalOptionsDto
        {
            ApprovingWithRemarkIsDisabled = options.ApprovingWithRemarkIsDisabled,
            AutoInProgressAssignmentsIsDisabled = options.AutoInProgressAssignmentsIsDisabled,
            AutoDelegatingIsDisabled = false,
            WatchersIds = { watchersIds }
        };

        return result;
    }
}
