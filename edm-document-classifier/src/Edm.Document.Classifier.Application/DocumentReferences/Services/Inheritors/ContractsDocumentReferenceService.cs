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
internal sealed class ContractsDocumentReferenceService(IContractorsClient contractorsClient) : DocumentReferenceService
{
    public override DocumentReferenceType Type { get; } = new DocumentReferenceType(
        DocumentReferenceTypeId.Contracts,
        DocumentReferenceSearchKind.Search,
        DocumentReferenceKind.None,
        "Договоры");

    public override async Task<DocumentReferenceValue[]> Search(DocumentReferenceSearchParamsInternal searchParams, CancellationToken cancellationToken)
    {
        var ids = new List<long>();

        ids.AddRange(searchParams.Ids.Select(long.Parse));

        if (!string.IsNullOrWhiteSpace(searchParams.Search))
        {
            if (!long.TryParse(searchParams.Search, out var id))
            {
                return [];
            }

            ids.Add(id);
        }

        if (ids.Count == 0)
        {
            return [];
        }

        ContractEs[] contracts = await contractorsClient.GetContracts(ids.ToArray(), cancellationToken);

        DocumentReferenceValue[] result = contracts
            .Select(c => new DocumentReferenceValue(c.Id.ToString(), c.Name, $"{c.Id} - {c.Type} в состоянии {c.State} с {c.ContractorName}", c))
            .ToArray();

        return result;
    }
}
