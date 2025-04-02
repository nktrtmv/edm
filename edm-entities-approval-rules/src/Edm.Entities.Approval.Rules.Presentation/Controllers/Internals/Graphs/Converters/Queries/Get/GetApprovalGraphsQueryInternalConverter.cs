using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Queries.Get.Contracts;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Converters.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Queries.Get;

internal static class GetApprovalGraphsQueryInternalConverter
{
    internal static GetApprovalGraphsQueryInternal FromDto(GetApprovalGraphsQuery query)
    {
        ApprovalRuleKeyInternal approvalRuleKey = ApprovalRuleKeyInternalConverter.FromDto(query.ApprovalRuleKey);

        Id<ApprovalGraphInternal> graphId = IdConverterFrom<ApprovalGraphInternal>.FromString(query.GraphId);

        var result = new GetApprovalGraphsQueryInternal(approvalRuleKey, graphId);

        return result;
    }
}
