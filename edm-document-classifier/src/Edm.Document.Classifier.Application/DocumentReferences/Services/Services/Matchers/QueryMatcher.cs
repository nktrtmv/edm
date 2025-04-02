namespace Edm.Document.Classifier.Application.DocumentReferences.Services.Services.Matchers;

public static class QueryMatcher
{
    public static bool ContainsQuery(string query, params string[] values)
    {
        bool result = values.Any(value => value.Contains(query, StringComparison.OrdinalIgnoreCase));

        return result;
    }

    public static bool ContainsNullOrEmptyQuery(string query, params string[] values)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return true;
        }

        bool result = ContainsQuery(query, values);

        return result;
    }
}
