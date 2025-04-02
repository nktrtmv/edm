using Edm.DocumentGenerators.Application.Contracts;
using Edm.DocumentGenerators.Application.DocumentTemplates.Commands.Update.Contracts.Bare;
using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes;
using Edm.DocumentGenerators.Domain;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Statuses;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Tokens.Concurrency;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Contracts.Prototypes;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Contracts.Statuses;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Commands.Update.Contracts.Bare;

internal static class DocumentTemplateBareDtoConverter
{
    internal static DocumentTemplateBareInternal ToInternal(DocumentTemplateBareDto template)
    {
        DocumentTemplateStatus status = DocumentTemplateStatusDboConverter.ToInternal(template.Status);
        DocumentPrototypeInternal documentPrototype = DocumentPrototypeDtoConverter.ToInternal(template.DocumentPrototype);
        Metadata<FrontInternal> frontMetadata = MetadataConverterFrom<FrontInternal>.FromString(template.FrontMetadata);

        ConcurrencyToken<DocumentTemplateBareInternal> concurrencyToken =
            ConcurrencyTokenConverterFrom<DocumentTemplateBareInternal>.FromString(template.ConcurrencyToken);

        string domainId = DomainIdHelper.GetDomainIdOrSetDefault(template.DomainId);
        var result = new DocumentTemplateBareInternal(
            domainId,
            template.Id,
            template.Name,
            template.SystemName,
            status,
            documentPrototype,
            frontMetadata,
            concurrencyToken);

        return result;
    }
}
