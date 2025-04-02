namespace Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues.Contracts.Values;

public sealed class ApprovalReferenceValueExternal
{
    public ApprovalReferenceValueExternal(string id, string displayValue, string displaySubValue)
    {
        Id = id;
        DisplayValue = displayValue;
        DisplaySubValue = displaySubValue;
    }

    public string Id { get; }
    public string DisplayValue { get; }
    public string DisplaySubValue { get; }
}
