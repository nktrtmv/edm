using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions.Data;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;

public sealed record DocumentReferenceAttribute(
    string[] DefaultValues,
    DocumentAttributeData Data,
    Metadata<DocumentReferenceAttribute> ReferenceType) : DocumentAttribute(Data);
