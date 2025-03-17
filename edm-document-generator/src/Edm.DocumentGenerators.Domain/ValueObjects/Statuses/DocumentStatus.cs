using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Types;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Statuses;

public sealed class DocumentStatus : IEquatable<DocumentStatus>
{
    internal DocumentStatus(Id<DocumentStatus> id, DocumentStatusType type, DocumentStatusParameter[] parameters, string systemName, string displayName)
    {
        Id = id;
        Type = type;
        Parameters = parameters;
        SystemName = systemName;
        DisplayName = displayName;
    }

    public Id<DocumentStatus> Id { get; }
    public DocumentStatusType Type { get; }
    public DocumentStatusParameter[] Parameters { get; private set; } // TODO: Remove Private Set
    public string SystemName { get; }
    public string DisplayName { get; }

    public bool Equals(DocumentStatus? other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Id.Equals(other.Id);
    }

    public void SetParameters(DocumentStatusParameter[] parameters)
    {
        Parameters = parameters;
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || (obj is DocumentStatus other && Equals(other));
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(DocumentStatus? left, DocumentStatus? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(DocumentStatus? left, DocumentStatus? right)
    {
        return !Equals(left, right);
    }

    public override string ToString()
    {
        return $"{{ Id: '{Id}', Type: {Type}, SystemName: '{SystemName}', DisplayName: '{DisplayName}' }}";
    }
}
