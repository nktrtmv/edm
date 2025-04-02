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
internal sealed class ContractorPaymentDetailsDocumentReferenceService(IContractorsClient contractorsClient) : DocumentReferenceService
{
    public override DocumentReferenceType Type { get; } = new DocumentReferenceType(
        DocumentReferenceTypeId.ContractorPaymentDetails,
        DocumentReferenceSearchKind.Search,
        DocumentReferenceKind.None,
        "Реквизиты контрагента",
        DocumentReferenceTypeId.Contractors);

    public override async Task<DocumentReferenceValue[]> Search(DocumentReferenceSearchParamsInternal searchParams, CancellationToken cancellationToken)
    {
        PaymentDetailsEs[] paymentDetails;

        if (searchParams.Ids.Length != 0)
        {
            var ids = searchParams.Ids.Select(long.Parse).ToArray();

            paymentDetails = await contractorsClient.GetPaymentDetails(ids, cancellationToken);
        }
        else
        {
            var metazonContractorId = searchParams
                .Key
                .ParentValues.Single(p => int.Parse(p.ReferenceTypeId.Value) == (int)DocumentReferenceTypeId.Contractors)
                .Ids
                .Select(long.Parse)
                .Single();

            paymentDetails = await contractorsClient.GetPaymentDetailsByContractorId(metazonContractorId, cancellationToken);
        }

        DocumentReferenceValue[] result = paymentDetails.Select(
                p => new DocumentReferenceValue(
                    p.PaymentDetailsId.ToString(),
                    p.CompanyName,
                    $"Банк:{p.BankName}, Номер счета:{p.BankAccount}, Активные:{p.IsActive}, По умолчанию:{p.IsDefault}, Id:{p.PaymentDetailsId}",
                    p))
            .ToArray();

        return result;
    }
}
