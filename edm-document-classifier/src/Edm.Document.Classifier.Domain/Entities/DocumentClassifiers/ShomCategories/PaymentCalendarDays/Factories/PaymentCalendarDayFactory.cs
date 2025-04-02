using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.ShomCategories.PaymentCalendarDays.PaymentEvents;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.ShomCategories.PaymentCalendarDays.Factories;

public static class PaymentCalendarDayFactory
{
    public static PaymentCalendarDay CreateFrom(string id, string name, PaymentEvent[] paymentEvents)
    {
        Id<PaymentCalendarDay> categoryId = IdConverterFrom<PaymentCalendarDay>.FromString(id);

        var result = new PaymentCalendarDay(categoryId, name, string.Empty, paymentEvents);

        return result;
    }
}
