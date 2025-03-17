using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Groups.Commands.Create.Contracts.Kinds;

internal static class CreateApprovalGroupsCommandKindBffConverter
{
    internal static CreateApprovalGroupsCommandKindDto ToDto(CreateApprovalGroupsCommandKindBff kind)
    {
        var result = kind switch
        {
            CreateApprovalGroupsCommandKindBff.Domestic => CreateApprovalGroupsCommandKindDto.Domestic,
            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        return result;
    }
}
