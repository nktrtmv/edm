using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Queries.GetAll.Contracts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Queries.GetAll.Graphs;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Queries.GetAll;

internal static class GetAllApprovalGraphsQueryResponseInternalConverter
{
    internal static GetAllApprovalGraphsQueryResponse ToDto(GetAllApprovalGraphsQueryResponseInternal response)
    {
        GetAllApprovalGraphsQueryResponseGraph[] graphs =
            response.Graphs.Select(GetAllApprovalGraphsQueryResponseGraphInternalConverter.ToDto).ToArray();

        var result = new GetAllApprovalGraphsQueryResponse
        {
            Graphs = { graphs }
        };

        return result;
    }
}
