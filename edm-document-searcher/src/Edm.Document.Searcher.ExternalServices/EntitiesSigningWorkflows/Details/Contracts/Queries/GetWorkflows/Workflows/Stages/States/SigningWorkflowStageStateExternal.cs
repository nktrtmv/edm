using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.States.Statuses;

namespace Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.States;

public sealed record SigningWorkflowStageStateExternal(SigningWorkflowStageStatusExternal Status, DateTime StatusChangedAt);
