using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes.Inheritors.Transits;

internal static class ApprovalGraphTransitNodeBffConverter
{
    internal static ApprovalGraphTransitNodeBff FromDto(string id)
    {
        var result = new ApprovalGraphTransitNodeBff
        {
            Id = id
        };

        return result;
    }

    internal static ApprovalGraphNodeDto ToDto(string id)
    {
        var asTransit = new ApprovalGraphTransitNodeDto();

        var result = new ApprovalGraphNodeDto
        {
            Id = id,
            AsTransit = asTransit
        };

        return result;
    }
}
