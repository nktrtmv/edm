using Edm.Document.Classifier.GenericSubdomain.Exceptions;

namespace Edm.Document.Classifier.Domain.ValueObjects.Usages.Services.Formatter;

public static class UsageFormatter
{
    public static string Format(string text, Usage usage)
    {
        string result = usage switch
        {
            Usage.Available => text,
            Usage.Obsolete => $"{text} (УСТАРЕВШИЙ)",
            Usage.Unused => $"{text} (НЕ ИСПОЛЬЗУЕТСЯ)",
            Usage.New => $"{text} (В РАЗРАБОТКЕ)",
            Usage.Reserved => $"{text} (В РЕЗЕРВЕ)",
            _ => throw new ArgumentTypeOutOfRangeException(usage)
        };

        return result;
    }
}
