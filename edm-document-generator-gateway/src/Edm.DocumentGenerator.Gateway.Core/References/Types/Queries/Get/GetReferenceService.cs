using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.Get.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.Get;

public sealed class GetReferenceService(ReferencesService.ReferencesServiceClient documentReferencesClient)
{
    public async Task<GetReferenceQueryResponseBff> Get(GetReferenceQueryBff request, CancellationToken cancellationToken)
    {
        var query = GetReferenceQueryBffConverter.ToDto(request);

        var response = await documentReferencesClient.GetReferenceAsync(query, cancellationToken: cancellationToken);

        var result = GetReferenceQueryResponseBffConverter.FromDto(response);

        return result;
    }
}
