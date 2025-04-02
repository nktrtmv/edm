using Edm.Entities.Signing.Edx.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts.Parties;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Converters.Commands.SendDocuments.Parties;

internal static class SigningEdxPartiesDtoConverter
{
    internal static SigningEdxPartiesDto FromExternal(SigningEdxPartiesExternal parties)
    {
        var contractorCompanyId = IdConverterTo.ToString(parties.ContractorId);

        var selfCompanyId = IdConverterTo.ToString(parties.SelfId);

        var result = new SigningEdxPartiesDto
        {
            ContractorCompanyId = contractorCompanyId,
            SelfCompanyId = selfCompanyId
        };

        return result;
    }
}
