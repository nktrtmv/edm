using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions.Data;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;

public sealed record DocumentStringAttribute(string[] DefaultValues, DocumentAttributeData Data) : DocumentAttribute(Data);
