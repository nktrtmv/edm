using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters.ValueObjects.Kinds;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Fetchers.StatusParameters.Selectors.Abstractions.ReferenceTypes;

internal abstract class DocumentStatusParameterReferenceTypeSelectorGeneric<TParameter, TValue>
    : DocumentStatusParameterSelectorGeneric<TParameter, TValue>,
        IDocumentStatusParameterReferenceTypeSelector<TValue>
    where TParameter : DocumentStatusParameter
    where TValue : class
{
    protected DocumentStatusParameterReferenceTypeSelectorGeneric(DocumentStatusParameterKind kind) : base(kind)
    {
    }

    TValue? IDocumentStatusParameterReferenceTypeSelector<TValue>.GetValueOrNull(DocumentStatusParameter parameter)
    {
        if (parameter.Kind != Kind)
        {
            return default;
        }

        if (parameter is not TParameter specificParameter)
        {
            throw new UnsupportedTypeArgumentException<TParameter>(parameter);
        }

        TValue? result = GetSingleValueOrDefault(specificParameter);

        return result;
    }

    public TValue[] GetValues(DocumentStatusParameter parameter)
    {
        if (parameter.Kind != Kind)
        {
            return [];
        }

        if (parameter is not TParameter specificParameter)
        {
            throw new UnsupportedTypeArgumentException<TParameter>(parameter);
        }

        TValue[] result = GetValues(specificParameter);

        return result;
    }

    protected abstract TValue? GetSingleValueOrDefault(TParameter parameter);

    protected virtual TValue[] GetValues(TParameter parameter)
    {
        TValue[] result = new[] { GetSingleValueOrDefault(parameter) }.OfType<TValue>().ToArray();

        return result;
    }
}
