using Edm.Document.Searcher.Application.Documents.Markers;
using Edm.Document.Searcher.GenericSubdomain;

using MediatR;

namespace Edm.Document.Searcher.Application.Documents.Events.ApprovalWorkflows.ParticipantsChanged.Contracts;

public sealed record ParticipantsChangedEntitiesApprovalWorkflowEventInternal(
    string DomainId,
    Id<SearchDocumentInternal> DocumentId) : IRequest;
