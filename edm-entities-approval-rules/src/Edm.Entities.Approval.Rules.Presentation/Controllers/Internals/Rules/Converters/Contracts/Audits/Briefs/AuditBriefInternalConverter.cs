using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Application.Briefs;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Contracts.Audits.Briefs;

internal static class AuditBriefInternalConverter
{
    internal static AuditBriefDto ToDto<T>(AuditBriefInternal<T> audit)
    {
        var createdBy = IdConverterTo.ToString(audit.CreatedBy);
        var updatedBy = IdConverterTo.ToString(audit.UpdatedBy);

        Timestamp createdAt = UtcDateTimeConverterTo.ToTimeStamp(audit.CreatedAt);
        Timestamp updatedAt = UtcDateTimeConverterTo.ToTimeStamp(audit.UpdatedAt);

        var result = new AuditBriefDto
        {
            CreatedBy = createdBy,
            UpdatedBy = updatedBy,
            CreatedAt = createdAt,
            UpdatedAt = updatedAt
        };

        return result;
    }
}
