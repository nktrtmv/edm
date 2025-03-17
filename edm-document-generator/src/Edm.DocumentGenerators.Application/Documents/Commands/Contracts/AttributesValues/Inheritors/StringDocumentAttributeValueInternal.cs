namespace Edm.DocumentGenerators.Application.Documents.Commands.Contracts.AttributesValues.Inheritors;

public sealed record StringDocumentAttributeValueInternal(string AttributeId, string[] Values) : DocumentAttributeValueGenericInternal<string>(AttributeId, Values);
