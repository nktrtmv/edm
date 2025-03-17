using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Fetchers.StatusParameters.Selectors.Abstractions.ReferenceTypes;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Fetchers.StatusParameters.Selectors.Abstractions.ValueTypes;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.ValueObjects.Statuses.ValueObjects.Parameters;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Fetchers.StatusParameters;

internal sealed class DocumentStatusParameterFetcher
{
    internal DocumentStatusParameterFetcher(DocumentStatus status)
    {
        Status = status;
    }

    private DocumentStatus Status { get; }

    #region Reference Types

    internal T GetRequiredValue<T>(IDocumentStatusParameterReferenceTypeSelector<T> selector) where T : class
    {
        T? result = FetchSingleOrDefault(selector.GetValueOrNull);

        if (result is null)
        {
            throw new BusinessLogicApplicationException($"There shall be single status parameter value none found.\nReference selector: {selector}");
        }

        return result;
    }

    internal T? GetValueOrNull<T>(IDocumentStatusParameterReferenceTypeSelector<T> selector) where T : class
    {
        T? result = FetchSingleOrDefault(selector.GetValueOrNull);

        return result;
    }

    internal T[] GetValues<T>(IDocumentStatusParameterReferenceTypeSelector<T> selector) where T : class
    {
        T[] result = FetchValues(selector.GetValues);

        return result;
    }

    private T? FetchSingleOrDefault<T>(Func<DocumentStatusParameter, T?> selector) where T : class
    {
        T? result = Status.Parameters
            .Select(selector)
            .SingleOrDefault(v => v is not null);

        return result;
    }

    private T[] FetchValues<T>(Func<DocumentStatusParameter, T[]> selector) where T : class
    {
        T[] result = Status.Parameters
            .SelectMany(selector)
            .ToArray();

        return result;
    }

    #endregion

    #region Value Types

    internal T GetRequiredValue<T>(IDocumentStatusParameterValueTypeSelector<T> selector) where T : struct
    {
        T? result = FetchSingleOrDefault(selector.GetValueOrNull);

        if (result is null)
        {
            throw new BusinessLogicApplicationException($"There shall be single status parameter value none found.\nValue selector: {selector}");
        }

        return result.Value;
    }

    internal T? GetValueOrNull<T>(IDocumentStatusParameterValueTypeSelector<T> selector) where T : struct
    {
        T? result = FetchSingleOrDefault(selector.GetValueOrNull);

        return result;
    }

    private T? FetchSingleOrDefault<T>(Func<DocumentStatusParameter, T?> selector) where T : struct
    {
        T? result = Status.Parameters
            .Select(selector)
            .SingleOrDefault(v => v is not null);

        return result;
    }

    #endregion
}
