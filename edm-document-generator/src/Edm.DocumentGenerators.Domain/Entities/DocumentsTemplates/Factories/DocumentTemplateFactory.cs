using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.ApprovalData;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.ApprovalData.Factories;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Factories;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.Factories;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.Services.Updaters;
using Edm.DocumentGenerators.GenericSubdomain.Tokens.Concurrency;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Factories;

public static class DocumentTemplateFactory
{
    public static DocumentTemplate CreateFrom(
        DomainId domainId,
        Id<DocumentTemplate> templateId,
        DocumentTemplateName name,
        DocumentTemplateStatus newTemplateStatus,
        Id<User> currentUserId,
        DocumentTemplate sourceTemplate)
    {
        Audit<DocumentTemplate> audit = AuditUpdater.Update(sourceTemplate.Audit, currentUserId);

        var concurrencyToken = ConcurrencyToken<DocumentTemplate>.Empty;

        DocumentTemplate? result = CreateFromDb(
            domainId,
            templateId,
            name,
            null,
            newTemplateStatus,
            sourceTemplate.ApprovalData,
            sourceTemplate.DocumentPrototype,
            sourceTemplate.FrontMetadata,
            audit,
            concurrencyToken,
            sourceTemplate.IsDeleted);

        return result;
    }

    public static DocumentTemplate CreateNew(
        DomainId domainId,
        Id<DocumentTemplate> templateId,
        DocumentTemplateName name,
        SystemName? systemName,
        Id<User> currentUserId)
    {
        const DocumentTemplateStatus status = DocumentTemplateStatus.Draft;

        DocumentTemplateApprovalData? approvalData = DocumentTemplateApprovalDataFactory.CreateNew();

        DocumentPrototype? documentPrototype = DocumentPrototypeFactory.CreateNew();

        var frontMetadata = Metadata<Front>.Empty;

        Audit<DocumentTemplate> audit = AuditFactory<DocumentTemplate>.CreateNew(currentUserId);

        var concurrencyToken = ConcurrencyToken<DocumentTemplate>.Empty;

        var result = new DocumentTemplate(
            domainId,
            templateId,
            name,
            systemName,
            status,
            approvalData,
            documentPrototype,
            frontMetadata,
            audit,
            concurrencyToken,
            false);

        return result;
    }

    public static DocumentTemplate CreateFromDb(
        DomainId domainId,
        Id<DocumentTemplate> id,
        DocumentTemplateName name,
        SystemName? systemName,
        DocumentTemplateStatus status,
        DocumentTemplateApprovalData approvalData,
        DocumentPrototype documentPrototype,
        Metadata<Front> frontMetadata,
        Audit<DocumentTemplate> audit,
        ConcurrencyToken<DocumentTemplate> concurrencyToken,
        bool isDeleted)
    {
        var result = new DocumentTemplate(
            domainId,
            id,
            name,
            systemName,
            status,
            approvalData,
            documentPrototype,
            frontMetadata,
            audit,
            concurrencyToken,
            isDeleted);

        return result;
    }
}
