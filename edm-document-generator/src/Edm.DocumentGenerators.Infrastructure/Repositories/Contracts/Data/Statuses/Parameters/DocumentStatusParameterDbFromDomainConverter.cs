using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.Booleans;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.DocumentStatuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.References;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.Inheritors.Strings;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Statuses.Parameters.Kinds;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Statuses.Parameters;

internal static class DocumentStatusParameterDbFromDomainConverter
{
    internal static DocumentStatusParameterDb FromDomain(DocumentStatusParameter parameter)
    {
        DocumentStatusParameterDb result = parameter switch
        {
            BooleanDocumentStatusParameter p => ToBoolean(p),
            StringDocumentStatusParameter p => ToString(p),
            ReferenceAttributeDocumentStatusParameter p => ToReferenceAttribute(p),
            DocumentStatusDocumentStatusParameter p => ToDocumentStatus(p),
            _ => throw new ArgumentTypeOutOfRangeException(parameter)
        };

        DocumentStatusParameterKindDb kind = DocumentStatusParameterKindDbConverter.FromDomain(parameter.Kind);

        result.Kind = kind;

        return result;
    }

    private static DocumentStatusParameterDb ToBoolean(BooleanDocumentStatusParameter parameter)
    {
        var asBoolean = new BooleanDocumentStatusParameterDb { Value = parameter.Value };

        var result = new DocumentStatusParameterDb
        {
            AsBoolean = asBoolean
        };

        return result;
    }

    private static DocumentStatusParameterDb ToString(StringDocumentStatusParameter parameter)
    {
        var asString = new StringDocumentStatusParameterDb { Value = parameter.Value };

        var result = new DocumentStatusParameterDb
        {
            AsString = asString
        };

        return result;
    }

    private static DocumentStatusParameterDb ToReferenceAttribute(ReferenceAttributeDocumentStatusParameter parameter)
    {
        var referenceType = MetadataConverterTo.ToString(parameter.ReferenceType);

        string[] values = parameter.Values.Select(IdConverterTo.ToString).ToArray();

        var asReferenceAttribute = new ReferenceAttributeDocumentStatusParameterDb
        {
            ReferenceType = referenceType,
            Values = { values },
            IsArray = parameter.IsArray
        };

        var result = new DocumentStatusParameterDb
        {
            AsReferenceAttribute = asReferenceAttribute
        };

        return result;
    }

    private static DocumentStatusParameterDb ToDocumentStatus(DocumentStatusDocumentStatusParameter parameter)
    {
        string? value = NullableConverter.Convert(parameter.Value, IdConverterTo.ToString);

        var asDocumentStatus = new DocumentStatusDocumentStatusParameterDb
        {
            Value = value
        };

        var result = new DocumentStatusParameterDb
        {
            AsDocumentStatus = asDocumentStatus
        };

        return result;
    }
}
