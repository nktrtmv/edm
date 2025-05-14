using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus;
using Edm.DocumentGenerator.Gateway.Core.Contracts.Parameters;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.AttributesValues;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Contracts.Audit;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Classifications;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Enrichers.Sources.AttributesPermissions.Keys;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Enrichers.Targets.AttributesPermissions;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Contracts.ApprovalRulesKeys;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Validate.Contracts.AttributesErrors;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed;

internal static class DocumentDetailedBffConverter
{
    public static DocumentDetailedBff ToBff(
        DocumentDetailedDto document,
        DocumentClassificationBff? classificationBff,
        DocumentWorkflowAvailableActionsBff availableActions,
        DocumentWorkflowStepperDetailsBff stepperDetails,
        DocumentConversionContext context,
        DomainRoles domainRoles)
    {
        var status =
            DocumentStatusBffConverter.ToBff(document.Status);

        DocumentAttributeValueDetailedBff[] attributesValues =
            document.AttributesValues.Select(x => DocumentAttributeValueDetailedBffConverter.ToBff(x, context, domainRoles)).ToArray();

        DocumentAttributeErrorBff[] attributesErrors = document.AttributesErrorsObsolete.Select(DocumentAttributeErrorBffConverter.ToBffObsolete).ToArray();

        var approvalRuleKey = ApprovalRuleKeyBffConverter.FromDto(document.DomainId, document.TemplateId, document.ApprovalData.AttributesVersion);

        var audit = DocumentAuditBffConverter.ToBff(document.Audit, context);

        var parameters = DocumentParametersBffConverter.FromDto(document.Parameters);

        var result = new DocumentDetailedBff
        {
            DomainId = document.DomainId,
            Id = document.Id,
            TemplateId = document.TemplateId,
            Status = status,
            AttributesValues = attributesValues,
            AttributesErrors = attributesErrors,
            ApprovalRuleKey = approvalRuleKey,
            FrontMetadata = document.FrontMetadata,
            Audit = audit,
            AvailableActions = availableActions,
            StepperDetails = stepperDetails,
            ConcurrencyToken = document.ConcurrencyToken,
            Parameters = parameters,
            Classification = classificationBff
        };

        var enrichAttributesPermissionsKey = new AttributesPermissionsEnricherKey(
            attributesValues,
            context.DocumentEnricherContext.Document,
            context.DocumentEnricherContext.User,
            context.DocumentEnricherContext.Workflows);

        var enrichAttributesPermissionsTarget = new AttributesPermissionsEnricherTarget(enrichAttributesPermissionsKey, attributesValues);

        context.DocumentEnricherContext.Add(enrichAttributesPermissionsTarget);

        context.Enricher.DocumentConversionComplete(result.AttributesValues, result.TemplateId);

        return result;
    }
}
