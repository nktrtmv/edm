using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetStages.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetStages.Contracts.Stages;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetStages;

[UsedImplicitly]
internal sealed class GetSigningStagesDetailsQueryInternalHandler
    : IRequestHandler<GetSigningStagesDetailsQueryInternal, GetSigningStagesDetailsQueryInternalResponse>
{
    public GetSigningStagesDetailsQueryInternalHandler(SigningWorkflowsFacade workflows)
    {
        Workflows = workflows;
    }

    private SigningWorkflowsFacade Workflows { get; }

    public async Task<GetSigningStagesDetailsQueryInternalResponse> Handle(
        GetSigningStagesDetailsQueryInternal request,
        CancellationToken cancellationToken)
    {
        Id<SigningWorkflow> workflowId = IdConverterFrom<SigningWorkflow>.From(request.WorkflowId);

        SigningWorkflow workflow = await Workflows.GetRequired(workflowId, cancellationToken);

        SigningStageDetailsInternal[] stages = workflow.State.Stages.Select(SigningStageInternalConverter.FromDomain).ToArray();

        var result = new GetSigningStagesDetailsQueryInternalResponse(stages);

        return result;
    }
}
