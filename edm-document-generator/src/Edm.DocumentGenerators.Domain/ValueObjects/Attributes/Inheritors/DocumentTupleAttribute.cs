using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions.Data;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;

public sealed record DocumentTupleAttribute(DocumentAttributeData Data, DocumentAttribute[] InnerAttributes) : DocumentAttribute(Data);
