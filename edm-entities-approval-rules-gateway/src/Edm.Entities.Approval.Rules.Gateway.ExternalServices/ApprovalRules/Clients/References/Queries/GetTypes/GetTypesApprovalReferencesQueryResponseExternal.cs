using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.GetTypes.Contracts.Types;

namespace Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.GetTypes;

public sealed class GetTypesApprovalReferencesQueryResponseExternal
{
    public GetTypesApprovalReferencesQueryResponseExternal(ApprovalReferenceTypeExternal[] types)
    {
        Types = types;
    }

    public ApprovalReferenceTypeExternal[] Types { get; }
}
