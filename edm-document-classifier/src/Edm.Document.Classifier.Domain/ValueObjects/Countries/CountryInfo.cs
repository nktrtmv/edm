namespace Edm.Document.Classifier.Domain.ValueObjects.Countries;

public sealed record CountryInfo(
    CountryCode Code,
    string? IsoCodeAlpha2,
    string NameRu,
    string? IsoCode);
