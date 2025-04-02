using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetAll.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetAll;

public sealed class GetAllReferenceService(ReferencesService.ReferencesServiceClient documentReferencesClient)
{
    public async Task<GetAllReferencesQueryResponseBff> GetAll(GetAllReferencesQueryBff request, CancellationToken cancellationToken)
    {
        var query = GetAllReferencesQueryBffConverter.ToDto(request);

        var response = await documentReferencesClient.GetAllReferencesAsync(query, cancellationToken: cancellationToken);

        var result = GetAllReferencesQueryResponseBffConverter.FromDto(response);

        return result;
    }
}
