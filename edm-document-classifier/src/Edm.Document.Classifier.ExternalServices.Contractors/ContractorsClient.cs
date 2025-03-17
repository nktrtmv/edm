using Edm.Document.Classifier.ExternalServices.Contractors.Contracts;

namespace Edm.Document.Classifier.ExternalServices.Contractors;

internal sealed class ContractorsClient : IContractorsClient
{
    private static readonly SelfCompanyEs[] SelfCompanies =
    [
        new SelfCompanyEs(1, "self_company_1", "self_inn_1", "self_kpp_1", 1)
    ];

    private static readonly ContractorEs[] Contractors =
    [
        new ContractorEs(1, "inn_1", "name_1", "kpp_1", 1),
        new ContractorEs(2, "inn_2", "name_2", "kpp_2", 2),
        new ContractorEs(3, "inn_3", "name_3", "kpp_3", 3),
        new ContractorEs(4, "inn_4", "name_4", "kpp_4", 4)
    ];

    private static readonly ContractEs[] Contracts =
    [
        new ContractEs(1, "name_1", "state_1", "type_1", "name_1"),
        new ContractEs(2, "name_2", "state_2", "type_2", "name_2"),
        new ContractEs(3, "name_3", "state_3", "type_3", "name_3"),
        new ContractEs(4, "name_4", "state_4", "type_4", "name_4")
    ];

    private static readonly PaymentDetailsEs[] PaymentDetails =
    [
        new PaymentDetailsEs
        {
            PaymentDetailsId = 1,
            ContractorId = 1,
            BankAccount = "account_1",
            CorrespondentAccount = "correspondent_account_1",
            Bic = "bic_1",
            Inn = "inn_1",
            Kpp = "kpp_1",
            Swift = "swift_1",
            BankName = "bank_1",
            BankAddress = "bank_address_1",
            LegalAddress = "legal_address_1",
            FactAddress = "fact_address_1",
            CompanyName = "company_1",
            Currency = "currency_1",
            IsDefault = true,
            IsActive = true,
            DisplayName = "реквизиты_1",
            ObjectTypeName = "платежные реквизиты"
        },
        new PaymentDetailsEs
        {
            PaymentDetailsId = 2,
            ContractorId = 2,
            BankAccount = "account_2",
            CorrespondentAccount = "correspondent_account_2",
            Bic = "bic_2",
            Inn = "inn_2",
            Kpp = "kpp_2",
            Swift = "swift_2",
            BankName = "bank_2",
            BankAddress = "bank_address_2",
            LegalAddress = "legal_address_2",
            FactAddress = "fact_address_2",
            CompanyName = "company_2",
            Currency = "currency_2",
            IsDefault = true,
            IsActive = true,
            DisplayName = "реквизиты_2",
            ObjectTypeName = "платежные реквизиты"
        },
        new PaymentDetailsEs
        {
            PaymentDetailsId = 3,
            ContractorId = 3,
            BankAccount = "account_3",
            CorrespondentAccount = "correspondent_account_3",
            Bic = "bic_3",
            Inn = "inn_3",
            Kpp = "kpp_3",
            Swift = "swift_3",
            BankName = "bank_3",
            BankAddress = "bank_address_3",
            LegalAddress = "legal_address_3",
            FactAddress = "fact_address_3",
            CompanyName = "company_3",
            Currency = "currency_3",
            IsDefault = true,
            IsActive = true,
            DisplayName = "реквизиты_3",
            ObjectTypeName = "платежные реквизиты"
        },
        new PaymentDetailsEs
        {
            PaymentDetailsId = 4,
            ContractorId = 4,
            BankAccount = "account_4",
            CorrespondentAccount = "correspondent_account_4",
            Bic = "bic_4",
            Inn = "inn_4",
            Kpp = "kpp_4",
            Swift = "swift_4",
            BankName = "bank_4",
            BankAddress = "bank_address_4",
            LegalAddress = "legal_address_4",
            FactAddress = "fact_address_4",
            CompanyName = "company_4",
            Currency = "currency_4",
            IsDefault = true,
            IsActive = true,
            DisplayName = "реквизиты_4",
            ObjectTypeName = "платежные реквизиты"
        }
    ];

    public Task<SelfCompanyEs[]> GetSelfCompanies(CancellationToken cancellationToken)
    {
        return Task.FromResult(SelfCompanies);
    }

    public Task<ContractorEs[]> GetContractors(string inn, CancellationToken cancellationToken)
    {
        var result = Contractors.Where(c => c.Inn == inn).ToArray();

        return Task.FromResult(result);
    }

    public Task<ContractorEs[]> GetContractors(long[] ids, CancellationToken cancellationToken)
    {
        var result = Contractors.Where(c => ids.Contains(c.Id)).ToArray();

        return Task.FromResult(result);
    }

    public Task<ContractEs[]> GetContracts(long[] ids, CancellationToken cancellationToken)
    {
        var result = Contracts.Where(c => ids.Contains(c.Id)).ToArray();

        return Task.FromResult(result);
    }

    public Task<PaymentDetailsEs[]> GetPaymentDetailsByContractorId(long contractorId, CancellationToken cancellationToken)
    {
        var result = PaymentDetails.Where(c => c.ContractorId == contractorId).ToArray();

        return Task.FromResult(result);
    }

    public Task<PaymentDetailsEs[]> GetPaymentDetails(long[] ids, CancellationToken cancellationToken)
    {
        var result = PaymentDetails.Where(c => ids.Contains(c.PaymentDetailsId)).ToArray();

        return Task.FromResult(result);
    }
}
