using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Data;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Contracts.Groups.Data;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Contracts.Groups.Details;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Contracts.Groups;

internal static class ApprovalGroupInternalConverter
{
    internal static ApprovalGroupInternal FromDto(ApprovalGroupDto group)
    {
        ApprovalGroupDataInternal data = ApprovalGroupDataInternalConverter.FromDto(group.Data);

        ApprovalGroupDetailsInternal details = ApprovalGroupDetailsInternalConverter.FromDto(group.Details);

        var result = new ApprovalGroupInternal(data, details);

        return result;
    }

    internal static ApprovalGroupDto ToDto(ApprovalGroupInternal group)
    {
        ApprovalGroupDataDto data = ApprovalGroupDataInternalConverter.ToDto(group.Data);

        ApprovalGroupDetailsDto details = ApprovalGroupDetailsInternalConverter.ToDto(group.Details);

        var result = new ApprovalGroupDto
        {
            Data = data,
            Details = details
        };

        return result;
    }
}
