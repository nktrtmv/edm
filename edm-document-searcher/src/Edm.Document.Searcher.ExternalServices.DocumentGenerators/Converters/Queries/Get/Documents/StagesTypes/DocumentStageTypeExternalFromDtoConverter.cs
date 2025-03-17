using Edm.Document.Searcher.ExternalServices.Documents.Contracts.StagesTypes;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.StagesTypes;

internal static class DocumentStageTypeExternalFromDtoConverter
{
    internal static DocumentStageTypeExternal FromDto(DocumentStageTypeDto stageType)
    {
        DocumentStageTypeExternal result = stageType switch
        {
            DocumentStageTypeDto.Draft => DocumentStageTypeExternal.Draft,
            DocumentStageTypeDto.Backlog => DocumentStageTypeExternal.Backlog,
            DocumentStageTypeDto.ApprovalPreparation => DocumentStageTypeExternal.ApprovalPreparation,
            DocumentStageTypeDto.Approval => DocumentStageTypeExternal.Approval,
            DocumentStageTypeDto.SigningPreparation => DocumentStageTypeExternal.SigningPreparation,
            DocumentStageTypeDto.Signing => DocumentStageTypeExternal.Signing,
            DocumentStageTypeDto.InEffect => DocumentStageTypeExternal.InEffect,
            DocumentStageTypeDto.Cancelled => DocumentStageTypeExternal.Cancelled,
            _ => throw new ArgumentTypeOutOfRangeException(stageType)
        };

        return result;
    }
}
