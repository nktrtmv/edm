using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Commands.Create.Contracts;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Commands.Create;

internal static class CreateApprovalGraphsCommandResponseInternalConverter
{
    internal static CreateApprovalGraphsCommandResponse ToDto(CreateApprovalGraphsCommandResponseInternal response)
    {
        var graphId = IdConverterTo.ToString(response.GraphId);

        var result = new CreateApprovalGraphsCommandResponse
        {
            GraphId = graphId
        };

        return result;
    }
}
