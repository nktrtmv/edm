namespace Edm.Document.Classifier.Domain.ValueObjects.Currencies;

public sealed record CurrencyInfo(
    Currency Id,
    string? AlphaCode3,
    string NameRu,
    string? IsoCode) : ITypedReference;
