using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes.Inheritors.Starts;

internal static class ApprovalGraphStartNodeBffConverter
{
    internal static ApprovalGraphStartNodeBff FromDto(string id)
    {
        var result = new ApprovalGraphStartNodeBff
        {
            Id = id
        };

        return result;
    }

    internal static ApprovalGraphNodeDto ToDto(string id)
    {
        var asStart = new ApprovalGraphStartNodeDto();

        var result = new ApprovalGraphNodeDto
        {
            Id = id,
            AsStart = asStart
        };

        return result;
    }
}
