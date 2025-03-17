using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit.Records.Headings;

internal static class AuditRecordHeadingBffConverter
{
    public static AuditRecordHeadingBff ToBff(AuditRecordHeadingDto heading, DocumentConversionContext context)
    {
        var updatedBy = PersonBff.CreateNotEnriched(heading.UpdatedById);
        context.Enricher.Add(updatedBy);

        var updatedDateTime = heading.UpdatedDateTime.ToDateTime();

        var result = new AuditRecordHeadingBff
        {
            UpdatedBy = updatedBy,
            UpdatedDateTime = updatedDateTime
        };

        return result;
    }
}
