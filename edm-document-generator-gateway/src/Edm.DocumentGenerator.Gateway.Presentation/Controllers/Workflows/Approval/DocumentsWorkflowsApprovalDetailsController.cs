using Edm.DocumentGenerator.Gateway.Presentation.Users;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Edm.DocumentGenerator.Gateway.Core.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions.Approval.Kinds;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails.
    CompletionReasons;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails.
    DelegationDetails.AutoDelegationKinds;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Assignments.Statuses;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Details.Queries.GetAddParticipantDetails;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Details.Queries.GetAddParticipantDetails.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Details.Queries.GetDelegateDetails;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Details.Queries.GetDelegateDetails.Contracts;
using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.Presentation.Controllers.Workflows.Approval;

[Route("documents/workflows/approval/details/[Action]")]
[ApiController]
[Authorize]
public class DocumentsWorkflowsApprovalDetailsController(
    UsersService users,
    GetDelegateDetailsDocumentWorkflowApprovalDetailsService getDelegateDetailsService,
    GetAddParticipantDetailsDocumentWorkflowApprovalDetailsService getAddParticipantDetailsService)
    : ControllerBase
{
    private static readonly Dictionary<DocumentWorkflowApprovalActionKindBff, string> Actions =
        new Dictionary<DocumentWorkflowApprovalActionKindBff, string>
        {
            { DocumentWorkflowApprovalActionKindBff.TakeInWork, "Взять в работу" },
            { DocumentWorkflowApprovalActionKindBff.Approve, "Согласовать" },
            { DocumentWorkflowApprovalActionKindBff.ApproveWithRemark, "Согласовать с замечаниями" },
            { DocumentWorkflowApprovalActionKindBff.ReturnToRework, "Отправить на доработку" },
            { DocumentWorkflowApprovalActionKindBff.Reject, "Отклонить" },
            { DocumentWorkflowApprovalActionKindBff.Delegate, "Делегировать" },
            { DocumentWorkflowApprovalActionKindBff.AddParticipant, "Добавить согласующего" }
        };

    private static readonly Dictionary<EntitiesApprovalWorkflowAssignmentStatusBff, string> Statuses =
        new Dictionary<EntitiesApprovalWorkflowAssignmentStatusBff, string>
        {
            { EntitiesApprovalWorkflowAssignmentStatusBff.NotStarted, "Назначено" },
            { EntitiesApprovalWorkflowAssignmentStatusBff.InProgress, "В работе" },
            { EntitiesApprovalWorkflowAssignmentStatusBff.Completed, "Завершено" }
        };

    private static readonly Dictionary<EntitiesApprovalWorkflowAssignmentCompletionReasonBff, string> CompletionReasons =
        new Dictionary<EntitiesApprovalWorkflowAssignmentCompletionReasonBff, string>
        {
            { EntitiesApprovalWorkflowAssignmentCompletionReasonBff.Approved, "Согласовано" },
            { EntitiesApprovalWorkflowAssignmentCompletionReasonBff.ApprovedWithRemark, "Согласовано с замечаниями" },
            { EntitiesApprovalWorkflowAssignmentCompletionReasonBff.Delegated, "Делегировано" },
            { EntitiesApprovalWorkflowAssignmentCompletionReasonBff.ReturnedToRework, "Отправлено на доработку" },
            { EntitiesApprovalWorkflowAssignmentCompletionReasonBff.Rejected, "Отклонено" }
        };

    private static readonly Dictionary<EntitiesApprovalWorkflowAssignmentAutoDelegationKindBff, string> AutoDelegationKinds =
        new Dictionary<EntitiesApprovalWorkflowAssignmentAutoDelegationKindBff, string>
        {
            { EntitiesApprovalWorkflowAssignmentAutoDelegationKindBff.Executor, "исполнителя" },
            { EntitiesApprovalWorkflowAssignmentAutoDelegationKindBff.ExecutorStaff, "заместителя исполнителя" },
            { EntitiesApprovalWorkflowAssignmentAutoDelegationKindBff.Approval, "участника" },
            { EntitiesApprovalWorkflowAssignmentAutoDelegationKindBff.ApprovalStaff, "заместителя участника" },
            { EntitiesApprovalWorkflowAssignmentAutoDelegationKindBff.Chief, "руководителя" },
            { EntitiesApprovalWorkflowAssignmentAutoDelegationKindBff.ChiefStaff, "заместителя руководителя" }
        };

    [HttpPost]
    public Task<CollectionQueryResponse<EnumMapBff<DocumentWorkflowApprovalActionKindBff>>> GetActions(CancellationToken _)
    {
        CollectionQueryResponse<EnumMapBff<DocumentWorkflowApprovalActionKindBff>> response =
            EnumMapBffConverter.ConvertToResponse(Actions);

        Task<CollectionQueryResponse<EnumMapBff<DocumentWorkflowApprovalActionKindBff>>> result =
            Task.FromResult(response);

        return result;
    }

    [HttpPost]
    public Task<CollectionQueryResponse<EnumMapBff<EntitiesApprovalWorkflowAssignmentStatusBff>>> GetAssignmentStatuses(CancellationToken _)
    {
        CollectionQueryResponse<EnumMapBff<EntitiesApprovalWorkflowAssignmentStatusBff>> response =
            EnumMapBffConverter.ConvertToResponse(Statuses);

        Task<CollectionQueryResponse<EnumMapBff<EntitiesApprovalWorkflowAssignmentStatusBff>>> result =
            Task.FromResult(response);

        return result;
    }

    [HttpPost]
    public Task<CollectionQueryResponse<EnumMapBff<EntitiesApprovalWorkflowAssignmentCompletionReasonBff>>> GetAssignmentCompletionReasons(CancellationToken _)
    {
        CollectionQueryResponse<EnumMapBff<EntitiesApprovalWorkflowAssignmentCompletionReasonBff>> response =
            EnumMapBffConverter.ConvertToResponse(CompletionReasons);

        Task<CollectionQueryResponse<EnumMapBff<EntitiesApprovalWorkflowAssignmentCompletionReasonBff>>> result =
            Task.FromResult(response);

        return result;
    }

    [HttpPost]
    public Task<CollectionQueryResponse<EnumMapBff<EntitiesApprovalWorkflowAssignmentAutoDelegationKindBff>>> GetAssignmentAutoDelegationKinds(CancellationToken _)
    {
        CollectionQueryResponse<EnumMapBff<EntitiesApprovalWorkflowAssignmentAutoDelegationKindBff>> response =
            EnumMapBffConverter.ConvertToResponse(AutoDelegationKinds);

        Task<CollectionQueryResponse<EnumMapBff<EntitiesApprovalWorkflowAssignmentAutoDelegationKindBff>>> result =
            Task.FromResult(response);

        return result;
    }

    [HttpPost]
    public async Task<GetDelegateDetailsDocumentWorkflowApprovalDetailsQueryBffResponse> GetDelegateDetails(
        GetDelegateDetailsDocumentWorkflowApprovalDetailsQueryBff query,
        CancellationToken cancellationToken)
    {
        var user = users.GetCurrentUser();

        var result =
            await getDelegateDetailsService.Get(query, user, cancellationToken);

        return result;
    }

    [HttpPost]
    public async Task<GetAddParticipantDetailsDocumentWorkflowApprovalDetailsQueryBffResponse> GetAddParticipantDetails(
        GetAddParticipantDetailsDocumentWorkflowApprovalDetailsQueryBff query,
        CancellationToken cancellationToken)
    {
        var result =
            await getAddParticipantDetailsService.Get(query, cancellationToken);

        return result;
    }
}
