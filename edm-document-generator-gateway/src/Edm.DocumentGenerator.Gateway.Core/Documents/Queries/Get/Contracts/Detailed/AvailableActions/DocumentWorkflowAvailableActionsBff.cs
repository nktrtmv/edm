using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions.Approval;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions.Signing;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions.Transitions;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.AvailableActions;

public sealed record DocumentWorkflowAvailableActionsBff(
    DocumentWorkflowApprovalActionsBff? Approval,
    DocumentWorkflowSigningActionsBff? Signing,
    DocumentStatusTransitionDetailedBff[] Transitions);
