using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.References;
using Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.References.Types;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Abstractions;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Services;
using Edm.Document.Searcher.Application.Documents.Services.Updaters.Contexts;
using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.ValueObjects.RegistryRoles.Ids;

namespace Edm.Document.Searcher.Application.Documents.Services.Updaters.AttributeValues.Collectors.Inheritors.LegalEntities;

internal sealed class LegalEntitiesCollector : ISearchDocumentAttributesValuesCollector
{
    public Task Collect(SearchDocumentUpdaterContext context, List<SearchDocumentAttributeValueInternal> attributesValues, CancellationToken cancellationToken)
    {
        AddIfAttributeNotExists(
            context,
            SearchDocumentRegistryRoleId.SelfCompany,
            attributesValues,
            selfCompanyRole =>
                GetRegistryRoles(
                    context,
                    [
                        c => DocumentAttributeValuesFetcher.FetchStringAttributeBySystemName(c.Document, "rent_aggregate_parties_self_organization_id")
                            ?.Values.FirstOrDefault()
                    ],
                    collected =>
                    {
                        if (collected.Any(string.IsNullOrWhiteSpace))
                        {
                            return null;
                        }

                        var selfId = collected[0]!;

                        var result = new SearchDocumentReferenceAttributeValueInternal(
                            selfCompanyRole,
                            [selfId],
                            SearchDocumentReferenceAttributeValueTypeInternal.SelfCompanies);

                        return result;
                    }));

        AddIfAttributeNotExists(
            context,
            SearchDocumentRegistryRoleId.ContractorCompany,
            attributesValues,
            contractorCompanyRole =>
                GetRegistryRoles(
                    context,
                    [
                        c => DocumentAttributeValuesFetcher.FetchStringAttributeBySystemName(c.Document, "rent_aggregate_parties_self_organization_id")
                            ?.Values.FirstOrDefault(),
                        c => DocumentAttributeValuesFetcher.FetchStringAttributeBySystemName(c.Document, "rent_aggregate_parties_contractor_organization_id")
                            ?.Values.FirstOrDefault()
                    ],
                    collected =>
                    {
                        if (collected.Any(string.IsNullOrWhiteSpace))
                        {
                            return null;
                        }

                        var (selfId, contractorId) = (collected[0]!, collected[1]!);

                        var parent = new ParentReferenceTypeAttributeValueInternal(SearchDocumentReferenceAttributeValueTypeInternal.SelfCompanies, [selfId]);
                        var result = new SearchDocumentReferenceAttributeValueInternal(
                            contractorCompanyRole,
                            [contractorId],
                            SearchDocumentReferenceAttributeValueTypeInternal.Contractors,
                            [parent]);

                        return result;
                    }));

        return Task.CompletedTask;
    }

    private static void AddIfAttributeNotExists<TAttribute>(
        SearchDocumentUpdaterContext context,
        int registryRoleIdInternal,
        List<SearchDocumentAttributeValueInternal> attributesValues,
        Func<SearchDocumentRegistryRoleInternal, TAttribute?> attributeFunc) where TAttribute : SearchDocumentAttributeValueInternal
    {
        var role = GetRegistryRole(context, registryRoleIdInternal);

        if (role == null)
        {
            return;
        }

        var attribute = attributeFunc(role);

        if (attribute is not null)
        {
            attributesValues.Add(attribute);
        }
    }

    private static SearchDocumentRegistryRoleInternal?
        GetRegistryRole(SearchDocumentUpdaterContext context, int registryRoleIdInternal)
    {
        var result = context.RegistryRolesById.GetValueOrDefault(registryRoleIdInternal);

        return result;
    }

    private static TResult? GetRegistryRoles<TFromContext, TResult>(
        SearchDocumentUpdaterContext context,
        List<Func<SearchDocumentUpdaterContext, TFromContext>> funcs,
        Func<List<TFromContext>, TResult?> resultFunc)
    {
        var attributes = funcs
            .Select(func => func(context))
            .ToList();

        return resultFunc(attributes);
    }
}
