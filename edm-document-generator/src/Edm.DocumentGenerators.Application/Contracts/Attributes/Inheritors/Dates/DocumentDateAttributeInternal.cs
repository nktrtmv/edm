using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions.Data;

namespace Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Dates;

public sealed record DocumentDateAttributeInternal(DateTime[] DefaultValues, DocumentAttributeDataInternal Data) : DocumentAttributeInternal(Data);
