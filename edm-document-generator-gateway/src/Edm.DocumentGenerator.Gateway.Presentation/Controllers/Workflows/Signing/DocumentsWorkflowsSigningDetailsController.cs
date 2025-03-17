using Microsoft.AspNetCore.Mvc;

using Edm.DocumentGenerator.Gateway.Core.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions.Signing.Kinds;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Signings.Stages.Statuses;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Signings.Stages.Types;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetArchiveDetails;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetArchiveDetails.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails.Contracts.Details.Documents.States.Statuses;
using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.Presentation.Controllers.Workflows.Signing;

[Route("documents/workflows/signing/details/[Action]")]
[ApiController]
public class DocumentsWorkflowsSigningDetailsController : ControllerBase
{
    private static readonly Dictionary<DocumentWorkflowSigningActionKindBff, string> Actions =
        new Dictionary<DocumentWorkflowSigningActionKindBff, string>
        {
            { DocumentWorkflowSigningActionKindBff.Cancel, "Отменить" },
            { DocumentWorkflowSigningActionKindBff.PutIntoEffect, "Ввести в действие" },
            { DocumentWorkflowSigningActionKindBff.ReturnToRework, "Отправить на доработку" },
            { DocumentWorkflowSigningActionKindBff.SendToContractor, "Отправить КА" },
            { DocumentWorkflowSigningActionKindBff.Sign, "Подписать" },
            { DocumentWorkflowSigningActionKindBff.WithdrawByContractor, "Отзыв с подписания" },
            { DocumentWorkflowSigningActionKindBff.WithdrawBySelf, "Отозвать с подписания" }
        };

    private static readonly Dictionary<DocumentWorkflowSigningDocumentStatusBff, string> DocumentStatuses =
        new Dictionary<DocumentWorkflowSigningDocumentStatusBff, string>
        {
            { DocumentWorkflowSigningDocumentStatusBff.PendingSelfSigning, "Ожидание подписания компании" },
            { DocumentWorkflowSigningDocumentStatusBff.SignedBySelf, "Подписан компанией" },
            { DocumentWorkflowSigningDocumentStatusBff.ReadyForSending, "Готов к отправке в ЭДО" },
            { DocumentWorkflowSigningDocumentStatusBff.RequiredToSign, "Требует подписания КА" },
            { DocumentWorkflowSigningDocumentStatusBff.Sent, "Отправлено в ЭДО" },
            { DocumentWorkflowSigningDocumentStatusBff.InProcess, "В процессе" },
            { DocumentWorkflowSigningDocumentStatusBff.Signed, "Подписан" },
            { DocumentWorkflowSigningDocumentStatusBff.Rejected, "Отклонен" },
            { DocumentWorkflowSigningDocumentStatusBff.Error, "Ошибка" },
            { DocumentWorkflowSigningDocumentStatusBff.RevocationRequested, "Запрошено аннулирование" },
            { DocumentWorkflowSigningDocumentStatusBff.RevocationRequired, "Предложено аннулирование" },
            { DocumentWorkflowSigningDocumentStatusBff.Revoked, "Аннулирован" }
        };

    private static readonly Dictionary<DocumentSigningStageTypeBff, string> StageTypes =
        new Dictionary<DocumentSigningStageTypeBff, string>
        {
            { DocumentSigningStageTypeBff.Self, "Компания" },
            { DocumentSigningStageTypeBff.Contractor, "Контрагент" }
        };

    private static readonly Dictionary<DocumentSigningStageStatusBff, string> StageStatuses =
        new Dictionary<DocumentSigningStageStatusBff, string>
        {
            { DocumentSigningStageStatusBff.NotStarted, "Ожидает" },
            { DocumentSigningStageStatusBff.InProgress, "В работе" },
            { DocumentSigningStageStatusBff.Completed, "Завершено" },
            { DocumentSigningStageStatusBff.Signed, "Подписано" },
            { DocumentSigningStageStatusBff.Rejected, "Отклонено" },
            { DocumentSigningStageStatusBff.ReturnedToRework, "Отправлено на доработку" },
            { DocumentSigningStageStatusBff.Withdrawn, "Отозвано с подписания" },
            { DocumentSigningStageStatusBff.Cancelled, "Отменено" },
            { DocumentSigningStageStatusBff.Error, "Ошибка" },
            { DocumentSigningStageStatusBff.Revocation, "Аннулирование" },
            { DocumentSigningStageStatusBff.Revoked, "Аннулирован" }
        };

