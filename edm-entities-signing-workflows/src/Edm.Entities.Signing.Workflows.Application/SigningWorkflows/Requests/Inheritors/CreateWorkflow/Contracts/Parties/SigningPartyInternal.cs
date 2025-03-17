using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parties.Markers;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parties.Types;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parties;

public sealed class SigningPartyInternal
{
    public SigningPartyInternal(SigningPartyTypeInternal type, Id<CompanyInternal> companyId, Id<UserInternal> executorId)
    {
        Type = type;
        CompanyId = companyId;
        ExecutorId = executorId;
    }

    public SigningPartyTypeInternal Type { get; }
    public Id<CompanyInternal> CompanyId { get; }
    public Id<UserInternal> ExecutorId { get; }
}
