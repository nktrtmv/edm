using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Parameters;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Parameters.Inheritors.Booleans;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Parameters.Inheritors.DocumentStatuses;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Parameters.Inheritors.ReferenceAttributes;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Parameters.Inheritors.Strings;
using Edm.Document.Searcher.Presentation.Abstractions;

namespace Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.DocumentStatuses.Parameters;

internal static class GetStepperQueryResponseStepsDocumentStatusParameterConverter
{
    internal static DocumentStatusParameterDto FromInternal(DocumentStatusParameterInternal statusParameter)
    {
        var result = statusParameter switch
        {
            BooleanDocumentStatusParameterInternal parameter => AsBoolean(parameter),
            StringDocumentStatusParameterInternal parameter => AsString(parameter),
            ReferenceAttributeDocumentStatusParameterInternal parameter => AsReferenceAttribute(parameter),
            DocumentStatusDocumentStatusParameterInternal parameter => AsDocumentStatus(parameter),
            _ => throw new ArgumentOutOfRangeException()
        };

        result.Kind = statusParameter.Kind;
        result.DisplayName = statusParameter.DisplayName;

        return result;
    }

    private static DocumentStatusParameterDto AsBoolean(BooleanDocumentStatusParameterInternal statusParameter)
    {
        var result = new DocumentStatusParameterDto
        {
            AsBoolean = new BooleanDocumentStatusParameterDto
            {
                Value = statusParameter.Value
            }
        };

        return result;
    }

    private static DocumentStatusParameterDto AsString(StringDocumentStatusParameterInternal statusParameter)
    {
        var result = new DocumentStatusParameterDto
        {
            AsString = new StringDocumentStatusParameterDto
            {
                Value = statusParameter.Value
            }
        };

        return result;
    }

    private static DocumentStatusParameterDto AsReferenceAttribute(ReferenceAttributeDocumentStatusParameterInternal statusParameter)
    {
        var result = new DocumentStatusParameterDto
        {
            AsReferenceAttribute = new ReferenceAttributeDocumentStatusParameterDto
            {
                ReferenceType = statusParameter.ReferenceType,
                Values = { statusParameter.Values ?? Array.Empty<string>() },
                IsArray = statusParameter.IsArray
            }
        };

        return result;
    }

    private static DocumentStatusParameterDto AsDocumentStatus(DocumentStatusDocumentStatusParameterInternal statusParameter)
    {
        var result = new DocumentStatusParameterDto
        {
            AsDocumentStatus = new DocumentStatusDocumentStatusParameterDto
            {
                Value = statusParameter.Value ?? string.Empty
            }
        };

        return result;
    }
}
