using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References;

namespace Edm.Entities.Approval.Rules.Gateway.Core.References;

public abstract class ApprovalReferencesServiceBase(IApprovalReferencesClient references)
{
    protected IApprovalReferencesClient References { get; } = references;
}
