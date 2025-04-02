using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Builders;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Transformers.Inheritors.Approval;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Transformers.Inheritors.Signing;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Workflows;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Enrichment.Contexts;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Workflows;
using Edm.Document.Searcher.Domain.Documents.ValueObjects;
using Edm.Document.Searcher.ExternalServices.Documents;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.GenericSubdomain.Enrichers.Abstractions.Sources;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Steppers;

internal sealed class GetDocumentStepperService(
    IDocumentsClient documentsServiceClient,
    DocumentWorkflowsService workflowsService,
    IEnumerable<IEnricherSource> enricherSources)
{
    internal async Task<DocumentWorkflowStepperDetailsInternal> GetDocumentStepper(
        Id<DocumentExternal> documentId,
        DomainId domainId,
        CancellationToken cancellationToken)
    {
        var document = await documentsServiceClient.Get(documentId, cancellationToken);

        var workflows = await workflowsService.Get(document, cancellationToken);

        var documentEnricherContext = new DocumentEnricherContext(document, workflows);

        var documentConversionContext = new DocumentConversionContext(documentEnricherContext);

        var stepperDetails = Construct(
            document,
            workflows,
            documentConversionContext);

        await documentEnricherContext.Enrich(enricherSources, cancellationToken);

        return stepperDetails;
    }

    private static DocumentWorkflowStepperDetailsInternal Construct(
        DocumentExternal document,
        DocumentWorkflows workflows,
        DocumentConversionContext conversionContext)
    {
        var stepBuilder = new DocumentWorkflowStepBuilder(document);

        var approvalStepTransformer = new DocumentWorkflowApprovalStepTransformer(workflows.Approval, conversionContext);

        var signingStepTransformer = new DocumentWorkflowSigningStepTransformer(workflows.Signing, conversionContext);

        var steps = document.Audit.Records
            .Select(x => stepBuilder.Create(x, document.Audit.Records))
            .OfType<DocumentWorkflowStepInternal>()
            .Select(approvalStepTransformer.TryTransform)
            .Select(signingStepTransformer.TryTransform)
            .ToArray();

        var result = new DocumentWorkflowStepperDetailsInternal(steps);

        return result;
    }
}
