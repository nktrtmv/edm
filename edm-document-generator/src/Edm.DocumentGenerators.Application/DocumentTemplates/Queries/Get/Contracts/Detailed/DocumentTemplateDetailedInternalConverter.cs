using Edm.DocumentGenerators.Application.Contracts;
using Edm.DocumentGenerators.Application.DocumentTemplates.Contracts.Prototypes;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Application.Audits;
using Edm.DocumentGenerators.GenericSubdomain.Tokens.Concurrency;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Queries.Get.Contracts.Detailed;

internal static class DocumentTemplateInternalConverter
{
    internal static DocumentTemplateDetailedInternal FromDomain(DocumentTemplate template)
    {
        var id = IdConverterTo.ToString(template.Id);

        DocumentPrototypeInternal? documentPrototype =
            DocumentPrototypeInternalConverter.FromDomain(template.DocumentPrototype, template);

        UtcDateTime<DocumentTemplate>? approvalAttributesVersion =
            NullableConverter.Convert(template.ApprovalData.AttributesVersion, UtcDateTimeConverterFrom<DocumentTemplate>.From);

        Metadata<FrontInternal> frontMetadata =
            MetadataConverterFrom<FrontInternal>.From(template.FrontMetadata);

        AuditInternal<DocumentTemplateDetailedInternal> audit =
            AuditInternalConverter<DocumentTemplateDetailedInternal>.FromDomain(template.Audit);

        ConcurrencyToken<DocumentTemplateDetailedInternal> concurrencyToken =
            ConcurrencyTokenConverterFrom<DocumentTemplateDetailedInternal>.From(template.ConcurrencyToken);

        var result = new DocumentTemplateDetailedInternal(
            template.DomainId.Value,
            id,
            template.Name.Value,
            template.SystemName?.Value,
            template.Status,
            documentPrototype,
            approvalAttributesVersion,
            frontMetadata,
            audit,
            concurrencyToken);

        return result;
    }
}
