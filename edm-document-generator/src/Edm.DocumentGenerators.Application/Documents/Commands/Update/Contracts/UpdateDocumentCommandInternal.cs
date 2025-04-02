using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts.Parameters;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Update.Contracts;

public sealed record UpdateDocumentCommandInternal(
    Id<DocumentInternal> DocumentId,
    DocumentUpdateParametersInternal Parameters,
    ConcurrencyToken<DocumentInternal> ConcurrencyToken,
    Id<UserInternal> CurrentUserId) : IRequest;
