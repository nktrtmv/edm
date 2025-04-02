using Edm.Entities.Signing.Edx.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts.Entities;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts.Summaries;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Converters.Commands.SendDocuments.Entites;

internal static class SigningEdxEntityDtoConverter
{
    internal static SigningEdxEntityDto FromExternal(SigningEdxEntityExternal entity, SigningEdxSummaryExternal summary)
    {
        var id = IdConverterTo.ToString(entity.Id);

        var domainId = IdConverterTo.ToString(entity.DomainId);

        Timestamp date = UtcDateTimeConverterTo.ToTimeStamp(summary.EntityDate);

        var result = new SigningEdxEntityDto
        {
            Id = id,
            DomainId = domainId,
            Name = summary.Name,
            Number = summary.Number,
            Date = date
        };

        return result;
    }
}
