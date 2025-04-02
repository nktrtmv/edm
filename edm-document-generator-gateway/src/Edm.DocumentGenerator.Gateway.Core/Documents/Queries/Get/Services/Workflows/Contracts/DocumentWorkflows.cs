using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.Workflows.Contracts;

internal sealed record DocumentWorkflows
{
    internal DocumentWorkflows(EntitiesApprovalWorkflowExternal[] approval, SigningWorkflowExternal[] signing)
    {
        Approval = approval;
        Signing = signing;
    }

    internal EntitiesApprovalWorkflowExternal[] Approval { get; }
    internal SigningWorkflowExternal[] Signing { get; }

    public override string ToString()
    {
        var approval = string.Join<EntitiesApprovalWorkflowExternal>(", ", Approval);

        var signing = string.Join<SigningWorkflowExternal>(", ", Signing);

        return $"{{ Approval: [{approval}], Signing: [{signing}] }}";
    }
}
