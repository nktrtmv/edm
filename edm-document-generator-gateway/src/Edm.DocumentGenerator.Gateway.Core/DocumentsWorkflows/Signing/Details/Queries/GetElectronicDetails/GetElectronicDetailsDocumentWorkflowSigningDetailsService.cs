using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails.Contracts.Details;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Services.Converters;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails;

public sealed class GetElectronicDetailsDocumentWorkflowSigningDetailsService
{
    public GetElectronicDetailsDocumentWorkflowSigningDetailsService(
        DocumentsService.DocumentsServiceClient documents,
        ISigningWorkflowsDetailsClient details)
    {
        Documents = documents;
        Details = details;
    }

    private DocumentsService.DocumentsServiceClient Documents { get; }
    private ISigningWorkflowsDetailsClient Details { get; }

    public async Task<GetElectronicDetailsDocumentWorkflowSigningDetailsQueryBffResponse> GetElectronicDetails(
        GetElectronicDetailsDocumentWorkflowSigningDetailsQueryBff request,
        CancellationToken cancellationToken)
    {
        var details = await GetElectronicDetails(request.DocumentId, cancellationToken);

        var result = new GetElectronicDetailsDocumentWorkflowSigningDetailsQueryBffResponse
        {
            Details = details
        };

        return result;
    }

    private async Task<DocumentWorkflowSigningElectronicDetailsBff?> GetElectronicDetails(string documentId, CancellationToken cancellationToken)
    {
        var lastWorkflowId = await GetLastSigningWorkflowId(documentId, cancellationToken);

        if (lastWorkflowId is null)
        {
            return null;
        }

        var result = await GetWorkflowDetails(lastWorkflowId, cancellationToken);

        return result;
    }

    private async Task<DocumentWorkflowSigningElectronicDetailsBff?> GetWorkflowDetails(string signingWorkflowId, CancellationToken cancellationToken)
    {
        var request = new GetElectronicDetailsSigningWorkflowDetailsQueryExternal(signingWorkflowId);

        var response =
            await Details.GetElectronicDetails(request, cancellationToken);

        var result =
            NullableConverter.Convert(response.Details, r => DocumentWorkflowSigningElectronicDetailsBffConverter.FromExternal(r, signingWorkflowId));

        return result;
    }

    private async Task<string?> GetLastSigningWorkflowId(string documentId, CancellationToken cancellationToken)
    {
        var query = new GetDocumentQuery
        {
            DocumentId = documentId
        };

        var response = await Documents.GetAsync(query, cancellationToken: cancellationToken);

        if (response.Document == null)
        {
            throw new ApplicationException($"Document (id: {documentId}) is not found.");
        }

        var signingWorkflow = response.Document.SigningData.Workflows.LastOrDefault();

        var result = NullableConverter.Convert(signingWorkflow, w => w.Id);

        return result;
    }
}
