using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Queries.GetAll.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Converters.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Queries.GetAll;

internal static class GetAllApprovalGraphsQueryInternalConverter
{
    internal static GetAllApprovalGraphsQueryInternal FromDto(GetAllApprovalGraphsQuery query)
    {
        ApprovalRuleKeyInternal approvalRuleKey = ApprovalRuleKeyInternalConverter.FromDto(query.ApprovalRuleKey);

        var result = new GetAllApprovalGraphsQueryInternal(approvalRuleKey);

        return result;
    }
}
