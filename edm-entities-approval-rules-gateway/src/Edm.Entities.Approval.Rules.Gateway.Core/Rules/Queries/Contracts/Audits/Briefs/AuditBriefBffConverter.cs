using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Persons;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Contracts.Audits.Briefs;

internal static class AuditBriefBffConverter
{
    internal static AuditBriefBff FromDto(AuditBriefDto audit, EnrichersContext context)
    {
        var createdBy = PersonBffConverter.FromDto(audit.CreatedBy, context);

        var updatedBy = PersonBffConverter.FromDto(audit.UpdatedBy, context);

        var createdAt = audit.CreatedAt.ToDateTime();

        var updatedAt = audit.UpdatedAt.ToDateTime();

        var result = new AuditBriefBff
        {
            CreatedBy = createdBy,
            UpdatedBy = updatedBy,
            CreatedAt = createdAt,
            UpdatedAt = updatedAt
        };

        return result;
    }
}
