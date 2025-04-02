using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus;
using Edm.Document.Searcher.Presentation.Abstractions;
using Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.DocumentStatuses.Parameters;
using Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.DocumentStatuses.Types;

namespace Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.DocumentStatuses;

internal static class GetStepperQueryResponseStepsDocumentStatusConverter
{
    internal static DocumentStatusDto FromInternal(DocumentStatusInternal status)
    {
        var statusType = GetStepperQueryResponseStepsDocumentStatusTypeConverter.FromInternal(status.Type);
        var parameters = status.Parameters.Select(GetStepperQueryResponseStepsDocumentStatusParameterConverter.FromInternal).ToArray();

        var result = new DocumentStatusDto
        {
            Id = status.Id,
            DisplayName = status.DisplayName,
            SystemName = status.SystemName,
            Type = statusType,
            Parameters = { parameters }
        };

        return result;
    }
}
