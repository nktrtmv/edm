using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Data;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups.Details;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.Factories;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Data;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups;

internal static class ApprovalGroupInternalConverter
{
    internal static ApprovalGroupInternal FromDomain(ApprovalGroup group)
    {
        ApprovalGroupDataInternal data = ApprovalGroupDataInternalConverter.FromDomain(group.Data);

        ApprovalGroupDetailsInternal details = ApprovalGroupDetailsInternalConverter.FromDomain(group.Details);

        var result = new ApprovalGroupInternal(data, details);

        return result;
    }

    internal static ApprovalGroup ToDomain(ApprovalGroupInternal group)
    {
        ApprovalGroupData data = ApprovalGroupDataInternalConverter.ToDomain(group.Data);

        ApprovalGroupDetails details = ApprovalGroupDetailsInternalConverter.ToDomain(group.Details);

        ApprovalGroup result = ApprovalGroupFactory.CreateFrom(data, details);

        return result;
    }
}
