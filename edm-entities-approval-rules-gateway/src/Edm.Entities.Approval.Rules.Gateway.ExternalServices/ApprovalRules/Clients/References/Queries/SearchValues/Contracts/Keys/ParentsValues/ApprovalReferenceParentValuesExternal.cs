namespace Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues.Contracts.Keys.ParentsValues;

public sealed class ApprovalReferenceParentValuesExternal
{
    public ApprovalReferenceParentValuesExternal(string referenceTypeId, string[] ids)
    {
        ReferenceTypeId = referenceTypeId;
        Ids = ids;
    }

    public string ReferenceTypeId { get; }
    public string[] Ids { get; }
}
