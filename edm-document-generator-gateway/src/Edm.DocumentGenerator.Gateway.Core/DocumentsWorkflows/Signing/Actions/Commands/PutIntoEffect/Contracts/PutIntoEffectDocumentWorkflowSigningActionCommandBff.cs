using JetBrains.Annotations;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.PutIntoEffect.Contracts;

public sealed class PutIntoEffectDocumentWorkflowSigningActionCommandBff
{
    [UsedImplicitly]
    public required string DomainId { get; init; }

    public required string WorkflowId { get; init; }
}
