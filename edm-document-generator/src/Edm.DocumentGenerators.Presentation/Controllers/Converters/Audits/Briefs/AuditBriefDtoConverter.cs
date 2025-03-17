using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Briefs;
using Edm.DocumentGenerators.Presentation.Abstractions;

using Google.Protobuf.WellKnownTypes;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.Audits.Briefs;

internal static class AuditBriefDtoConverter
{
    internal static AuditBriefDto FromInternal<T>(AuditBriefInternal<T> document)
    {
        var createdById = IdConverterTo.ToString(document.CreatedById);

        var updatedById = IdConverterTo.ToString(document.UpdatedById);

        Timestamp createdDateTime = UtcDateTimeConverterTo.ToTimeStamp(document.CreatedDateTime);

        Timestamp updatedDateTime = UtcDateTimeConverterTo.ToTimeStamp(document.UpdatedDateTime);

        var result = new AuditBriefDto
        {
            CreatedById = createdById,
            UpdatedById = updatedById,
            CreatedDateTime = createdDateTime,
            UpdatedDateTime = updatedDateTime
        };

        return result;
    }
}
