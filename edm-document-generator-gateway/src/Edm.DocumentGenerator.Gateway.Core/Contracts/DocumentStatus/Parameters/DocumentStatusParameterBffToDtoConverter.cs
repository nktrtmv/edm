using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters.Inheritors.Booleans;
using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters.Inheritors.DocumentStatuses;
using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters.Inheritors.ReferenceAttributes;
using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters.Inheritors.Strings;
using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters.Kinds;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters;

internal static class DocumentStatusParameterBffToDtoConverter
{
    internal static DocumentStatusParameterDto ToDto(DocumentStatusParameterBff parameter)
    {
        var kindEnum = Enum.Parse<DocumentStatusParameterKindBff>(parameter.Kind);
        var kind = DocumentStatusParameterKindBffConverter.ToDto(kindEnum);

        var result = parameter switch
        {
            BooleanDocumentStatusParameterBff p => ToBoolean(kind, p),
            StringDocumentStatusParameterBff p => ToString(kind, p),
            ReferenceAttributeDocumentStatusParameterBff p => ToReferenceAttribute(kind, p),
            DocumentStatusDocumentStatusParameterBff p => ToDocumentStatus(kind, p),
            _ => throw new ArgumentTypeOutOfRangeException(parameter)
        };

        return result;
    }

    private static DocumentStatusParameterDto ToBoolean(DocumentStatusParameterKindDto kind, BooleanDocumentStatusParameterBff parameter)
    {
        var asBoolean = new BooleanDocumentStatusParameterDto
        {
            Value = parameter.Value
        };

        var result = new DocumentStatusParameterDto
        {
            Kind = kind,
            AsBoolean = asBoolean
        };

        return result;
    }

    private static DocumentStatusParameterDto ToString(DocumentStatusParameterKindDto kind, StringDocumentStatusParameterBff parameter)
    {
        var asString = new StringDocumentStatusParameterDto
        {
            Value = parameter.Value
        };

        var result = new DocumentStatusParameterDto
        {
            Kind = kind,
            AsString = asString
        };

        return result;
    }

    private static DocumentStatusParameterDto ToReferenceAttribute(DocumentStatusParameterKindDto kind, ReferenceAttributeDocumentStatusParameterBff parameter)
    {
        var asReferenceAttribute = new ReferenceAttributeDocumentStatusParameterDto
        {
            ReferenceType = parameter.ReferenceType,
            Values = { parameter.Values },
            IsArray = parameter.IsArray
        };

        var result = new DocumentStatusParameterDto
        {
            Kind = kind,
            AsReferenceAttribute = asReferenceAttribute
        };

        return result;
    }

    private static DocumentStatusParameterDto ToDocumentStatus(DocumentStatusParameterKindDto kind, DocumentStatusDocumentStatusParameterBff parameter)
    {
        var value = string.IsNullOrEmpty(parameter.Value)
            ? null
            : parameter.Value;

        var asDocumentStatus = new DocumentStatusDocumentStatusParameterDto
        {
            Value = value
        };

        var result = new DocumentStatusParameterDto
        {
            Kind = kind,
            AsDocumentStatus = asDocumentStatus
        };

        return result;
    }
}
