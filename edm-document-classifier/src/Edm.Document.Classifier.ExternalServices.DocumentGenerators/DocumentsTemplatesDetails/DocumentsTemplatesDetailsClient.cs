using Edm.Document.Classifier.ExternalServices.DocumentGenerators.Converters;
using Edm.Document.Classifier.ExternalServices.DocumentsTemplates.Contracts.Queries.GetDetails;
using Edm.Document.Classifier.ExternalServices.DocumentsTemplates.Details;
using Edm.Document.Classifier.GenericSubdomain.Tracing;
using Edm.DocumentGenerators.Presentation.Abstractions;

using Microsoft.Extensions.Logging;

namespace Edm.Document.Classifier.ExternalServices.DocumentGenerators.DocumentsTemplatesDetails;

public sealed class DocumentsTemplatesDetailsClient(
    DocumentsTemplatesDetailsService.DocumentsTemplatesDetailsServiceClient documentsTemplatesDetails,
    ILogger<DocumentsTemplatesDetailsClient> logger)
    : IDocumentsTemplatesDetails
{
    public async Task<GetDetailsDocumentsTemplatesQueryExternalResponse> GetDetails(
        GetDetailsDocumentsTemplatesQueryExternal query,
        CancellationToken cancellationToken)
    {
        var request = GetDetailsDocumentsTemplatesQueryExternalConverter.ToDto(query);
        var response = await TracingFacility.TraceGrpc(
            logger,
            nameof(documentsTemplatesDetails.GetDetailsAsync),
            request,
            async () => await documentsTemplatesDetails.GetDetailsAsync(request, cancellationToken: cancellationToken));

        var result = GetDetailsDocumentsTemplatesQueryExternalResponseConverter.FromDto(response);

        return result;
    }
}
