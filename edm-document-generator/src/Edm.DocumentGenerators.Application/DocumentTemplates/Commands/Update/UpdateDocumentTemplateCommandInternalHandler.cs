using Edm.DocumentGenerators.Application.DocumentTemplates.Commands.Update.Contracts;
using Edm.DocumentGenerators.Application.DocumentTemplates.Services;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Parameters;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.PendingApprovalParticipantAttributes.Contexts;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.Services.Updaters.Services.RequiredApprovalGraphsTags;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Statuses;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Entities.Types;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Entities.Types.Keys;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;
using Edm.DocumentGenerators.GenericSubdomain.Tokens.Concurrency;

using JetBrains.Annotations;

using MediatR;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Commands.Update;

[UsedImplicitly]
internal sealed class UpdateDocumentTemplateCommandInternalHandler : IRequestHandler<UpdateDocumentTemplateCommandInternal>
{
    public UpdateDocumentTemplateCommandInternalHandler(DocumentsTemplatesFacade templates, IEntitiesApprovalRulesClient rules)
    {
        Templates = templates;
        Rules = rules;
    }

    private DocumentsTemplatesFacade Templates { get; }
    private IEntitiesApprovalRulesClient Rules { get; }

    public async Task Handle(UpdateDocumentTemplateCommandInternal request, CancellationToken cancellationToken)
    {
        Id<DocumentTemplate> id = IdConverterFrom<DocumentTemplate>.FromString(request.Template.Id);
        DomainId domainId = DomainId.Parse(request.Template.DomainId);

        DocumentTemplate? template = await Templates.GetRequired(domainId, id, cancellationToken);

        ConcurrencyToken<DocumentTemplate> concurrencyToken = ConcurrencyTokenConverterFrom<DocumentTemplate>.From(request.Template.ConcurrencyToken);

        template.ConcurrencyToken.AssertEqualsTo(concurrencyToken);

        DocumentTemplateUpdateParameters? updateParameters = UpdateDocumentTemplateCommandInternalConverter.ToUpdateParameters(request, template);

        DocumentTemplateUpdatingContext? documentTemplateUpdatingContext = DocumentTemplateUpdater.Update(updateParameters);

        // TODO: Add idempotency.

        await UpdateApprovalRules(template, documentTemplateUpdatingContext, updateParameters.CurrentUserId, cancellationToken);

        await Templates.Upsert(template, cancellationToken);
    }

    private async Task UpdateApprovalRules(
        DocumentTemplate template,
        DocumentTemplateUpdatingContext? documentTemplateUpdatingContext,
        Id<User> currentUserId,
        CancellationToken cancellationToken)
    {
        if (template.Status != DocumentTemplateStatus.Draft && documentTemplateUpdatingContext is not null)
        {
            await UpsertEntityType(template, documentTemplateUpdatingContext.ApprovalParticipantAttributes, currentUserId, cancellationToken);
        }

        if (template.Status == DocumentTemplateStatus.ReadyForDocumentCreation && template.ApprovalData.AttributesVersion is not null)
        {
            await ValidateThereAreActiveApprovalRuleGraphs(template, cancellationToken);
        }
    }

    private async Task ValidateThereAreActiveApprovalRuleGraphs(
        DocumentTemplate template,
        CancellationToken cancellationToken)
    {
        EntitiesApprovalRuleEntityTypeKeyExternal? entityTypeKey = CreateEntityTypeKey(template);

        string[] approvalGraphsTags = RequiredApprovalGraphsTagsCollector.Collect(template.Status, template.DocumentPrototype.StatusTransitions);

        if (!approvalGraphsTags.Any())
        {
            return;
        }

        await Rules.ValidateThereAreActiveApprovalRuleGraphs(entityTypeKey, approvalGraphsTags, cancellationToken);
    }

    private async Task UpsertEntityType(
        DocumentTemplate template,
        DocumentAttribute[] attributes,
        Id<User> currentUserId,
        CancellationToken cancellationToken)
    {
        EntitiesApprovalRuleEntityTypeKeyExternal? entityTypeKey = CreateEntityTypeKey(template);

        var entityType = new EntitiesApprovalRuleEntityTypeExternal(entityTypeKey, attributes, template.Name.Value);

        var currentUserIdExternal = IdConverterTo.ToString(currentUserId);

        await Rules.UpsertEntityType(entityType, currentUserIdExternal, cancellationToken);
    }

    private static EntitiesApprovalRuleEntityTypeKeyExternal CreateEntityTypeKey(DocumentTemplate template)
    {
        Id<DocumentTemplate>? entityTypeId = template.Id;

        UtcDateTime<DocumentTemplate>? approvalAttributesVersion = template.ApprovalData.AttributesVersion;

        if (approvalAttributesVersion is null)
        {
            throw new BusinessLogicApplicationException($"Template approval attributes version is not set.\n{{ TemplateId: {template.Id} }}");
        }

        var result = new EntitiesApprovalRuleEntityTypeKeyExternal(entityTypeId, template.DomainId, approvalAttributesVersion.Value);

        return result;
    }
}
