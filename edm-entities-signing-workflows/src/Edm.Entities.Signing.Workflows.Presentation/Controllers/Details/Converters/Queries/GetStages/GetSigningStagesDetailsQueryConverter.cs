using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetStages.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Details.Converters.Queries.GetStages;

internal static class GetSigningStagesDetailsQueryConverter
{
    internal static GetSigningStagesDetailsQueryInternal ToInternal(GetSigningStagesDetailsQuery query)
    {
        Id<SigningInternal> workflowId = IdConverterFrom<SigningInternal>.FromString(query.WorkflowId);

        var result = new GetSigningStagesDetailsQueryInternal(workflowId);

        return result;
    }
}
