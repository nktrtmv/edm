using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions.Data;

namespace Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Strings;

public sealed record DocumentStringAttributeInternal(string[] DefaultValues, DocumentAttributeDataInternal Data) : DocumentAttributeInternal(Data);
