using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Validate.Contracts;

public sealed class ValidateDocumentQueryBff
{
    public required DocumentBareBff Document { get; init; }
}
