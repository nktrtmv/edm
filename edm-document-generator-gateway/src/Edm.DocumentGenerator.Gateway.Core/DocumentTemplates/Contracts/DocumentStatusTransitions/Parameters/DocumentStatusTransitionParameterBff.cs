using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentStatusTransitions.Parameters.Kinds;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentStatusTransitions.Parameters;

public sealed class DocumentStatusTransitionParameterBff
{
    public required DocumentStatusTransitionParameterKindBff Kind { get; init; }
}
