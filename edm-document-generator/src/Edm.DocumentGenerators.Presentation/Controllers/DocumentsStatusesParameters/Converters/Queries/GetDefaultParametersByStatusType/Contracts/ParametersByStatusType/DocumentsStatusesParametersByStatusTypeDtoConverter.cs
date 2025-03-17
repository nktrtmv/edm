using Edm.DocumentGenerators.Application.DocumentsStatusesParameters.Queries.GetDefaultParametersByStatusType.Contracts.ParametersByStatusType;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Statuses.Parameters;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Statuses.Types;

namespace Edm.DocumentGenerators.Presentation.Controllers.DocumentsStatusesParameters.Converters.Queries.GetDefaultParametersByStatusType.Contracts.
    ParametersByStatusType;

internal static class DocumentsStatusesParametersByStatusTypeDtoConverter
{
    internal static DocumentsStatusesParametersByStatusTypeDto FromInternal(DocumentsStatusesParametersByStatusTypeInternal parametersByStatusTypes)
    {
        DocumentStatusTypeDto type = DocumentStatusTypeDtoConverter.FromInternal(parametersByStatusTypes.Type);

        DocumentStatusParameterDto[] parameters = parametersByStatusTypes.Parameters.Select(DocumentStatusParameterDtoFromInternalConverter.FromInternal).ToArray();

        var result = new DocumentsStatusesParametersByStatusTypeDto
        {
            Type = type,
            Parameters = { parameters }
        };

        return result;
    }
}
