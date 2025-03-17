using Edm.Entities.Approval.Rules.Application.Internal.Groups.Queries.GetAll.Contracts.Groups;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Queries.GetAll.Contracts.Groups;

internal static class GetAllApprovalGroupsQueryResponseGroupConverter
{
    internal static GetAllApprovalGroupsQueryResponseGroup ToDto(GetAllApprovalGroupsQueryResponseGroupInternal group)
    {
        var id = IdConverterTo.ToString(group.Id);

        var result = new GetAllApprovalGroupsQueryResponseGroup
        {
            Id = id,
            DisplayName = group.DisplayName,
            Label = group.Label
        };

        return result;
    }
}
