using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.Document.Classifier.ExternalServices.DocumentGenerators.Converters.DocumentsStagesTypes;

internal static class DocumentStageTypeDtoConverter
{
    internal static string FromDto(DocumentStageTypeDto stageType)
    {
        var result = "Статус: " + stageType switch
        {
            DocumentStageTypeDto.Draft => "Черновик",
            DocumentStageTypeDto.Backlog => "Ожидает обработки",
            DocumentStageTypeDto.ApprovalPreparation => "Подготовка к согласованию",
            DocumentStageTypeDto.Approval => "На согласовании",
            DocumentStageTypeDto.SigningPreparation => "Подготовка к подписанию",
            DocumentStageTypeDto.Signing => "На подписании",
            DocumentStageTypeDto.InEffect => "Действует",
            DocumentStageTypeDto.Cancelled => "Отменен",

            _ => throw new ArgumentOutOfRangeException(nameof(stageType), stageType, null)
        };

        return result;
    }
}
