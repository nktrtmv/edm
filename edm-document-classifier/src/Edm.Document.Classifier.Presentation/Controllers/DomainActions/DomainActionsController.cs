using Edm.Document.Classifier.Application.DomainActions.Contracts;
using Edm.Document.Classifier.GenericSubdomain.Tracing;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DomainActions.Converters;

using Grpc.Core;

using MediatR;

namespace Edm.Document.Classifier.Presentation.Controllers.DomainActions;

public sealed class DomainActionsController(IMediator mediator, ILogger<DomainActionsController> logger)
    : DomainActionsService.DomainActionsServiceBase
{
    public override async Task<GetDomainActionsQueryResponse> GetDomainActions(GetDomainActionsQuery query, ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(GetDomainActions),
            query,
            async () =>
            {
                GetDomainActionsQueryInternal request = GetDomainActionsQueryConverter.ToInternal(query);

                GetDomainActionsQueryResponseInternal response = await mediator.Send(request, context.CancellationToken);

                GetDomainActionsQueryResponse result = GetDomainActionsQueryResponseConverter.FromInternal(response);

                return result;
            },
            LogLevel.Debug);
    }
}
