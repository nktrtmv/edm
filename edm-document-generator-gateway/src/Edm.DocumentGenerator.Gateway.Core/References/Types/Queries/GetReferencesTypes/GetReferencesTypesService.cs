using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetReferencesTypes.Contracts;
using Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetReferencesTypes.Converters;

namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Queries.GetReferencesTypes;

public sealed class GetReferencesTypesService(ReferencesService.ReferencesServiceClient references)
{
    public async Task<GetReferencesTypesQueryBffResponse> Get(GetReferencesTypesQueryBff query, CancellationToken cancellationToken)
    {
        var types = await references.GetTypesAsync(new GetTypesQuery(), cancellationToken: cancellationToken);

        var result = new GetReferencesTypesQueryBffResponse
        {
            References = types.References.Select(ReferenceTypeBffConverter.FromDto).ToArray()
        };

        return result;
    }
}
