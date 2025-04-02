using Edm.DocumentGenerator.Gateway.Presentation.Authorization;
using Edm.DocumentGenerator.Gateway.Presentation.Users;
using Edm.DocumentGenerators.Presentation.Abstractions;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus;

namespace Edm.DocumentGenerator.Gateway.Presentation.Controllers.Tech;

[Route("documents/tech/[Action]")]
[ApiController]
[Authorize]
public sealed class DocumentsTechController(
    DocumentsTechService.DocumentsTechServiceClient techServiceClient,
    UsersService usersService,
    AccessCheckerFacade accessCheckerFacade) : ControllerBase
{
    [HttpPost]
    public async Task<ChangeDocumentStatusTechCommandResponseBff> ChangeDocumentStatus(
        ChangeDocumentStatusTechCommandBff command,
        CancellationToken cancellationToken)
    {
        var user = usersService.GetCurrentUser();

        accessCheckerFacade.ThrowIfAdminAccessMissing(user);

        await techServiceClient.ChangeDocumentStatusAsync(
            new ChangeDocumentStatusTechCommand
            {
                DomainId = command.DomainId,
                DocumentId = command.DocumentId,
                CurrentStatusId = command.CurrentStatusId,
                StatusToId = command.StatusToId,
                UserId = user.Id
            },
            cancellationToken: cancellationToken);

        return new ChangeDocumentStatusTechCommandResponseBff();
    }

    [HttpPost]
    public async Task<GetAllDocumentStatusesTechQueryResponseBff> GetAllDocumentStatuses(
        GetAllDocumentStatusesTechQueryBff query,
        CancellationToken cancellationToken)
    {
        accessCheckerFacade.ThrowIfAdminAccessMissing();

        var response = await techServiceClient.GetAllDocumentStatusesAsync(
            new GetAllDocumentStatusesTechQuery
            {
                DomainId = query.DomainId,
                DocumentId = query.DocumentId
            },
            cancellationToken: cancellationToken);

        return new GetAllDocumentStatusesTechQueryResponseBff(response.Statuses.Select(DocumentStatusBffConverter.ToBff).ToArray());
    }

    public sealed record ChangeDocumentIsSynchronizingTechCommandBff(string DomainId, string DocumentId, bool IsSynchronizing);

    public sealed record ChangeDocumentIsSynchronizingTechCommandResponseBff;

    public sealed record ChangeDocumentStatusTechCommandBff(string DomainId, string DocumentId, string CurrentStatusId, string StatusToId);

    public sealed record ChangeDocumentStatusTechCommandResponseBff;

    public sealed record GetAllDocumentStatusesTechQueryBff(string DomainId, string DocumentId);

    public sealed record GetAllDocumentStatusesTechQueryResponseBff(DocumentStatusBff[] Statuses);
}
