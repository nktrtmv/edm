namespace Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters.Inheritors.DocumentStatuses;

public sealed class DocumentStatusDocumentStatusParameterBff : DocumentStatusParameterBff
{
    public required string? Value { get; init; }
}
