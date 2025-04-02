namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails.Details.Documents.States.Statuses;

public enum SigningWorkflowDocumentStatusExternal
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
    RevocationRequired = 10,
    RevocationRequested = 11,
    Revoked = 12
}
