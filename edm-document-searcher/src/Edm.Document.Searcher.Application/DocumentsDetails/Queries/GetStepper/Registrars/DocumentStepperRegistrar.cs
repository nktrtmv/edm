using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Enrichment.Enrichers.References;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Fetchers.Approval;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Fetchers.Signing;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Steppers;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Workflows;
using Edm.Document.Searcher.GenericSubdomain.Enrichers.Abstractions.Sources;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Registrars;

internal static class DocumentStepperRegistrar
{
    internal static void Configure(IServiceCollection services)
    {
        services.AddSingleton<GetDocumentStepperService>();
        services.AddSingleton<DocumentWorkflowsService>();
        services.AddSingleton<ApprovalWorkflowDocumentWorkflowsFetcher>();
        services.AddSingleton<SigningWorkflowDocumentWorkflowsFetcher>();

        services.AddSingleton<IEnricherSource, ReferenceValueEnricherSource>();
    }
}
