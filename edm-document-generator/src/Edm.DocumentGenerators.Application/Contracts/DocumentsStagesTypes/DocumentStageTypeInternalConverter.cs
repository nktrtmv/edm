using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.StagesTypes;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Application.Contracts.DocumentsStagesTypes;

internal static class DocumentStageTypeInternalConverter
{
    internal static DocumentStageType ToDomain(DocumentStageTypeInternal type)
    {
        DocumentStageType result = type switch
        {
            DocumentStageTypeInternal.Draft => DocumentStageType.Draft,
            DocumentStageTypeInternal.Backlog => DocumentStageType.Backlog,
            DocumentStageTypeInternal.ApprovalPreparation => DocumentStageType.ApprovalPreparation,
            DocumentStageTypeInternal.Approval => DocumentStageType.Approval,
            DocumentStageTypeInternal.SigningPreparation => DocumentStageType.SigningPreparation,
            DocumentStageTypeInternal.Signing => DocumentStageType.Signing,
            DocumentStageTypeInternal.InEffect => DocumentStageType.InEffect,
            DocumentStageTypeInternal.Cancelled => DocumentStageType.Cancelled,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    internal static DocumentStageTypeInternal FromDomain(DocumentStageType type)
    {
        DocumentStageTypeInternal result = type switch
        {
            DocumentStageType.Draft => DocumentStageTypeInternal.Draft,
            DocumentStageType.Backlog => DocumentStageTypeInternal.Backlog,
            DocumentStageType.ApprovalPreparation => DocumentStageTypeInternal.ApprovalPreparation,
            DocumentStageType.Approval => DocumentStageTypeInternal.Approval,
            DocumentStageType.SigningPreparation => DocumentStageTypeInternal.SigningPreparation,
            DocumentStageType.Signing => DocumentStageTypeInternal.Signing,
            DocumentStageType.InEffect => DocumentStageTypeInternal.InEffect,
            DocumentStageType.Cancelled => DocumentStageTypeInternal.Cancelled,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
