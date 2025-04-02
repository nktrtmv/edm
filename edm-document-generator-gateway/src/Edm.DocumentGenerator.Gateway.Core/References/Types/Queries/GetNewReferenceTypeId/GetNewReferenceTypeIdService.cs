using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetNewReferenceTypeId.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetNewReferenceTypeId;

public sealed class GetNewReferenceTypeIdService(ReferencesService.ReferencesServiceClient documentReferencesClient)
{
    public async Task<GetNewReferenceTypeIdQueryResponseBff> GetNewReferenceTypeId(GetNewReferenceTypeIdQueryBff query, CancellationToken cancellationToken)
    {
        var request = new GetNewReferenceTypeIdQuery();

        var response = await documentReferencesClient.GetNewReferenceTypeIdAsync(request, cancellationToken: cancellationToken);

        var result = GetNewReferenceTypeIdQueryResponseBffConverter.FromDto(response);

        return result;
    }
}
