using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.References;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.References.Types;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Abstractions;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.Contexts;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.References;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.ValueObjects.RegistryRoles.Ids;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Inheritors.Reference;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Reference;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.GenericSubdomain.Extensions.Types;

namespace Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Inheritors.Participants.
    Documents;

internal sealed class DocumentParticipantsSearchDocumentAttributesValuesExtractor : ISearchDocumentAttributesValuesCollector
{
    Task ISearchDocumentAttributesValuesCollector.Collect(
        SearchDocumentUpdaterContext context,
        List<SearchDocumentAttributeValueInternal> attributesValues,
        CancellationToken cancellationToken)
    {
        string[] currentParticipants = DetectCurrentParticipants(context);

        CollectParticipants(context, attributesValues, currentParticipants, SearchDocumentRegistryRoleId.DocumentParticipants);

        string[] cumulativeParticipants = DetectCumulativeParticipants(context, currentParticipants);

        CollectParticipants(context, attributesValues, cumulativeParticipants, SearchDocumentRegistryRoleId.DocumentCumulativeParticipants);

        return Task.CompletedTask;
    }

    private static void CollectParticipants(
        SearchDocumentUpdaterContext context,
        List<SearchDocumentAttributeValueInternal> attributesValues,
        string[] values,
        int registryRoleId)
    {
        if (values.Length == 0)
        {
            return;
        }

        SearchDocumentRegistryRoleInternal? registryRole =
            context.RegistryRolesById.GetValueOrDefault(registryRoleId);

        if (registryRole is null)
        {
            return;
        }

        var participantsAttributeValue = new SearchDocumentReferenceAttributeValueInternal(
            registryRole,
            values,
            SearchDocumentReferenceAttributeValueTypeInternal.Employees);

        attributesValues.Add(participantsAttributeValue);
    }

    private static string[] DetectCumulativeParticipants(SearchDocumentUpdaterContext context, string[] currentParticipants)
    {
        SearchDocumentAttributeValue? cumulativeParticipantsAttributeValue = context.OriginalDocument?.AttributesValues
            .SingleOrDefault(v => v.RegistryRoleId == SearchDocumentRegistryRoleId.DocumentCumulativeParticipants);

        SearchDocumentReferenceAttributeValue? cumulativeParticipantsReferenceAttributeValue =
            NullableConverter.Convert(cumulativeParticipantsAttributeValue, TypeCasterTo<SearchDocumentReferenceAttributeValue>.CastRequired);

        string[] cumulativeParticipants = cumulativeParticipantsReferenceAttributeValue?.Values ?? Array.Empty<string>();

        string[] result = cumulativeParticipants
            .Concat(currentParticipants)
            .Distinct()
            .ToArray();

        return result;
    }

    private static string[] DetectCurrentParticipants(SearchDocumentUpdaterContext context)
    {
        string[] result = context.Document.AttributesValues
            .OfType<DocumentReferenceAttributeValueExternal>()
            .Where(DetectIsParticipant)
            .SelectMany(v => v.Values)
            .Distinct()
            .ToArray();

        return result;
    }

    private static bool DetectIsParticipant(DocumentReferenceAttributeValueExternal attributeValue)
    {
        DocumentReferenceAttributeExternal attribute = TypeCasterTo<DocumentReferenceAttributeExternal>.CastRequired(attributeValue.Attribute);

        if (attribute.ReferenceType == SearchDocumentReferenceAttributeValueTypeInternal.Employees)
        {
            return true;
        }

        return false;
    }
}
