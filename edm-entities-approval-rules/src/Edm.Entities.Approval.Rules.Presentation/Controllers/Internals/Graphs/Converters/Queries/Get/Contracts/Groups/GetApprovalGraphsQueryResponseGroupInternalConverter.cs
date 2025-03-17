using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Queries.Get.Contracts.Groups;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Queries.Get.Contracts.Groups;

internal static class GetApprovalGraphsQueryResponseGroupInternalConverter
{
    internal static GetApprovalGraphsQueryResponseGroup ToDto(GetApprovalGraphsQueryResponseGroupInternal group)
    {
        var id = IdConverterTo.ToString(group.Id);

        var result = new GetApprovalGraphsQueryResponseGroup
        {
            Id = id,
            DisplayName = group.DisplayName
        };

        return result;
    }
}
