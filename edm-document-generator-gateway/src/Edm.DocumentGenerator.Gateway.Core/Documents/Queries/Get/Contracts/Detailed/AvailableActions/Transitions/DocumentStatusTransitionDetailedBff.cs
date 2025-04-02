using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentStatusTransitions.Parameters;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions.Transitions;

public sealed class DocumentStatusTransitionDetailedBff
{
    public required DocumentStatusBff Status { get; init; }
    public required DocumentStatusTransitionParameterBff[] Parameters { get; init; }
    public required string DisplayName { get; init; }
}
