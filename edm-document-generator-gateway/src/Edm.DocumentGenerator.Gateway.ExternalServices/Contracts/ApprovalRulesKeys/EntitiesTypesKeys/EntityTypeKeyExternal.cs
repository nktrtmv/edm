namespace Edm.DocumentGenerator.Gateway.ExternalServices.Contracts.ApprovalRulesKeys.
    EntitiesTypesKeys;

public sealed class EntityTypeKeyExternal
{
    public EntityTypeKeyExternal(string domainId, string entityTypeId, DateTime entityTypeUpdatedDate)
    {
        DomainId = domainId;
        EntityTypeId = entityTypeId;
        EntityTypeUpdatedDate = entityTypeUpdatedDate;
    }

    public string DomainId { get; }
    public string EntityTypeId { get; }
    public DateTime EntityTypeUpdatedDate { get; }
}
