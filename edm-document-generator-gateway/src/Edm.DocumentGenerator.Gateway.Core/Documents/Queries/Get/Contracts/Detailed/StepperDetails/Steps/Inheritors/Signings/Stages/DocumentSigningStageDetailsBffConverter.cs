using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Enrichers.Targets.ReferenceValues;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Signings.Stages.Statuses;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Signings.Stages.Types;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Signings.Stages;

internal static class DocumentSigningStageDetailsBffConverter
{
    private const int SigningPartyContractor = 10;

    internal static DocumentSigningStageDetailsBff FromExternal(SigningWorkflowStageExternal details, int number, DocumentConversionContext conversionContext)
    {
        var stageType = DocumentSigningStageTypeBffConverter.FromExternal(details.StageType);
        var status = DocumentSigningStageStatusBffConverter.FromExternal(details.State.Status);

        var executor = PersonBff.CreateNotEnriched(details.ExecutorId);
        conversionContext.Enricher.Add(executor);

        ContractorBff? contractor = null;

        if (stageType == DocumentSigningStageTypeBff.Contractor)
        {
            var contractorId = FetchContractor(conversionContext.DocumentEnricherContext.Document);

            contractor = ContractorBff.CreateNotEnriched(contractorId);

            conversionContext.Enricher.References.Add(contractor);
        }

        var result = new DocumentSigningStageDetailsBff
        {
            Number = number,
            StageType = stageType,
            Contractor = contractor?.Value,
            Executor = executor,
            Status = status,
            StatusChangedAt = details.State.StatusChangedAt,
            CompletionComment = details.CompletionComment
        };

        return result;
    }

    private static string FetchContractor(DocumentDetailedDto document)
    {
        var contractorAttributeValue = document.AttributesValues.SingleOrDefault(x => x.Attribute.Data.DocumentsRoles.Any(role => role == SigningPartyContractor));

        if (contractorAttributeValue == null)
        {
            throw new ApplicationException($"{nameof(SigningPartyContractor)} attribute not found in document with id: {document.Id}");
        }

        var contractorId = contractorAttributeValue.AsReference.Values.Single();

        return contractorId;
    }
}
