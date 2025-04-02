using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Contracts.AttributesValues.Inheritors;

public sealed record DateDocumentAttributeValueInternal(string AttributeId, UtcDateTime<DateDocumentAttributeValueInternal>[] Values)
    : DocumentAttributeValueGenericInternal<UtcDateTime<DateDocumentAttributeValueInternal>>(AttributeId, Values);
