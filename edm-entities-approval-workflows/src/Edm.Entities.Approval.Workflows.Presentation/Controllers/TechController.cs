using System.Text.Json;

using Edm.Entities.Approval.Workflows.Application.Workflows.Services;
using Edm.Entities.Approval.Workflows.Application.Workflows.Tech.Commands.CompleteWorkflows.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Tech.Queries.GetWorkflowsByEntity.Contracts;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers;

[ApiController]
[Route("api/tech/[action]")]
public sealed class TechController(ApprovalWorkflowsFacade approvalWorkflowsFacade, IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> GetApprovalWorkflow(
        [FromQuery] string workflowId,
        [FromQuery] bool processApplicationsEvents,
        CancellationToken cancellationToken = default)
    {
        var workflow = await approvalWorkflowsFacade.GetRequired(
            IdConverterFrom<ApprovalWorkflow>.FromString(workflowId),
            processApplicationsEvents,
            cancellationToken);

        var json = JsonSerializer.Serialize(workflow);

        return Content(json, "application/json");
    }

    [HttpPost]
    public async Task<IActionResult> CompleteWorkflow(
        [FromQuery] string workflowId,
        [FromQuery] ApprovalWorkflowStatus completeStatus,
        CancellationToken cancellationToken = default)
    {
        var command = new CompleteWorkflowTechCommandInternal(workflowId, completeStatus);

        await mediator.Send(command, cancellationToken);

        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> GetWorkflowsByEntity(
        [FromQuery] string entityId,
        CancellationToken cancellationToken = default)
    {
        var command = new GetWorkflowsByEntityTechQuery(entityId);

        var response = await mediator.Send(command, cancellationToken);

        GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryResponseWorkflow[] workflows =
            response.Select(GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryResponseWorkflowConverter.FromInternal).ToArray();

        return Ok(workflows);
    }
}
