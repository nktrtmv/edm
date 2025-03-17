using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Signings.Stages.Types;
using Edm.Document.Searcher.Presentation.Abstractions;

namespace Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Signings.Stages.Types;

internal static class DocumentSigningStageTypeConverter
{
    internal static DocumentSigningStageTypeDto FromInternal(
        DocumentSigningStageTypeInternal stageType)
    {
        return stageType switch
        {
            DocumentSigningStageTypeInternal.Self => DocumentSigningStageTypeDto.Self,
            DocumentSigningStageTypeInternal.Contractor => DocumentSigningStageTypeDto.Contractor,
            _ => throw new ArgumentOutOfRangeException(nameof(stageType), stageType, "Unknown enum value for DocumentSigningStageTypeInternal")
        };
    }
}
