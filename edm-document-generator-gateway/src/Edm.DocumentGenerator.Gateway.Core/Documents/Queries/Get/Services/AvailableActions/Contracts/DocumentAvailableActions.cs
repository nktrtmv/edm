using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.AvailableActions.Contracts.Approval;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.AvailableActions.Contracts.Signing;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.AvailableActions.Contracts;

internal sealed record DocumentAvailableActions(
    DocumentApprovalActions? Approval,
    DocumentSigningActions? Signing);
