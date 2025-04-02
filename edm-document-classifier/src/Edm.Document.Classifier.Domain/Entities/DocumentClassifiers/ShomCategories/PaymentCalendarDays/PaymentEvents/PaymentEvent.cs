using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.ShomCategories.PaymentCalendarDays.PaymentEvents.PaymentDays;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.ShomCategories.PaymentCalendarDays.PaymentEvents;

public sealed record PaymentEvent(
    Id<PaymentEvent> Id,
    string Name,
    string Description,
    PaymentDay[] PaymentDays
    ) : ITypedReference;
