using Google.Protobuf.WellKnownTypes;

using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Contracts.ApprovalRulesKeys.EntitiesTypesKeys;
using Edm.DocumentGenerator.Gateway.ExternalServices.Contracts.ApprovalRulesKeys;
using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Contracts.ApprovalRulesKeys;

internal static class ApprovalRuleKeyBffConverter
{
    internal static ApprovalRuleKeyBff FromExternal(ApprovalRuleKeyExternal approvalRuleKey)
    {
        var entityTypeKey = EntityTypeKeyBffConverter.FromExternal(approvalRuleKey.EntityTypeKey);

        var result = new ApprovalRuleKeyBff
        {
            EntityTypeKey = entityTypeKey,
            Version = approvalRuleKey.Version
        };

        return result;
    }

    internal static ApprovalRuleKeyBff FromDto(string domainId, string entityTypeId, Timestamp approvalAttributesVersion)
    {
        var entityTypeUpdatedDate =
            UtcDateTimeConverter.FromTimestampToDateTime(approvalAttributesVersion);

        var entityTypeKey = new EntityTypeKeyBff
        {
            DomainId = domainId,
            EntityTypeId = entityTypeId,
            EntityTypeUpdatedDate = entityTypeUpdatedDate
        };

        var result = new ApprovalRuleKeyBff { EntityTypeKey = entityTypeKey };

        return result;
    }
}
