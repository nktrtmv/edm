using Edm.DocumentGenerators.Application.Documents.Commands.Contracts.AttributesValues.Inheritors.InnerValues;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Contracts.AttributesValues.Inheritors;

public sealed record TupleDocumentAttributeValueInternal(string AttributeId, TupleInnerValueDocumentAttributeValueInternal[] Values)
    : DocumentAttributeValueGenericInternal<TupleInnerValueDocumentAttributeValueInternal>(AttributeId, Values);
