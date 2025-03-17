using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Commands.Create.Contracts;

public sealed class CreateApprovalGraphsCommandResponseInternal
{
    internal CreateApprovalGraphsCommandResponseInternal(Id<ApprovalGraphInternal> graphId)
    {
        GraphId = graphId;
    }

    public Id<ApprovalGraphInternal> GraphId { get; }
}
