namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Audits.Briefs;

public sealed class AuditBriefDb
{
    internal AuditBriefDb(string createdById, string updatedById, DateTime createdDateTime, DateTime updatedDateTime)
    {
        CreatedById = createdById;
        UpdatedById = updatedById;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public string CreatedById { get; }
    public string UpdatedById { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
}
