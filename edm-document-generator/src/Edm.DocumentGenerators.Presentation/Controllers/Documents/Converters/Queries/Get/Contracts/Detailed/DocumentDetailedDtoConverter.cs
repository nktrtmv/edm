using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Tokens.Concurrency;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.DocumentsStagesTypes;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Parameters;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Statuses;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Validators;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.ApprovalData;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.AttributesValues;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.Audits;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.SigningData;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.StatusTransitions;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Validate.Contracts.Errors.Attributes;

using Google.Protobuf.WellKnownTypes;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed;

internal static class DocumentDetailedDtoConverter
{
    internal static DocumentDetailedDto FromInternal(DocumentDetailedInternal document)
    {
        DocumentStatusDto? status = DocumentStatusDtoConverter.FromInternal(document.Status);

        DocumentStageTypeDto stageType = DocumentStageTypeDtoConverter.FromInternal(document.StageType);

        DocumentStatusTransitionDetailedDto[] availableStatusesTransitions =
            document.AvailableStatusesTransitions.Select(DocumentStatusTransitionDetailedDtoConverter.FromInternal).ToArray();

        DocumentAttributeValueDetailedDto[] attributesValues =
            document.AttributesValues.Select(DocumentAttributeValueDetailedDtoFromInternalConverter.FromInternal).ToArray();

        DocumentAttributeErrorDto[] attributes = document.AttributesErrors.Select(DocumentAttributeErrorDtoConverter.FromInternal).ToArray();

        DocumentValidatorDto[] validators =
            document.Validators.Select(DocumentValidatorDtoConverter.FromInternal).ToArray();

        DocumentApprovalDataDto? approvalData = DocumentApprovalDataDtoConverter.FromInternal(document.ApprovalData);

        DocumentSigningDataDto? signingData = DocumentSigningDataDtoConverter.FromInternal(document.SigningData);

        var frontMetadata = MetadataConverterTo.ToString(document.FrontMetadata);

        DocumentAuditDto? audit = DocumentAuditDtoFromInternalConverter.FromInternal(document.Audit);

        var concurrencyToken = ConcurrencyTokenConverterTo.ToString(document.ConcurrencyToken);

        Timestamp? templateUpdatedDate = NullableConverter.Convert(document.TemplateUpdatedDate, UtcDateTimeConverterTo.ToTimeStamp);

        DocumentParametersDto? parameters = DocumentParametersDtoConverter.FromInternal(document.Parameters);

        ClassificationDto? classification = document.Classification == null
            ? null
            : new ClassificationDto
            {
                Category = document.Classification.DocumentCategoryId,
                Kind = document.Classification.DocumentKindId,
                Type = document.Classification.DocumentTypeId,
                BusinessSegment = document.Classification.BusinessSegmentId
            };

        var result = new DocumentDetailedDto
        {
            DomainId = document.DomainId,
            Id = document.Id,
            TemplateId = document.TemplateId,
            Status = status,
            StageType = stageType,
            AvailableStatusesTransitions = { availableStatusesTransitions },
            AttributesValues = { attributesValues },
            Validators = { validators },
            ApprovalData = approvalData,
            SigningData = signingData,
            FrontMetadata = frontMetadata,
            Audit = audit,
            ConcurrencyToken = concurrencyToken,
            TemplateUpdatedDate = templateUpdatedDate,
            AttributesErrorsObsolete = { attributes },
            Parameters = parameters,
            Classification = classification
        };

        return result;
    }
}
