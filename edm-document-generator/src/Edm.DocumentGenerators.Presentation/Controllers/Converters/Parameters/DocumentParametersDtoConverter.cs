using Edm.DocumentGenerators.Application.Contracts.Parameters;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.Parameters;

internal static class DocumentParametersDtoConverter
{
    public static DocumentParametersInternal ToInternal(DocumentParametersDto parameters)
    {
        var result = new DocumentParametersInternal(parameters.AttachmentsInCommentsIsAllowed);

        return result;
    }

    public static DocumentParametersDto FromInternal(DocumentParametersInternal parameters)
    {
        var result = new DocumentParametersDto
        {
            AttachmentsInCommentsIsAllowed = parameters.AttachmentsInCommentsIsAllowed
        };

        return result;
    }
}
