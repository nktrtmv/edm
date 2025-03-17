using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.DocumentStatus.Types;
using Edm.Document.Searcher.Presentation.Abstractions;

namespace Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.DocumentStatuses.Types;

internal static class GetStepperQueryResponseStepsDocumentStatusTypeConverter
{
    internal static DocumentStatusTypeDto FromInternal(DocumentStatusTypeInternal type)
    {
        var result = type switch
        {
            DocumentStatusTypeInternal.Initial => DocumentStatusTypeDto.Initial,
            DocumentStatusTypeInternal.Backlog => DocumentStatusTypeDto.Backlog,
            DocumentStatusTypeInternal.Simple => DocumentStatusTypeDto.Simple,
            DocumentStatusTypeInternal.Approval => DocumentStatusTypeDto.Approval,
            DocumentStatusTypeInternal.Signing => DocumentStatusTypeDto.Signing,
            DocumentStatusTypeInternal.Completed => DocumentStatusTypeDto.Completed,
            DocumentStatusTypeInternal.Cancelled => DocumentStatusTypeDto.Cancelled,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };

        return result;
    }
}
