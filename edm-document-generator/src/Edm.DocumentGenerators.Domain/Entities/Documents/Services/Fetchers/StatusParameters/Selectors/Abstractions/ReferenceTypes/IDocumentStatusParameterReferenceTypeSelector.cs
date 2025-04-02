using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Fetchers.StatusParameters.Selectors.Abstractions.ReferenceTypes;

public interface IDocumentStatusParameterReferenceTypeSelector<out T> where T : class
{
    public T? GetValueOrNull(DocumentStatusParameter parameter);
    public T[] GetValues(DocumentStatusParameter parameter);
}
