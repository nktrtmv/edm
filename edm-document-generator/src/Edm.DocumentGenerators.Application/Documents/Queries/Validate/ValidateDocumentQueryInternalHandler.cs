using Edm.DocumentGenerators.Application.Contracts.Validators;
using Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters.AttributesChanges;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues;
using Edm.DocumentGenerators.Application.Documents.Queries.Validate.Contracts;
using Edm.DocumentGenerators.Application.Documents.Queries.Validate.Contracts.Errors;
using Edm.DocumentGenerators.Application.Documents.Queries.Validate.Contracts.Parameters;
using Edm.DocumentGenerators.Application.Documents.Services;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Updaters.Parameters.ValueObjects.AttributesChanges;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Validators;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Validators.Parameters;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Validators.Results;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Validate;

[UsedImplicitly]
internal sealed class ValidateDocumentQueryInternalHandler(DocumentsFacade documents)
    : IRequestHandler<ValidateDocumentQueryInternal, ValidateDocumentQueryInternalResponse>
{
    public async Task<ValidateDocumentQueryInternalResponse> Handle(ValidateDocumentQueryInternal request, CancellationToken cancellationToken)
    {
        Id<Document> documentId = IdConverterFrom<Document>.From(request.DocumentId);
        DomainId domainId = DomainId.Parse(request.DomainId);

        Document document = await documents.GetRequired(domainId, documentId, true, cancellationToken);

        DocumentValidateParameters validateParameters =
            DocumentValidateParametersInternalConverter.ToDomain(request.Parameters, document);

        DocumentValidatorValidationResult[] validationResult =
            DocumentValidatorByValidators.GetValidationResults(validateParameters);

        DocumentValidatorValidationResultInternal[] validationResultInternal =
            validationResult.Select(DocumentValidationResultInternalConverter.FromDomain).ToArray();

        DocumentErrorsInternal documentErrors = DocumentErrorsInternalConverter.FromDomain(document.DocumentErrors);

        DocumentAttributesChange documentAttributesValuesChange = DocumentAttributesChangeConverter.FromInternal(request.Parameters, document);

        DocumentAttributeValueDetailedInternal[] attributesValues =
            documentAttributesValuesChange.UpdatedValues.Select(DocumentAttributeValueDetailedInternalFromDomainConverter.FromDomain).ToArray();

        var result = new ValidateDocumentQueryInternalResponse(validationResultInternal, documentErrors, attributesValues);

        return result;
    }
}
