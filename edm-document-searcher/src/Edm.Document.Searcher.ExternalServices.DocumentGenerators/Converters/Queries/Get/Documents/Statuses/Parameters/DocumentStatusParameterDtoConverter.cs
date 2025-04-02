using Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.Statuses.Parameters.Kinds;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters.Inheritors.Booleans;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters.Inheritors.DocumentStatuses;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters.Inheritors.ReferenceAttributes;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters.Inheritors.Strings;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters.Kinds;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.Statuses.Parameters;

internal static class DocumentStatusParameterDtoConverter
{
    internal static DocumentStatusParameterExternal ToExternal(DocumentStatusParameterDto parameter)
    {
        DocumentStatusParameterKindExternal kind = DocumentStatusParameterKindExternalConverter.FromDto(parameter.Kind);

        DocumentStatusParameterExternal result = parameter.ValueCase switch
        {
            DocumentStatusParameterDto.ValueOneofCase.AsBoolean => ToBoolean(kind, parameter.AsBoolean),
            DocumentStatusParameterDto.ValueOneofCase.AsString => ToString(kind, parameter.AsString),
            DocumentStatusParameterDto.ValueOneofCase.AsReferenceAttribute => ToReferenceAttribute(kind, parameter.AsReferenceAttribute),
            DocumentStatusParameterDto.ValueOneofCase.AsDocumentStatus => ToDocumentStatus(kind, parameter.AsDocumentStatus),
            _ => throw new ArgumentTypeOutOfRangeException(parameter)
        };

        result.DisplayName = parameter.Display;

        return result;
    }

    private static DocumentStatusParameterExternal ToBoolean(DocumentStatusParameterKindExternal kind, BooleanDocumentStatusParameterDto parameter)
    {
        var result = new BooleanDocumentStatusParameterExternal
        {
            Kind = kind,
            Value = parameter.Value
        };

        return result;
    }

    private static DocumentStatusParameterExternal ToString(DocumentStatusParameterKindExternal kind, StringDocumentStatusParameterDto parameter)
    {
        var result = new StringDocumentStatusParameterExternal
        {
            Kind = kind,
            Value = parameter.Value
        };

        return result;
    }

    private static DocumentStatusParameterExternal ToReferenceAttribute(DocumentStatusParameterKindExternal kind, ReferenceAttributeDocumentStatusParameterDto parameter)
    {
        var result = new ReferenceAttributeDocumentStatusParameterExternal
        {
            Kind = kind,
            ReferenceType = parameter.ReferenceType,
            Values = parameter.Values.ToArray(),
            IsArray = parameter.IsArray
        };

        return result;
    }

    private static DocumentStatusParameterExternal ToDocumentStatus(DocumentStatusParameterKindExternal kind, DocumentStatusDocumentStatusParameterDto parameter)
    {
        var result = new DocumentStatusDocumentStatusParameterExternal
        {
            Kind = kind,
            Value = parameter.Value
        };

        return result;
    }
}
