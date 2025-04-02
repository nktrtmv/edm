using Edm.DocumentGenerators.Application.Contracts.Statuses.Parameters;
using Edm.DocumentGenerators.Application.Contracts.Statuses.Types;

namespace Edm.DocumentGenerators.Application.Contracts.Statuses;

public sealed class DocumentStatusInternal
{
    public DocumentStatusInternal(string id, DocumentStatusTypeInternal type, DocumentStatusParameterInternal[] parameters, string systemName, string displayName)
    {
        Id = id;
        Type = type;
        Parameters = parameters;
        SystemName = systemName;
        DisplayName = displayName;
    }

    public string Id { get; }
    public DocumentStatusTypeInternal Type { get; }
    public DocumentStatusParameterInternal[] Parameters { get; }
    public string SystemName { get; }
    public string DisplayName { get; private set; }
}
