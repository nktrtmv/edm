using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.ShomCategories.PaymentCalendarDays.PaymentEvents.PaymentDays;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.ShomCategories.PaymentCalendarDays.PaymentEvents.Factories;

public static class PaymentEventFactory
{
    public static PaymentEvent CreateFrom(string id, string name, PaymentDay[] paymentDays)
    {
        Id<PaymentEvent> categoryId = IdConverterFrom<PaymentEvent>.FromString(id);

        var result = new PaymentEvent(categoryId, name, string.Empty, paymentDays);

        return result;
    }
}
