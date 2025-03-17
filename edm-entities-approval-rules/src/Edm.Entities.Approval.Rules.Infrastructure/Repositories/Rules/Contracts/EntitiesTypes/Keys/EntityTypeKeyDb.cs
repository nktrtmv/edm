namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.EntitiesTypes.Keys;

internal sealed class EntityTypeKeyDb
{
    public EntityTypeKeyDb(
        string domainId,
        string entityTypeId,
        DateTime entityTypeUpdatedDate)
    {
        DomainId = domainId;
        EntityTypeId = entityTypeId;
        EntityTypeUpdatedDate = entityTypeUpdatedDate;
    }

    internal string DomainId { get; }
    internal string EntityTypeId { get; }
    internal DateTime EntityTypeUpdatedDate { get; }
}
