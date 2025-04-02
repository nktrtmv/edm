using Edm.DocumentGenerators.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters;
using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Types;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsStatusesParameters.Queries.GetDefaultParametersByStatusType.Contracts.ParametersByStatusType;

internal static class DocumentsStatusesParametersByStatusTypeBffConverter
{
    internal static DocumentsStatusesParametersByStatusTypeBff FromDto(DocumentsStatusesParametersByStatusTypeDto parametersByStatusType)
    {
        var type = DocumentStatusTypeBffConverter.FromDto(parametersByStatusType.Type);
        DocumentStatusParameterBff[] parameters = parametersByStatusType.Parameters.Select(DocumentStatusParameterBffFromDtoConverter.FromDto).ToArray();

        var result = new DocumentsStatusesParametersByStatusTypeBff(type, parameters);

        return result;
    }
}
