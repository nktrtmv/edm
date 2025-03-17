using JetBrains.Annotations;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.WithdrawByContractor.Contracts;

public sealed class WithdrawByContractorDocumentWorkflowSigningActionCommandBff
{
    [UsedImplicitly]
    public required string DomainId { get; init; }

    public required string WorkflowId { get; init; }

    public required string Comment { get; init; }
}
