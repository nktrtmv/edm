namespace Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.AttributesValues;

public class DocumentAttributeValueGenericBareBff<T>
    : DocumentAttributeValueBareBff
{
    public required T[] Values { get; init; }
}
