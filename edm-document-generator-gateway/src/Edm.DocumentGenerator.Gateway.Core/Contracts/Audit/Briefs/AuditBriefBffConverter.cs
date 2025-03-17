using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Services.Enrichers.References;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Audit.Briefs;

internal static class AuditBriefBffConverter
{
    public static AuditBriefBff ToBff(AuditBriefDto audit, ReferencesEnricher personsEnricher)
    {
        var createdBy = PersonBff.CreateNotEnriched(audit.CreatedById);
        var updatedBy = PersonBff.CreateNotEnriched(audit.UpdatedById);
        var createdDateTime = audit.CreatedDateTime.ToDateTime();
        var updatedDateTime = audit.UpdatedDateTime.ToDateTime();

        personsEnricher.Add(createdBy);
        personsEnricher.Add(updatedBy);

        var result = new AuditBriefBff
        {
            CreatedBy = createdBy,
            UpdatedBy = updatedBy,
            CreatedDateTime = createdDateTime,
            UpdatedDateTime = updatedDateTime
        };

        return result;
    }
}
