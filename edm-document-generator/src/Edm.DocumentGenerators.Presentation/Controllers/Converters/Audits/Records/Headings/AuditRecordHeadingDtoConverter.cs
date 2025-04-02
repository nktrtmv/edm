using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Application.Audits.Records.ValueObjects.Headings;
using Edm.DocumentGenerators.Presentation.Abstractions;

using Google.Protobuf.WellKnownTypes;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.Audits.Records.Headings;

internal static class AuditRecordHeadingDtoConverter
{
    internal static AuditRecordHeadingDto FromInternal<T>(AuditRecordHeadingInternal<T> heading)
    {
        var updatedById = IdConverterTo.ToString(heading.UpdatedById);

        Timestamp updatedDateTime = UtcDateTimeConverterTo.ToTimeStamp(heading.UpdatedDateTime);

        var result = new AuditRecordHeadingDto
        {
            UpdatedById = updatedById,
            UpdatedDateTime = updatedDateTime
        };

        return result;
    }
}
