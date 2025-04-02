using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.StatusTransitionParametersValues;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts;

public sealed class UpdateDocumentCommandBff
{
    public required DocumentBareBff Document { get; init; }

    public DocumentStatusTransitionParameterValueBff[] StatusTransitionParametersValues { get; init; } = [];
}
