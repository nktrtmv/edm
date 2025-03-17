using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Audit.Briefs;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Services.Enrichers.References;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.GetAll.Contracts.Slim;

internal static class DocumentTemplateSlimBffConverter
{
    public static DocumentTemplateSlimBff ToBff(string domainId, DocumentTemplateSlimDto dto, ReferencesEnricher personsEnricher)
    {
        var status = DocumentTemplateStatusBffConverter.ToBff(dto.Status);

        var audit = AuditBriefBffConverter.ToBff(dto.Audit, personsEnricher);

        var bff = new DocumentTemplateSlimBff
        {
            Id = dto.Id,
            DomainId = domainId,
            Name = dto.Name,
            Status = status,
            Audit = audit
        };

        return bff;
    }
}
