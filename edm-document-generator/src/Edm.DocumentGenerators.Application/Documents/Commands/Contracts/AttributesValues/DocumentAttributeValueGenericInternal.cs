namespace Edm.DocumentGenerators.Application.Documents.Commands.Contracts.AttributesValues;

public abstract record DocumentAttributeValueGenericInternal<T>(string AttributeId, T[] Values) : DocumentAttributeValueInternal(AttributeId);
