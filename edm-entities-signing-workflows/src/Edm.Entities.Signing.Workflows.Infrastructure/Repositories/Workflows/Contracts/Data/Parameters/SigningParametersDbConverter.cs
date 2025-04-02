using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ElectronicDetails;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.SigningWorkflows.Contracts;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters.ElectronicDetails;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters;

internal static class SigningParametersDbConverter
{
    internal static SigningParametersDb FromDomain(SigningParameters parameters)
    {
        string? documentClerkId = NullableConverter.Convert(parameters.DocumentClerkId, IdConverterTo.ToString);

        SigningElectronicDetailsDb? electronicDetails =
            NullableConverter.Convert(parameters.ElectronicDetails, SigningElectronicDetailsDbConverter.FromDomain);

        var result = new SigningParametersDb
        {
            DocumentClerkId = documentClerkId,
            ElectronicDetails = electronicDetails,
        };

        return result;
    }

    internal static SigningParameters ToDomain(SigningParametersDb parametersDb)
    {
        Id<User>? documentClerkId = NullableConverter.Convert(parametersDb.DocumentClerkId, IdConverterFrom<User>.FromString);

        SigningElectronicDetails? parameters =
            NullableConverter.Convert(parametersDb.ElectronicDetails, SigningElectronicDetailsDbConverter.ToDomain);

        var result = new SigningParameters(documentClerkId, parameters);

        return result;
    }

    internal static SigningParameters ObsoleteToDomain(SigningElectronicDetailsDb? electronicDetailsDb)
    {
        SigningElectronicDetails? electronicDetails =
            NullableConverter.Convert(electronicDetailsDb, SigningElectronicDetailsDbConverter.ToDomain);

        var result = new SigningParameters(null, electronicDetails);

        return result;
    }
}
