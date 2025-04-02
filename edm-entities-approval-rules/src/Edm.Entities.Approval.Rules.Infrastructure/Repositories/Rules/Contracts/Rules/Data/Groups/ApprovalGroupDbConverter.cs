using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.Factories;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Data;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Groups.Data;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Groups.Details;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Groups;

internal static class ApprovalGroupDbConverter
{
    internal static ApprovalGroupDb FromDomain(ApprovalGroup group)
    {
        ApprovalGroupDataDb data = ApprovalGroupDataDbConverter.FromDomain(group.Data);

        ApprovalGroupDetailsDb details = ApprovalGroupDetailsDbConverter.FromDomain(group.Details);

        var result = new ApprovalGroupDb
        {
            Data = data,
            Details = details
        };

        return result;
    }

    internal static ApprovalGroup ToDomain(ApprovalGroupDb group)
    {
        ApprovalGroupData data = ApprovalGroupDataDbConverter.ToDomain(group.Data);

        ApprovalGroupDetails details = ApprovalGroupDetailsDbConverter.ToDomain(group.Details);

        ApprovalGroup result = ApprovalGroupFactory.CreateFromDb(data, details);

        return result;
    }
}
