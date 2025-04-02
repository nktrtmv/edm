using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

using MediatR;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetStages.Contracts;

public sealed class GetSigningStagesDetailsQueryInternal : IRequest<GetSigningStagesDetailsQueryInternalResponse>
{
    public GetSigningStagesDetailsQueryInternal(Id<SigningInternal> workflowId)
    {
        WorkflowId = workflowId;
    }

    internal Id<SigningInternal> WorkflowId { get; }
}
