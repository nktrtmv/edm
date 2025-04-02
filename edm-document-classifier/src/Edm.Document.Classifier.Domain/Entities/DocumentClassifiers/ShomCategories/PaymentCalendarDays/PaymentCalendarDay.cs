using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.ShomCategories.PaymentCalendarDays.PaymentEvents;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.ShomCategories.PaymentCalendarDays;

public sealed record PaymentCalendarDay(
    Id<PaymentCalendarDay> Id,
    string Name,
    string Description,
    PaymentEvent[] PaymentEvents) : ITypedReference;
