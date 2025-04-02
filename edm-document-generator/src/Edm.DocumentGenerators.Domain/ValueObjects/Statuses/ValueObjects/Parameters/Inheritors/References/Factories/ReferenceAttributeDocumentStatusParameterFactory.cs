using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.References.Factories;

public static class ReferenceAttributeDocumentStatusParameterFactory
{
    public static ReferenceAttributeDocumentStatusParameter CreateFrom(
        DocumentStatusParameterKind kind,
        string referenceType,
        Id<DocumentAttribute>[] values,
        bool isArray)
    {
        Metadata<ReferenceAttributeDocumentStatusParameter> referenceTypeMetadata =
            MetadataConverterFrom<ReferenceAttributeDocumentStatusParameter>.FromString(referenceType);

        var result = new ReferenceAttributeDocumentStatusParameter(kind, referenceTypeMetadata, values, isArray);

        return result;
    }
}
