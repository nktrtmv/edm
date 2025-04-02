using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Fetchers.StatusParameters.Selectors.Abstractions.ValueTypes;

internal abstract class DocumentStatusParameterValueTypeSelectorGeneric<TParameter, TValue>
    : DocumentStatusParameterSelectorGeneric<TParameter, TValue>,
        IDocumentStatusParameterValueTypeSelector<TValue>
    where TParameter : DocumentStatusParameter
    where TValue : struct
{
    protected DocumentStatusParameterValueTypeSelectorGeneric(DocumentStatusParameterKind kind) : base(kind)
    {
    }

    TValue? IDocumentStatusParameterValueTypeSelector<TValue>.GetValueOrNull(DocumentStatusParameter parameter)
    {
        if (parameter.Kind != Kind)
        {
            return default;
        }

        if (parameter is not TParameter specificParameter)
        {
            throw new UnsupportedTypeArgumentException<TParameter>(parameter);
        }

        TValue? result = GetValue(specificParameter);

        return result;
    }

    protected abstract TValue? GetValue(TParameter parameter);
}
