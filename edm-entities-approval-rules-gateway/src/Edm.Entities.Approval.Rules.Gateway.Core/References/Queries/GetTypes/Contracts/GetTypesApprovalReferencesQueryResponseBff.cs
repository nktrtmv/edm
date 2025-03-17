using Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.GetTypes.Contracts.Types;

namespace Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.GetTypes.Contracts;

public sealed class GetTypesApprovalReferencesQueryResponseBff
{
    public required ApprovalReferenceTypeBff[] Types { get; init; }
}
