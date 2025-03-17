using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Application.Contracts.Statuses;
using Edm.DocumentGenerators.Application.Contracts.Statuses.Parameters;
using Edm.DocumentGenerators.Application.Contracts.Statuses.Parameters.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Statuses.Parameters.Kinds;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.Statuses.Parameters;

internal static class DocumentStatusParameterDtoToInternalConverter
{
    internal static DocumentStatusParameterInternal ToInternal(DocumentStatusParameterDto parameter)
    {
        DocumentStatusParameterKind kind = DocumentStatusParameterKindDtoConverter.ToInternal(parameter.Kind);

        DocumentStatusParameterInternal result = parameter.ValueCase switch
        {
            DocumentStatusParameterDto.ValueOneofCase.AsBoolean => ToBoolean(parameter.AsBoolean, kind),
            DocumentStatusParameterDto.ValueOneofCase.AsString => ToString(parameter.AsString, kind),
            DocumentStatusParameterDto.ValueOneofCase.AsReferenceAttribute => ToReferenceAttribute(parameter.AsReferenceAttribute, kind),
            DocumentStatusParameterDto.ValueOneofCase.AsDocumentStatus => ToDocumentStatus(parameter.AsDocumentStatus, kind),
            _ => throw new ArgumentTypeOutOfRangeException(parameter)
        };

        return result;
    }

    private static BooleanDocumentStatusParameterInternal ToBoolean(BooleanDocumentStatusParameterDto parameter, DocumentStatusParameterKind kind)
    {
        var result = new BooleanDocumentStatusParameterInternal(kind, parameter.Value);

        return result;
    }

    private static StringDocumentStatusParameterInternal ToString(StringDocumentStatusParameterDto parameter, DocumentStatusParameterKind kind)
    {
        var result = new StringDocumentStatusParameterInternal(kind, parameter.Value);

        return result;
    }

    private static ReferenceAttributeDocumentStatusParameterInternal ToReferenceAttribute(
        ReferenceAttributeDocumentStatusParameterDto parameter,
        DocumentStatusParameterKind kind)
    {
        Metadata<ReferenceAttributeDocumentStatusParameterInternal> referenceType =
            MetadataConverterFrom<ReferenceAttributeDocumentStatusParameterInternal>.FromString(parameter.ReferenceType);

        Id<DocumentAttributeInternal>[] values = parameter.Values.Select(IdConverterFrom<DocumentAttributeInternal>.FromString).ToArray();

        var result = new ReferenceAttributeDocumentStatusParameterInternal(kind, referenceType, values, parameter.IsArray);

        return result;
    }

    private static DocumentStatusDocumentStatusParameterInternal ToDocumentStatus(
        DocumentStatusDocumentStatusParameterDto parameter,
        DocumentStatusParameterKind kind)
    {
        Id<DocumentStatusInternal>? value = NullableConverter.Convert(parameter.Value, IdConverterFrom<DocumentStatusInternal>.FromString);

        var result = new DocumentStatusDocumentStatusParameterInternal(kind, value);

        return result;
    }
}
