using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.Factories;

public static class DocumentSigningDataFactory
{
    public static DocumentSigningData CreateNew()
    {
        var result = new DocumentSigningData(Array.Empty<DocumentSigningWorkflow>());

        return result;
    }

    public static DocumentSigningData CreateFromDb(DocumentSigningWorkflow[] signingWorkflows)
    {
        var result = new DocumentSigningData(signingWorkflows);

        return result;
    }
}
