using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetArchiveDetails.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails.Contracts.Details.Archives.Types;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetArchiveDetails;

public sealed class GetElectronicArchiveDetailsDocumentWorkflowSigningDetailsService
{
    public GetElectronicArchiveDetailsDocumentWorkflowSigningDetailsService(ISigningWorkflowsDetailsClient client)
    {
        Details = client;
    }

    private ISigningWorkflowsDetailsClient Details { get; }

    public async Task<GetElectronicArchiveDetailsDocumentWorkflowSigningDetailsQueryBffResponse> GetElectronicArchiveDetails(
        GetElectronicArchiveDetailsDocumentWorkflowSigningDetailsQueryBff query,
        CancellationToken cancellationToken)
    {
        var request = new GetElectronicDetailsSigningWorkflowDetailsQueryExternal(query.WorkflowId);

        var response =
            await Details.GetElectronicDetails(request, cancellationToken);

        if (response.Details is null)
        {
            return GetElectronicArchiveDetailsDocumentWorkflowSigningDetailsQueryBffResponse.Instance;
        }

        var archiveType = DocumentWorkflowSigningArchiveTypeBffConverter.ToExternal(query.ArchiveType);

        var archive = response.Details.Archives.First(a => a.Type == archiveType);

        var result = new GetElectronicArchiveDetailsDocumentWorkflowSigningDetailsQueryBffResponse
        {
            ArchiveAttachmentId = archive.AttachmentId
        };

        return result;
    }
}
