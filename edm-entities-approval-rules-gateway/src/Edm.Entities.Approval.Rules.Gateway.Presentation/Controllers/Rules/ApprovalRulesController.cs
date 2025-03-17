using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Activate;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Activate.Contracts;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.CreateNewVersion;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.CreateNewVersion.Contracts;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Deactivate;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Deactivate.Contracts;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Update;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Update.Contracts;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Get;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Get.Contracts;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetActivationAudit;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetActivationAudit.Contracts;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetAll;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetAll.Contracts;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetVersions;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetVersions.Contracts;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Search;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Search.Contracts;
using Edm.Entities.Approval.Rules.Gateway.Presentation.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Edm.Entities.Approval.Rules.Gateway.Presentation.Controllers.Rules;

[Authorize]
[ApiController]
[Route("rules/[Action]")]
public sealed class ApprovalRulesController(
    ActivateApprovalRulesCommandService activateCommandService,
    CreateNewVersionApprovalRulesCommandService createNewVersionCommandService,
    DeactivateApprovalRulesCommandService deactivateCommandService,
    UpdateApprovalRulesCommandService updateCommandService,
    GetActivationAuditApprovalRulesQueryService getActivationAuditQueryService,
    GetAllApprovalRulesQueryService getAllQueryService,
    GetVersionsApprovalRulesQueryService getVersionsQueryService,
    GetApprovalRuleQueryService getApprovalRuleService,
    SearchApprovalRulesQueryService searchQueryService,
    UserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<ActivateApprovalRulesCommandResponseBff> Activate(
        ActivateApprovalRulesCommandBff command,
        CancellationToken cancellationToken)
    {
        var user = userService.GetCurrentUser();

        await activateCommandService.Activate(command, user.Id, cancellationToken);

        return ActivateApprovalRulesCommandResponseBff.Instance;
    }

    [HttpPost]
    public async Task<CreateNewVersionApprovalRulesCommandResponseBff> CreateNewVersion(
        CreateNewVersionApprovalRulesCommandBff command,
        CancellationToken cancellationToken)
    {
        var user = userService.GetCurrentUser();

        var result =
            await createNewVersionCommandService.CreateNewVersion(command, user.Id, cancellationToken);

        return result;
    }

    [HttpPost]
    public async Task<DeactivateApprovalRulesCommandResponseBff> Deactivate(
        DeactivateApprovalRulesCommandBff command,
        CancellationToken cancellationToken)
    {
        var user = userService.GetCurrentUser();

        await deactivateCommandService.Deactivate(command, user.Id, cancellationToken);

        return DeactivateApprovalRulesCommandResponseBff.Instance;
    }

    [HttpPost]
    public async Task<UpdateApprovalRulesCommandResponseBff> Update(
        UpdateApprovalRulesCommandBff command,
        CancellationToken cancellationToken)
    {
        var user = userService.GetCurrentUser();

        var result = await updateCommandService.Update(command, user.Id, cancellationToken);

        return result;
    }

    [HttpPost]
    public async Task<GetActivationAuditApprovalRulesQueryResponseBff> GetActivationAudit(
        GetActivationAuditApprovalRulesQueryBff query,
        CancellationToken cancellationToken)
    {
        var result =
            await getActivationAuditQueryService.GetActivationAudit(query, cancellationToken);

        return result;
    }

    [HttpPost]
    public async Task<GetAllApprovalRulesQueryResponseBff> GetAll(
        GetAllApprovalRulesQueryBff query,
        CancellationToken cancellationToken)
    {
        var result = await getAllQueryService.GetAll(query, cancellationToken);

        return result;
    }

    [HttpPost]
    public async Task<GetApprovalRuleQueryResponseBff> Get(
        GetApprovalRuleQueryBff query,
        CancellationToken cancellationToken)
    {
        var result = await getApprovalRuleService.Get(query, cancellationToken);

        return result;
    }

    [HttpPost]
    public async Task<GetVersionsApprovalRulesQueryResponseBff> GetVersions(
        GetVersionsApprovalRulesQueryBff query,
        CancellationToken cancellationToken)
    {
        var result = await getVersionsQueryService.GetVersions(query, cancellationToken);

        return result;
    }

    [HttpPost]
    public async Task<SearchApprovalRulesQueryResponseBff> Search(
        SearchApprovalRulesQueryBff query,
        CancellationToken cancellationToken)
    {
        var result = await searchQueryService.Search(query, cancellationToken);

        return result;
    }
}
