using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Parameters;
using Edm.DocumentGenerator.Gateway.Core.Contracts.DocumentStatus.Types;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsStatusesParameters.Queries.GetDefaultParametersByStatusType.Contracts.ParametersByStatusType;

public sealed class DocumentsStatusesParametersByStatusTypeBff
{
    internal DocumentsStatusesParametersByStatusTypeBff(DocumentStatusTypeBff type, DocumentStatusParameterBff[] parameters)
    {
        Type = type;
        Parameters = parameters;
    }

    public DocumentStatusTypeBff Type { get; }
    public DocumentStatusParameterBff[] Parameters { get; }
}
