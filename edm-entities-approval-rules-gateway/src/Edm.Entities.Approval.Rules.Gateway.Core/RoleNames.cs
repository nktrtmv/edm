namespace Edm.Entities.Approval.Rules.Gateway.Core;

public static class RoleNames
{
    public const string ApprovalRulesResponsibleForEdm = "entitiesApprovalRulesResponsible";
    public const string ApprovalRulesViewerForEdm = "entitiesApprovalRulesViewer";

    public const string ApprovalRulesResponsibleForSupportRequests = "entitiesApprovalRulesResponsibleForSupportRequests";
    public const string ApprovalRulesViewerForSupportRequests = "entitiesApprovalRulesViewerForSupportRequests";

    public static readonly IReadOnlySet<string> All = new HashSet<string>
    {
        ApprovalRulesResponsibleForEdm,
        ApprovalRulesViewerForEdm,
        ApprovalRulesResponsibleForSupportRequests,
        ApprovalRulesViewerForSupportRequests
    };
}
