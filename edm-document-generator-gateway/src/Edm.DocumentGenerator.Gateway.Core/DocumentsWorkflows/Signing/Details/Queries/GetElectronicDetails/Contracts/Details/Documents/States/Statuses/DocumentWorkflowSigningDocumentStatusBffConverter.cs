using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails.Details.Documents.States.Statuses;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails.Contracts.Details.Documents.States.Statuses;

internal static class DocumentWorkflowSigningDocumentStatusBffConverter
{
    internal static DocumentWorkflowSigningDocumentStatusBff FromExternal(SigningWorkflowDocumentStatusExternal status)
    {
        var result = status switch
        {
            SigningWorkflowDocumentStatusExternal.PendingSelfSigning => DocumentWorkflowSigningDocumentStatusBff.PendingSelfSigning,
            SigningWorkflowDocumentStatusExternal.SignedBySelf => DocumentWorkflowSigningDocumentStatusBff.SignedBySelf,
            SigningWorkflowDocumentStatusExternal.ReadyForSending => DocumentWorkflowSigningDocumentStatusBff.ReadyForSending,
            SigningWorkflowDocumentStatusExternal.RequiredToSign => DocumentWorkflowSigningDocumentStatusBff.RequiredToSign,
            SigningWorkflowDocumentStatusExternal.Sent => DocumentWorkflowSigningDocumentStatusBff.Sent,
            SigningWorkflowDocumentStatusExternal.InProcess => DocumentWorkflowSigningDocumentStatusBff.InProcess,
            SigningWorkflowDocumentStatusExternal.Signed => DocumentWorkflowSigningDocumentStatusBff.Signed,
            SigningWorkflowDocumentStatusExternal.Rejected => DocumentWorkflowSigningDocumentStatusBff.Rejected,
            SigningWorkflowDocumentStatusExternal.Error => DocumentWorkflowSigningDocumentStatusBff.Error,
            SigningWorkflowDocumentStatusExternal.RevocationRequested => DocumentWorkflowSigningDocumentStatusBff.RevocationRequested,
            SigningWorkflowDocumentStatusExternal.RevocationRequired => DocumentWorkflowSigningDocumentStatusBff.RevocationRequired,
            SigningWorkflowDocumentStatusExternal.Revoked => DocumentWorkflowSigningDocumentStatusBff.Revoked,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
