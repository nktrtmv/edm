namespace Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Values;

public sealed record DocumentReferenceValue(string Id, string DisplayValue, string DisplaySubValue, ITypedReference TypedReference);
