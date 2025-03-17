using Edm.DocumentGenerators.Application.Contracts;
using Edm.DocumentGenerators.Application.Contracts.DocumentsStagesTypes;
using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.Contracts.Parameters;
using Edm.DocumentGenerators.Application.Contracts.Statuses;
using Edm.DocumentGenerators.Application.Contracts.Validators;
using Edm.DocumentGenerators.Application.Documents.Commands.Contracts.Classifications;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.ApprovalData;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesErrors;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.SigningData;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.StatusesTransitions;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Application.Audits;
using Edm.DocumentGenerators.GenericSubdomain.Tokens.Concurrency;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed;

public sealed record DocumentDetailedInternal(
    string DomainId,
    string Id,
    string TemplateId,
    DocumentStatusInternal Status,
    DocumentStageTypeInternal StageType,
    DocumentClassificationInternal? Classification,
    DocumentStatusTransitionDetailedInternal[] AvailableStatusesTransitions,
    DocumentAttributeValueDetailedInternal[] AttributesValues,
    DocumentAttributeErrorInternal[] AttributesErrors,
    DocumentValidatorInternal[] Validators,
    DocumentApprovalDataInternal ApprovalData,
    DocumentSigningDataInternal SigningData,
    Metadata<FrontInternal> FrontMetadata,
    AuditInternal<DocumentDetailedInternal> Audit,
    ConcurrencyToken<DocumentDetailedInternal> ConcurrencyToken,
    UtcDateTime<DocumentTemplateInternal>? TemplateUpdatedDate,
    DocumentParametersInternal Parameters);
