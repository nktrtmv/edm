using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions.Data;

namespace Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Numbers;

public sealed record DocumentNumberAttributeInternal(long[] DefaultValues, DocumentAttributeDataInternal Data, int Precision) : DocumentAttributeInternal(Data);
