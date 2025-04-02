using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.ShomCategories.PaymentCalendarDays;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.ShomCategories;

public sealed record PaymentPercentage(
    Id<PaymentPercentage> Id,
    string SystemName,
    string Name,
    string Description,
    PaymentCalendarDay[] CalendarDays
    ) : ITypedReference;
