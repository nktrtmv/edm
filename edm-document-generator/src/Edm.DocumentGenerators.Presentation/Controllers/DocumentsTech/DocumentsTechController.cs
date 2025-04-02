using Edm.DocumentGenerators.Application.Tech.Commands.ChangeDocumentStatus.Contracts;
using Edm.DocumentGenerators.Application.Tech.Queries.GetAllDocumentStatuses.Contracts;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Statuses;

using Grpc.Core;

using MediatR;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTech;

internal sealed class DocumentsTechController(IMediator mediator) : DocumentsTechService.DocumentsTechServiceBase
{
    public override async Task<ChangeDocumentStatusTechCommandResponse> ChangeDocumentStatus(ChangeDocumentStatusTechCommand request, ServerCallContext context)
    {
        var command = new ChangeDocumentStatusTechCommandInternal(request.DocumentId, request.CurrentStatusId, request.StatusToId, request.UserId);

        await mediator.Send(command, context.CancellationToken);

        return new ChangeDocumentStatusTechCommandResponse();
    }

    public override async Task<GetAllDocumentStatusesTechQueryResponse> GetAllDocumentStatuses(GetAllDocumentStatusesTechQuery request, ServerCallContext context)
    {
        var query = new GetAllDocumentStatusesTechQueryInternal(request.DocumentId);

        GetAllDocumentStatusesTechQueryResponseInternal? response = await mediator.Send(query, context.CancellationToken);

        var result = new GetAllDocumentStatusesTechQueryResponse
        {
            Statuses = { response.Statuses.Select(DocumentStatusDtoConverter.FromInternal) }
        };

        return result;
    }
}
