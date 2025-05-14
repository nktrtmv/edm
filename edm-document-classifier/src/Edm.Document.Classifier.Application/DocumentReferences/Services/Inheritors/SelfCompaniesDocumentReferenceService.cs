using System.Diagnostics.CodeAnalysis;

using Edm.Document.Classifier.Application.DocumentReferences.Services.Services.Matchers;
using Edm.Document.Classifier.Application.DocumentReferences.Values.Queries.SearchValues.Contracts.SearchParams;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.ReferenceKind;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.SearchKinds;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values;
using Edm.Document.Classifier.ExternalServices.Contractors;
using Edm.Document.Classifier.ExternalServices.Contractors.Contracts;

using JetBrains.Annotations;

namespace Edm.Document.Classifier.Application.DocumentReferences.Services.Inheritors;

[UsedImplicitly]
[SuppressMessage("ReSharper", "ArrangeMethodOrOperatorBody")]
internal sealed class SelfCompaniesDocumentReferenceService(IContractorsClient contractorsClient) : DocumentReferenceService
{
    public override DocumentReferenceType Type { get; } = new DocumentReferenceType(
        DocumentReferenceTypeId.SelfCompanies,
        DocumentReferenceSearchKind.Search,
        DocumentReferenceKind.None,
        "Юр. лица компании");

    public override async Task<DocumentReferenceValue[]> Search(DocumentReferenceSearchParamsInternal searchParams, CancellationToken cancellationToken)
    {
        SelfCompanyEs[] companies = await GetContractors(searchParams, cancellationToken);

        DocumentReferenceValue[] result = companies
            .Skip(searchParams.Skip)
            .Take(searchParams.Limit)
            .Select(
                c => new DocumentReferenceValue(
                    c.Id.ToString(),
                    c.Name,
                    !string.IsNullOrWhiteSpace(c.Kpp)
                        ? $"ИНН: {c.Inn} КПП: {c.Kpp}"
                        : $"ИНН: {c.Inn}",
                    c))
            .ToArray();

        return result;
    }

    private async Task<SelfCompanyEs[]> GetContractors(DocumentReferenceSearchParamsInternal searchParams, CancellationToken cancellationToken)
    {
        SelfCompanyEs[] companies = await contractorsClient.GetSelfCompanies(cancellationToken);

        if (searchParams.Ids.Length != 0)
        {
            companies = companies.Where(c => searchParams.Ids.Contains(c.Id.ToString())).ToArray();
        }
        else
        {
            companies = companies.Where(c => QueryMatcher.ContainsNullOrEmptyQuery(searchParams.Search, c.Name)).ToArray();
        }

        return companies;
    }
}
