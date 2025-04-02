using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Stages;

internal static class DocumentStageTypeBffConverter
{
    internal static DocumentStageTypeDto ToDto(DocumentStageTypeBff stageType)
    {
        var result = stageType switch
        {
            DocumentStageTypeBff.Draft => DocumentStageTypeDto.Draft,
            DocumentStageTypeBff.Backlog => DocumentStageTypeDto.Backlog,
            DocumentStageTypeBff.ApprovalPreparation => DocumentStageTypeDto.ApprovalPreparation,
            DocumentStageTypeBff.Approval => DocumentStageTypeDto.Approval,
            DocumentStageTypeBff.SigningPreparation => DocumentStageTypeDto.SigningPreparation,
            DocumentStageTypeBff.Signing => DocumentStageTypeDto.Signing,
            DocumentStageTypeBff.InEffect => DocumentStageTypeDto.InEffect,
            DocumentStageTypeBff.Cancelled => DocumentStageTypeDto.Cancelled,
            _ => throw new ArgumentTypeOutOfRangeException(stageType)
        };

        return result;
    }
}
