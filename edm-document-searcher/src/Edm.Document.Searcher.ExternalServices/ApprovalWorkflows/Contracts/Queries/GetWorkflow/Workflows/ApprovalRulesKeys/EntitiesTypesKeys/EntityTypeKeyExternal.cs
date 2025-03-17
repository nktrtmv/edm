using Edm.Document.Searcher.ExternalServices.Markers;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.ApprovalRulesKeys.
    EntitiesTypesKeys;

public sealed record EntityTypeKeyExternal(
    string DomainId,
    Id<EntityTypeExternal> EntityTypeId,
    UtcDateTime<EntityTypeExternal> EntityTypeUpdatedDate);
