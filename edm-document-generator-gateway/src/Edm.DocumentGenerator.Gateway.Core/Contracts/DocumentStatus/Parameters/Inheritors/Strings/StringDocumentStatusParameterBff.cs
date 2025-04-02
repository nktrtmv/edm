namespace Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters.Inheritors.Strings;

public sealed class StringDocumentStatusParameterBff : DocumentStatusParameterBff
{
    public required string Value { get; init; }
}
