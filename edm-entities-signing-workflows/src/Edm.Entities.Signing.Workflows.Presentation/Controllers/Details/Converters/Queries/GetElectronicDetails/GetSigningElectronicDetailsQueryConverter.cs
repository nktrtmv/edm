using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.Entities.Signing.Workflows.Presentation.Controllers.Details.Converters.Queries.GetElectronicDetails;

internal static class GetSigningElectronicDetailsQueryConverter
{
    internal static GetSigningElectronicDetailsQueryInternal ToInternal(GetSigningElectronicDetailsQuery query)
    {
        Id<SigningInternal> workflowId = IdConverterFrom<SigningInternal>.FromString(query.WorkflowId);

        var result = new GetSigningElectronicDetailsQueryInternal(workflowId);

        return result;
    }
}
