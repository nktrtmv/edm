using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Commands.Update.Contracts;

internal static class DocumentTemplateBareBffConverter
{
    public static DocumentTemplateBareDto ToDto(DomainRoles domainRoles, DocumentTemplateBareBff template)
    {
        var status = DocumentTemplateStatusBffConverter.ToDto(template.Status);

        var documentPrototype = DocumentPrototypeBffConverter.ToDto(domainRoles, template.DocumentPrototype);

        var templateDto = new DocumentTemplateBareDto
        {
            Id = template.Id,
            DomainId = template.DomainId,
            Name = template.Name,
            SystemName = template.SystemName,
            Status = status,
            DocumentPrototype = documentPrototype,
            FrontMetadata = template.FrontMetadata,
            ConcurrencyToken = template.ConcurrencyToken
        };

        return templateDto;
    }
}
