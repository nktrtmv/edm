using Edm.DocumentGenerators.Application.Contracts.DocumentsStagesTypes;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.DocumentsStagesTypes;

internal static class DocumentStageTypeDtoConverter
{
    internal static DocumentStageTypeInternal ToInternal(DocumentStageTypeDto type)
    {
        DocumentStageTypeInternal result = type switch
        {
            DocumentStageTypeDto.Draft => DocumentStageTypeInternal.Draft,
            DocumentStageTypeDto.Backlog => DocumentStageTypeInternal.Backlog,
            DocumentStageTypeDto.ApprovalPreparation => DocumentStageTypeInternal.ApprovalPreparation,
            DocumentStageTypeDto.Approval => DocumentStageTypeInternal.Approval,
            DocumentStageTypeDto.SigningPreparation => DocumentStageTypeInternal.SigningPreparation,
            DocumentStageTypeDto.Signing => DocumentStageTypeInternal.Signing,
            DocumentStageTypeDto.InEffect => DocumentStageTypeInternal.InEffect,
            DocumentStageTypeDto.Cancelled => DocumentStageTypeInternal.Cancelled,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    internal static DocumentStageTypeDto FromInternal(DocumentStageTypeInternal type)
    {
        DocumentStageTypeDto result = type switch
        {
            DocumentStageTypeInternal.Draft => DocumentStageTypeDto.Draft,
            DocumentStageTypeInternal.Backlog => DocumentStageTypeDto.Backlog,
            DocumentStageTypeInternal.ApprovalPreparation => DocumentStageTypeDto.ApprovalPreparation,
            DocumentStageTypeInternal.Approval => DocumentStageTypeDto.Approval,
            DocumentStageTypeInternal.SigningPreparation => DocumentStageTypeDto.SigningPreparation,
            DocumentStageTypeInternal.Signing => DocumentStageTypeDto.Signing,
            DocumentStageTypeInternal.InEffect => DocumentStageTypeDto.InEffect,
            DocumentStageTypeInternal.Cancelled => DocumentStageTypeDto.Cancelled,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
