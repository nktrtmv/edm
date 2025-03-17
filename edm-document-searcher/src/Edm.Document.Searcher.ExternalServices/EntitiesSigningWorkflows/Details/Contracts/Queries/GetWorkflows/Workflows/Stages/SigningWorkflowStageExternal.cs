using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.States;
using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Types;

namespace Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages;

public sealed record SigningWorkflowStageExternal(
    SigningWorkflowStageTypeExternal StageType,
    string ExecutorId,
    SigningWorkflowStageStateExternal State,
    string? CompletionComment,
    string Id);
