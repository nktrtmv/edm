using Edm.Entities.Approval.Rules.Application.Internal.GroupsDetails.Queries.GetParticipantSourceAttributes.Contracts;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tracing;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.GroupsDetails.Domestic.Converters;

using Grpc.Core;

using MediatR;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.GroupsDetails;

internal sealed class ApprovalGroupsDetailsController(IMediator mediator, ILogger<ApprovalGroupsController> logger)
    : ApprovalGroupsDetailsService.ApprovalGroupsDetailsServiceBase
{
    public override async Task<GetParticipantSourceAttributesApprovalGroupsDetailsQueryResponse> GetParticipantSourceAttributes(
        GetParticipantSourceAttributesApprovalGroupsDetailsQuery query,
        ServerCallContext context)
    {
        return await TracingFacility.TraceGrpc(
            logger,
            nameof(GetParticipantSourceAttributes),
            query,
            async () =>
            {
                GetParticipantSourceAttributesApprovalGroupsDetailsQueryInternal request =
                    GetParticipantSourceAttributesApprovalGroupsDetailsQueryConverter.ToInternal(query);

                GetParticipantSourceAttributesApprovalGroupsDetailsQueryResponseInternal response =
                    await mediator.Send(request, context.CancellationToken);

                GetParticipantSourceAttributesApprovalGroupsDetailsQueryResponse result =
                    GetParticipantSourceAttributesApprovalGroupsDetailsQueryResponseConverter.FromInternal(response);

                return result;
            });
    }
}
