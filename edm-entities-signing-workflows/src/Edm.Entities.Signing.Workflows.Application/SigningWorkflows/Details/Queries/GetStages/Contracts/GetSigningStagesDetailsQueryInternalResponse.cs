using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetStages.Contracts.Stages;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetStages.Contracts;

public sealed class GetSigningStagesDetailsQueryInternalResponse
{
    public GetSigningStagesDetailsQueryInternalResponse(SigningStageDetailsInternal[] stages)
    {
        Stages = stages;
    }

    public SigningStageDetailsInternal[] Stages { get; }
}
