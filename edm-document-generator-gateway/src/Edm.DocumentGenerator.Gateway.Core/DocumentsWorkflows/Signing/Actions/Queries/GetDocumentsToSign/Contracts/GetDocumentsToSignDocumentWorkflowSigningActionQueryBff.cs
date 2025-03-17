using JetBrains.Annotations;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Queries.GetDocumentsToSign.Contracts;

public sealed class GetDocumentsToSignDocumentWorkflowSigningActionQueryBff
{
    [UsedImplicitly]
    public required string DomainId { get; init; }

    public required string WorkflowId { get; init; }
}
