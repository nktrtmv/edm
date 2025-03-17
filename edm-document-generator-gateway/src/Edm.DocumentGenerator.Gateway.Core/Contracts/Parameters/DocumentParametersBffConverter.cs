using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.Contracts.Parameters;

internal static class DocumentParametersBffConverter
{
    public static DocumentParametersBff FromDto(DocumentParametersDto parameters)
    {
        var result = new DocumentParametersBff(parameters.AttachmentsInCommentsIsAllowed);

        return result;
    }

    public static DocumentParametersDto ToDto(DocumentParametersBff parameters)
    {
        var result = new DocumentParametersDto
        {
            AttachmentsInCommentsIsAllowed = parameters.AttachmentsInCommentsIsAllowed
        };

        return result;
    }
}
