using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Signings.Stages.Statuses;
using Edm.Document.Searcher.Presentation.Abstractions;

namespace Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Signings.Stages.Statuses;

internal static class DocumentSigningStageStatusConverter
{
    internal static DocumentSigningStageStatusDto FromInternal(DocumentSigningStageStatusInternal status)
    {
        return status switch
        {
            DocumentSigningStageStatusInternal.NotStarted => DocumentSigningStageStatusDto.NotStarted,
            DocumentSigningStageStatusInternal.InProgress => DocumentSigningStageStatusDto.InProgress,
            DocumentSigningStageStatusInternal.Completed => DocumentSigningStageStatusDto.Completed,
            DocumentSigningStageStatusInternal.Signed => DocumentSigningStageStatusDto.Signed,
            DocumentSigningStageStatusInternal.Rejected => DocumentSigningStageStatusDto.Rejected,
            DocumentSigningStageStatusInternal.ReturnedToRework => DocumentSigningStageStatusDto.ReturnedToRework,
            DocumentSigningStageStatusInternal.Withdrawn => DocumentSigningStageStatusDto.Withdrawn,
            DocumentSigningStageStatusInternal.Cancelled => DocumentSigningStageStatusDto.Cancelled,
            DocumentSigningStageStatusInternal.Error => DocumentSigningStageStatusDto.Error,
            DocumentSigningStageStatusInternal.Revocation => DocumentSigningStageStatusDto.Revocation,
            DocumentSigningStageStatusInternal.Revoked => DocumentSigningStageStatusDto.Revoked,
            _ => throw new ArgumentOutOfRangeException(nameof(status), status, "Unknown enum value for DocumentSigningStageStatusInternal")
        };
    }
}
