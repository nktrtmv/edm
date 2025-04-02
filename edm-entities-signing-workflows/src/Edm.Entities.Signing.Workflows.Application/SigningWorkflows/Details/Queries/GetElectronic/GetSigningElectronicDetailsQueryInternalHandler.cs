using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic;

[UsedImplicitly]
internal sealed class GetSigningElectronicDetailsQueryInternalHandler
    : IRequestHandler<GetSigningElectronicDetailsQueryInternal, GetSigningElectronicDetailsQueryInternalResponse>
{
    public GetSigningElectronicDetailsQueryInternalHandler(SigningWorkflowsFacade workflows)
    {
        Workflows = workflows;
    }

    private SigningWorkflowsFacade Workflows { get; }

    public async Task<GetSigningElectronicDetailsQueryInternalResponse> Handle(
        GetSigningElectronicDetailsQueryInternal request,
        CancellationToken cancellationToken)
    {
        Id<SigningWorkflow> workflowId = IdConverterFrom<SigningWorkflow>.From(request.WorkflowId);

        SigningWorkflow workflow = await Workflows.GetRequired(workflowId, cancellationToken);

        SigningElectronicDetailsInternal? details =
            NullableConverter.Convert(workflow.Parameters.ElectronicDetails, SigningElectronicDetailsInternalConverter.FromDomain);

        var result = new GetSigningElectronicDetailsQueryInternalResponse(details);

        return result;
    }
}
