using Edm.DocumentGenerators.Application.Contracts.Markers;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.SigningData.Workflows;
using Edm.DocumentGenerators.Application.DocumentsWorkflows.Signing.Events.SelfSigned.Contracts;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Presentation.Consumers.EntitiesSigningWorkflows.Events.Converters.SelfSigned;

internal static class SelfSignedEntitiesSigningWorkflowsEventConverter
{
    internal static SelfSignedEntitiesSigningWorkflowsEventInternal ToInternal(
        Id<DocumentInternal> documentId,
        Id<DocumentSigningWorkflowInternal> workflowId)
    {
        var result = new SelfSignedEntitiesSigningWorkflowsEventInternal(documentId, workflowId);

        return result;
    }
}
