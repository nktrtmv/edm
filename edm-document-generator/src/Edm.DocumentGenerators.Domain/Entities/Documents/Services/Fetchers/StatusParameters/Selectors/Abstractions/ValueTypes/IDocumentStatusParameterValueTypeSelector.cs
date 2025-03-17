using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Fetchers.StatusParameters.Selectors.Abstractions.ValueTypes;

public interface IDocumentStatusParameterValueTypeSelector<T> where T : struct
{
    public T? GetValueOrNull(DocumentStatusParameter parameter);
}
