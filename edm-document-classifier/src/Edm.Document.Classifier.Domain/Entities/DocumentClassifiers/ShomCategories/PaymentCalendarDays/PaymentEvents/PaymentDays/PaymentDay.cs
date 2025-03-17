using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.ShomCategories.PaymentCalendarDays.PaymentEvents.PaymentDays;

public record PaymentDay(
    Id<PaymentDay> Id,
    string Name,
    string Description) : ITypedReference;
