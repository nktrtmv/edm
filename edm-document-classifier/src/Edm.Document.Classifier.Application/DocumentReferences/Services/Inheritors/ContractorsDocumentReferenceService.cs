using System.Diagnostics.CodeAnalysis;

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
internal sealed class ContractorsDocumentReferenceService(IContractorsClient contractorsClient) : DocumentReferenceService
{
    public override DocumentReferenceType Type { get; } = new DocumentReferenceType(
        DocumentReferenceTypeId.Contractors,
        DocumentReferenceSearchKind.Search,
        DocumentReferenceKind.None,
        "Контрагенты");

    public override async Task<DocumentReferenceValue[]> Search(DocumentReferenceSearchParamsInternal searchParams, CancellationToken cancellationToken)
    {
        ContractorEs[] contractors = await GetContractors(searchParams, cancellationToken);

        DocumentReferenceValue[] result = contractors
            .Select(
                c => new DocumentReferenceValue(
                    c.Id.ToString(),
                    c.Name,
                    !string.IsNullOrWhiteSpace(c.Kpp)
                        ? $"ИНН: {c.Inn} КПП: {c.Kpp} MetazonId: {c.Id}"
                        : $"ИНН: {c.Inn} MetazonId: {c.Id}",
                    c))
            .ToArray();

        return result;
    }

    private async Task<ContractorEs[]> GetContractors(DocumentReferenceSearchParamsInternal searchParams, CancellationToken cancellationToken)
    {
        var ids = searchParams.Ids.Select(long.Parse).ToArray();

        if (long.TryParse(searchParams.Search, out var id))
        {
            ids = ids.Append(id).ToArray();
        }

        if (ids.Length != 0)
        {
            ContractorEs[] contractors = await contractorsClient.GetContractors(ids, cancellationToken);

            if (contractors.Length != 0)
            {
                return contractors;
            }
        }

        if (!string.IsNullOrWhiteSpace(searchParams.Search) && searchParams.Search.Length is 10 or 12)
        {
            ContractorEs[] contractors = await contractorsClient.GetContractors(searchParams.Search, cancellationToken);
            ContractorEs[] result = contractors
                .Skip(searchParams.Skip)
                .Take(searchParams.Limit)
                .ToArray();

            return result;
        }

        return [];
    }
}
