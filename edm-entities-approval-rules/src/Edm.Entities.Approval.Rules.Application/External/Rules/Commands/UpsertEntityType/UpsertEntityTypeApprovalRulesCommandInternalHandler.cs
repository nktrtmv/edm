using Edm.Entities.Approval.Rules.Application.External.Rules.Commands.UpsertEntityType.Contracts;
using Edm.Entities.Approval.Rules.Application.External.Rules.Commands.UpsertEntityType.Contracts.EntitiesTypes;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Factories;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Factories.Services.Analyzers;
using Edm.Entities.Approval.Rules.Domain.Markers;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.Infrastructure.Abstractions.Repositories.Rules;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Commands.UpsertEntityType;

[UsedImplicitly]
internal sealed class UpsertEntityTypeApprovalRulesCommandInternalHandler(IApprovalRulesRepository rules)
    : IRequestHandler<UpsertEntityTypeApprovalRulesCommandInternal>
{
    private IApprovalRulesRepository Rules { get; } = rules;

    public async Task Handle(UpsertEntityTypeApprovalRulesCommandInternal request, CancellationToken cancellationToken)
    {
        EntityType entityType = EntityTypeInternalConverter.ToDomain(request.EntityType);

        Id<User> currentUserId = IdConverterFrom<User>.From(request.CurrentUserId);

        ApprovalRule[] previousRules = await Rules.GetActualVersions(entityType.Key, cancellationToken);

        ApprovalRule[] previousRulesWithPossibleMigration =
            previousRules.Where(r => ApprovalRuleMigrationCapabilityAnalyzer.IsMigrationPossible(r, entityType)).ToArray();

        if (previousRulesWithPossibleMigration.Length == 0)
        {
            ApprovalRule rule = ApprovalRuleFactory.CreateNew(entityType, currentUserId);

            await Rules.Upsert(rule, cancellationToken);

            return;
        }

        foreach (ApprovalRule previousRule in previousRulesWithPossibleMigration)
        {
            ApprovalRule rule = ApprovalRuleFactory.CreateFrom(previousRule, entityType);

            await Rules.Upsert(rule, cancellationToken);
        }
    }
}
