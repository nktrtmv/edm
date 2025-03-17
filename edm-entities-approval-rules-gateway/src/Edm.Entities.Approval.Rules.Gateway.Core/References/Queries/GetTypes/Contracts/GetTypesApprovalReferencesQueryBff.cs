using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Keys;

namespace Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.GetTypes.Contracts;

public sealed class GetTypesApprovalReferencesQueryBff
{
    public required EntityTypeKeyBff EntityTypeKey { get; init; }
}
