using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs;

public abstract class ApprovalGraphsServiceBase
{
    protected ApprovalGraphsServiceBase(ApprovalGraphsService.ApprovalGraphsServiceClient graphs)
    {
        Graphs = graphs;
    }

    protected ApprovalGraphsService.ApprovalGraphsServiceClient Graphs { get; }
}
