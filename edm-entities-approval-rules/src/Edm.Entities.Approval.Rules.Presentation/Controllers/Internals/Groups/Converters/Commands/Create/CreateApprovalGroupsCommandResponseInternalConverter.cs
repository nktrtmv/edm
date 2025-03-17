using Edm.Entities.Approval.Rules.Application.Internal.Groups.Commands.Create.Contracts;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Commands.Create;

internal static class CreateApprovalGroupsCommandResponseInternalConverter
{
    internal static CreateApprovalGroupsCommandResponse ToDto(CreateApprovalGroupsCommandResponseInternal response)
    {
        var groupId = IdConverterTo.ToString(response.GroupId);

        var result = new CreateApprovalGroupsCommandResponse
        {
            GroupId = groupId
        };

        return result;
    }
}
