using Edm.Document.Searcher.Application.Documents.Markers;
using Edm.Document.Searcher.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Document.Searcher.Application.Documents.Events.ApprovalWorkflows.StageChanged.Contracts;

[UsedImplicitly]
public sealed record StageChangedEntitiesApprovalWorkflowEventInternal(
    string DomainId,
    Id<SearchDocumentInternal> DocumentId) : IRequest;
