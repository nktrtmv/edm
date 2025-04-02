using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions.Data;

namespace Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Booleans;

public sealed record DocumentBooleanAttributeInternal(bool[] DefaultValues, DocumentAttributeDataInternal Data) : DocumentAttributeInternal(Data);
