using Edm.DocumentGenerators.Domain;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.Factories;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Approvals.Data;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Errors;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects;
using Edm.DocumentGenerators.Domain.ValueObjects.Notifications;
using Edm.DocumentGenerators.Domain.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.Domain.ValueObjects.Validators;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.Factories;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.Markers;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Briefs;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Briefs.Factories;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Audits.ValueObjects.Records;
using Edm.DocumentGenerators.GenericSubdomain.Tokens.Concurrency;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.Documents;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Notifications;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Parameters;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.StatusesTransitions;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Validators;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApplicationEvents;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.ApprovalData;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.AttributesValues;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Audits.Records;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Errors;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.SigningData;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts;

internal static class DocumentDbToDomainConverter
{
    internal static Document ToDomain(DocumentDb document)
    {
        Id<Document> id = IdConverterFrom<Document>.FromString(document.Id);

        Id<DocumentTemplate> templateId = IdConverterFrom<DocumentTemplate>.FromString(document.TemplateId);

        Id<DocumentStatus> statusId = IdConverterFrom<DocumentStatus>.FromString(document.StatusId);

        DocumentDataDb? protobufData = DocumentDataDb.Parser.ParseFrom(document.Data);

        Data data = ToData(protobufData);

        Audit<Document> audit = ToAudit(document, data.AuditRecords);

        ConcurrencyToken<Document> concurrencyToken =
            ConcurrencyTokenConverterFrom<Document>.FromUnspecifiedUtcDateTime(document.ConcurrencyToken);

        SystemName? templateSystemName = string.IsNullOrWhiteSpace(document.TemplateSystemName)
            ? null
            : SystemName.Parse(document.TemplateSystemName);

        string? domainIdString = DomainIdHelper.GetDomainIdOrSetDefault(document.DomainId);

        DomainId domainId = DomainId.Parse(domainIdString);

        Document? result = DocumentFactory.CreateFromDb(
            domainId,
            id,
            templateId,
            templateSystemName,
            statusId,
            data.StatusTransitions,
            data.AttributesValues,
            data.Errors,
            data.Validators,
            data.Notifications,
            data.ApprovalData,
            data.SigningData,
            data.FrontMetadata,
            audit,
            data.ApplicationEvents,
            concurrencyToken,
            data.TemplateUpdatedDate,
            data.Parameters);

        return result;
    }

    private static Audit<Document> ToAudit(DocumentDb document, AuditRecord<Document>[] records)
    {
        Id<AuditUser> createdById =
            IdConverterFrom<AuditUser>.FromString(document.CreatedById);

        Id<AuditUser> updatedById =
            IdConverterFrom<AuditUser>.FromString(document.UpdatedById);

        UtcDateTime<AuditDateTime> createdDateTime =
            UtcDateTimeConverterFrom<AuditDateTime>.FromUnspecifiedUtcDateTime(document.CreatedDateTime);

        UtcDateTime<AuditDateTime> updatedDateTime =
            UtcDateTimeConverterFrom<AuditDateTime>.FromUnspecifiedUtcDateTime(document.UpdatedDateTime);

        AuditBrief<Document> auditBrief =
            AuditBriefFactory<Document>.CreateFromDb(createdById, updatedById, createdDateTime, updatedDateTime);

        Audit<Document> result =
            AuditFactory<Document>.CreateFromDb(auditBrief, records);

        return result;
    }

    private static Data ToData(DocumentDataDb data)
    {
        DocumentStatusTransition[] statusTransitions =
            data.StatusTransitions.Select(DocumentStatusTransitionDbConverter.ToDomain).ToArray();

        DocumentAttributeValue[] attributesValues =
            data.AttributesValues.Select(DocumentAttributeValueDbToDomainConverter.ToDomain).ToArray();

        DocumentErrors? documentErrors = data.DocumentErrors is null
            ? DocumentErrorsDbConverter.ObsoleteToDomain(data.AttributesErrorsObsolete)
            : DocumentErrorsDbConverter.ToDomain(data.DocumentErrors);

        DocumentValidator[] validators =
            data.Validators.Select(DocumentValidatorDbConverter.ToDomain).ToArray();

        DocumentNotification[] notifications =
            data.Notifications.Select(DocumentNotificationDbConverter.ToDomain).ToArray();

        AuditRecord<Document>[] auditRecords =
            data.AuditRecords.Select(r => DocumentAuditRecordDbConverter.ToDomain(r, statusTransitions)).ToArray();

        DocumentApprovalData? approvalData =
            DocumentApprovalDataDbConverter.ToDomain(data.ApprovalData);

        DocumentSigningData? signingData =
            DocumentSigningDataDbConverter.ToDomainObsolete(data.SigningData);

        Metadata<Front> frontMetadata =
            MetadataConverterFrom<Front>.FromString(data.FrontMetadata);

        List<DocumentApplicationEvent> applicationEvents =
            data.ApplicationEvents.Select(DocumentApplicationEventDbToDomainConverter.ToDomain).ToList();

        UtcDateTime<DocumentTemplate>? templateUpdatedDate = NullableConverter.Convert(
            data.TemplateUpdatedDate,
            UtcDateTimeConverterFrom<DocumentTemplate>.FromTimestamp);

        DocumentParameters? parameters = DocumentParametersDbConverter.ToDomain(data.Parameters);

        var result = new Data(
            statusTransitions,
            attributesValues,
            documentErrors,
            validators,
            notifications,
            auditRecords,
            approvalData,
            signingData,
            frontMetadata,
            applicationEvents,
            templateUpdatedDate,
            parameters);

        return result;
    }

    private readonly record struct Data(
        DocumentStatusTransition[] StatusTransitions,
        DocumentAttributeValue[] AttributesValues,
        DocumentErrors Errors,
        DocumentValidator[] Validators,
        DocumentNotification[] Notifications,
        AuditRecord<Document>[] AuditRecords,
        DocumentApprovalData ApprovalData,
        DocumentSigningData SigningData,
        Metadata<Front> FrontMetadata,
        List<DocumentApplicationEvent> ApplicationEvents,
        UtcDateTime<DocumentTemplate>? TemplateUpdatedDate,
        DocumentParameters Parameters);
}
