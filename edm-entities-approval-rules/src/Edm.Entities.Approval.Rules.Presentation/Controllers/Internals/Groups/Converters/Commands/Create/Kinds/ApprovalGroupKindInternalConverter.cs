using Edm.Entities.Approval.Rules.Application.Internal.Groups.Commands.Create.Contracts.Kinds;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups.Converters.Commands.Create.Kinds;

internal static class ApprovalGroupKindInternalConverter
{
    internal static ApprovalGroupKindInternal FromDto(CreateApprovalGroupsCommandKindDto kind)
    {
        ApprovalGroupKindInternal result = kind switch
        {
            CreateApprovalGroupsCommandKindDto.Domestic => ApprovalGroupKindInternal.Domestic,
            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        return result;
    }
}
