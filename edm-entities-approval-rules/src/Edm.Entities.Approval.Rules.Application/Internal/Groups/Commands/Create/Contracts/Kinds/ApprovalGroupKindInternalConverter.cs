using Edm.Entities.Approval.Rules.Domain.Entities.Groups.Factories.Kinds;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Commands.Create.Contracts.Kinds;

internal static class ApprovalGroupKindInternalConverter
{
    internal static ApprovalGroupKind ToDomain(ApprovalGroupKindInternal kind)
    {
        ApprovalGroupKind result = kind switch
        {
            ApprovalGroupKindInternal.Domestic => ApprovalGroupKind.Domestic,
            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        return result;
    }
}
