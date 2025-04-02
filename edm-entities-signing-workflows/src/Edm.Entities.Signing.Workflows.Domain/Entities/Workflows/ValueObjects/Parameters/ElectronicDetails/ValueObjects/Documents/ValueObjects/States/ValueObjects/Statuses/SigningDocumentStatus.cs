namespace Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails.ValueObjects.Documents.ValueObjects.States.ValueObjects.
    Statuses;

public enum SigningDocumentStatus
{
    None = 0,
    PendingSelfSigning = 1,
    SignedBySelf = 2,
    ReadyForSending = 3,
    RequiredToSign = 4,
    Sent = 5,
    InProcess = 6,
    Signed = 7,
    Rejected = 8,
    Error = 9,
    RevocationRequested = 10,
    RevocationRequired = 11,
    Revoked = 12
}
