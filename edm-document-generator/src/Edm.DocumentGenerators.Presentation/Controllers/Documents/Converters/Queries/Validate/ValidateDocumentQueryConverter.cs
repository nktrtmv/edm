using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.Documents.Queries.Validate.Contracts;
using Edm.DocumentGenerators.Application.Documents.Queries.Validate.Contracts.Parameters;
using Edm.DocumentGenerators.Domain;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Validate.Contracts.Parameters;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Validate;

internal static class ValidateDocumentQueryConverter
{
    internal static ValidateDocumentQueryInternal ToInternal(ValidateDocumentQuery command)
    {
        Id<DocumentInternal> documentId = IdConverterFrom<DocumentInternal>.FromString(command.DocumentId);
        string domainId = DomainIdHelper.GetDomainIdOrSetDefault(command.DomainId);

        DocumentValidateParametersInternal parameters = DocumentValidateParametersDtoConverter.ToInternal(command.Parameters);

        var result = new ValidateDocumentQueryInternal(domainId, documentId, parameters);

        return result;
    }
}
