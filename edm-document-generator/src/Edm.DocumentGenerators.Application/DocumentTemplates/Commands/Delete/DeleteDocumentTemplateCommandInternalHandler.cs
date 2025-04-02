using Edm.DocumentGenerators.Application.DocumentTemplates.Commands.Delete.Contracts;
using Edm.DocumentGenerators.Application.DocumentTemplates.Services;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Entities.Types.Keys;
using Edm.DocumentGenerators.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.DocumentGenerators.Application.DocumentTemplates.Commands.Delete;

[UsedImplicitly]
internal sealed class DeleteDocumentTemplateCommandInternalHandler(
    DocumentsTemplatesFacade templates,
    IEntitiesApprovalRulesClient approvalRulesClient) : IRequestHandler<DeleteDocumentTemplateCommandInternal>
{
    public async Task Handle(DeleteDocumentTemplateCommandInternal request, CancellationToken cancellationToken)
    {
        DomainId domainId = DomainId.Parse(request.DomainId);
        Id<DocumentTemplate> id = IdConverterFrom<DocumentTemplate>.FromString(request.Id);
        Id<User> currentUserId = IdConverterFrom<User>.FromString(request.CurrentUser);

        await templates.Delete(domainId, id, currentUserId, cancellationToken);

        var entityTypeKey = new EntitiesApprovalRuleEntityTypeKeyExternal(id, domainId, UtcDateTime<DocumentTemplate>.MinValue);

        await approvalRulesClient.DeleteEntityType(entityTypeKey, currentUserId, cancellationToken);
    }
}
