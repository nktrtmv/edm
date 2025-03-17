using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Audit.Briefs;
using Edm.DocumentGenerator.Gateway.Core.Services.Enrichers.References;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.Contracts.Audit;

internal static class DocumentTemplateAuditBffConverter
{
    public static DocumentTemplateAuditBff ToBff(DocumentTemplateAuditDto audit, ReferencesEnricher personsEnrichers)
    {
        var brief = AuditBriefBffConverter.ToBff(audit.Brief, personsEnrichers);

        var result = new DocumentTemplateAuditBff
        {
            Brief = brief
        };

        return result;
    }
}
