using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.Strings;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Abstractions.Single.Synchronous;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Inheritors.Properties.Stages.Type;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.Contexts;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.ValueObjects.RegistryRoles.Ids;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.StagesTypes;
using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages;
using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.States.Statuses;
using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Types;

namespace Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Inheritors.Properties.
    Stages;

internal sealed class StageSearchDocumentAttributesValuesExtractor() : SynchronousSingleAttributesValuesCollector(SearchDocumentRegistryRoleId.Stage)
{
    private const string SelfSigning = "SelfSigning";
    private const string ContractorSigning = "ContractorSigning";

    protected override SearchDocumentAttributeValueInternal Collect(
        SearchDocumentUpdaterContext context,
        SearchDocumentRegistryRoleInternal registryRole)
    {
        string value = DocumentStageTypeExternalConverter.ToDomain(context.Document.StageType);

        var values = new List<string>(2) { value };

        AddSigningValue(values, context);

        var result = new SearchDocumentStringAttributeValueInternal(registryRole, values.ToArray());

        return result;
    }

    private void AddSigningValue(List<string> values, SearchDocumentUpdaterContext context)
    {
        if (context.Document.StageType != DocumentStageTypeExternal.Signing)
        {
            return;
        }

        SigningWorkflowStageExternal[] stages = context.SigningWorkflows.LastOrDefault()?.Stages.ToArray() ?? [];
        SigningWorkflowStageExternal? currentStage = stages.SingleOrDefault(stage => stage.State.Status == SigningWorkflowStageStatusExternal.InProgress);

        string? stageTypeAlias = currentStage?.StageType switch
        {
            SigningWorkflowStageTypeExternal.Self => SelfSigning,
            SigningWorkflowStageTypeExternal.Contractor => ContractorSigning,
            _ => null
        };

        if (stageTypeAlias is not null)
        {
            values.Add(stageTypeAlias);
        }
    }
}
