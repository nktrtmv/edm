using Edm.Document.Classifier.Domain;

namespace Edm.Document.Classifier.ExternalServices.Contractors.Contracts;

public sealed class PaymentDetailsEs : ITypedReference
{
    public required long PaymentDetailsId { get; init; }
    public required long ContractorId { get; init; }
    public required string BankAccount { get; init; } = string.Empty;
    public required string CorrespondentAccount { get; init; } = string.Empty;
    public required string Bic { get; init; } = string.Empty;
    public required string Inn { get; init; } = string.Empty;
    public required string Kpp { get; init; } = string.Empty;
    public required string Swift { get; init; } = string.Empty;
    public required string BankName { get; init; } = string.Empty;
    public required string BankAddress { get; init; } = string.Empty;
    public required string LegalAddress { get; init; } = string.Empty;
    public required string FactAddress { get; init; } = string.Empty;
    public required string CompanyName { get; init; } = string.Empty;
    public required string Currency { get; init; } = string.Empty;
    public required bool IsDefault { get; init; }
    public required bool IsActive { get; init; }
    public required string DisplayName { get; init; } = string.Empty;
    public required string ObjectTypeName { get; init; } = string.Empty;
}
