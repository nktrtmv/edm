using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Signings.Stages.Statuses;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Signings.Stages.Types;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Enrichment;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Enrichment.Contexts;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Inheritors.Reference;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Reference;
using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages;
using Edm.Document.Searcher.GenericSubdomain.Extensions.Types;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Signings.Stages;

internal static class DocumentSigningStageDetailsInternalConverter
{
    private const int SigningPartyContractor = 10;

    internal static DocumentSigningStageDetailsInternal FromExternal(SigningWorkflowStageExternal details, int number, DocumentConversionContext conversionContext)
    {
        var stageType = DocumentSigningStageTypeInternalConverter.FromExternal(details.StageType);
        var status = DocumentSigningStageStatusInternalConverter.FromExternal(details.State.Status);

        var executor = details.ExecutorId;

        ContractorInternal? contractor = null;

        if (stageType == DocumentSigningStageTypeInternal.Contractor)
        {
            var (contractorReferenceType, contractorId) = FetchContractor(conversionContext.DocumentEnricherContext.Document);

            contractor = ContractorInternal.CreateNotEnriched(contractorId);

            var contractorTargetEnricherKey =
                new ReferenceValueEnricherKey(contractorReferenceType, contractorId, conversionContext.DocumentEnricherContext.Document.TemplateId.Value);

            var target = new ContractorInternalEnricherTarget(contractorTargetEnricherKey, contractor);

            conversionContext.DocumentEnricherContext.Add(target);
        }

        var result = new DocumentSigningStageDetailsInternal(
            number,
            stageType,
            contractor,
            executor,
            status,
            details.State.StatusChangedAt,
            details.CompletionComment,
            details.Id);

        return result;
    }

    private static (string referenceType, string id) FetchContractor(DocumentExternal document)
    {
        var contractorAttributeValue = document.AttributesValues.FirstOrDefault(x => x.Attribute.Data.DocumentsRoles.Any(role => role == SigningPartyContractor));

        if (contractorAttributeValue == null)
        {
            throw new ApplicationException($"{nameof(SigningPartyContractor)} attribute not found in document Id: {document.Id}");
        }

        var attributeValue = TypeCasterTo<DocumentReferenceAttributeValueExternal>.CastRequired(contractorAttributeValue);
        var attribute = TypeCasterTo<DocumentReferenceAttributeExternal>.CastRequired(contractorAttributeValue.Attribute);

        var contractorId = attributeValue.Values.Single();
        var referenceType = attribute.ReferenceType;

        return (referenceType, contractorId);
    }
}
