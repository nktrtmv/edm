using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.Documents.Commands.Contracts.Classifications;
using Edm.DocumentGenerators.GenericSubdomain;

using MediatR;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Create.ByClassification.Contracts;

public sealed record CreateByClassificationDocumentsCommandInternal(
    string DomainId,
    DocumentClassificationInternal Classification,
    Id<UserInternal> CurrentUserId) : IRequest<CreateByClassificationDocumentsCommandInternalResponse>;
