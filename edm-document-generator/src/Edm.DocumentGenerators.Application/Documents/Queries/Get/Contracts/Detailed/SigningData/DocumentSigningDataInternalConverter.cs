using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.SigningData.Workflows;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.SigningData;

internal static class DocumentSigningDataInternalConverter
{
    internal static DocumentSigningDataInternal FromDomain(DocumentSigningData signingData)
    {
        DocumentSigningWorkflowInternal[] workflows = signingData.Workflows.Select(DocumentSigningWorkflowInternalConverter.FromDomain).ToArray();

        var result = new DocumentSigningDataInternal(workflows);

        return result;
    }
}
