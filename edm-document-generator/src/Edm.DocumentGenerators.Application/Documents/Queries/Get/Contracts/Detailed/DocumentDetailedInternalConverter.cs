using Edm.DocumentGenerators.Application.Contracts;
using Edm.DocumentGenerators.Application.Contracts.DocumentsStagesTypes;
using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.Contracts.Parameters;
using Edm.DocumentGenerators.Application.Contracts.Statuses;
using Edm.DocumentGenerators.Application.Contracts.Statuses.Services;
using Edm.DocumentGenerators.Application.Contracts.Statuses.Services.Factories;
using Edm.DocumentGenerators.Application.Contracts.Validators;
using Edm.DocumentGenerators.Application.Documents.Commands.Contracts.Classifications;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.ApprovalData;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesErrors;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.Audits.Records;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.SigningData;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.StatusesTransitions;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.ValueObjects.Classifications;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Application.Audits;
using Edm.DocumentGenerators.GenericSubdomain.Tokens.Concurrency;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed;

internal static class DocumentDetailedInternalFromDomainConverter
{
    internal static DocumentDetailedInternal FromDomain(Document document, DocumentClassification? classification)
    {
        var id = IdConverterTo.ToString(document.Id);

        var templateId = IdConverterTo.ToString(document.TemplateId);

        DocumentStatusInternal? status =
            DocumentStatusInternalConverter.FromDomain(document.Status);

        DocumentStageTypeInternal stageType =
            DocumentStageTypeInternalConverter.FromDomain(document.StageType);

        DocumentStatusTransition[] transitions =
            document.StatusStateMachine.GetAvailableTransitionsForStatus(document.Status.Id);

        DocumentStatusTransitionDetailedInternal[] availableStatusesTransitions =
            transitions.Select(DocumentStatusTransitionDetailedInternalConverter.FromDomain).ToArray();

        DocumentAttributeValueDetailedInternal[] attributesValues =
            document.AttributesValues.Select(DocumentAttributeValueDetailedInternalFromDomainConverter.FromDomain).ToArray();

        DocumentAttributeErrorInternal[] attributesErrors = document.DocumentErrors.AttributesErrors.Select(DocumentAttributeErrorInternalConverter.FromDomain).ToArray();

        DocumentValidatorInternal[] validators =
            document.Validators.Select(DocumentValidatorInternalConverter.FromDomain).ToArray();

        DocumentApprovalDataInternal? approvalData =
            DocumentApprovalDataInternalConverter.FromDomain(document.ApprovalData);

        DocumentSigningDataInternal? signingData =
            DocumentSigningDataInternalConverter.FromDomain(document.SigningData);

        DocumentStatusInternalEnricher? statusEnricher =
            DocumentStatusInternalEnricherFactory.Create(document);

        Metadata<FrontInternal> frontMetadata =
            MetadataConverterFrom<FrontInternal>.From(document.FrontMetadata);

        AuditInternal<DocumentDetailedInternal> audit =
            AuditInternalConverter<DocumentDetailedInternal>.FromDomain(
                document.Audit,
                record => DocumentAuditRecordInternalConverter.FromDomain(record, statusEnricher));

        ConcurrencyToken<DocumentDetailedInternal> concurrencyToken =
            ConcurrencyTokenConverterFrom<DocumentDetailedInternal>.From(document.ConcurrencyToken);

        UtcDateTime<DocumentTemplateInternal>? templateUpdatedDate =
            NullableConverter.Convert(document.TemplateUpdatedDate, UtcDateTimeConverterFrom<DocumentTemplateInternal>.From);

        DocumentParametersInternal? parameters = DocumentParametersInternalConverter.FromDomain(document.Parameters);

        DocumentClassificationInternal? documentClassification = classification == null
            ? null
            : new DocumentClassificationInternal(
                classification.BusinessSegmentId.Value,
                classification.DocumentCategoryId.Value,
                classification.DocumentTypeId.Value,
                classification.DocumentKindId.Value);

        var result = new DocumentDetailedInternal(
            document.DomainId.Value,
            id,
            templateId,
            status,
            stageType,
            documentClassification,
            availableStatusesTransitions,
            attributesValues,
            attributesErrors,
            validators,
            approvalData,
            signingData,
            frontMetadata,
            audit,
            concurrencyToken,
            templateUpdatedDate,
            parameters);

        return result;
    }
}
