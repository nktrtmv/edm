using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions.Signing.Kinds;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions.Signing;

public sealed class DocumentWorkflowSigningActionBff
{
    public required DocumentWorkflowSigningActionKindBff Kind { get; init; }
    public string? ValidateStatusId { get; init; }
}
