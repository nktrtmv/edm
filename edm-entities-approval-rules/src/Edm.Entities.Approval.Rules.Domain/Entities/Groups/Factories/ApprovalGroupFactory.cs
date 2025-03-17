using Edm.Entities.Approval.Rules.Domain.Entities.Groups.Factories.Kinds;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Data;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Data.Factories;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.ValueObjects.Details.Inheritors.Domestic.Factories;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Groups.Factories;

public static class ApprovalGroupFactory
{
    public static ApprovalGroup CreateNew(ApprovalGroupKind kind, string displayName)
    {
        ApprovalGroupData data = ApprovalGroupDataFactory.CreateNew(displayName);

        ApprovalGroupDetails details = kind switch
        {
            ApprovalGroupKind.Domestic => DomesticApprovalGroupDetailsFactory.CreateNew(),
            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        ApprovalGroup result = CreateFromDb(data, details);

        return result;
    }

    public static ApprovalGroup CreateFrom(ApprovalGroupData data, ApprovalGroupDetails details)
    {
        ApprovalGroup result = CreateFromDb(data, details);

        return result;
    }

    public static ApprovalGroup CreateFromDb(ApprovalGroupData data, ApprovalGroupDetails details)
    {
        var result = new ApprovalGroup(data, details);

        return result;
    }
}
