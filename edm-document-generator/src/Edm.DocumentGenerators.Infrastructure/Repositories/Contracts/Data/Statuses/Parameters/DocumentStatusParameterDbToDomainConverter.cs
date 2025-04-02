using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.Booleans;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.DocumentStatuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.DocumentStatuses.Factories;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.References;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.Strings;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Statuses.Parameters.Kinds;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Statuses.Parameters;

internal static class DocumentStatusParameterDbToDomainConverter
{
    internal static DocumentStatusParameter ToDomain(DocumentStatusParameterDb parameter)
    {
        DocumentStatusParameterKind kind = DocumentStatusParameterKindDbConverter.ToDomain(parameter.Kind);

        DocumentStatusParameter result = parameter.ValueCase switch
        {
            DocumentStatusParameterDb.ValueOneofCase.AsBoolean => ToBoolean(parameter.AsBoolean, kind),
            DocumentStatusParameterDb.ValueOneofCase.AsString => ToString(parameter.AsString, kind),
            DocumentStatusParameterDb.ValueOneofCase.AsReferenceAttribute => ToReferenceAttribute(parameter.AsReferenceAttribute, kind),
            DocumentStatusParameterDb.ValueOneofCase.AsDocumentStatus => ToDocumentStatus(parameter.AsDocumentStatus, kind),
            _ => throw new ArgumentTypeOutOfRangeException(parameter)
        };

        return result;
    }

    private static BooleanDocumentStatusParameter ToBoolean(BooleanDocumentStatusParameterDb parameter, DocumentStatusParameterKind kind)
    {
        var result = new BooleanDocumentStatusParameter(kind, parameter.Value);

        return result;
    }

    private static StringDocumentStatusParameter ToString(StringDocumentStatusParameterDb parameter, DocumentStatusParameterKind kind)
    {
        var result = new StringDocumentStatusParameter(kind, parameter.Value);

        return result;
    }

    private static ReferenceAttributeDocumentStatusParameter ToReferenceAttribute(ReferenceAttributeDocumentStatusParameterDb parameter, DocumentStatusParameterKind kind)
    {
        Metadata<ReferenceAttributeDocumentStatusParameter> referenceType =
            MetadataConverterFrom<ReferenceAttributeDocumentStatusParameter>.FromString(parameter.ReferenceType);

        Id<DocumentAttribute>[] values;

        if (parameter.ValueObsolete is not null)
        {
            Id<DocumentAttribute> obsoleteValue = IdConverterFrom<DocumentAttribute>.FromString(parameter.ValueObsolete);

            values = [obsoleteValue];
        }
        else
        {
            values = parameter.Values.Select(IdConverterFrom<DocumentAttribute>.FromString).ToArray();
        }

        var result = new ReferenceAttributeDocumentStatusParameter(kind, referenceType, values, parameter.IsArray);

        return result;
    }

    private static DocumentStatusDocumentStatusParameter ToDocumentStatus(DocumentStatusDocumentStatusParameterDb parameter, DocumentStatusParameterKind kind)
    {
        Id<DocumentStatus>? value =
            NullableConverter.Convert(parameter.Value, IdConverterFrom<DocumentStatus>.FromString);

        DocumentStatusDocumentStatusParameter result =
            DocumentStatusDocumentStatusParameterFactory.CreateFromDb(kind, value);

        return result;
    }
}
