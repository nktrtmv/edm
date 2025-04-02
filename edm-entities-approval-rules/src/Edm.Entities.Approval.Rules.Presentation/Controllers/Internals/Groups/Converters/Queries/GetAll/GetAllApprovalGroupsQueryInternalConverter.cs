using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Queries.GetAll.Contracts;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Queries.GetAll.Contracts.QueryParams;
using Edm.Entities.Approval.Rules.GenericSubdomain.Converters;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Queries.GetAll.Contracts.QueryParams;
using Edm.Entities.Approval.Rules.Presentation.Converters.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Queries.GetAll;

internal static class GetAllApprovalGroupsQueryInternalConverter
{
    internal static GetAllApprovalGroupsQueryInternal FromDto(GetAllApprovalGroupsQuery query)
    {
        ApprovalRuleKeyInternal approvalRuleKey = ApprovalRuleKeyInternalConverter.FromDto(query.ApprovalRuleKey);

        GetAllApprovalGroupsQueryParamsInternal? queryParams =
            NullableConverter.Convert(query.QueryParams, GetAllApprovalGroupsQueryParamsInternalConverter.FromDto);

        var result = new GetAllApprovalGroupsQueryInternal(approvalRuleKey, queryParams);

        return result;
    }
}
