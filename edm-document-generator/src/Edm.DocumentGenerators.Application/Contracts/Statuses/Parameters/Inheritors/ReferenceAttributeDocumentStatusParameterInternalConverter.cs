using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.References;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Contracts.Statuses.Parameters.Inheritors;

internal static class ReferenceAttributeDocumentStatusParameterInternalConverter
{
    internal static ReferenceAttributeDocumentStatusParameterInternal FromDomain(
        DocumentStatusParameterKind kind,
        ReferenceAttributeDocumentStatusParameter p)
    {
        Metadata<ReferenceAttributeDocumentStatusParameterInternal> referenceType =
            MetadataConverterFrom<ReferenceAttributeDocumentStatusParameterInternal>.From(p.ReferenceType);

        Id<DocumentAttributeInternal>[] values = p.Values.Select(IdConverterFrom<DocumentAttributeInternal>.From).ToArray();

        var result = new ReferenceAttributeDocumentStatusParameterInternal(kind, referenceType, values, p.IsArray);

        return result;
    }

    internal static ReferenceAttributeDocumentStatusParameter ToDomain(DocumentStatusParameterKind kind, ReferenceAttributeDocumentStatusParameterInternal p)
    {
        Metadata<ReferenceAttributeDocumentStatusParameter> referenceType = MetadataConverterFrom<ReferenceAttributeDocumentStatusParameter>.From(p.ReferenceType);

        Id<DocumentAttribute>[] values = p.Values.Select(IdConverterFrom<DocumentAttribute>.From).ToArray();

        var result = new ReferenceAttributeDocumentStatusParameter(kind, referenceType, values, p.IsArray);

        return result;
    }
}
