using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Create;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Create.Contracts;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Delete;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Delete.Contracts;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Update;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Update.Contracts;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Queries.Get;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Queries.Get.Contracts;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Queries.GetAll;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Queries.GetAll.Contracts;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Queries.GetAll.Contracts.Filtering;
using Edm.Entities.Approval.Rules.Gateway.Presentation.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Edm.Entities.Approval.Rules.Gateway.Presentation.Controllers.Groups;

[Authorize]
[ApiController]
[Route("groups/[Action]")]
public sealed class ApprovalGroupsController(
    CreateApprovalGroupsCommandService createCommandService,
    DeleteApprovalGroupsCommandService deleteCommandService,
    UpdateApprovalGroupsCommandService updateCommandService,
    GetApprovalGroupsQueryService getQueryService,
    GetAllApprovalGroupsQueryService getAllQueryService,
    UserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<CreateApprovalGroupsCommandResponseBff> Create(CreateApprovalGroupsCommandBff command, CancellationToken cancellationToken)
    {
        var user = userService.GetCurrentUser();

        var response = await createCommandService.Create(command, user.Id, cancellationToken);

        return response;
    }

    [HttpPost]
    public async Task<DeleteApprovalGroupsCommandResponseBff> Delete(DeleteApprovalGroupsCommandBff command, CancellationToken cancellationToken)
    {
        var user = userService.GetCurrentUser();

        await deleteCommandService.Delete(command, user.Id, cancellationToken);

        return DeleteApprovalGroupsCommandResponseBff.Instance;
    }

    [HttpPost]
    public async Task<UpdateApprovalGroupsCommandResponseBff> Update(UpdateApprovalGroupsCommandBff command, CancellationToken cancellationToken)
    {
        var user = userService.GetCurrentUser();

        var response = await updateCommandService.Update(command, user.Id, cancellationToken);

        return response;
    }

    [HttpPost]
    public async Task<GetApprovalGroupsQueryResponseBff> Get(GetApprovalGroupsQueryBff query, CancellationToken cancellationToken)
    {
        var response = await getQueryService.Get(query, cancellationToken);

        return response;
    }

    [HttpPost]
    public async Task<GetAllApprovalGroupsQueryResponseBff> GetAll(
        GetAllApprovalGroupsQueryBff query,
        [FromQuery] FilteringParametersDto filtering,
        [FromQuery] int skip,
        [FromQuery] int limit,
        CancellationToken cancellationToken)
    {
        var response = await getAllQueryService.GetAll(query, filtering, skip, limit, cancellationToken);

        return response;
    }
}
