using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Data;
using Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups.Details;
using Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Contexts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Contracts.Groups;

internal static class ApprovalGroupBffConverter
{
    internal static ApprovalGroupBff FromDto(ApprovalGroupDto group, ApprovalEnrichersContext context)
    {
        var data = ApprovalGroupDataBffConverter.FromDto(group.Data);

        var details = ApprovalGroupDetailsBffConverter.FromDto(group.Details, context);

        var result = new ApprovalGroupBff
        {
            Data = data,
            Details = details
        };

        return result;
    }

    internal static ApprovalGroupDto ToDto(ApprovalGroupBff group)
    {
        var data = ApprovalGroupDataBffConverter.ToDto(group.Data);

        var details = ApprovalGroupDetailsBffConverter.ToDto(group.Details);

        var result = new ApprovalGroupDto
        {
            Data = data,
            Details = details
        };

        return result;
    }
}
