using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Documents.States.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Documents.States;

public sealed class SigningDocumentStateInternal
{
    public SigningDocumentStateInternal(SigningDocumentStatusInternal status, string statusDescription, UtcDateTime<SigningDocumentInternal> statusChangedAt)
    {
        Status = status;
        StatusDescription = statusDescription;
        StatusChangedAt = statusChangedAt;
    }

    public SigningDocumentStatusInternal Status { get; }
    public string StatusDescription { get; }
    public UtcDateTime<SigningDocumentInternal> StatusChangedAt { get; }
}
