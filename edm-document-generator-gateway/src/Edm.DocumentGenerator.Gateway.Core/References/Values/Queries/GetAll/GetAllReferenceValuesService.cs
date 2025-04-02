using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.GetAll.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.GetAll;

public sealed class GetAllReferenceValuesService(ReferencesService.ReferencesServiceClient documentReferencesClient)
{
    public async Task<GetAllReferenceValuesQueryResponseBff> Get(GetAllReferenceValuesQueryBff request, CancellationToken cancellationToken)
    {
        var query = GetAllReferenceValuesQueryBffConverter.ToDto(request);

        var response = await documentReferencesClient.GetAllReferenceValuesAsync(query, cancellationToken: cancellationToken);

        var result = GetAllReferenceValuesQueryResponseBffConverter.FromDto(response);

        return result;
    }
}
