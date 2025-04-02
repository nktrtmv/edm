using Edm.DocumentGenerator.Gateway.Presentation.Users;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Edm.DocumentGenerator.Gateway.Core.Actions.Registry.Documents.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Actions.Registry.Documents.UpdateDocumentsClerks;
using Edm.DocumentGenerator.Gateway.Core.Actions.Registry.Documents.UpdateDocumentsClerks.Contracts.Commands;
using Edm.DocumentGenerator.Gateway.Core.Actions.Registry.Documents.UpdateDocumentsStatuses;
using Edm.DocumentGenerator.Gateway.Core.Actions.Registry.Documents.UpdateDocumentsStatuses.Contracts.Commands;
using Edm.DocumentGenerator.Gateway.Core.Actions.Registry.Documents.UpdateDocumentsStatuses.Contracts.Queries;

namespace Edm.DocumentGenerator.Gateway.Presentation.Controllers.Actions;

[Authorize]
[Route("registry/documents/actions/[Action]")]
[ApiController]
public class DocumentsRegistryActionsController(
    UpdateDocumentsClerksService updateClerksService,
    UpdateDocumentsStatusesService updateStatusesService,
    UsersService usersService) : ControllerBase
{
    [HttpPost]
    public async Task<UpdateDocumentsResponseBff> UpdateDocumentsClerks(
        UpdateDocumentsClerksCommandBff command,
        CancellationToken cancellationToken)
    {
        var user = usersService.GetCurrentUser();

        var response = await updateClerksService.Update(command, user, cancellationToken);

        return response;
    }

    [HttpPost]
    public async Task<GetDocumentsAllowedStatusesResponseBff> GetDocumentsAllowedStatuses(
        GetDocumentsAllowedStatusesQueryBff query,
        CancellationToken cancellationToken)
    {
        var user = usersService.GetCurrentUser();

        var response = await updateStatusesService.GetDocumentsAllowedStatuses(query, user, cancellationToken);

        return response;
    }

    [HttpPost]
    public async Task<UpdateDocumentsResponseBff> UpdateDocumentsStatuses(
        UpdateDocumentsStatusesCommandBff command,
        CancellationToken cancellationToken)
    {
        var user = usersService.GetCurrentUser();

        var response = await updateStatusesService.Update(command, user, cancellationToken);

        return response;
    }
}
