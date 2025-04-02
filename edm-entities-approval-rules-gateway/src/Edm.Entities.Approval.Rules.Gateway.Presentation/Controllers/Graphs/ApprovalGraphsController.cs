using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Commands.Create;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Commands.Create.Contracts;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Commands.Delete;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Commands.Delete.Contracts;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Commands.Update;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Commands.Update.Contracts;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Queries.Get;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Queries.Get.Contracts;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Queries.GetAll;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Queries.GetAll.Contracts;
using Edm.Entities.Approval.Rules.Gateway.Presentation.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Edm.Entities.Approval.Rules.Gateway.Presentation.Controllers.Graphs;

[Authorize]
[ApiController]
[Route("graphs/[Action]")]
public sealed class ApprovalGraphsController(
    CreateApprovalGraphsCommandService createCommandService,
    UpdateApprovalGraphsCommandService updateCommandService,
    DeleteApprovalGraphsCommandService deleteCommandService,
    GetApprovalGraphsQueryService getQueryService,
    GetAllApprovalGraphsService getAllQueryService,
    UserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<CreateApprovalGraphsCommandResponseBff> Create(CreateApprovalGraphsCommandBff command, CancellationToken cancellationToken)
    {
        var user = userService.GetCurrentUser();

        var response = await createCommandService.Create(command, user.Id, cancellationToken);

        return response;
    }

    [HttpPost]
    public async Task<DeleteApprovalGraphsCommandResponseBff> Delete(DeleteApprovalGraphsCommandBff command, CancellationToken cancellationToken)
    {
        var user = userService.GetCurrentUser();

        await deleteCommandService.Delete(command, user.Id, cancellationToken);

        return DeleteApprovalGraphsCommandResponseBff.Instance;
    }

    [HttpPost]
    public async Task<UpdateApprovalGraphsCommandResponseBff> Update(UpdateApprovalGraphsCommandBff command, CancellationToken cancellationToken)
    {
        var user = userService.GetCurrentUser();

        var response = await updateCommandService.Update(command, user.Id, cancellationToken);

        return response;
    }

    [HttpPost]
    public async Task<GetApprovalGraphsQueryResponseBff> Get(GetApprovalGraphsQueryBff query, CancellationToken cancellationToken)
    {
        var response = await getQueryService.Get(query, cancellationToken);

        return response;
    }

    [HttpPost]
    public async Task<GetAllApprovalGraphsQueryResponseBff> GetAll(GetAllApprovalGraphsQueryBff query, CancellationToken cancellationToken)
    {
        var response = await getAllQueryService.GetAll(query, cancellationToken);

        return response;
    }
}
