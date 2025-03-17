using Edm.DocumentGenerators.Domain.ValueObjects.Parameters;

namespace Edm.DocumentGenerators.Application.Contracts.Parameters;

internal static class DocumentParametersInternalConverter
{
    public static DocumentParametersInternal FromDomain(DocumentParameters parameters)
    {
        var result = new DocumentParametersInternal(parameters.AttachmentsInCommentsIsAllowed);

        return result;
    }

    public static DocumentParameters ToDomain(DocumentParametersInternal parameters)
    {
        var result = new DocumentParameters(parameters.AttachmentsInCommentsIsAllowed);

        return result;
    }
}
