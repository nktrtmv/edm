using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Commands.Create.Contracts;

internal static class CreateApprovalGraphsCommandResponseInternalConverter
{
    internal static CreateApprovalGraphsCommandResponseInternal FromDomain(ApprovalGraph graph)
    {
        Id<ApprovalGraphInternal> graphId = IdConverterFrom<ApprovalGraphInternal>.From(graph.Id);

        var result = new CreateApprovalGraphsCommandResponseInternal(graphId);

        return result;
    }
}
