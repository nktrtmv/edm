using Edm.DocumentGenerators.Domain.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.Parameters.Factories;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Parameters;

internal static class DocumentParametersDbConverter
{
    public static DocumentParametersDb FromDomain(DocumentParameters parameters)
    {
        var result = new DocumentParametersDb
        {
            AttachmentsInCommentsIsAllowed = parameters.AttachmentsInCommentsIsAllowed
        };

        return result;
    }

    public static DocumentParameters ToDomain(DocumentParametersDb? parameters)
    {
        DocumentParameters result;

        if (parameters is null) // FOR BACKWARD COMPABILITY
        {
            result = DocumentParametersFactory.CreateNew();

            return result;
        }

        result = new DocumentParameters(parameters.AttachmentsInCommentsIsAllowed);

        return result;
    }
}
