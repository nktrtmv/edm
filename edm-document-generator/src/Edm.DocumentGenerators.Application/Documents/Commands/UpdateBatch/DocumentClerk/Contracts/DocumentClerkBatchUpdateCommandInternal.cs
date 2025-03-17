using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

using MediatR;

namespace Edm.DocumentGenerators.Application.Documents.Commands.UpdateBatch.DocumentClerk.Contracts;

public sealed record DocumentClerkBatchUpdateCommandInternal(string DomainId, Id<DocumentInternal>[] DocumentIds, Id<UserInternal> CurrentUserId, string NewClerkId)
    : IRequest<DocumentClerkBatchUpdateCommandInternalResponse>;
