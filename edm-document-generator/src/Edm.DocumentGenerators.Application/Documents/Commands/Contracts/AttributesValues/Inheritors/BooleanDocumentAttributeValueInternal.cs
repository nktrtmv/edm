namespace Edm.DocumentGenerators.Application.Documents.Commands.Contracts.AttributesValues.Inheritors;

public sealed record BooleanDocumentAttributeValueInternal(string AttributeId, bool[] Values) : DocumentAttributeValueGenericInternal<bool>(AttributeId, Values);
