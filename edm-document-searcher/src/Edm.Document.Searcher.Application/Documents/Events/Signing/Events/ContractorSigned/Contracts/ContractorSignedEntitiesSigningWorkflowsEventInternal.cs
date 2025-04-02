using Edm.Document.Searcher.Application.Documents.Markers;
using Edm.Document.Searcher.GenericSubdomain;

using MediatR;

namespace Edm.Document.Searcher.Application.Documents.Events.Signing.Events.ContractorSigned.Contracts;

public sealed record ContractorSignedEntitiesSigningWorkflowsEventInternal(
    Id<SearchDocumentInternal> DocumentId,
    string DomainId)
    : IRequest;
