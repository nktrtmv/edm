using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters.Inheritors.Booleans;
using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters.Inheritors.DocumentStatuses;
using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters.Inheritors.ReferenceAttributes;
using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters.Inheritors.Strings;
using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters.Kinds;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters;

internal static class DocumentStatusParameterBffFromDtoConverter
{
    internal static DocumentStatusParameterBff FromDto(DocumentStatusParameterDto parameter)
    {
        var kind = DocumentStatusParameterKindBffConverter.FromDto(parameter.Kind).ToString();

        var result = parameter.ValueCase switch
        {
            DocumentStatusParameterDto.ValueOneofCase.AsBoolean => ToBoolean(kind, parameter.AsBoolean),
            DocumentStatusParameterDto.ValueOneofCase.AsString => ToString(kind, parameter.AsString),
            DocumentStatusParameterDto.ValueOneofCase.AsReferenceAttribute => ToReferenceAttribute(kind, parameter.AsReferenceAttribute),
            DocumentStatusParameterDto.ValueOneofCase.AsDocumentStatus => ToDocumentStatus(kind, parameter.AsDocumentStatus),
            _ => throw new ArgumentTypeOutOfRangeException(parameter)
        };

        result.DisplayName = parameter.Display;
        result.Description = parameter.Description;
        result.Group = parameter.Group;

        return result;
    }

    private static DocumentStatusParameterBff ToBoolean(string kind, BooleanDocumentStatusParameterDto parameter)
    {
        var result = new BooleanDocumentStatusParameterBff
        {
            Kind = kind,
            Value = parameter.Value
        };

        return result;
    }

    private static DocumentStatusParameterBff ToString(string kind, StringDocumentStatusParameterDto parameter)
    {
        var result = new StringDocumentStatusParameterBff
        {
            Kind = kind,
            Value = parameter.Value
        };

        return result;
    }

    private static DocumentStatusParameterBff ToReferenceAttribute(string kind, ReferenceAttributeDocumentStatusParameterDto parameter)
    {
        var result = new ReferenceAttributeDocumentStatusParameterBff
        {
            Kind = kind,
            ReferenceType = parameter.ReferenceType,
            Values = parameter.Values.ToArray(),
            IsArray = parameter.IsArray
        };

        return result;
    }

    private static DocumentStatusParameterBff ToDocumentStatus(string kind, DocumentStatusDocumentStatusParameterDto parameter)
    {
        var result = new DocumentStatusDocumentStatusParameterBff
        {
            Kind = kind,
            Value = parameter.Value
        };

        return result;
    }
}
