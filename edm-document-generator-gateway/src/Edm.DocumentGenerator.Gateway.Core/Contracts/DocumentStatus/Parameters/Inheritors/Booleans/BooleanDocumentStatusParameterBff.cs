namespace Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters.Inheritors.Booleans;

public sealed class BooleanDocumentStatusParameterBff : DocumentStatusParameterBff
{
    public required bool Value { get; init; }
}
