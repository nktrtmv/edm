using JetBrains.Annotations;

using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.Sign.Contracts.DocumentsWithSignatures;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.Sign.Contracts;

public sealed class SignDocumentWorkflowSigningActionCommandBff
{
    [UsedImplicitly]
    public required string DomainId { get; init; }

    public required string WorkflowId { get; init; }

    public required DocumentWorkflowSigningDocumentWithSignatureBff[] Documents { get; init; }
}
