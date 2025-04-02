using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Contracts.ApprovalRulesKeys;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentClassifiers;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Contracts.DocumentPrototype;
using Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.Contracts.Audit;
using Edm.DocumentGenerator.Gateway.Core.Services.Enrichers.References;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentTemplates.Queries.Contracts;

internal static class DocumentTemplateDetailedBffConverter
{
    public static DocumentTemplateDetailedBff ToBff(
        DocumentTemplateDetailedDto template,
        DocumentClassifierSubsetDto? subsetDto,
        ReferencesEnricher personsEnricher,
        DomainRoles domainRoles)
    {
        var status = DocumentTemplateStatusBffConverter.ToBff(template.Status);

        var documentPrototype = DocumentPrototypeBffConverter.ToBff(template.DocumentPrototype, domainRoles);

        var approvalRuleKey = template.ApprovalAttributesVersion is null
            ? null
            : ApprovalRuleKeyBffConverter.FromDto(template.DomainId, template.Id, template.ApprovalAttributesVersion);

        var audit = DocumentTemplateAuditBffConverter.ToBff(template.Audit, personsEnricher);

        var documentClassifierSubsetBff = subsetDto == null ? null : DocumentClassifierSubsetBffConverter.ToBff(subsetDto);

        var bff = new DocumentTemplateDetailedBff
        {
            DomainId = template.DomainId,
            Id = template.Id,
            SystemName = template.SystemName,
            ClassifierSubset = documentClassifierSubsetBff,
            Name = template.Name,
            Status = status,
            DocumentPrototype = documentPrototype,
            ApprovalRuleKey = approvalRuleKey,
            FrontMetadata = template.FrontMetadata,
            Audit = audit,
            ConcurrencyToken = template.ConcurrencyToken
        };

        return bff;
    }
}
