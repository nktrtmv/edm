using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data.ValueObjects.Workflows;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Signings.Data;

public sealed class DocumentSigningData
{
    internal DocumentSigningData(DocumentSigningWorkflow[] workflows)
    {
        Workflows = workflows;
    }

    public DocumentSigningWorkflow[] Workflows { get; internal set; }
}
