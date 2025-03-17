using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.Factories;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.SigningData.Workflows;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.SigningData;

internal static class DocumentSigningDataDbConverter
{
    internal static DocumentSigningDataDb FromDomain(DocumentSigningData data)
    {
        DocumentSigningWorkflowDb[] workflows = data.Workflows.Select(DocumentSigningWorkflowDbConverter.FromDomain).ToArray();

        var result = new DocumentSigningDataDb
        {
            Workflows = { workflows }
        };

        return result;
    }

    // TODO: REMOVE: This is for backward compatability (DocumentSigningDataDb shall be not null).

    internal static DocumentSigningData ToDomainObsolete(DocumentSigningDataDb? data)
    {
        DocumentSigningData result = data is null
            ? DocumentSigningDataFactory.CreateNew()
            : ToDomain(data);

        return result;
    }

    private static DocumentSigningData ToDomain(DocumentSigningDataDb data)
    {
        DocumentSigningWorkflow[] workflows = data.Workflows.Select(DocumentSigningWorkflowDbConverter.ToDomain).ToArray();

        DocumentSigningData result = DocumentSigningDataFactory.CreateFromDb(workflows);

        return result;
    }
}
