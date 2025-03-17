using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Persons;

internal static class PersonBffConverter
{
    internal static PersonBff FromDto(string id, EnrichersContext context)
    {
        var result = new PersonBff
        {
            Id = id,
            MainInfo = string.Empty,
            AdditionalInfo = string.Empty,
        };

        var enricher = new PersonBffEnricherTarget(result);

        context.Add(enricher);

        return result;
    }
}
