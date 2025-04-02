namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetArchiveDetails.Contracts;

public sealed class GetElectronicArchiveDetailsDocumentWorkflowSigningDetailsQueryBffResponse
{
    internal static readonly GetElectronicArchiveDetailsDocumentWorkflowSigningDetailsQueryBffResponse Instance =
        new GetElectronicArchiveDetailsDocumentWorkflowSigningDetailsQueryBffResponse
        {
            ArchiveAttachmentId = null
        };

    public required string? ArchiveAttachmentId { get; init; }
}
