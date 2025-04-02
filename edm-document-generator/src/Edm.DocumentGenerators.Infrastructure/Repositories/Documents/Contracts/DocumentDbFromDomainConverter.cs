using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Tokens.Concurrency;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Repositories.Documents;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Audits.Briefs;
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

using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts;

internal static class DocumentDbFromDomainConverter
{
    internal static DocumentDb FromDomain(Document document)
    {
        var id = IdConverterTo.ToString(document.Id);

        var templateId = IdConverterTo.ToString(document.TemplateId);

        var statusId = IdConverterTo.ToString(document.Status.Id);

        byte[]? data = ToData(document);

        AuditBriefDb? audit = AuditBriefDbConverter.FromDomain(document.Audit.Brief);

        var concurrencyToken = ConcurrencyTokenConverterTo.ToDateTime(document.ConcurrencyToken);

        var result = new DocumentDb
        {
            Id = id,
            TemplateId = templateId,
            TemplateSystemName = document.TemplateSystemName?.Value,
            StatusId = statusId,
            Data = data,
            CreatedById = audit.CreatedById,
            UpdatedById = audit.UpdatedById,
            CreatedDateTime = audit.CreatedDateTime,
            UpdatedDateTime = audit.UpdatedDateTime,
            ConcurrencyToken = concurrencyToken
        };

        return result;
    }

    private static byte[] ToData(Document document)
    {
        DocumentStatusTransitionDb[] statusTransitions =
            document.StatusStateMachine.Transitions.Select(DocumentStatusTransitionDbConverter.FromDomain).ToArray();

        DocumentAttributeValueDb[] attributesValues =
            document.AttributesValues.Select(DocumentAttributeValueDbFromDomainConverter.FromDomain).ToArray();

        DocumentErrorsDb? errors =
            DocumentErrorsDbConverter.FromDomain(document.DocumentErrors);

        DocumentValidatorDb[] validators =
            document.Validators.Select(DocumentValidatorDbConverter.FromDomain).ToArray();

        DocumentNotificationDb[] notifications =
            document.Notifications.Select(DocumentNotificationDbConverter.FromDomain).ToArray();

        DocumentAuditRecordDb[] auditRecords =
            document.Audit.Records.Select(DocumentAuditRecordDbConverter.FromDomain).ToArray();

        DocumentApprovalDataDb? approvalData =
            DocumentApprovalDataDbConverter.FromDomain(document.ApprovalData);

        DocumentSigningDataDb? signingData =
            DocumentSigningDataDbConverter.FromDomain(document.SigningData);

        var frontMetadata =
            MetadataConverterTo.ToString(document.FrontMetadata);

        DocumentApplicationEventDb[] applicationEvents =
            document.ApplicationEvents.Select(DocumentApplicationEventDbFromDomainConverter.FromDomain).ToArray();

        Timestamp? templateUpdatedDate = NullableConverter.Convert(document.TemplateUpdatedDate, UtcDateTimeConverterTo.ToTimeStamp);

        DocumentParametersDb? parameters = DocumentParametersDbConverter.FromDomain(document.Parameters);

        var data = new DocumentDataDb
        {
            StatusTransitions = { statusTransitions },
            AttributesValues = { attributesValues },
            DocumentErrors = errors,
            Validators = { validators },
            Notifications = { notifications },
            AuditRecords = { auditRecords },
            ApprovalData = approvalData,
            SigningData = signingData,
            FrontMetadata = frontMetadata,
            ApplicationEvents = { applicationEvents },
            TemplateUpdatedDate = templateUpdatedDate,
            Parameters = parameters
        };

        byte[]? result = data.ToByteArray();

        return result;
    }
}
