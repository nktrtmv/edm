using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters.Electronics;

public sealed class SigningElectronicParametersInternal
{
    public SigningElectronicParametersInternal(
        string entityName,
        string entityNumber,
        UtcDateTime<EntityInternal> entityDate,
        Id<AttachmentInternal>[] documentsIds)
    {
        EntityName = entityName;
        EntityNumber = entityNumber;
        EntityDate = entityDate;
        DocumentsIds = documentsIds;
    }

    public string EntityName { get; }
    public string EntityNumber { get; }
    public UtcDateTime<EntityInternal> EntityDate { get; }
    public Id<AttachmentInternal>[] DocumentsIds { get; }
}
