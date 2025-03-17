using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Documents;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetStages.Contracts.Stages.States.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetStages.Contracts.Stages.States;

public sealed class SigningStageStateInternal
{
    public SigningStageStateInternal(SigningStageStatusInternal status, UtcDateTime<SigningDocumentInternal> statusChangedAt)
    {
        Status = status;
        StatusChangedAt = statusChangedAt;
    }

    public SigningStageStatusInternal Status { get; }
    public UtcDateTime<SigningDocumentInternal> StatusChangedAt { get; }
}
