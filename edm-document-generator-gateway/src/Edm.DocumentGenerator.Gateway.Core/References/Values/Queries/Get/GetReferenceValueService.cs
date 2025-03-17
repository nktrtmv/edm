using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.Get.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.Get;

public sealed class GetReferenceValueService(ReferencesService.ReferencesServiceClient documentReferencesClient)
{
    public async Task<GetReferenceValueQueryResponseBff> Get(GetReferenceValueQueryBff request, CancellationToken cancellationToken)
    {
        var query = GetReferenceValueQueryBffConverter.ToDto(request);

        var response = await documentReferencesClient.GetReferenceValueAsync(query, cancellationToken: cancellationToken);

        var result = GetReferenceValueQueryResponseBffConverter.FromDto(response);

        return result;
    }
}
