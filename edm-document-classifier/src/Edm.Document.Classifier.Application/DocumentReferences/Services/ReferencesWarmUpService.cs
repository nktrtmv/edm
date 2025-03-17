namespace Edm.Document.Classifier.Application.DocumentReferences.Services;

public sealed class ReferencesWarmUpService(IEnumerable<DocumentReferenceService> references)
{
    private const int InitDbReferenceId = 100_000;

    public Task WarmUp()
    {
        var isValidReferenceIds = references.All(x => (int)x.Type.Id < InitDbReferenceId);

        if (!isValidReferenceIds)
        {
            throw new ApplicationException(
                $"""
                 Id справочников, зашитые в коде, не должны превышать значение {InitDbReferenceId}.
                 Справочники с Id больше {InitDbReferenceId} создаются в бд.
                 """);
        }

        return Task.CompletedTask;
    }
}
