namespace Edm.Document.Classifier.Domain.ValueObjects.Usages.Services.Selectors;

public static class UsageSelector
{
    public static T[] Select<T>(IEnumerable<T> values, Func<T, Usage> usage)
    {
        bool shallBeFiltered = ShallBeFiltered();

        IEnumerable<T> result = shallBeFiltered
            ? values.Where(v => usage(v) == Usage.Available)
            : values.OrderBy(usage);

        return result.ToArray();
    }

    private static bool ShallBeFiltered()
    {
        string? environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        bool result = environment is "Production";

        return result;
    }
}
