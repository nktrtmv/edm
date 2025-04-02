using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.References;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.References.Types;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Abstractions.Single;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.Contexts;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.ValueObjects.RegistryRoles.Ids;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.Statuses.Types;

namespace Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Inheritors;

internal sealed class DocumentStateCollector() : SingleAttributesValuesCollector(SearchDocumentRegistryRoleId.State)
{
    protected override Task<SearchDocumentAttributeValueInternal?> Collect(
        SearchDocumentUpdaterContext context,
        SearchDocumentRegistryRoleInternal registryRole,
        CancellationToken cancellationToken)
    {
        var value = context.Document.Status.Type switch
        {
            DocumentStatusTypeExternal.Initial => "Draft",
            DocumentStatusTypeExternal.Backlog
                or DocumentStatusTypeExternal.Simple
                or DocumentStatusTypeExternal.Approval
                or DocumentStatusTypeExternal.Signing => "Uncompleted",
            DocumentStatusTypeExternal.Completed => "InEffect",
            DocumentStatusTypeExternal.Cancelled => null,
            _ => throw new ArgumentOutOfRangeException(nameof(context.Document.Status.Type), context.Document.Status.Type, null)
        };

        if (value == null)
        {
            return Task.FromResult<SearchDocumentAttributeValueInternal?>(null);
        }

        var result = new SearchDocumentReferenceAttributeValueInternal(registryRole, [value], SearchDocumentReferenceAttributeValueTypeInternal.State);

        return Task.FromResult<SearchDocumentAttributeValueInternal?>(result);
    }
}
