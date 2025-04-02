using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions.Data;

namespace Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Tuples;

public sealed record DocumentTupleAttributeInternal(DocumentAttributeDataInternal Data, DocumentAttributeInternal[] InnerAttributes) : DocumentAttributeInternal(Data);
