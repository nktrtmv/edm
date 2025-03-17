using Edm.DocumentGenerators.Application.Contracts.Validators;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues;
using Edm.DocumentGenerators.Application.Documents.Queries.Validate.Contracts.Errors;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Validate.Contracts;

public sealed record ValidateDocumentQueryInternalResponse(
    DocumentValidatorValidationResultInternal[] ValidationResults,
    DocumentErrorsInternal DocumentErrors,
    DocumentAttributeValueDetailedInternal[] UpdatedAttributeValues);
