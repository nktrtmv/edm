using JetBrains.Annotations;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.Cancel.Contracts;

public sealed class CancelDocumentWorkflowSigningActionCommandBff
{
    [UsedImplicitly]
    public required string DomainId { get; init; }

    public required string WorkflowId { get; init; }

    public required string Comment { get; init; }
}
