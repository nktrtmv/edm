using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.ValidateThereAreActiveGraphs.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;
using Edm.Entities.Approval.Rules.Presentation.Converters.EntitiesTypes.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules.Converters.Queries.ValidateThereAreActiveGraphs;

internal static class ValidateThereAreActiveGraphsApprovalRulesQueryInternalConverter
{
    internal static ValidateThereAreActiveGraphsApprovalRulesQueryInternal FromDto(ValidateThereAreActiveGraphsApprovalRulesQuery query)
    {
        EntityTypeKeyInternal entityTypeKey = EntityTypeKeyDtoConverter.ToInternal(query.EntityTypeKey);

        string[] approvalGraphsTags = query.ApprovalGraphsTags.ToArray();

        var result = new ValidateThereAreActiveGraphsApprovalRulesQueryInternal(entityTypeKey, approvalGraphsTags);

        return result;
    }
}
