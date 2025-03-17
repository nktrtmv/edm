using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.ShomCategories.PaymentCalendarDays.PaymentEvents.PaymentDays.Factories;

public static class PaymentDayFactory
{
    public static PaymentDay CreateFrom(string id, string name)
    {
        Id<PaymentDay> categoryId = IdConverterFrom<PaymentDay>.FromString(id);

        var result = new PaymentDay(categoryId, name, string.Empty);

        return result;
    }
}
