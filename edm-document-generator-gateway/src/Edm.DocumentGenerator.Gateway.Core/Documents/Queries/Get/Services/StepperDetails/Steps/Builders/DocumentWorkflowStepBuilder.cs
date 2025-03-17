using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.StepperDetails.Steps.Builders.Factories;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.StepperDetails.Steps.Builders.Helpers;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.StepperDetails.Steps.Builders;

internal sealed class DocumentWorkflowStepBuilder(
    DocumentDetailedDto document,
    DocumentConversionContext conversionContext)
{
    private DocumentWorkflowStepFactory Factory { get; } = new DocumentWorkflowStepFactory();

    internal DocumentWorkflowStepBff? Create(DocumentAuditRecordDto record)
    {
        var statusChange = DocumentStatusChangeDetector.GetStatusChangeFromAuditRecord(record, document);

        if (statusChange is null)
        {
            return null;
        }

        var status = DocumentStatusBffConverter.ToBff(statusChange);

        var processedDateTime = record.Heading.UpdatedDateTime.ToDateTime();
        var personId = record.Heading.UpdatedById;
        var processedBy = PersonBff.CreateNotEnriched(personId);

        conversionContext.Enricher.Add(processedBy);

        var result = Factory.Create(status, processedDateTime, processedBy);

        return result;
    }
}
