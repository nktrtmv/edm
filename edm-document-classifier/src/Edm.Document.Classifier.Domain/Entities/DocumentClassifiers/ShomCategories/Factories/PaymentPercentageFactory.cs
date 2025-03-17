using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.ShomCategories.PaymentCalendarDays;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.ShomCategories.Factories;

public static class PaymentPercentageFactory
{
    public static PaymentPercentage CreateFrom(
        string id,
        string systemName,
        string name,
        PaymentCalendarDay[] calendarDays)
    {
        Id<PaymentPercentage> categoryId = IdConverterFrom<PaymentPercentage>.FromString(id);

        var result = new PaymentPercentage(categoryId, systemName, name, string.Empty, calendarDays);

        return result;
    }
}
