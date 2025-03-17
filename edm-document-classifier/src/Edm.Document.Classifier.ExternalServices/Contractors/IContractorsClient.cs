using Edm.Document.Classifier.ExternalServices.Contractors.Contracts;

namespace Edm.Document.Classifier.ExternalServices.Contractors;

public interface IContractorsClient
{
    Task<SelfCompanyEs[]> GetSelfCompanies(CancellationToken cancellationToken);
    Task<ContractorEs[]> GetContractors(string inn, CancellationToken cancellationToken);
    Task<ContractorEs[]> GetContractors(long[] ids, CancellationToken cancellationToken);
    Task<ContractEs[]> GetContracts(long[] ids, CancellationToken cancellationToken);
    Task<PaymentDetailsEs[]> GetPaymentDetailsByContractorId(long contractorId, CancellationToken cancellationToken);
    Task<PaymentDetailsEs[]> GetPaymentDetails(long[] ids, CancellationToken cancellationToken);
}
