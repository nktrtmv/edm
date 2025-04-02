using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetStages.Contracts;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Controllers.Details.Converters.Queries.GetStages.Contracts.Stages;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Details.Converters.Queries.GetStages;

internal static class GetSigningStagesDetailsQueryResponseConverter
{
    internal static GetSigningStagesDetailsQueryResponse FromInternal(GetSigningStagesDetailsQueryInternalResponse response)
    {
        SigningStageDetailsDto[] stages = response.Stages.Select(SigningStageDtoConverter.FromInternal).ToArray();

        var result = new GetSigningStagesDetailsQueryResponse
        {
            Stages = { stages }
        };

        return result;
    }
}
