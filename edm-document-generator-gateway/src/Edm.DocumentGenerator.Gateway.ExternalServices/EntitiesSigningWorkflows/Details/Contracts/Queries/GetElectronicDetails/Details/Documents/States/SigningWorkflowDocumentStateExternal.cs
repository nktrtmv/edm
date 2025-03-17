using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails.Details.Documents.States.Statuses;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails.Details.Documents.States;

public sealed class SigningWorkflowDocumentStateExternal
{
    public SigningWorkflowDocumentStateExternal(SigningWorkflowDocumentStatusExternal status, string statusDescription, DateTime statusChangedAt)
    {
        Status = status;
        StatusDescription = statusDescription;
        StatusChangedAt = statusChangedAt;
    }

    public SigningWorkflowDocumentStatusExternal Status { get; }
    public string StatusDescription { get; }
    public DateTime StatusChangedAt { get; }
}
