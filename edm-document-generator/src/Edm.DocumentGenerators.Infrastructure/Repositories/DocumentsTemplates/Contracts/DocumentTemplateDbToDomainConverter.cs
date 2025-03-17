using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Factories;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.ApprovalData;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.Factories;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.Markers;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Briefs;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Briefs.Factories;
using Edm.DocumentGenerators.GenericSubdomain.Tokens.Concurrency;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.DocumentsTemplates.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates.Contracts.Data.ApprovalData;
using Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates.Contracts.Data.Prototypes;
using Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates.Contracts.Data.Statuses;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.DocumentsTemplates.Contracts;

internal static class DocumentTemplateDbToDomainConverter
{
    internal static DocumentTemplate ToDomain(DocumentTemplateDb template)
    {
        Id<DocumentTemplate>? id = IdConverterFrom<DocumentTemplate>.FromString(template.Id);

        Data data = ToData(template.Data);

        Audit<DocumentTemplate>? audit = ToAudit(template);

        ConcurrencyToken<DocumentTemplate> concurrencyToken = ConcurrencyTokenConverterFrom<DocumentTemplate>.FromUnspecifiedUtcDateTime(template.ConcurrencyToken);

        DomainId domainId = DomainId.Parse(template.DomainId);
        DocumentTemplateName name = DocumentTemplateName.Parse(template.Name);
        SystemName? systemName = string.IsNullOrWhiteSpace(template.SystemName)
            ? null
            : SystemName.Parse(template.SystemName);

        DocumentTemplate? result = DocumentTemplateFactory.CreateFromDb(
            domainId,
            id,
            name,
            systemName,
            data.Status,
            data.ApprovalData,
            data.DocumentPrototype,
            data.FrontMetadata,
            audit,
            concurrencyToken,
            template.IsDeleted);

        return result;
    }

    private static Audit<DocumentTemplate> ToAudit(DocumentTemplateDb template)
    {
        Id<AuditUser>? createdById =
            IdConverterFrom<AuditUser>.FromString(template.CreatedById);

        Id<AuditUser>? updatedById =
            IdConverterFrom<AuditUser>.FromString(template.UpdatedById);

        UtcDateTime<AuditDateTime> createdDateTime =
            UtcDateTimeConverterFrom<AuditDateTime>.FromUnspecifiedUtcDateTime(template.CreatedDateTime);

        UtcDateTime<AuditDateTime> updatedDateTime =
            UtcDateTimeConverterFrom<AuditDateTime>.FromUnspecifiedUtcDateTime(template.UpdatedDateTime);

        AuditBrief<DocumentTemplate>? auditBrief =
            AuditBriefFactory<DocumentTemplate>.CreateFromDb(createdById, updatedById, createdDateTime, updatedDateTime);

        Audit<DocumentTemplate>? result = AuditFactory<DocumentTemplate>.CreateFromDb(auditBrief, []);

        return result;
    }

    private static Data ToData(byte[] bytes)
    {
        DocumentTemplateDataDb? data = DocumentTemplateDataDb.Parser.ParseFrom(bytes);

        DocumentTemplateStatus status = DocumentTemplateStatusDbConverter.ToDomain(data.Status);

        DocumentTemplateApprovalData? approvalData = DocumentTemplateApprovalDataDbConverter.ToDomain(data.ApprovalData);

        DocumentPrototype? documentPrototype = DocumentPrototypeDbConverter.ToDomain(data.DocumentPrototype);

        Metadata<Front> frontMetadata = MetadataConverterFrom<Front>.FromString(data.FrontMetadata);

        var result = new Data(
            status,
            approvalData,
            documentPrototype,
            frontMetadata);

        return result;
    }

    private readonly record struct Data(
        DocumentTemplateStatus Status,
        DocumentTemplateApprovalData ApprovalData,
        DocumentPrototype DocumentPrototype,
        Metadata<Front> FrontMetadata);
}
