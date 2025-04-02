using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Tokens.Concurrency;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.DocumentsTemplates.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Audits.Briefs;
using Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates.Contracts.Data.ApprovalData;
using Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates.Contracts.Data.Prototypes;
using Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates.Contracts.Data.Statuses;

using Google.Protobuf;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates.Contracts;

internal static class DocumentTemplateDbFromDomainConverter
{
    internal static DocumentTemplateDb FromDomain(DocumentTemplate template)
    {
        var id = IdConverterTo.ToString(template.Id);

        byte[]? data = ToData(template);

        AuditBriefDb? audit = AuditBriefDbConverter.FromDomain(template.Audit.Brief);

        var concurrencyToken = ConcurrencyTokenConverterTo.ToDateTime(template.ConcurrencyToken);

        var result = new DocumentTemplateDb
        {
            Id = id,
            DomainId = template.DomainId.Value,
            SystemName = template.SystemName?.Value,
            Name = template.Name.Value,
            Data = data,
            CreatedById = audit.CreatedById,
            UpdatedById = audit.UpdatedById,
            CreatedDateTime = audit.CreatedDateTime,
            UpdatedDateTime = audit.UpdatedDateTime,
            IsDeleted = template.IsDeleted,
            ConcurrencyToken = concurrencyToken
        };

        return result;
    }

    private static byte[] ToData(DocumentTemplate template)
    {
        DocumentTemplateStatusDb status = DocumentTemplateStatusDbConverter.FromDomain(template.Status);

        DocumentTemplateApprovalDataDb? approvalData = DocumentTemplateApprovalDataDbConverter.FromDomain(template.ApprovalData);

        DocumentPrototypeDb? documentPrototype = DocumentPrototypeDbConverter.FromDomain(template.DocumentPrototype);

        var frontMetadata = MetadataConverterTo.ToString(template.FrontMetadata);

        var result = new DocumentTemplateDataDb
        {
            Status = status,
            ApprovalData = approvalData,
            DocumentPrototype = documentPrototype,
            FrontMetadata = frontMetadata
        };

        return result.ToByteArray();
    }
}
