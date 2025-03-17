using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Starts;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Graphs.Validators.Validators.Nodes;

internal static class GraphHasExactlyOneStartNodeValidator
{
    internal static void Validate(IEnumerable<ApprovalGraphNode> nodes)
    {
        int numberOfStartNodes = nodes.OfType<ApprovalGraphStartNode>().Count();

        if (numberOfStartNodes != 1)
        {
            throw new ArgumentException($"Graph is allowed to have only one start node but found {numberOfStartNodes}");
        }
    }
}
