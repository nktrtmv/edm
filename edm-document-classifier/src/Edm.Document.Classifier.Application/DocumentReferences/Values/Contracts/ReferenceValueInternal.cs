using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.GenericSubdomain.Tokens.Concurrency;

namespace Edm.Document.Classifier.Application.DocumentReferences.Values.Contracts;

public sealed record ReferenceValueInternal(
    Id<ReferenceValueInternal> Id,
    string DisplayValue,
    string DisplaySubValue,
    bool IsHidden,
    ConcurrencyToken<ReferenceValueInternal> ConcurrencyToken);
