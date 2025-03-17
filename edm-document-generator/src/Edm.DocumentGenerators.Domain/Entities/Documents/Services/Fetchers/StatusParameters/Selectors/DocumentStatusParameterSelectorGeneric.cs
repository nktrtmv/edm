using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Fetchers.StatusParameters.Selectors;

internal abstract class DocumentStatusParameterSelectorGeneric<TParameter, TValue>
    where TParameter : DocumentStatusParameter
{
    protected DocumentStatusParameterSelectorGeneric(DocumentStatusParameterKind kind)
    {
        Kind = kind;
    }

    protected DocumentStatusParameterKind Kind { get; }

    public override string ToString()
    {
        var result = $"{{ Kind: {Kind}, ParameterType: {typeof(TParameter).Name}, ValueType: {typeof(TValue).Name} }}";

        return result;
    }
}
