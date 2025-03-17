using Microsoft.Extensions.Logging;

using Edm.DocumentGenerator.Gateway.Core.References.Values.Contracts;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.GetReferencesTypeValuesSearch;
using Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.GetReferencesTypeValuesSearch.Contracts;
using Edm.DocumentGenerator.Gateway.Core.Services.Enrichers.References.Contracts;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Services.Enrichers;

namespace Edm.DocumentGenerator.Gateway.Core.Services.Enrichers.References;

public class ReferencesByTypeEnricher : GenericEnricher<string, ReferenceTypeValueBff, ReferenceTypeValueBff>
{
    private readonly ReferenceTypeKey _referenceTypeKey;
    private readonly GetReferencesTypeValuesSearchService _searchService;
    private readonly string _templateId;

    public ReferencesByTypeEnricher(
        ReferenceTypeKey referenceTypeKey,
        GetReferencesTypeValuesSearchService searchService,
        ILogger<ReferencesByTypeEnricher> logger) : base(logger)
    {
        _referenceTypeKey = referenceTypeKey;
        _searchService = searchService;
        _templateId = referenceTypeKey.TemplateId;
    }

    protected override void EnrichValue(ReferenceTypeValueBff value, ReferenceTypeValueBff fullValue)
    {
        value.DisplayValue = fullValue.DisplayValue;
        value.DisplaySubValue = fullValue.DisplaySubValue;
    }

    protected override string GetKey(ReferenceTypeValueBff value)
    {
        return value.Id;
    }

    protected override string GetKeyFromFullValue(ReferenceTypeValueBff value)
    {
        return value.Id;
    }

    protected override async Task<ReferenceTypeValueBff[]> GetFullValues(string[] keys, CancellationToken cancellationToken)
    {
        var query = new GetReferencesTypeValuesSearchQueryBff
        {
            ReferenceType = _referenceTypeKey.ReferenceType,
            ParentReferenceTypeIdToValues = _referenceTypeKey.Parents?.Select(
                    x => new ParentReferenceTypeIdToValueBff
                    {
                        Ids = x.Values,
                        ReferenceTypeId = x.ReferenceType
                    })
                .ToList(),
            TemplateId = _templateId,
            Ids = keys,
            Limit = keys.Length,
            Query = string.Empty,
            Skip = 0
        };

        var response = await _searchService.Get(query, cancellationToken);

        ReferenceTypeValueBff[] result = response.Items;

        return result;
    }

    public override string ToString()
    {
        var result = $"{base.ToString()}, Reference type: {_referenceTypeKey.ReferenceType}";

        return result;
    }
}
