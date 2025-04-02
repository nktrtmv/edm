using System.Text.Json.Serialization;

using Edm.DocumentGenerators.Domain.ValueObjects.Permissions;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions.ValueObjects.Types;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.StatusesTransitions;

public sealed class DocumentStatusTransition
{
    internal DocumentStatusTransition(
        Id<DocumentStatusTransition> id,
        DocumentStatusTransitionType type,
        DocumentStatus from,
        DocumentStatus to,
        DocumentStatusTransitionParameter[] parameters,
        DocumentPermission[] permissions,
        string systemName,
        string displayName)
    {
        Id = id;
        Type = type;
        From = from;
        To = to;
        Parameters = parameters;
        Permissions = permissions;
        SystemName = systemName;
        DisplayName = displayName;
    }

    public Id<DocumentStatusTransition> Id { get; }
    public DocumentStatusTransitionType Type { get; }
    public DocumentStatus From { get; }
    public DocumentStatus To { get; }
    public DocumentStatusTransitionParameter[] Parameters { get; private set; }

    [JsonIgnore]
    public DocumentPermission[] Permissions { get; }

    public string SystemName { get; }
    public string DisplayName { get; }

    public void SetParameters(DocumentStatusTransitionParameter[] parameters)
    {
        Parameters = parameters;
    }

    public override string ToString()
    {
        return $"{{ Id: '{Id}', Type: {Type}, SystemName: {SystemName}, From: {From}, To: {To} }}";
    }
}
