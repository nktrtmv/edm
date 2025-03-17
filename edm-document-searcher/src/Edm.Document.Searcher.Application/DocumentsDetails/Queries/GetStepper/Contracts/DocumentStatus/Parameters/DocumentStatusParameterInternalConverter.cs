using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Parameters.Inheritors.Booleans;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Parameters.Inheritors.DocumentStatuses;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Parameters.Inheritors.ReferenceAttributes;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Parameters.Inheritors.Strings;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Parameters.Kinds;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters.Inheritors.Booleans;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters.Inheritors.DocumentStatuses;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters.Inheritors.ReferenceAttributes;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Parameters.Inheritors.Strings;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Parameters;

internal static class DocumentStatusParameterInternalConverter
{
    internal static DocumentStatusParameterInternal FromExternal(DocumentStatusParameterExternal parameter)
    {
        var kind = DocumentStatusParameterKindInternalConverter.FromExternal(parameter.Kind).ToString();

        DocumentStatusParameterInternal result = parameter switch
        {
            BooleanDocumentStatusParameterExternal external => ToBoolean(kind, external),
            StringDocumentStatusParameterExternal external => ToString(kind, external),
            ReferenceAttributeDocumentStatusParameterExternal external => ToReferenceAttribute(kind, external),
            DocumentStatusDocumentStatusParameterExternal external => ToDocumentStatus(kind, external),
            _ => throw new ArgumentTypeOutOfRangeException(parameter)
        };

        result.DisplayName = parameter.DisplayName;

        return result;
    }

    private static BooleanDocumentStatusParameterInternal ToBoolean(string kind, BooleanDocumentStatusParameterExternal parameter)
    {
        var result = new BooleanDocumentStatusParameterInternal
        {
            Kind = kind,
            Value = parameter.Value
        };

        return result;
    }

    private static StringDocumentStatusParameterInternal ToString(string kind, StringDocumentStatusParameterExternal parameter)
    {
        var result = new StringDocumentStatusParameterInternal
        {
            Kind = kind,
            Value = parameter.Value
        };

        return result;
    }

    private static ReferenceAttributeDocumentStatusParameterInternal ToReferenceAttribute(string kind, ReferenceAttributeDocumentStatusParameterExternal parameter)
    {
        var result = new ReferenceAttributeDocumentStatusParameterInternal
        {
            Kind = kind,
            ReferenceType = parameter.ReferenceType,
            Values = parameter.Values.ToArray(),
            IsArray = parameter.IsArray
        };

        return result;
    }

    private static DocumentStatusDocumentStatusParameterInternal ToDocumentStatus(string kind, DocumentStatusDocumentStatusParameterExternal parameter)
    {
        var result = new DocumentStatusDocumentStatusParameterInternal
        {
            Kind = kind,
            Value = parameter.Value
        };

        return result;
    }
}
