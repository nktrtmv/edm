using Edm.DocumentGenerator.Gateway.Core.Contracts.Stages;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.GetDocumentStages;

public static class GetDocumentStagesTypesService
{
    public static readonly Dictionary<DocumentStageTypeBff, string> DocumentStagesTypes =
        new Dictionary<DocumentStageTypeBff, string>
        {
            { DocumentStageTypeBff.Draft, "Черновик" },
            { DocumentStageTypeBff.Backlog, "Ожидает обработки" },
            { DocumentStageTypeBff.ApprovalPreparation, "Подготовка к согласованию" },
            { DocumentStageTypeBff.Approval, "На согласовании" },
            { DocumentStageTypeBff.SigningPreparation, "Подготовка к подписанию" },
            { DocumentStageTypeBff.Signing, "На подписании" },
            { DocumentStageTypeBff.InEffect, "Действует" },
            { DocumentStageTypeBff.Cancelled, "Отменен" },
            { DocumentStageTypeBff.SelfSigning, "На подписи компании" },
            { DocumentStageTypeBff.ContractorSigning, "На подписи КА" }
        };
}
