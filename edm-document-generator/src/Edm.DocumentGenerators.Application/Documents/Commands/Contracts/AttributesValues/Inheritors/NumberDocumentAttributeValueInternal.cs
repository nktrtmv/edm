using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Contracts.AttributesValues.Inheritors;

public sealed record NumberDocumentAttributeValueInternal(string AttributeId, Number<NumberDocumentAttributeValueInternal>[] Values)
    : DocumentAttributeValueGenericInternal<Number<NumberDocumentAttributeValueInternal>>(AttributeId, Values);
