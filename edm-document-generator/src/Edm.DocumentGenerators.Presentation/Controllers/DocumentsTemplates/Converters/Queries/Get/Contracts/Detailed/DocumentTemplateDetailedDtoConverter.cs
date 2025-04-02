using Edm.DocumentGenerators.Application.DocumentTemplates.Queries.Get.Contracts.Detailed;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Tokens.Concurrency;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Contracts.Prototypes;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Contracts.Statuses;
using Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Queries.Get.Contracts.Detailed.Audits;

using Google.Protobuf.WellKnownTypes;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsTemplates.Converters.Queries.Get.Contracts.Detailed;

internal static class DocumentTemplateDetailedDtoConverter
{
    internal static DocumentTemplateDetailedDto FromInternal(DocumentTemplateDetailedInternal template)
    {
        DocumentTemplateStatusDto status = DocumentTemplateStatusDboConverter.FromInternal(template.Status);

        DocumentPrototypeDto documentPrototype = DocumentPrototypeDtoConverter.FromInternal(template.DocumentPrototype);

        Timestamp? approvalAttributeVersion = NullableConverter.Convert(template.ApprovalAttributesVersion, UtcDateTimeConverterTo.ToTimeStamp);

        var frontMetadata = MetadataConverterTo.ToString(template.FrontMetadata);

        DocumentTemplateAuditDto audit = DocumentTemplateAuditDtoFromInternalConverter.FromInternal(template.Audit);

        var concurrencyToken = ConcurrencyTokenConverterTo.ToString(template.ConcurrencyToken);

        var result = new DocumentTemplateDetailedDto
        {
            Id = template.Id,
            DomainId = template.DomainId,
            Name = template.Name,
            SystemName = template.SystemName,
            Status = status,
            DocumentPrototype = documentPrototype,
            ApprovalAttributesVersion = approvalAttributeVersion,
            FrontMetadata = frontMetadata,
            Audit = audit,
            ConcurrencyToken = concurrencyToken
        };

        return result;
    }
}
