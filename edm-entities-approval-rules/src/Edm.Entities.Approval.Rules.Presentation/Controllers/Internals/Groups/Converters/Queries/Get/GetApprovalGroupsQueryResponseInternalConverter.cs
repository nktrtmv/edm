using Edm.Entities.Approval.Rules.Application.Internal.Groups.Queries.Get.Contracts;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tokens.Concurrency;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Contracts.Groups;
using Edm.Entities.Approval.Rules.Presentation.Converters.EntitiesTypes.Attributes;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Queries.Get;

internal static class GetApprovalGroupsQueryResponseInternalConverter
{
    internal static GetApprovalGroupsQueryResponse ToDto(GetApprovalGroupsQueryResponseInternal response)
    {
        ApprovalGroupDto group = ApprovalGroupInternalConverter.ToDto(response.Group);

        EntityTypeAttributeDto[] attributes =
            response.Attributes.Select(EntityTypeAttributeInternalToDtoConverter.ToDto).ToArray();

        var concurrencyToken = ConcurrencyTokenConverterTo.ToString(response.ConcurrencyToken);

        var result = new GetApprovalGroupsQueryResponse
        {
            Group = group,
            Attributes = { attributes },
            ConcurrencyToken = concurrencyToken
        };

        return result;
    }
}
