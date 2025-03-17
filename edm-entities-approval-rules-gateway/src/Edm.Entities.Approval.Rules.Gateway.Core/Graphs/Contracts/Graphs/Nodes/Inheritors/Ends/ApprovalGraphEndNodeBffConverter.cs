using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes.Inheritors.Ends;

internal static class ApprovalGraphEndNodeBffConverter
{
    internal static ApprovalGraphEndNodeBff FromDto(string id)
    {
        var result = new ApprovalGraphEndNodeBff
        {
            Id = id
        };

        return result;
    }

    internal static ApprovalGraphNodeDto ToDto(string id)
    {
        var asEnd = new ApprovalGraphEndNodeDto();

        var result = new ApprovalGraphNodeDto
        {
            Id = id,
            AsEnd = asEnd
        };

        return result;
    }
}
