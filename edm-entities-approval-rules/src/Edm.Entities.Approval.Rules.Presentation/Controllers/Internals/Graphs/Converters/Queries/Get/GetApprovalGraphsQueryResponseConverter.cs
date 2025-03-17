using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Queries.Get.Contracts;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tokens.Concurrency;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Contracts.Graphs;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Queries.Get.Contracts.Groups;
using Edm.Entities.Approval.Rules.Presentation.Converters.EntitiesTypes.Attributes;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Queries.Get;

internal static class GetApprovalGraphsQueryResponseConverter
{
    internal static GetApprovalGraphsQueryResponse ToDto(GetApprovalGraphsQueryResponseInternal response)
    {
        ApprovalGraphDto graph = ApprovalGraphInternalConverter.ToDto(response.Graph);

        EntityTypeAttributeDto[] attributes =
            response.Attributes.Select(EntityTypeAttributeInternalToDtoConverter.ToDto).ToArray();

        GetApprovalGraphsQueryResponseGroup[] groups =
            response.Groups.Select(GetApprovalGraphsQueryResponseGroupInternalConverter.ToDto).ToArray();

        var concurrencyToken = ConcurrencyTokenConverterTo.ToString(response.ConcurrencyToken);

        var result = new GetApprovalGraphsQueryResponse
        {
            Graph = graph,
            Attributes = { attributes },
            Groups = { groups },
            ConcurrencyToken = concurrencyToken
        };

        return result;
    }
}
