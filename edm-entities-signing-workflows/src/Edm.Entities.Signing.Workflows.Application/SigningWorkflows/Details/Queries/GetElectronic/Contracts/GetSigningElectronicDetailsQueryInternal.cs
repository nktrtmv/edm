using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

using MediatR;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts;

public sealed class GetSigningElectronicDetailsQueryInternal : IRequest<GetSigningElectronicDetailsQueryInternalResponse>
{
    public GetSigningElectronicDetailsQueryInternal(Id<SigningInternal> workflowId)
    {
        WorkflowId = workflowId;
    }

    internal Id<SigningInternal> WorkflowId { get; }
}
