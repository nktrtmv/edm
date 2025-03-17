namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues.Inheritors;

public class DocumentAttributeValueGenericDetailedBff<T> : DocumentAttributeValueDetailedBff
{
    public required T[] Values { get; set; }
}
