using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.References.Values.Contracts;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.GetReferencesTypeValuesSearch.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.GetReferencesTypeValuesSearch;

public sealed class GetReferencesTypeValuesSearchService
{
    private readonly ReferencesService.ReferencesServiceClient _references;

    public GetReferencesTypeValuesSearchService(ReferencesService.ReferencesServiceClient references)
    {
        _references = references;
    }

    public async Task<GetReferencesTypeValuesSearchQueryBffResponse> Get(GetReferencesTypeValuesSearchQueryBff queryBff, CancellationToken cancellationToken)
    {
        IEnumerable<ParentReferenceTypeId> parentReferenceTypeIdToValues = queryBff.ParentReferenceTypeIdToValues?.Select(
            item =>
                new ParentReferenceTypeId
                {
                    Ids = { item.Ids },
                    ReferenceType = item.ReferenceTypeId
                }) ?? [];
        var request = new GetReferenceValuesSearchQuery
        {
            Limit = queryBff.Limit ?? int.MaxValue,
            Query = queryBff.Query,
            ReferenceType = queryBff.ReferenceType,
            Skip = queryBff.Skip,
            Ids = { queryBff.Ids },
            ParentReferenceTypeIdToValues = { parentReferenceTypeIdToValues }
        };

        if (!string.IsNullOrWhiteSpace(queryBff.TemplateId))
        {
            request.TemplateId = queryBff.TemplateId;
        }

        var values = await _references.GetReferenceValuesSearchAsync(
            request,
            cancellationToken: cancellationToken);

        ReferenceTypeValueBff[] valueBffs = values.ReferenceValues.Select(
                v => new ReferenceTypeValueBff
                {
                    DisplayValue = v.DisplayValue,
                    Id = v.Id,
                    DisplaySubValue = v.DisplaySubValue,
                    Arguments = v.Arguments.ToDictionary(x => x.Key, x => x.Value)
                })
            .ToArray();

        var result = new GetReferencesTypeValuesSearchQueryBffResponse
        {
            Items = valueBffs
        };

        return result;
    }
}
