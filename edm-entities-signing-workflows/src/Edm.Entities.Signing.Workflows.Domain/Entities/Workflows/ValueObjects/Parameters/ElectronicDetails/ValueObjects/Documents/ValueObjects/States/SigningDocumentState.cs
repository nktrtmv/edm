using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.ValueObjects.States;

public sealed class SigningDocumentState
{
    internal SigningDocumentState(SigningDocumentStatus status, string statusDescription, UtcDateTime<SigningDocument> statusChangedAt)
    {
        Status = status;
        StatusDescription = statusDescription;
        StatusChangedAt = statusChangedAt;
    }

    public SigningDocumentStatus Status { get; private set; }
    public string StatusDescription { get; }
    public UtcDateTime<SigningDocument> StatusChangedAt { get; }

    public void SetStatus(SigningDocumentStatus status)
    {
        Status = status;
    }
}
