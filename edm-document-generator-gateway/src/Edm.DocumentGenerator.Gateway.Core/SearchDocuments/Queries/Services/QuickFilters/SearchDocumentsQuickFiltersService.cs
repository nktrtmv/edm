using Edm.Document.Searcher.Presentation.Abstractions;

using Grpc.Core;

using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.Documents;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Inheritors;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Values;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Values.Inheritors;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Services.QuickFilters.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Services.QuickFilters;

public sealed class SearchDocumentsQuickFiltersService(
    SearchDocumentsService.SearchDocumentsServiceClient documentsClient,
    IRoleAdapter roleAdapter)
{
    public SearchDocumentsQueryFilterBff[] ConvertToSearchDocumentQueryFilters(
        string domainId,
        SearchDocumentsQuickFilterBff? filter,
        UserBff user)
    {
        var result = new List<SearchDocumentsQueryFilterBff>(2);

        var additionalFilter = GetAdditionalFilter(user, filter);

        if (additionalFilter is not null)
        {
            result.Add(additionalFilter);
        }

        if (user.Roles.Count == 0 && domainId != "7496db8c-c80f-42ec-b724-f1590c458258")
        {
            result.Add(GetFilterByMe(true, user));
        }

        return result.ToArray();
    }

    public async Task<bool> CheckDocumentContainsUserIdInParticipants(string domainId, string documentId, UserBff user, CancellationToken cancellationToken)
    {
        var queryBff = new GetAllDocumentsQueryBff
        {
            DomainId = domainId,
            DocumentIds = [documentId],
            Filters = { GetFilterByMe(true, user) }
        };

        var roles = await roleAdapter.GetDomainRoles(domainId, cancellationToken);
        var query = GetAllDocumentsQueryBffConverter.ToDto(queryBff, 0, 1, roles);

        await foreach (var f in documentsClient.Get(query, cancellationToken: cancellationToken).ResponseStream.ReadAllAsync(cancellationToken))
        {
            return true;
        }

        return false;
    }

    public string[]? GetPersonsIdsByFilter(
        UserBff user,
        SearchDocumentsQuickFilterBff? quickFilter)
    {
        var additionalFilter = GetAdditionalFilter(user, quickFilter);

        var result = additionalFilter?.Values
            .OfType<SearchDocumentsQueryFilterReferenceValueBff>()
            .Select(x => x.Value)
            .ToArray();

        return result;
    }

    private SearchDocumentsQueryMatchFilterBff? GetAdditionalFilter(
        UserBff user,
        SearchDocumentsQuickFilterBff? quickFilter)
    {
        if (quickFilter is null)
        {
            return null;
        }

        var additionalFilter = quickFilter switch
        {
            SearchDocumentsMineQuickFilterBff m => GetFilterByMe(m.IsCumulative, user),
            SearchDocumentsMineTeamQuickFilterBff mineTeamFilter => GetFilterByMineTeam(mineTeamFilter, user),
            _ => null
        };

        return additionalFilter;
    }

    private SearchDocumentsQueryMatchFilterBff? GetFilterByMineTeam(
        SearchDocumentsMineTeamQuickFilterBff searchDocumentsMineTeamQuickFilterBff,
        UserBff user)
    {
        SearchDocumentsQueryFilterValueBff[] values;

        var personIds = searchDocumentsMineTeamQuickFilterBff.PersonIds ?? [];

        if (personIds.Length == 0)
        {
            values = GetTeamPersons(user.Id);
        }
        else
        {
            values = personIds.Select(userId => new SearchDocumentsQueryFilterReferenceValueBff { Value = userId }).ToArray();
        }

        return new SearchDocumentsQueryMatchFilterBff
        {
            RegistryRolesIds = GetFilterByPeople(searchDocumentsMineTeamQuickFilterBff.IsCumulative),
            Values = values
        };
    }

    private SearchDocumentsQueryFilterValueBff[] GetTeamPersons(string userId)
    {
        SearchDocumentsQueryFilterValueBff[] mineTeamPersonIds = [new SearchDocumentsQueryFilterReferenceValueBff { Value = userId }];

        return mineTeamPersonIds;
    }

    private static SearchDocumentsQueryMatchFilterBff GetFilterByMe(bool isCumulative, UserBff user)
    {
        return new SearchDocumentsQueryMatchFilterBff
        {
            RegistryRolesIds = GetFilterByPeople(isCumulative),
            Values = [new SearchDocumentsQueryFilterReferenceValueBff { Value = user.Id }]
        };
    }

    private static string[] GetFilterByPeople(bool isCumulative)
    {
        string[] roleIds = isCumulative
            ? ["ApprovalCumulativeParticipants", "DocumentCumulativeParticipants"]
            : ["ApprovalParticipants", "DocumentParticipants"];

        return roleIds;
    }
}
