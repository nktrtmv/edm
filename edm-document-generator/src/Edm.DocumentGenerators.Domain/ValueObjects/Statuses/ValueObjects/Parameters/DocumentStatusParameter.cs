using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters;

public abstract record DocumentStatusParameter(DocumentStatusParameterKind Kind)
{
    protected string BaseToString()
    {
        return $"Type: {GetType().Name}, Kind: {Kind}";
    }
}
