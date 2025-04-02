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
internal sealed class SelfCompanyPaymentDetailsDocumentReferenceService(IContractorsClient contractorsClient) : DocumentReferenceService
{
    public override DocumentReferenceType Type { get; } = new DocumentReferenceType(
        DocumentReferenceTypeId.SelfCompanyPaymentDetails,
        DocumentReferenceSearchKind.Search,
        DocumentReferenceKind.None,
        "Реквизиты юр. лица Озон",
        DocumentReferenceTypeId.SelfCompanies);

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
            var selfCompanyId = searchParams
                .Key
                .ParentValues.Single(p => int.Parse(p.ReferenceTypeId.Value) == (int)DocumentReferenceTypeId.SelfCompanies)
                .Ids
                .Select(long.Parse)
                .Single();

            SelfCompanyEs[] selfCompanies = await contractorsClient.GetSelfCompanies(cancellationToken);

            var metazonContractorId = selfCompanies.Single(o => o.Id == selfCompanyId).PersonId;

            paymentDetails = await contractorsClient.GetPaymentDetailsByContractorId(metazonContractorId, cancellationToken);

            if (!string.IsNullOrWhiteSpace(searchParams.Search))
            {
                paymentDetails = paymentDetails.Where(
                        p =>
                            p.BankAccount.Contains(searchParams.Search) ||
                            p.PaymentDetailsId.ToString() == searchParams.Search ||
                            p.BankName.Contains(searchParams.Search))
                    .ToArray();
            }
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
