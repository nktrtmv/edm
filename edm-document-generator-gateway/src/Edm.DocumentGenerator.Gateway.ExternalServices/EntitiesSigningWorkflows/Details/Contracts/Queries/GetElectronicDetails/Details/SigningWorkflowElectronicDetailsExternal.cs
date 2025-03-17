using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails.Details.Archives;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails.Details.Documents;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails.Details;

public sealed class SigningWorkflowElectronicDetailsExternal
{
    public SigningWorkflowElectronicDetailsExternal(SigningWorkflowArchiveExternal[] archives, SigningWorkflowDocumentExternal[] documents)
    {
        Archives = archives;
        Documents = documents;
    }

    public SigningWorkflowArchiveExternal[] Archives { get; }
    public SigningWorkflowDocumentExternal[] Documents { get; }
}
