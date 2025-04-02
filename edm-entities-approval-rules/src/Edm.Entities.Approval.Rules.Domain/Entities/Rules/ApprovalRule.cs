using Edm.Entities.Approval.Rules.Domain.Entities.Graphs;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Audits.Records.Activate;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Audits.Records.Deactivate;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Domain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tokens.Concurrency;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules;

public sealed class ApprovalRule
{
    internal ApprovalRule(
        EntityType entityType,
        int originalVersion,
        int version,
        bool isActive,
        ApprovalGraph[] graphs,
        ApprovalGroup[] groups,
        Audit<ApprovalRule> audit,
        ConcurrencyToken<ApprovalRule> concurrencyToken,
        bool isDeleted)
    {
        EntityType = entityType;
        Version = version;
        OriginalVersion = originalVersion;
        IsActive = isActive;
        Graphs = graphs;
        Groups = groups;
        Audit = audit;
        ConcurrencyToken = concurrencyToken;
        IsDeleted = isDeleted;
    }

    public EntityType EntityType { get; }
    public int Version { get; private set; }
    public int OriginalVersion { get; private set; }
    public bool IsActive { get; private set; }
    public ApprovalGraph[] Graphs { get; private set; }
    public ApprovalGroup[] Groups { get; private set; }
    public Audit<ApprovalRule> Audit { get; private set; }
    public ConcurrencyToken<ApprovalRule> ConcurrencyToken { get; }
    public bool IsDeleted { get; private set; }

    public bool HasBeenActivated => IsActive || Audit.Records.Any(r => r is ApprovalRuleActivatedAuditRecord or ApprovalRuleDeactivatedAuditRecord);

    internal void SetIsActive(bool isActive)
    {
        IsActive = isActive;
    }

    public void AddOrUpdateGraph(ApprovalGraph approvalGraph)
    {
        ApprovalGraph[] graphs = Graphs.Where(r => r.Id != approvalGraph.Id).Concat([approvalGraph]).ToArray();

        Graphs = graphs;
    }

    public void RemoveGraphById(Id<ApprovalGraph> id)
    {
        if (Graphs.All(x => x.Id != id))
        {
            return;
        }

        ApprovalGraph[] graphs = Graphs.Where(r => r.Id != id).ToArray();
        Graphs = graphs;
    }

    internal void SetGroups(ApprovalGroup[] groups)
    {
        Groups = groups;
    }

    internal void SetAudit(Audit<ApprovalRule> audit)
    {
        Audit = audit;
    }

    public override string ToString()
    {
        return $"{{ EntityType: {EntityType}, Version: {Version}, IsActive: {IsActive} }}";
    }
}
