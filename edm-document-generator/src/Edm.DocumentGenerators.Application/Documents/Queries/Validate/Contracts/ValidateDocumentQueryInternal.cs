using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.Documents.Queries.Validate.Contracts.Parameters;
using Edm.DocumentGenerators.GenericSubdomain;

using MediatR;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Validate.Contracts;

public sealed record ValidateDocumentQueryInternal(
    string DomainId,
    Id<DocumentInternal> DocumentId,
    DocumentValidateParametersInternal Parameters)
    : IRequest<ValidateDocumentQueryInternalResponse>;
