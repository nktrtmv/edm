using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions.Data;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.References;

public sealed record DocumentReferenceAttributeInternal(
    string[] DefaultValues,
    DocumentAttributeDataInternal Data,
    Metadata<DocumentReferenceAttributeInternal> ReferenceType)
    : DocumentAttributeInternal(Data);
