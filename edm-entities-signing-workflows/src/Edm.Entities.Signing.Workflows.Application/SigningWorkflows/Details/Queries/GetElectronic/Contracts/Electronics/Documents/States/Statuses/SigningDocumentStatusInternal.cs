namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Documents.States.Statuses;

public enum SigningDocumentStatusInternal
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