    public DocumentsWorkflowsSigningDetailsController(
        GetElectronicArchiveDetailsDocumentWorkflowSigningDetailsService getElectronicArchiveDetailsService,
        GetElectronicDetailsDocumentWorkflowSigningDetailsService getElectronicDetailsService)
    {
        GetElectronicArchiveDetailsService = getElectronicArchiveDetailsService;
        GetElectronicDetailsService = getElectronicDetailsService;
    }

    private GetElectronicArchiveDetailsDocumentWorkflowSigningDetailsService GetElectronicArchiveDetailsService { get; }
    private GetElectronicDetailsDocumentWorkflowSigningDetailsService GetElectronicDetailsService { get; }

    [HttpPost]
    public Task<CollectionQueryResponse<EnumMapBff<DocumentWorkflowSigningActionKindBff>>> GetActions(CancellationToken _)
    {
        CollectionQueryResponse<EnumMapBff<DocumentWorkflowSigningActionKindBff>> response =
            EnumMapBffConverter.ConvertToResponse(Actions);

        Task<CollectionQueryResponse<EnumMapBff<DocumentWorkflowSigningActionKindBff>>> result =
            Task.FromResult(response);

        return result;
    }

    [HttpPost]
    public Task<CollectionQueryResponse<EnumMapBff<DocumentWorkflowSigningDocumentStatusBff>>> GetElectronicDocumentStatuses(CancellationToken _)
    {
        CollectionQueryResponse<EnumMapBff<DocumentWorkflowSigningDocumentStatusBff>> response =
            EnumMapBffConverter.ConvertToResponse(DocumentStatuses);

        Task<CollectionQueryResponse<EnumMapBff<DocumentWorkflowSigningDocumentStatusBff>>> result =
            Task.FromResult(response);

        return result;
    }

    [HttpPost]
    public Task<CollectionQueryResponse<EnumMapBff<DocumentSigningStageTypeBff>>> GetStageTypes(CancellationToken _)
    {
        CollectionQueryResponse<EnumMapBff<DocumentSigningStageTypeBff>> response =
            EnumMapBffConverter.ConvertToResponse(StageTypes);

        Task<CollectionQueryResponse<EnumMapBff<DocumentSigningStageTypeBff>>> result =
            Task.FromResult(response);

        return result;
    }

    [HttpPost]
    public Task<CollectionQueryResponse<EnumMapBff<DocumentSigningStageStatusBff>>> GetStageStatuses(CancellationToken _)
    {
        CollectionQueryResponse<EnumMapBff<DocumentSigningStageStatusBff>> response =
            EnumMapBffConverter.ConvertToResponse(StageStatuses);

        Task<CollectionQueryResponse<EnumMapBff<DocumentSigningStageStatusBff>>> result =
            Task.FromResult(response);

        return result;
    }

    [HttpPost]
    public async Task<GetElectronicArchiveDetailsDocumentWorkflowSigningDetailsQueryBffResponse> GetElectronicArchiveDetails(
        GetElectronicArchiveDetailsDocumentWorkflowSigningDetailsQueryBff query,
        CancellationToken cancellationToken)
    {
        var result =
            await GetElectronicArchiveDetailsService.GetElectronicArchiveDetails(query, cancellationToken);

        return result;
    }

    [HttpPost]
    public async Task<GetElectronicDetailsDocumentWorkflowSigningDetailsQueryBffResponse> GetElectronicDetails(
        GetElectronicDetailsDocumentWorkflowSigningDetailsQueryBff query,
        CancellationToken cancellationToken)
    {
        var result =
            await GetElectronicDetailsService.GetElectronicDetails(query, cancellationToken);

        return result;
    }
}
