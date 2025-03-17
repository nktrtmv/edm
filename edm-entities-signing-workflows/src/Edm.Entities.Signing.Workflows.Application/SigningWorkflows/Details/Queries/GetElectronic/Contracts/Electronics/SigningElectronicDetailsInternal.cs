using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Archives;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics.Documents;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Details.Queries.GetElectronic.Contracts.Electronics;

public sealed class SigningElectronicDetailsInternal
{
    internal SigningElectronicDetailsInternal(SigningArchiveInternal[] archives, SigningDocumentInternal[] documents)
    {
        Archives = archives;
        Documents = documents;
    }

    public SigningArchiveInternal[] Archives { get; }
    public SigningDocumentInternal[] Documents { get; }
}
