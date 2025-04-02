using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Services.Enrichment;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts;

internal static class PersonBffConverter
{
    internal static PersonBff FromDto(string ownerId, DocumentConversionContext conversionContext)
    {
        var result = PersonBff.CreateNotEnriched(ownerId);

        conversionContext.Enricher.Add(result);

        return result;
    }
}
